using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public partial class FileDelete : MutableRunnableBase
  {
    public FileDelete()
    {
      InitializeComponent();
    }

    public FileDelete(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();
    }

    #region Implementation of IRunnable

    public override string Description
    {
      get { throw new NotImplementedException(); }
    }

    public override Control ConfigurationUserInterface
    {
      get { return this; }
    }

    public override bool Run()
    {
      throw new NotImplementedException();
    }

    #endregion

    public override void ReadXml(XmlReader reader)
    {
      throw new NotImplementedException();
    }

    public override void WriteXml(XmlWriter writer)
    {
      throw new NotImplementedException();
    }

    private void FilePath_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}
