using System.Collections.Generic;
using System.Xml.Serialization;
using EllieWare.Interfaces;

namespace EllieWare.Manager
{
  public interface ISpecification : IXmlSerializable
  {
    IParameterManager ParameterManager { get; }
    List<IRunnable> Steps { get; }
  }
}
