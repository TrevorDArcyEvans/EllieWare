//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Text;
using Microsoft.Win32;

namespace EllieWare.Licensing
{
  public class LicenseManager
  {
    // HKCU
    //  Software
    //    EllieWare
    //      [ProductName]
    //        {UserName}

    // HKLM
    //  SOFTWARE
    //    EllieWare
    //      [ProductName]
    //        License
    //          UserName1
    //            {Code} --> LicenseCode
    //          UserName2
    //            {Code} --> LicenseCode
    //          UserNameX
    //            {Code} --> LicenseCode

    private const string RegistryKey = "EllieWare";

    internal static string GetUserName(string productName)
    {
      var currentUser = Registry.CurrentUser.OpenSubKey("SOFTWARE");
      var ellieWare = currentUser.OpenSubKey(RegistryKey);
      if (ellieWare == null)
      {
        return string.Empty;
      }

      var product = ellieWare.OpenSubKey(productName);
      if (product == null)
      {
        return string.Empty;
      }

      var userName = (string)product.GetValue("UserName");

      return userName ?? string.Empty;
    }

    private static void CreateUserName(string productName, string userName)
    {
      var currentUser = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
      var ellieWare = currentUser.OpenSubKey(RegistryKey, true) ?? currentUser.CreateSubKey(RegistryKey);
      var product = ellieWare.OpenSubKey(productName, true) ?? ellieWare.CreateSubKey(productName);

      product.SetValue("UserName", userName);
    }

    private static void UnregisterForCurrentUser(string productName)
    {
      var currentUser = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
      var ellieWare = currentUser.OpenSubKey(RegistryKey, true);
      ellieWare.DeleteSubKey(productName);
    }

    public static bool IsLicensed(string productName)
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

      var userName = GetUserName(productName);
      if (string.IsNullOrEmpty(userName))
      {
        return false;
      }

      var userNameKey = productLicense.OpenSubKey(userName);
      if (userNameKey == null)
      {
        return false;
      }

      var regLicCode = (string)userNameKey.GetValue("Code");
      var licCode = GetLicenceCode(productName, userName);

      return regLicCode == licCode;
    }

    internal static void Register(string productName, string userName, string licCode)
    {
      // save user name to HKCU
      CreateUserName(productName, userName);

      // all license code (and user names) are saved to HKLM
      var root = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
      var ellieWare = root.OpenSubKey(RegistryKey, true) ?? root.CreateSubKey(RegistryKey);
      var product = ellieWare.OpenSubKey(productName, true) ?? ellieWare.CreateSubKey(productName);
      var productLicense = product.OpenSubKey("License", true) ?? product.CreateSubKey("License");
      var userNameKey = productLicense.OpenSubKey(userName, true) ?? productLicense.CreateSubKey(userName);

      userNameKey.SetValue("Code", licCode);
    }

    internal static void Unregister(string productName, string userName)
    {
      // remove from HKCU
      UnregisterForCurrentUser(productName);

      var root = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
      var ellieWare = root.OpenSubKey(RegistryKey, true);
      var product = ellieWare.OpenSubKey(productName, true);
      var productLicense = product.OpenSubKey("License", true);

      productLicense.DeleteSubKey(userName);
    }

    internal static string GetLicenceCode(string productName, string userName)
    {
      var data = Encoding.ASCII.GetBytes(productName + userName);
      data = System.Security.Cryptography.SHA1.Create().ComputeHash(data);

      return Convert.ToBase64String(data);
    }
  }
}
