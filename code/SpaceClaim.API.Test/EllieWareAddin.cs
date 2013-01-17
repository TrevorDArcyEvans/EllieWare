//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using SpaceClaim.API.Test.Properties;
using SpaceClaim.Api.V10.Extensibility;

namespace SpaceClaim.API.Test
{
  public class EllieWareAddin : AddIn, IExtensibility, ICommandExtensibility, IRibbonExtensibility
  {
    private readonly CommandCapsule[] mCapsules = new[]
                                                   {
                                                     new CommandCapsule("EllieWare.RibbonTab", Resources.RibbonTabText),
                                                     new CommandCapsule("EllieWare.ManagerGroup", Resources.ManagerGroupText),
                                                     new ManagerCapsule()
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
