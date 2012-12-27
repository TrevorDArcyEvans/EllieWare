//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using RobotWare.SpaceClaim.Properties;
using SpaceClaim.Api.V10.Extensibility;

namespace RobotWare.SpaceClaim
{
  public class RobotWareAddin : AddIn, IExtensibility, ICommandExtensibility, IRibbonExtensibility
  {
    private readonly CommandCapsule[] mCapsules = new[]
                                                   {
                                                     new CommandCapsule("RobotWare.RibbonTab", Resources.RibbonTabText),
                                                     new CommandCapsule("RobotWare.ManagerGroup", Resources.ManagerGroupText),
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
