using System;
using EllieWare.Interfaces;

namespace EllieWare.Transfer.FTP
{
  public class FileDownloadFactory : FtpFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "FTP file download";
      }
    }

    public override string Description
    {
      get
      {
        return "Download a file from an FTP server";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(FileDownload);
      }
    }

    public override IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      return new FileDownload(root, callback, mgr);
    }
  }
}
