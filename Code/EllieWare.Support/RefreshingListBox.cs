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
