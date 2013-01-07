//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

using System.Xml;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class DirectoryBatchParameter : Parameter, IDirectoryBatchParameter
  {
    public string FileMask { get; set; }
    public string Directory
    {
      get
      {
        return (string)ParameterValue;
      }
      set
      {
        ParameterValue = value;
      }
    }

    public DirectoryBatchParameter() :
      base()
    {
    }

    public DirectoryBatchParameter(string name, string directory, string fileMask) :
      base(name, directory)
    {
      FileMask = fileMask;
    }

    public override void ReadXml(XmlReader reader)
    {
      // TODO   ReadXml
      base.ReadXml(reader);
    }

    public override void WriteXml(XmlWriter writer)
    {
      // TODO   WriteXml
      base.WriteXml(writer);
    }
  }
}
