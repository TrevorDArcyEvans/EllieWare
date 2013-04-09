//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Alsing.SourceCode;
using IronPython.Hosting;
using IronPython.Runtime;
using IronPython.Runtime.Exceptions;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using SerpentWare.Interfaces;

namespace SerpentWare.Common
{
  public partial class DebugWindow : EditForm
  {
    private ScriptEngine mEngine;
    private ScriptScope mScope;
    private readonly AutoResetEvent mDbgContinue = new AutoResetEvent(false);
    private readonly Action<TraceBackFrame, string, object> mTracebackAction;

    private TraceBackFrame mCurFrame;
    private FunctionCode mCurCode;
    private string mCurResult;
    private object mCurPayload;

    private bool mHasStarted;
    private bool mBreaktrace = true;
    private TracebackDelegate mTraceback;

    private readonly ISerpentWare mRoot;

    public DebugWindow()
    {
      InitializeComponent();

      DebugContainer.Panel2Collapsed = false;
    }

    public DebugWindow(ISerpentWare root, EditForm ef) :
      this()
    {
      mRoot = root;

      sBox.ReadOnly = true;
      sBox.Document.Lines = File.ReadAllLines(ef.Doc.Path);
      sBox.Document.Parser.Init(ef.sBox.Document.Parser.SyntaxDefinition);

      Doc = ef.Doc;
      Text = ef.Doc.Title;

      mTracebackAction = new Action<TraceBackFrame, string, object>(OnTraceback);
    }

    private void Shutdown()
    {
      if (mEngine != null)
      {
        mEngine.Runtime.Shutdown();
        mEngine.SetTrace(null);
      }
    }

    private void StartScript()
    {
      if (mHasStarted)
      {
        return;
      }
      mHasStarted = true;

      Shutdown();
      mEngine = null;
      mScope = null;

      mEngine = Utils.CreateEngine(mRoot, Output, Doc.Path);
      mScope = mEngine.CreateScope();

      mEngine.SetTrace(OnTracebackReceived);

      var source = mEngine.CreateScriptSourceFromFile(Doc.Path, Encoding.Default, SourceCodeKind.Statements);

      try
      {
        source.Execute(mScope);
      }
      catch (Exception ex)
      {
        ReportError(ex);
      }
    }

    private void DebugWindow_FormClosing(object sender, FormClosingEventArgs e)
    {
      mBreaktrace = false;
      mDbgContinue.Set();
    }

    private void DebugWindow_FormClosed(object sender, FormClosedEventArgs e)
    {
      Shutdown();
    }

    private void HighlightLine(int lineNum, Color background)
    {
      var row = sBox.Document[lineNum - 1];

      row.BackColor = background;

      sBox.Refresh();
    }

    private void TracebackCall()
    {
      Status.Panels[0].Text = string.Format("Call {0}", mCurCode.co_name);
      HighlightLine((int)mCurFrame.f_lineno, Color.LightGreen);
    }

    private void TracebackReturn()
    {
      Status.Panels[0].Text = string.Format("Return {0}", mCurCode.co_name);
      HighlightLine(mCurCode.co_firstlineno, Color.LightPink);
    }

    private void TracebackLine()
    {
      Status.Panels[0].Text = string.Format("Line {0}", mCurFrame.f_lineno);

      // get value of local variables
      var locals = (PythonDictionary)mCurFrame.f_locals;
      var localsGridAdapter = new PythonDictionaryPropertyGridAdapter(locals);
      PyGrid.SelectedObject = localsGridAdapter;

      HighlightLine((int)mCurFrame.f_lineno, Color.Yellow);
    }

    private void OnTraceback(TraceBackFrame frame, string result, object payload)
    {
      var code = (FunctionCode)frame.f_code;
      if (mCurCode == null || mCurCode.co_filename != code.co_filename)
      {
        sDoc.Clear();

        if (File.Exists(code.co_filename))
        {
          sDoc.Lines = File.ReadAllLines(code.co_filename);
        }
      }

      mCurFrame = frame;
      mCurCode = code;
      mCurResult = result;
      mCurPayload = payload;

      switch (result)
      {
        case "call":
          TracebackCall();
          break;

        case "line":
          TracebackLine();
          break;

        case "return":
          TracebackReturn();
          break;

        default:
          MessageBox.Show(string.Format("{0} not supported!", result));
          break;
      }
    }

    private TracebackDelegate OnTracebackReceived(TraceBackFrame frame, string result, object payload)
    {
      if (mBreaktrace)
      {
        Invoke((MethodInvoker)delegate { OnTraceback(frame, result, payload); });

        while (!mDbgContinue.WaitOne(10))
        {
          Application.DoEvents();
        }

        return mTraceback;
      }
      else
      {
        return null;
      }
    }

    private void ExecuteStep()
    {
      Status.Panels[0].Text = "Running";

      // unhighlight all lines
      foreach (Row row in sBox.Document)
      {
        row.BackColor = Color.Transparent;
      }
      sBox.Refresh();

      mDbgContinue.Set();
    }

    private void mnuDebug_Run_Click(object sender, EventArgs e)
    {
      mTraceback = OnTracebackReceived;

      StartScript();
      ExecuteStep();
    }

    private void mnuDebug_StepInto_Click(object sender, EventArgs e)
    {
      mTraceback = OnTracebackReceived;

      StartScript();
      ExecuteStep();
    }

    private void mnuDebug_StepOver_Click(object sender, EventArgs e)
    {
      mTraceback = OnTracebackReceived;

      StartScript();
      ExecuteStep();
    }

    private void mnuDebug_StepOut_Click(object sender, EventArgs e)
    {
      mTraceback = null;

      StartScript();
      ExecuteStep();
    }

    private void mnuDebug_Reset_Click(object sender, EventArgs e)
    {
      mHasStarted = false;
    }
  }
}
