using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClickForensics.Quartz.Manager
{
  public class SchedulerNode : TreeNode
  {
    public SchedulerNode(QuartzScheduler scheduler)
      : base()
    {
      this.Text = this.Name = scheduler.Address;
      Scheduler = scheduler;
    }

    public QuartzScheduler Scheduler { get; private set; }
  }
}
