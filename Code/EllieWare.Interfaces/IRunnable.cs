//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

using System;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace EllieWare.Interfaces
{
  /// <summary>
  /// A single unit of execution ie step, which can be saved and loaded
  /// </summary>
  public abstract class Runnable : MarshalByRefObject, IXmlSerializable
  {
    /// <summary>
    /// Summary of what the step will do, including any parameters.
    /// This will be displayed in a secondary, summary user interface.
    /// </summary>
    /// <remarks>Should be localised</remarks>
    public abstract string Summary { get; }

    /// <summary>
    /// A <see cref="Control"/> to allow a user to configure any parameters for the step
    /// </summary>
    public abstract Control ConfigurationUserInterface { get; }

    /// <summary>
    /// If the step can be executed with its current parameters
    /// </summary>
    /// <list type="bullet">
    /// <item>Called immediately before <see cref="Run"/></item>
    /// <item>Returning false will stop execution of this step and any subsequent steps</item>
    /// </list>
    public abstract bool CanRun { get; }

    /// <summary>
    /// Execute the step with its current parameters
    /// </summary>
    /// <returns>true if step successfully completes</returns>
    /// <remarks>Returning false will stop execution of any subsequent steps</remarks>
    public abstract bool Run();

    public abstract XmlSchema GetSchema();
    public abstract void ReadXml(XmlReader reader);
    public abstract void WriteXml(XmlWriter writer);
  }
}
