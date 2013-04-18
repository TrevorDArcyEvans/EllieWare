//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public partial class AboutBox : Form
  {
    private const string Separator = "=======================================================";

    public AboutBox()
    {
      InitializeComponent();

      Initialise(Assembly.GetExecutingAssembly());
    }

    public AboutBox(string appName) :
      this()
    {
      Initialise(appName);
    }

    public AboutBox(string appName, Image img, Assembly infoAssy) :
      this(appName)
    {
      AppImage.Image = img;

      Initialise(infoAssy);
      Initialise(appName);
    }

    private void Initialise(Assembly infoAssy)
    {
      Text = String.Format("About {0}", AssemblyTitle(infoAssy));
      labelProductName.Text = AssemblyProduct(infoAssy);
      labelVersion.Text = String.Format("Version {0}", AssemblyVersion(infoAssy));
      labelCopyright.Text = AssemblyCopyright(infoAssy);
      labelCompanyName.Text = AssemblyCompany(infoAssy);
      textBoxDescription.Text = AssemblyDescription(infoAssy) + Environment.NewLine + Environment.NewLine +
                                Separator + Environment.NewLine +
                                GetAllLicenseText();
    }

    private void Initialise(string appName)
    {
      Text = String.Format("About {0}", appName);
      labelProductName.Text = appName;
    }

    #region Assembly Attribute Accessors

    private string AssemblyTitle(Assembly infoAssy)
    {
      object[] attributes = infoAssy.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
      if (attributes.Length > 0)
      {
        var titleAttribute = (AssemblyTitleAttribute)attributes[0];
        if (titleAttribute.Title != "")
        {
          return titleAttribute.Title;
        }
      }
      return Path.GetFileNameWithoutExtension(infoAssy.CodeBase);
    }

    private string AssemblyVersion(Assembly infoAssy)
    {
      return infoAssy.GetName().Version.ToString();
    }

    private string AssemblyDescription(Assembly infoAssy)
    {
      object[] attributes = infoAssy.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
      if (attributes.Length == 0)
      {
        return "";
      }
      return ((AssemblyDescriptionAttribute)attributes[0]).Description;
    }

    private string AssemblyProduct(Assembly infoAssy)
    {
      object[] attributes = infoAssy.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
      if (attributes.Length == 0)
      {
        return "";
      }
      return ((AssemblyProductAttribute)attributes[0]).Product;
    }

    private string AssemblyCopyright(Assembly infoAssy)
    {
      object[] attributes = infoAssy.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
      if (attributes.Length == 0)
      {
        return "";
      }
      return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
    }

    private string AssemblyCompany(Assembly infoAssy)
    {
      object[] attributes = infoAssy.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
      if (attributes.Length == 0)
      {
        return "";
      }
      return ((AssemblyCompanyAttribute)attributes[0]).Company;
    }

    #endregion

    private string GetAllLicenseText()
    {
      var sb = new StringBuilder();
      var callAssyLoc = Assembly.GetCallingAssembly().Location;
      var callAssyDir = Path.GetDirectoryName(callAssyLoc);
      var dllFiles = Directory.EnumerateFiles(callAssyDir, "*.dll");
      foreach (var thisDllFile in dllFiles)
      {
        try
        {
          var assy = Assembly.LoadFrom(thisDllFile);
          var allLicInfoAttrs = from attr in assy.GetCustomAttributes(true) where attr is LicenseInformation select (LicenseInformation)attr;
          foreach (var licInfoAttr in allLicInfoAttrs)
          {
            var manResStrmName = assy.GetName().Name + "." + licInfoAttr.LicenseFileName;
            using (var stream = assy.GetManifestResourceStream(manResStrmName))
            {
              using (var reader = new StreamReader(stream))
              {
                var result = reader.ReadToEnd();
                sb.AppendLine(result);
                sb.AppendLine(Separator);
              }
            }
          }
        }
        catch (BadImageFormatException)
        {
          // might not be a .NET dll but how?
        }
      }

      return sb.ToString();
    }
  }
}
