//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace RobotWare.Runtime.Server.Manager
{
  public partial class CronSelector : Form
  {
    public CronSelector()
    {
      InitializeComponent();
    }

    public string Expression
    {
      get
      {
        return mCron.Expression;
      }
    }

    public string GetXml()
    {
      var sb = new StringBuilder();
      using (var sw = new StringWriter(sb))
      {
        using (var writer = new XmlTextWriter(sw))
        {
          mCron.WriteXml(writer);
        }
      }
      return sb.ToString();
    }

    public void SetXml(string triggerXml)
    {
      using (var sr = new StringReader(triggerXml))
      {
        using (var reader = XmlReader.Create(sr))
        {
          mCron.ReadXml(reader);
        }
      }
    }
  }
}
