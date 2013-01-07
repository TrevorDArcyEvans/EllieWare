//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class FileBatchParameter : Parameter, IFileBatchParameter
  {
    public string FilePath
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

    public FileBatchParameter(string name, string filePath) :
      base(name, filePath)
    {
    }
  }
}
