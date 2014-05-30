using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ClickForensics.Quartz.Manager
{
  public class AssemblyRepository
  {
    private const string JobAssemblyFileName = "JobAssemblies.txt";

    public static void AddAssembly(string assembly)
    {
      var assemblies = GetAssemblies();
      assemblies.Add(assembly);
      using (StreamWriter stream = File.CreateText(JobAssemblyFileName))
      {
        foreach (var assemblyName in assemblies)
        {
          stream.WriteLine(assemblyName);
        }
      }
    }

    public static HashSet<string> GetAssemblies()
    {
      HashSet<string> assemblies = new HashSet<string>();
      using (FileStream stream = File.OpenRead(JobAssemblyFileName))
      {
        using (StreamReader reader = new StreamReader(stream))
        {
          string line;
          while ((line = reader.ReadLine()) != null)
          {
            if (!string.IsNullOrWhiteSpace(line))
            {
              assemblies.Add(line);
            }
          }
        }
      }

      return assemblies;
    }

    public static void DeleteAssembly(string assembly)
    {
      var assemblies = GetAssemblies();
      assemblies.Remove(assembly);
      using (StreamWriter stream = File.CreateText(JobAssemblyFileName))
      {
        foreach (var assemblyName in assemblies)
        {
          stream.WriteLine(assemblyName);
        }
      }
    }
  }
}
