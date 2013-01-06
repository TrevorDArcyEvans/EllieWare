using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class Utils
  {

    public static IEnumerable<IFactory> GetFactories()
    {
      var retVal = new List<IFactory>();
      var callAssyLoc = Assembly.GetCallingAssembly().Location;
      var callAssyDir = Path.GetDirectoryName(callAssyLoc);
      var dllFiles = Directory.EnumerateFiles(callAssyDir, "*.dll");
      foreach (var thisDllFile in dllFiles)
      {
        try
        {
          var assy = Assembly.LoadFrom(thisDllFile);
          var factories = from t in assy.GetTypes()
                          where t.GetInterfaces().Contains(typeof(IFactory))
                          select Activator.CreateInstance(t) as IFactory;
          retVal.AddRange(factories);
        }
        catch (BadImageFormatException)
        {
          // might not be a .NET dll but how?
        }
      }

      return retVal;
    }
  }
}
