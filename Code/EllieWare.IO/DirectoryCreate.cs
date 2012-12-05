using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public partial class DirectoryCreate : MutableRunnableBase
  {
    public DirectoryCreate()
    {
      InitializeComponent();
    }

    public DirectoryCreate(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();
    }
  }
}
