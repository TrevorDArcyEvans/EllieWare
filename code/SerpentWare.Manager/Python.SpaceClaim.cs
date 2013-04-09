//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using SerpentWare.Manager.Properties;
using SpaceClaim.Api.V10.Extensibility;

namespace SerpentWare.Manager
{
  public class EllieWarePythonAddin : AddIn, IExtensibility, ICommandExtensibility, IRibbonExtensibility
  {
    private readonly CommandCapsule[] mCapsules = new[]
                                                   {
                                                     new CommandCapsule("SerpentWare.Manager.RibbonTab", "EllieWare Python"),
                                                     new CommandCapsule("SerpentWare.Manager.ManagerGroup", "Python"),
                                                     new PythonCapsule()
                                                   };

    #region Implementation of IExtensibility

    public bool Connect()
    {
      return true;
    }

    public void Disconnect()
    {
    }

    #endregion

    #region Implementation of ICommandExtensibility

    public void Initialize()
    {
      foreach (var commandCapsule in mCapsules)
      {
        commandCapsule.Initialize();
      }
    }

    #endregion

    #region Implementation of IRibbonExtensibility

    public string GetCustomUI()
    {
      return Resources.Ribbon;
    }

    #endregion
  }
}
