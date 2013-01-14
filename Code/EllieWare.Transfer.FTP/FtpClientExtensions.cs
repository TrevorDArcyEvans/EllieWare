//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using EnterpriseDT.Net.Ftp;

namespace EllieWare.Transfer.FTP
{
  public static class FtpClientExtensions
  {
    public static FTPFile[] GetFileInfosRecursive(this FTPConnection connection)
    {
      var resultList = new List<FTPFile>();
      var fileInfos = connection.GetFileInfos();
      resultList.AddRange(fileInfos);
      foreach (var fileInfo in fileInfos)
      {
        if (fileInfo.Dir)
        {
          connection.ServerDirectory = fileInfo.Path;
          resultList.AddRange(connection.GetFileInfosRecursive());
        }
      }

      return resultList.ToArray();
    }

    public static void CreateDirectoryEx(this FTPConnection connection, string directory)
    {
      // have to create each individual directory in the requested tree
      var dirFragment = directory;
      var dirTree = new List<string>();
      while (!string.IsNullOrEmpty(dirFragment))
      {
        var dir = Path.GetFileName(dirFragment);
        dirTree.Insert(0, dir);
        dirFragment = Path.GetDirectoryName(dirFragment);
      }

      for (var i = 0; i < dirTree.Count; i++)
      {
        var newDir = dirTree[i];
        var bRet = false;
        try
        {
          bRet = connection.ChangeWorkingDirectory(newDir);
        }
        catch (FTPException)
        {
        }
        if (!bRet)
        {
          connection.CreateDirectory(newDir);
          connection.ChangeWorkingDirectory(newDir);
        }
        Debug.WriteLine(connection.ServerDirectory);
      }
    }
  }
}
