//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Windows.Forms;

namespace EllieWare.Support
{
  public class RefreshingListBox : ListBox
  {
    public new void RefreshItem(int index)
    {
      base.RefreshItem(index);
    }

    public new void RefreshItems()
    {
      base.RefreshItems();
    }
  }
}
