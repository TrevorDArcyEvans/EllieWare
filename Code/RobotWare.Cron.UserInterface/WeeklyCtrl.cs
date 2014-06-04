//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;

namespace RobotWare.Cron.UserInterface
{
  public partial class WeeklyCtrl : CronCtrlBase
  {
    public WeeklyCtrl()
    {
      InitializeComponent();
    }

    private void FireExpressionChangedInternal(object sender, EventArgs e)
    {
      FireExpressionChanged(sender, e);
    }

    public override string Expression
    {
      get
      {
        var daysCronStr = GetDays();

        return string.Format("0 {1} {0} ? * {2} *", WeeklyTimeValue.Value.Hour, WeeklyTimeValue.Value.Minute, daysCronStr);
      }
    }

    private string GetDays()
    {
      var dayNames = new List<string>(WeeklyDays.CheckedIndices.Count);
      dayNames.AddRange(from int thisIndex in WeeklyDays.CheckedIndices select GetDay(thisIndex));

      var retval = string.Join(",", dayNames.ToArray());

      return retval;
    }

    #region Implementation of IXmlSerializable

    public override void ReadXml(XmlReader reader)
    {
      // first clear all checked days of week
      for (var i = 0; i < WeeklyDays.Items.Count; i++)
      {
        WeeklyDays.SetItemChecked(i, false);
      }

      var weeklyDaysStr = reader.GetAttribute("WeeklyDays");
      var checkedIndicies = weeklyDaysStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
      for (var i = 0; i < checkedIndicies.Length; i++)
      {
        var idx = int.Parse(checkedIndicies[i], CultureInfo.InvariantCulture);
        WeeklyDays.SetItemChecked(idx, true);
      }

      var weeklyTimeValueStr = reader.GetAttribute("WeeklyTimeValue");
      WeeklyTimeValue.Value = DateTime.ParseExact(weeklyTimeValueStr, "s", CultureInfo.InvariantCulture);
    }

    public override void WriteXml(XmlWriter writer)
    {
      var checkedIndicies = string.Empty;
      for (var i = 0; i < WeeklyDays.CheckedIndices.Count; i++)
      {
        checkedIndicies += (string.IsNullOrEmpty(checkedIndicies) ? string.Empty : ",") + WeeklyDays.CheckedIndices[i].ToString(CultureInfo.InvariantCulture);
      }
      writer.WriteAttributeString("WeeklyDays", checkedIndicies);

      writer.WriteAttributeString("WeeklyTimeValue", WeeklyTimeValue.Value.ToString("s", CultureInfo.InvariantCulture));
    }

    #endregion
  }
}
