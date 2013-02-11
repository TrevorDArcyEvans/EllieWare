//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Globalization;
using System.Text;
using Microsoft.Win32;

namespace EllieWare.Licensing
{
  public class LicenseManager
  {
    // HKLM
    //  SOFTWARE
    //    EllieWare
    //      [ProductName]
    //        License
    //          {Code} --> LicenseCode
    //          {UserName} --> UserName

    private const string RegistryKey = "EllieWare";

    public static bool IsLicensed(string productName, Version appVer)
    {
      var root = Registry.LocalMachine.OpenSubKey("SOFTWARE");
      var ellieWare = root.OpenSubKey(RegistryKey);
      if (ellieWare == null)
      {
        return false;
      }

      var product = ellieWare.OpenSubKey(productName);
      if (product == null)
      {
        return false;
      }

      var productLicense = product.OpenSubKey("License");
      if (productLicense == null)
      {
        return false;
      }

      var regLicCode = (string)productLicense.GetValue("Code");
      var userName = (string)productLicense.GetValue("UserName");
      var licCode = GetLicenceCode(productName, appVer, userName);

      return regLicCode == licCode;
    }

    public static void Register(string productName, Version appVer, string userName, string licCode)
    {
      // all license code (and user names) are saved to HKLM
      var root = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
      var ellieWare = root.OpenSubKey(RegistryKey, true) ?? root.CreateSubKey(RegistryKey);
      var product = ellieWare.OpenSubKey(productName, true) ?? ellieWare.CreateSubKey(productName);
      var productLicense = product.OpenSubKey("License", true) ?? product.CreateSubKey("License");

      productLicense.SetValue("Code", licCode);
      productLicense.SetValue("UserName", userName);
    }

    public static void Unregister(string productName, Version appVer, string userName)
    {
      var root = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
      var ellieWare = root.OpenSubKey(RegistryKey, true);
      var product = ellieWare.OpenSubKey(productName, true);

      product.DeleteSubKey("License");
    }

    // products are licensed on major version number
    internal static string GetLicenceCode(string productName, Version appVer, string userName)
    {
      var data = Encoding.ASCII.GetBytes(productName + userName + appVer.Major.ToString(CultureInfo.InvariantCulture));
      data = System.Security.Cryptography.SHA1.Create().ComputeHash(data);

      return Convert.ToBase64String(data);
    }
  }
}
