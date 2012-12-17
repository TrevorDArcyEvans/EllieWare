using System;
using EllieWare.Interfaces;

namespace EllieWare.Transfer.FTP
{
  public class FileUploadFactory : FtpFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "FTP file upload";
      }
    }

    public override string Description
    {
      get
      {
        return "Upload a file to an FTP server";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(FileUpload);
      }
    }

    public override IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      return new FileUpload(root, callback, mgr);
    }
  }
}
