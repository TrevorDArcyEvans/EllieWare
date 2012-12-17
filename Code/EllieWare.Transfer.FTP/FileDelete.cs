using EllieWare.Interfaces;

namespace EllieWare.Transfer.FTP
{
  public partial class FileDelete : FtpSingleItemExistsIOBase
  {
    public FileDelete()
    {
      InitializeComponent();

      Initialise();
    }

    public FileDelete(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();

      Initialise();
    }

    private void Initialise()
    {
      mDualItemIO.AllowSourceBrowse = false;
      mDualItemIO.SetExistsVisible(false);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Login to {0} as {1}[{2}] and delete (file) {3}", 
                          mFtpInfo.Host.ResolvedValue,
                          mFtpInfo.UserName.ResolvedValue,
                          mFtpInfo.Password.ResolvedValue,
                          mDualItemIO.SourceFilePathResolvedValue);

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

        return ftp.DeleteFile(mDualItemIO.SourceFilePathResolvedValue);
      }
    }
  }
}
