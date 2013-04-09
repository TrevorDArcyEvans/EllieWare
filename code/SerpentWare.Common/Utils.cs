//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Scripting.Hosting;
using SerpentWare.Interfaces;

namespace SerpentWare.Common
{
  public class Utils
  {
    public static ScriptEngine CreateEngine(ISerpentWare root, TextBox txtOutput, string path)
    {
      var engine = IronPython.Hosting.Python.CreateEngine();
      var output = new TextBoxWriter(txtOutput);

      // add directory of file to Python search path
      var paths = engine.GetSearchPaths();
      var fileDir = Path.GetDirectoryName(path);
      if (!paths.Contains(fileDir))
      {
        paths.Add(fileDir);
        engine.SetSearchPaths(paths);
      }

      engine.Runtime.IO.SetOutput(new MemoryStream(), output);
      engine.Runtime.IO.SetErrorOutput(new MemoryStream(), output);

      foreach (var assy in root.Assemblies)
      {
        engine.Runtime.LoadAssembly(assy);
      }

      return engine;
    }

    public static string GetSourceLines(EditForm ef)
    {
      var allLines = ef.sBox.Document.Lines;
      var code = new StringBuilder(allLines.Count());

      foreach (var line in allLines)
      {
        code.Append(line);
      }

      return code.ToString();
    }
  }
}
