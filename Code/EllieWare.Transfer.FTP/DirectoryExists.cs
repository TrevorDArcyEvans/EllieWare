using EllieWare.Interfaces;

namespace EllieWare.Transfer.FTP
{
  public partial class DirectoryExists : FtpSingleItemExistsIOBase
  {
    public DirectoryExists()
    {
      InitializeComponent();
    }

    public DirectoryExists(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Check that {0} is ", mDualItemIO.SourceFilePathResolvedValue) + (mDualItemIO.Exists ? "" : "not ") + "present";

        return descrip;
      }
    }

    public override bool Run()
    {
      using (var ftp = mFtpInfo.GetFtpConnection())
      {
        // connect and login
        ftp.Connect();
        ftp.Login();

        // TODO   check this works (or not)
        return ftp.ChangeWorkingDirectory(mDualItemIO.SourceFilePathResolvedValue);
      }
    }
  }
}
