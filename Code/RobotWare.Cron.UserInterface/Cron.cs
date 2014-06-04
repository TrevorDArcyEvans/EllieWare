//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using CronExpressionDescriptor;

namespace RobotWare.Cron.UserInterface
{
  public partial class Cron : CronCtrlBase
  {
    public Cron()
    {
      InitializeComponent();

      UpdateUserInterface();
    }

    private void FireExpressionChangedInternal(object sender, EventArgs e)
    {
      FireExpressionChanged(sender, e);
    }

    protected override void UpdateUserInterface()
    {
      var cb = GetSelectedCronBuilder();
      Description.Text = ExpressionDescriptor.GetDescription(cb.Expression);
    }

    private ICronBuilder GetSelectedCronBuilder()
    {
      var selTab = CronTab.SelectedTab.Controls.OfType<ICronBuilder>().Single();
      return selTab;
    }

    #region Implementation of IXmlSerializable

    public override void ReadXml(XmlReader reader)
    {
      if (!reader.ReadToDescendant("CronTabs"))
      {
        throw new XmlException("Could not find CronTabs element");
      }
      var selTabName = reader.GetAttribute("SelectedCronBuilder");
      CronTab.SelectedTab = CronTab.TabPages[selTabName];

      if (!reader.ReadToFollowing("Minutes"))
      {
        throw new XmlException("Could not find Minutes element");
      }
      MinutesValue.ReadXml(reader);

      if (!reader.ReadToFollowing("Hourly"))
      {
        throw new XmlException("Could not find Hourly element");
      }
      HourlyValue.ReadXml(reader);

      if (!reader.ReadToFollowing("Daily"))
      {
        throw new XmlException("Could not find Daily element");
      }
      DailyValue.ReadXml(reader);

      if (!reader.ReadToFollowing("Weekly"))
      {
        throw new XmlException("Could not find Weekly element");
      }
      WeeklyValue.ReadXml(reader);

      if (!reader.ReadToFollowing("Monthly"))
      {
        throw new XmlException("Could not find Monthly element");
      }
      MonthlyValue.ReadXml(reader);

      if (!reader.ReadToFollowing("Yearly"))
      {
        throw new XmlException("Could not find Yearly element");
      }
      YearlyValue.ReadXml(reader);
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteStartElement("CronTabs");
      writer.WriteAttributeString("SelectedCronBuilder", CronTab.SelectedTab.Name);

      {
        writer.WriteStartElement("Minutes");
        MinutesValue.WriteXml(writer);
        writer.WriteEndElement();
      }

      {
        writer.WriteStartElement("Hourly");
        HourlyValue.WriteXml(writer);
        writer.WriteEndElement();
      }

      {
        writer.WriteStartElement("Daily");
        DailyValue.WriteXml(writer);
        writer.WriteEndElement();
      }

      {
        writer.WriteStartElement("Weekly");
        WeeklyValue.WriteXml(writer);
        writer.WriteEndElement();
      }

      {
        writer.WriteStartElement("Monthly");
        MonthlyValue.WriteXml(writer);
        writer.WriteEndElement();
      }

      {
        writer.WriteStartElement("Yearly");
        YearlyValue.WriteXml(writer);
        writer.WriteEndElement();
      }

      writer.WriteEndElement();
    }

    #endregion

    public override string Expression
    {
      get
      {
        return GetSelectedCronBuilder().Expression;
      }
    }
  }
}
