//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using SpaceClaim.Api.V10.Extensibility;

namespace RobotWare.SpaceClaim
{
  public class RobotWareAddin : AddIn, IExtensibility, ICommandExtensibility
  {
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
      var mgrCapsule = new ManagerCapsule();
      mgrCapsule.Initialize();
    }

    #endregion
  }
}
