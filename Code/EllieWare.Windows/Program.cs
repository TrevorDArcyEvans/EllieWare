using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EllieWare.Windows
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      var userDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
      var userSpecsPath = Path.Combine(userDocs, "EllieWare for Windows");
      Directory.CreateDirectory(userSpecsPath);

      Application.Run(new EllieWare.Manager.Manager(null, userSpecsPath));
    }
  }
}
