using System.Windows.Forms;
using EllieWare.Interfaces;

namespace EllieWare.Transfer.FTP
{
  public partial class FtpSingleItemExistsIOBase : FtpDualItemIOBase
  {
    public FtpSingleItemExistsIOBase()
    {
      InitializeComponent();

      Initialise();
    }

    public FtpSingleItemExistsIOBase(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();

      Initialise();
    }

    private void Initialise()
    {
      mDualItemIO.SetDestinationVisible(false);
      mDualItemIO.AllowSourceBrowse = false;
    }

    public override Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }
  }
}
