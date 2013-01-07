//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
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

namespace EllieWare.Batch
{
  public partial class BatchRunner : MutableRunnableBase
  {
    public BatchRunner() :
      base()
    {
      InitializeComponent();
    }

    public BatchRunner(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();
    }

    #region Implementation of IXmlSerializable

    public override void ReadXml(XmlReader reader)
    {
      // TODO   ReadXml
    }

    public override void WriteXml(XmlWriter writer)
    {
      // TODO   WriteXml
    }

    #endregion

    #region Implementation of IRunnable

    public override string Summary
    {
      get
      {
        return "TODO    Summary";
      }
    }

    public override Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }

    public override bool Run()
    {
      return true;
    }

    #endregion
  }
}
