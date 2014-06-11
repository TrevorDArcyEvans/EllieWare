//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RobotWare.Runtime.Server.Manager
{
  public partial class AddJobGroup : Form
  {
    private readonly IEnumerable<string> mExistingNames;

    public AddJobGroup()
    {
      InitializeComponent();
    }

    public AddJobGroup(IEnumerable<string> existJobGroups) :
      this()
    {
      mExistingNames = existJobGroups;
    }

    public string JobGroupName
    {
      get
      {
        return JobGroup.Text;
      }
    }

    private void JobGroup_TextChanged(object sender, System.EventArgs e)
    {
      CmdOK.Enabled = !string.IsNullOrWhiteSpace(JobGroupName) && !mExistingNames.Contains(JobGroupName);
    }
  }
}
