//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;

namespace RobotWare.Cron.UserInterface
{
  interface ICronBuilder
  {
    event EventHandler ExpressionChanged;
    string Expression { get; }
  }
}
