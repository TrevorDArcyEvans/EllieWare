//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
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

      Text = String.Format("About {0}", AssemblyTitle);
      labelProductName.Text = AssemblyProduct;
      labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
      labelCopyright.Text = AssemblyCopyright;
      labelCompanyName.Text = AssemblyCompany;
      textBoxDescription.Text = AssemblyDescription + Environment.NewLine + Environment.NewLine +
                                  Separator + Environment.NewLine +
                                  GetAllLicenseText();
    }

    public AboutBox(string appName) :
      this()
    {
      Text = String.Format("About {0}", appName);
      labelProductName.Text = appName;
    }

    #region Assembly Attribute Accessors

    private static string AssemblyTitle
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
        if (attributes.Length > 0)
        {
          var titleAttribute = (AssemblyTitleAttribute)attributes[0];
          if (titleAttribute.Title != "")
          {
            return titleAttribute.Title;
          }
        }
        return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
      }
    }

    private static string AssemblyVersion
    {
      get
      {
        return Assembly.GetExecutingAssembly().GetName().Version.ToString();
      }
    }

    private static string AssemblyDescription
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
        if (attributes.Length == 0)
        {
          return "";
        }
        return ((AssemblyDescriptionAttribute)attributes[0]).Description;
      }
    }

    private static string AssemblyProduct
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
        if (attributes.Length == 0)
        {
          return "";
        }
        return ((AssemblyProductAttribute)attributes[0]).Product;
      }
    }

    private static string AssemblyCopyright
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
        if (attributes.Length == 0)
        {
          return "";
        }
        return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
      }
    }

    private static string AssemblyCompany
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
        if (attributes.Length == 0)
        {
          return "";
        }
        return ((AssemblyCompanyAttribute)attributes[0]).Company;
      }
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
