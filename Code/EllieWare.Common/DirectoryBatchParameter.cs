//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class DirectoryBatchParameter : SerializableBatchParameter, IDirectoryBatchParameter
  {
    public string FileMask { get; set; }
    public string Directory { get; set; }

    public DirectoryBatchParameter() :
      base()
    {
    }

    public DirectoryBatchParameter(string name, string directory, string fileMask) :
      base(name, string.Empty)
    {
      FileMask = fileMask;
      Directory = directory;
    }

    public override void ReadXml(XmlReader reader)
    {
      base.ReadXml(reader);

      FileMask = reader.GetAttribute("FileMask");
      Directory = reader.GetAttribute("Directory");
    }

    public override void WriteXml(XmlWriter writer)
    {
      base.WriteXml(writer);

      writer.WriteAttributeString("FileMask", FileMask);
      writer.WriteAttributeString("Directory", Directory);
    }

    public override string Summary
    {
      get
      {
        var summ = string.Format("{0} -- > {1} files in {2}", DisplayName, FileMask, Directory);

        return summ;
      }
    }

    public override IEnumerable<string> ResolvedValues
    {
      get
      {
        return from thisFile in System.IO.Directory.EnumerateFiles(Directory, FileMask) select Path.GetFileName(thisFile);
      }
    }
  }
}
