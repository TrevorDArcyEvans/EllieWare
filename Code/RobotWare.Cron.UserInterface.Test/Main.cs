//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace RobotWare.Cron.UserInterface.Test
{
  public partial class Main : Form
  {
    public Main()
    {
      InitializeComponent();
    }

    private void CmdSave_Click(object sender, System.EventArgs e)
    {
      if (DlgSave.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      using (var fs = new FileStream(DlgSave.FileName, FileMode.Create))
      {
        var xs = new XmlSerializer(typeof(Cron));
        xs.Serialize(fs, CronTab);
      }
    }

    private void CmdOpen_Click(object sender, System.EventArgs e)
    {
      if (DlgOpen.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      using (var fs = new FileStream(DlgOpen.FileName, FileMode.Open))
      {
        var reader = XmlReader.Create(fs);
        CronTab.ReadXml(reader);
      }
    }
  }
}
