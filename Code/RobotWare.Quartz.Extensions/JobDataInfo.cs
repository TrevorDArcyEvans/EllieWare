//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;

namespace RobotWare.Quartz.Extensions
{
  public class JobDataInfo : IJobDataInfo
  {
    public JobDataInfo(string name, Type type, Type editorType, string descrip)
    {
      Name = name;
      DataType = type;
      EditorType = editorType;
      Description = descrip;
    }

    public string Name { get; private set; }
    public Type DataType { get; private set; }
    public Type EditorType { get; private set; }
    public string Description { get; private set; }
  }
}
