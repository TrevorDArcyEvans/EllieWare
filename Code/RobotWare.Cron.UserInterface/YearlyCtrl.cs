//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Xml;
using System.Globalization;

namespace RobotWare.Cron.UserInterface
{
  public partial class YearlyCtrl : CronCtrlBase
  {
    public YearlyCtrl() :
      base()
    {
      InitializeComponent();

      DayMonth.SelectedIndex = PeriodicInterval.SelectedIndex = PeriodicDay.SelectedIndex = PeriodicMonth.SelectedIndex = 0;
    }

    private void FireExpressionChangedInternal(object sender, EventArgs e)
    {
      FireExpressionChanged(sender, e);
    }

    protected override void UpdateUserInterface()
    {
      DayMonth.Enabled = DayValue.Enabled = OptDay.Checked;
      PeriodicInterval.Enabled = PeriodicDay.Enabled = PeriodicMonth.Enabled = !OptDay.Checked;
    }

    public override string Expression
    {
      get
      {
        if (OptDay.Checked)
        {
          return string.Format("0 {3} {2} {1} {0} ? *", DayMonth.SelectedIndex + 1, DayValue.Value, YearlyTimeValue.Value.Hour, YearlyTimeValue.Value.Minute);
        }

        var perDay = GetDay(PeriodicDay.SelectedIndex);
        return string.Format("0 {4} {3} ? {2} {1}#{0} *", PeriodicInterval.SelectedIndex + 1, perDay, PeriodicMonth.SelectedIndex + 1, YearlyTimeValue.Value.Hour, YearlyTimeValue.Value.Minute);
      }
    }

    #region Implementation of IXmlSerializable

    public override void ReadXml(XmlReader reader)
    {
      // TODO
    }

    public override void WriteXml(XmlWriter writer)
    {
      // TODO
    }

    #endregion
  }
}
