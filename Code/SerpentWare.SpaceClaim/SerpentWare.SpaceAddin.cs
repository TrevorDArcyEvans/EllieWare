//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using SpaceClaim.Api.V10.Extensibility;

namespace SerpentWare.SpaceClaim
{
  public class SerpentWareAddin : AddIn, IExtensibility, ICommandExtensibility, IRibbonExtensibility
  {
    private readonly CommandCapsule[] mCapsules = new[]
                                                   {
                                                     new CommandCapsule("SerpentWare.SpaceClaim.RibbonTab", "SerpentWare Python"),
                                                     new CommandCapsule("SerpentWare.SpaceClaim.ManagerGroup", "Python"),
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
      return SerpentWare.SpaceClaim.Properties.Resource.Ribbon;
    }

    #endregion
  }
}
