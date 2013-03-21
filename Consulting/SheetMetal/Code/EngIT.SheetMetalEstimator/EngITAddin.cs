//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EngIT.SheetMetalEstimator.Properties;
using SpaceClaim.Api.V10.Extensibility;

namespace EngIT.SheetMetalEstimator
{
  public class EngITAddin : AddIn, IExtensibility, ICommandExtensibility, IRibbonExtensibility
  {
    private readonly CommandCapsule[] mCapsules = new[]
                                                   {
                                                     new CommandCapsule("EngIT.RibbonTab", Resources.RibbonTabText),
                                                     new CommandCapsule("EngIT.ManagerGroup", Resources.ManagerGroupText),
                                                     new SingleCapsule(),
                                                     new BatchCapsule()
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
