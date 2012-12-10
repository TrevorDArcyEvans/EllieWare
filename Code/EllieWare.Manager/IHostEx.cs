using System.Collections.Generic;

namespace EllieWare.Manager
{
  public interface IHostEx
  {
    void RefreshSpecificationsList();
    string SpecificationsFolder { get; }
    IEnumerable<string> Specifications { get; }
  }
}
