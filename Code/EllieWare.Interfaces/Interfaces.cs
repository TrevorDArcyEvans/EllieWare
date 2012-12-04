using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace EllieWare.Interfaces
{
  public enum LogLevel
  {
    Debug,
    Information,
    Warning,
    Severe,
    Critical
  }

  public interface ICallback
  {
    void Log(LogLevel level, string message);
  }

  public interface IParameter : IXmlSerializable
  {
    string DisplayName { get; }
    string Value { get; }
  }

  public interface IParameterManager : IXmlSerializable
  {
    bool Contains(Guid key);
    void Add(Guid key, IParameter parameter);
    IParameter Get(Guid key);
  }

  public interface IRunnable : IXmlSerializable
  {
    string Description { get; }
    Control ConfigurationUserInterface { get; }

    bool Run();
  }

  public interface IFactory
  {
    string Title { get; }
    string Description { get; }
    string Keywords { get; }
    IEnumerable<string> Categories { get; }
    Type CreatedType { get; }

    IRunnable Create(object root, ICallback callback, IParameterManager mgr);
  }

  public interface ISpecification : IXmlSerializable
  {
    IParameterManager ParameterManager { get; }
    List<IRunnable> Steps { get; }
  }
}
