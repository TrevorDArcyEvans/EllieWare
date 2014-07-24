//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using EllieWare.Common;
using Quartz;
using Quartz.Impl;
using RobotWare.Runtime.Server.Web.Models;
using RobotWare.Runtime.Server.Web.Properties;

namespace RobotWare.Runtime.Server.Web.Controllers
{
  public class HomeController : Controller
  {
    private readonly IScheduler mScheduler;

    public HomeController()
    {
      var schedulerFactory = CreateSchedulerFactory();
      mScheduler = schedulerFactory.GetScheduler();
    }

    public ActionResult Index()
    {
      return View(new SchedulerInfo(mScheduler));
    }

    public ActionResult About()
    {
      var assyNames = new HashSet<string>();

      AddAssemblyNames(assyNames, Assembly.GetExecutingAssembly());
      foreach (var assy in AppDomain.CurrentDomain.GetAssemblies())
      {
        AddAssemblyNames(assyNames, assy);
      }

      // add assemblies which seem to be loaded by reflection/magic
      AddAssemblyNames(assyNames, typeof(Quartz.Server.QuartzServer).Assembly);
      AddAssemblyNames(assyNames, typeof(Topshelf.Runtime.Windows.WindowsHostEnvironment).Assembly);
      AddAssemblyNames(assyNames, typeof(Antlr.Runtime.Parser).Assembly);
      AddAssemblyNames(assyNames, typeof(Common.Logging.LogManager).Assembly);
      AddAssemblyNames(assyNames, typeof(log4net.LogManager).Assembly);
      AddAssemblyNames(assyNames, typeof(Microsoft.VisualBasic.Information).Assembly);
      AddAssemblyNames(assyNames, typeof(System.Activities.DurableInstancing.SqlWorkflowInstanceStore).Assembly);
      AddAssemblyNames(assyNames, typeof(System.ServiceModel.Channels.ChannelBase).Assembly);
      AddAssemblyNames(assyNames, typeof(System.Workflow.Activities.CodeActivity).Assembly);
      AddAssemblyNames(assyNames, typeof(System.Workflow.ComponentModel.Activity).Assembly);
      AddAssemblyNames(assyNames, typeof(System.Workflow.Runtime.WorkflowRuntime).Assembly);

      // alphabetically order assy names as a user convenience
      return View(assyNames.OrderBy(s => s));
    }

    private void AddAssemblyNames(HashSet<string> assyNames, Assembly assy)
    {
      foreach (var assyName in assy.GetReferencedAssemblies())
      {
        assyNames.SafeAdd(assyName.FullName);
      }
    }

    [HttpPost]
    public ActionResult RunJob(string name, string group)
    {
      var key = new JobKey(name, group);
      mScheduler.TriggerJob(key);

      return new EmptyResult();
    }

    [HttpPost]
    public ActionResult DeleteJob(string name, string group)
    {
      var key = new JobKey(name, group);
      var bRet = mScheduler.DeleteJob(key);
      var obj = new { Succeeded = bRet };

      return Json(obj);
    }

    [HttpPost]
    public ActionResult DeleteTrigger(string name, string group)
    {
      var key = new TriggerKey(name, group);
      var bRet = mScheduler.UnscheduleJob(key);
      var obj = new { Succeeded = bRet };

      return Json(obj);
    }

    private void ResetSchedulerFactory()
    {
      var repo = SchedulerRepository.Instance;
      var scheds = repo.LookupAll();
      foreach (var sched in scheds)
      {
        repo.Remove(sched.SchedulerName);
      }
    }

    private ISchedulerFactory CreateSchedulerFactory()
    {
      ResetSchedulerFactory();

      var address = string.Format("tcp://{0}:{1}/{2}", Settings.Default.Server, Settings.Default.Port, Settings.Default.Scheduler);
      var properties = new NameValueCollection();
      properties["quartz.scheduler.instanceName"] = "RemoteClient";
      properties["quartz.scheduler.proxy"] = "true";
      properties["quartz.threadPool.threadCount"] = "0";
      properties["quartz.scheduler.proxy.address"] = address;

      return new StdSchedulerFactory(properties);
    }
  }
}
