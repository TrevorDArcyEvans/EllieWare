//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

namespace EllieWare.Common
{
  public partial class SingleItemExistsIOBaseCtrl : DualItemIOBaseCtrl
  {
    public SingleItemExistsIOBaseCtrl()
    {
      InitializeComponent();

      SetDestinationVisible(false);
      SetExistsVisible(true);
    }
  }
}
