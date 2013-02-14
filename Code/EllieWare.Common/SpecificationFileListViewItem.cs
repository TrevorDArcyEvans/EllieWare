//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.IO;
using System.Windows.Forms;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class SpecificationFileListViewItem : ListViewItem
  {
    public string FilePath { get; private set; }

    public SpecificationFileListViewItem(IRobotWare root, string filePath) :
      base(Path.GetFileNameWithoutExtension(filePath))
    {
      FilePath = filePath;
      ImageIndex = Utils.IsLocalSpecification(root, FilePath) ?  0 : 1;
    }
  }
}
