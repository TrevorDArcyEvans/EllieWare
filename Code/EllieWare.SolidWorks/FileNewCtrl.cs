//
//  Copyright (C) 2014 EllieWare
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
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.SolidWorks
{
  public partial class FileNewCtrl : UserControlBase
  {
    private IRobotWare mRoot;

    public FileNewCtrl()
    {
      InitializeComponent();
    }

    public override string Summary
    {
      get
      {
        //var descrip = string.Format("Run {0}", MacroFileName.ResolvedValue);

        return @"Create a new part";
      }
    }

    public override void ReadXml(XmlReader reader)
    {
      base.ReadXml(reader);

      //MacroFileName.Text = reader.GetAttribute("MacroFileName");
    }

    public override void WriteXml(XmlWriter writer)
    {
      base.WriteXml(writer);

     // writer.WriteAttributeString("MacroFileName", MacroFileName.Text);
    }

    public override void Initialise(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      mRoot = root;
    }
  }
}
