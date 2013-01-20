//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.IO;
using System.IO.IsolatedStorage;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace EllieWare.Support
{
  public static class WindowPersister
  {
    private static string GetSettingsFileName(Assembly assy)
    {
      return assy.FullName + ".Settings";
    }

    private static IsolatedStorageFile GetIsolatedStorageFile()
    {
      return IsolatedStorageFile.GetStore(
              IsolatedStorageScope.User | IsolatedStorageScope.Assembly | IsolatedStorageScope.Domain,
              typeof(System.Security.Policy.Url), typeof(System.Security.Policy.Url));
    }

    public static void Restore(Assembly assy, Form form, params SplitContainer[] splitters)
    {
      using (var store = GetIsolatedStorageFile())
      {
        var settingsFileName = GetSettingsFileName(assy);
        if (!store.FileExists(settingsFileName))
        {
          // probably first time run
          return;
        }

        using (var settings = store.OpenFile(settingsFileName, FileMode.Open))
        {
          var formatter = new BinaryFormatter();
          var windowSettings = (WindowSettings.WindowSettings)formatter.Deserialize(settings);

          windowSettings.Restore(form, splitters);
        }
      }
    }

    public static void Record(Assembly assy, Form form, params SplitContainer[] splitters)
    {
      using (var store = GetIsolatedStorageFile())
      {
        using (var settings = store.OpenFile(GetSettingsFileName(assy), FileMode.OpenOrCreate))
        {
          var windowSettings = new WindowSettings.WindowSettings();
          windowSettings.Record(form, splitters);

          var formatter = new BinaryFormatter();
          formatter.Serialize(settings, windowSettings);
        }
      }
    }
  }
}
