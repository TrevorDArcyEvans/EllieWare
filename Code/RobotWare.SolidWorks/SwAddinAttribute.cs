//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

using System;

namespace RobotWare.SolidWorks
{
  [AttributeUsage(AttributeTargets.Class)]
  public class SwAddinAttribute : Attribute
  {
    public string Description { get; private set; }

    public string Title { get; private set; }

    public bool LoadAtStartup { get; private set; }

    public SwAddinAttribute(string descr, string title, bool loadStart)
    {
      Description = descr;
      Title = title;
      LoadAtStartup = loadStart;
    }
  }
}
