//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Windows.Forms;

namespace RobotWare.Cron.UserInterface
{
  public partial class CronCtrlBase : UserControl, ICronBuilder
  {
    public CronCtrlBase()
    {
      InitializeComponent();
    }

    protected virtual void UpdateUserInterface()
    {
    }

    protected virtual void FireExpressionChanged(object sender, EventArgs e)
    {
      UpdateUserInterface();

      var handler = ExpressionChanged;
      if (handler != null)
      {
        handler(this, e);
      }
    }

    protected string GetDay(int selIndex)
    {
      switch (selIndex)
      {
        case 0:
          return "MON";

        case 1:
          return "TUE";

        case 2:
          return "WED";

        case 3:
          return "THU";

        case 4:
          return "FRI";

        case 5:
          return "SAT";

        case 6:
          return "SUN";

        default:
          throw new IndexOutOfRangeException("Unknown day of week: " + selIndex.ToString());
      }
    }

    public event EventHandler ExpressionChanged;

    public virtual string Expression
    {
      get
      {
        return string.Empty;
      }
    }
  }
}
