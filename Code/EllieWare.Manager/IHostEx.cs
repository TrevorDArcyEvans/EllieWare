using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EllieWare.Interfaces;

namespace EllieWare.Manager
{
  public interface IHostEx
  {
    void RefreshSpecificationsList();
    string SpecificationsFolder { get; }
    IEnumerable<string> Specifications { get; }
  }
}
