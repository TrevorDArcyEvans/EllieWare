//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.Xml;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class DirectoryBatchParameter : BatchParameter, IDirectoryBatchParameter
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
      base.ReadXml(reader);

      FileMask = reader.GetAttribute("FileMask");
    }

    public override void WriteXml(XmlWriter writer)
    {
      base.WriteXml(writer);

      writer.WriteAttributeString("FileMask", FileMask);
    }

    public override string Summary
    {
      get
      {
        var summ = string.Format("{0} files in {1}", FileMask, Directory);

        return summ;
      }
    }

    public override IEnumerable<string> ResolvedValues
    {
      get
      {
        return System.IO.Directory.EnumerateFiles(Directory, FileMask);
      }
    }
  }
}
