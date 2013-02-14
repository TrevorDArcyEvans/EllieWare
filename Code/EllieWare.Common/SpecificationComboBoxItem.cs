//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.IO;
using System.Windows.Forms;
using ComboxExtended;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class SpecificationComboBoxItem : ComboBoxItem
  {
    public string FilePath { get; private set; }

    public SpecificationComboBoxItem(IRobotWare root, string filePath, ImageList images) :
      base(Path.GetFileNameWithoutExtension(filePath))
    {
      FilePath = filePath;
      var imageIndex = Utils.IsLocalSpecification(root, FilePath) ?  0 : 1;
      Image = images.Images[imageIndex];
    }
  }
}
