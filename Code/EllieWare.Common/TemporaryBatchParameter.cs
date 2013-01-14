//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Xml;

namespace EllieWare.Common
{
  public class TemporaryBatchParameter : SerializableBatchParameter
  {
    public TemporaryBatchParameter() :
      base()
    {
    }

    public TemporaryBatchParameter(string name, string paramValue) :
      base(name, paramValue)
    {
    }

    public override void ReadXml(XmlReader reader)
    {
    }

    public override void WriteXml(XmlWriter writer)
    {
    }
  }
}
