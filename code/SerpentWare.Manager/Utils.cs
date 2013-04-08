//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Scripting.Hosting;
using Microsoft.Win32;

namespace EllieWare.Python
{
  public class Utils
  {
    public static ScriptEngine CreateEngine(EditForm ef)
    {
      var engine = IronPython.Hosting.Python.CreateEngine();
      var output = new TextBoxWriter(ef.Output);

      // add directory of file to Python search path
      var paths = engine.GetSearchPaths();
      var fileDir = Path.GetDirectoryName(ef.Doc.Path);
      if (!paths.Contains(fileDir))
      {
        paths.Add(fileDir);
        engine.SetSearchPaths(paths);
      }

      engine.Runtime.IO.SetOutput(new MemoryStream(), output);
      engine.Runtime.IO.SetErrorOutput(new MemoryStream(), output);

      AddSpaceClaimReference(engine);

      return engine;
    }

    private static void AddSpaceClaimReference(ScriptEngine engine)
    {
      const string ApiDirectoryPrefix = "SpaceClaim.Api.V";
      const string ApiPathTemplate = ApiDirectoryPrefix + @"{0}\" + ApiDirectoryPrefix + "{0}.dll";

      // work out path to API dll from registry:
      //    HKCR\SpaceClaim.Location
      //      {Path}
      var hkcrLoc = Registry.ClassesRoot.OpenSubKey("SpaceClaim.Location");
      var SCpath = (string)hkcrLoc.GetValue("Path");
      var apiDirPath = Path.Combine(SCpath, ApiDirectoryPrefix);
      var allApiDirs = Directory.EnumerateDirectories(SCpath).Where(x => x.Contains(apiDirPath));
      var allApiVersStrs = from thisAllApiDir in allApiDirs
                       select
                         thisAllApiDir.Substring(apiDirPath.Length,
                                                 thisAllApiDir.Length - apiDirPath.Length);
      var allApiVers = from thisApiVerStr in allApiVersStrs select int.Parse(thisApiVerStr);
      var latestApi = allApiVers.OrderBy(x => x).Last();
      var apiDllRelpath = string.Format(ApiPathTemplate, latestApi);
      var assyPath = Path.Combine(SCpath, apiDllRelpath);
      var assy = Assembly.LoadFile(assyPath);

      // add references to SpaceClaim
      engine.Runtime.LoadAssembly(assy);
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
