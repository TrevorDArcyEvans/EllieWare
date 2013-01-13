//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.IO;
using System.Xml;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class FileBatchParameter : BatchParameter, IFileBatchParameter
  {
    public string FilePath { get; set; }

    public FileBatchParameter() :
      base()
    {
    }

    public FileBatchParameter(string name, string filePath) :
      base(name, string.Empty)
    {
      FilePath = filePath;
    }

    public override void ReadXml(XmlReader reader)
    {
      base.ReadXml(reader);

      FilePath = reader.GetAttribute("FilePath");
    }

    public override void WriteXml(XmlWriter writer)
    {
      base.WriteXml(writer);

      writer.WriteAttributeString("FilePath", FilePath);
    }

    public override string Summary
    {
      get
      {
        var summ = string.Format("{0} -- > List of files from {1}", DisplayName, FilePath);

        return summ;
      }
    }

    public override IEnumerable<string> ResolvedValues
    {
      get
      {
        return File.ReadAllLines(FilePath);
      }
    }
  }
}
