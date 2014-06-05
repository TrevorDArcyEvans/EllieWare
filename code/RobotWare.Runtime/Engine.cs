//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.IO;
using System.Linq;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;
using EllieWare.Support;

namespace RobotWare.Runtime
{
  public class Engine
  {
    private const int MaxUnlicensedSteps = 5;

    private readonly IRobotWare mRoot;
    private readonly ISpecification mSpecification;
    private readonly ICallback mCallback;

    public Engine(IRobotWare root, ICallback callback, string filePath)
    {
      mRoot = root;
      mCallback = callback;
      var factories = Utils.GetFactories().ToList();
      mSpecification = new Specification(mRoot, mCallback, factories);

      using (var fs = new FileStream(filePath, FileMode.Open))
      {
        var reader = XmlReader.Create(fs);
        mSpecification.ReadXml(reader);
      }
    }

    public bool Run()
    {
      foreach (var step in mSpecification.Steps)
      {
        if (mSpecification.Steps.IndexOf(step) >= MaxUnlicensedSteps && !mRoot.IsLicensed)
        {
          var msg = string.Format("Only {0} steps in demo mode", MaxUnlicensedSteps);

          mCallback.Log(LogLevel.Information, msg);

          return false;
        }

        if (!step.CanRun)
        {
          return false;
        }

        try
        {
          using (new AutoWaitCursor())
          {
            if (!step.Run())
            {
              return false;
            }
          }
        }
        catch (Exception ex)
        {
          mCallback.Log(LogLevel.Critical, ex.Message);

          return false;
        }
      }

      return true;
    }
  }
}
