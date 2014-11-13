//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace RobotWare.SolidWorks
{
  public class BitmapHandler : IDisposable
  {
    private IList<string> mFilePaths = new List<string>();

    public string CreateFileFromResourceBitmap(string bitmapName, Assembly assy)
    {
      Stream manifestResStrm = null;
      Bitmap bmp = null;
      try
      {
        manifestResStrm = assy.GetManifestResourceStream(bitmapName);
        bmp = new Bitmap(manifestResStrm);
        var tempFileName = Path.GetTempFileName();
        bmp.Save(tempFileName);
        mFilePaths.Add(tempFileName);

        return tempFileName;
      }
      catch (Exception)
      {
        return string.Empty;
      }
      finally
      {
        bmp.Dispose();
        manifestResStrm.Close();
        manifestResStrm = null;
      }
    }

    public void Dispose()
    {
      foreach (var thisBmp in mFilePaths)
      {
        try
        {
          File.Delete(thisBmp);
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
      }
    }
  }
}
