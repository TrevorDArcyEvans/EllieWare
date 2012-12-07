using System;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public partial class MutableRunnableBase : UserControl, IMutableRunnable
  {
    protected readonly object mRoot;
    protected readonly ICallback mCallback;
    protected readonly IParameterManager mParamMgr;

    public MutableRunnableBase()
    {
      InitializeComponent();
    }

    public MutableRunnableBase(object root, ICallback callback, IParameterManager mgr) :
      this()
    {
      mRoot = root;
      mCallback = callback;
      mParamMgr = mgr;
    }

    #region Implementation of IXmlSerializable

    public XmlSchema GetSchema()
    {
      return null;
    }

    public virtual void ReadXml(XmlReader reader)
    {
      throw new NotImplementedException();
    }

    public virtual void WriteXml(XmlWriter writer)
    {
      throw new NotImplementedException();
    }

    #endregion

    #region Implementation of IRunnable

    public virtual string Description
    {
      get { throw new NotImplementedException(); }
    }

    public virtual Control ConfigurationUserInterface
    {
      get { throw new NotImplementedException(); }
    }

    public virtual bool Run()
    {
      throw new NotImplementedException();
    }

    #endregion

    protected void FireConfigurationChanged()
    {
      if (ConfigurationChanged != null)
      {
        ConfigurationChanged(this, new EventArgs());
      }
    }

    #region Implementation of IMutableRunnable

    public event EventHandler ConfigurationChanged;

    #endregion
  }
}
