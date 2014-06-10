using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RobotWare.Runtime.Server.Manager
{
  public partial class CronSelector : Form
  {
    public CronSelector()
    {
      InitializeComponent();
    }

    public string Expression
    {
      get
      {
        return mCron.Expression;
      }
    }
  }
}
