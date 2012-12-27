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
using System.Xml;
using EllieWare.Interfaces;
using NUnit.Framework;

namespace EllieWare.Common.Tests
{
  [TestFixture]
  public class ParameterManagerPersistenceTests
  {
    private IParameterManager mParamMgr;

    #region SetUp/TearDown

    [TestFixtureSetUp]
    public void FixtureSetUp()
    {
    }

    [TestFixtureTearDown]
    public void FixtureTearDown()
    {
    }

    [SetUp]
    public void Setup()
    {
      mParamMgr = new ParameterManager();
    }

    [TearDown]
    public void TearDown()
    {
    }

    #endregion

    private string GetXml()
    {
      string xmlTxt;
      using (var sw = new StringWriter())
      {
        using (var writer = XmlWriter.Create(sw))
        {
          writer.WriteStartElement("Specification");
          writer.WriteStartElement("ParameterManager");

          mParamMgr.WriteXml(writer);

          writer.WriteEndElement();
          writer.WriteEndElement();
        }

        xmlTxt = sw.ToString();
      }
      return xmlTxt;
    }

    private IParameterManager CreateParameterManager(string xmlTxt)
    {
      var reader = XmlReader.Create(new StringReader(xmlTxt));
      var newParamMgr = new ParameterManager();
      newParamMgr.ReadXml(reader);

      return newParamMgr;
    }

    [Test]
    public void ParameterManager_Persistence_String()
    {
      // string
      mParamMgr.Add("Key1", "Param1");
      mParamMgr.Add("Key2", "Param2");

      var newParamMgr = CreateParameterManager(GetXml());

      Assert.True(newParamMgr.DisplayNames.Count() == 2);

      Assert.True(newParamMgr.DisplayNames.Contains("Key1"));
      Assert.True(newParamMgr.DisplayNames.Contains("Key2"));

      Assert.AreEqual(newParamMgr.Get("Key1").GetType(), typeof(string));
      Assert.AreEqual(newParamMgr.Get("Key2").GetType(), typeof(string));

      Assert.AreEqual(newParamMgr.Get("Key1"), "Param1");
      Assert.AreEqual(newParamMgr.Get("Key2"), "Param2");
    }

    [Test]
    public void ParameterManager_Persistence_Boolean()
    {
      // boolean
      mParamMgr.Add("Key1", true);
      mParamMgr.Add("Key2", false);

      var newParamMgr = CreateParameterManager(GetXml());

      Assert.True(newParamMgr.DisplayNames.Count() == 2);

      Assert.True(newParamMgr.DisplayNames.Contains("Key1"));
      Assert.True(newParamMgr.DisplayNames.Contains("Key2"));

      Assert.AreEqual(newParamMgr.Get("Key1").GetType(), typeof(bool));
      Assert.AreEqual(newParamMgr.Get("Key2").GetType(), typeof(bool));

      Assert.AreEqual(newParamMgr.Get("Key1"), true);
      Assert.AreEqual(newParamMgr.Get("Key2"), false);
    }

    [Test]
    public void ParameterManager_Persistence_Number()
    {
      // number
      mParamMgr.Add("Key1", 6);
      mParamMgr.Add("Key2", 7.21f);

      var newParamMgr = CreateParameterManager(GetXml());

      Assert.True(newParamMgr.DisplayNames.Count() == 2);

      Assert.True(newParamMgr.DisplayNames.Contains("Key1"));
      Assert.True(newParamMgr.DisplayNames.Contains("Key2"));

      Assert.AreEqual(newParamMgr.Get("Key1").GetType(), typeof(int));
      Assert.AreEqual(newParamMgr.Get("Key2").GetType(), typeof(float));

      Assert.AreEqual(newParamMgr.Get("Key1"), 6);
      Assert.AreEqual(newParamMgr.Get("Key2"), 7.21f);
    }

    [Test]
    public void ParameterManager_Persistence_DateTime()
    {
      // date-time
      mParamMgr.Add("Key1", new DateTime(2006, 02, 20));
      mParamMgr.Add("Key2", new DateTime(1963, 10, 19));

      var newParamMgr = CreateParameterManager(GetXml());

      Assert.True(newParamMgr.DisplayNames.Count() == 2);

      Assert.True(newParamMgr.DisplayNames.Contains("Key1"));
      Assert.True(newParamMgr.DisplayNames.Contains("Key2"));

      Assert.AreEqual(newParamMgr.Get("Key1").GetType(), typeof(DateTime));
      Assert.AreEqual(newParamMgr.Get("Key2").GetType(), typeof(DateTime));

      Assert.AreEqual(newParamMgr.Get("Key1"), new DateTime(2006, 02, 20));
      Assert.AreEqual(newParamMgr.Get("Key2"), new DateTime(1963, 10, 19));
    }

    [Test]
    public void ParameterManager_Persistence_StringArray()
    {
      // string array
      mParamMgr.Add("Key1", new[] { "Key1.1", "Key1.2", "Key1.3" });
      mParamMgr.Add("Key2", new[] { "Key2.1", "Key2.2", "Key2.3" });

      var newParamMgr = CreateParameterManager(GetXml());

      Assert.True(newParamMgr.DisplayNames.Count() == 2);

      Assert.True(newParamMgr.DisplayNames.Contains("Key1"));
      Assert.True(newParamMgr.DisplayNames.Contains("Key2"));

      Assert.AreEqual(newParamMgr.Get("Key1").GetType(), typeof(string[]));
      Assert.AreEqual(newParamMgr.Get("Key2").GetType(), typeof(string[]));

      var array1 = (string[])newParamMgr.Get("Key1");
      Assert.True(array1.Count() == 3);
      Assert.AreEqual(array1[0], "Key1.1");
      Assert.AreEqual(array1[1], "Key1.2");
      Assert.AreEqual(array1[2], "Key1.3");

      var array2 = (string[])newParamMgr.Get("Key2");
      Assert.True(array2.Count() == 3);
      Assert.AreEqual(array2[0], "Key2.1");
      Assert.AreEqual(array2[1], "Key2.2");
      Assert.AreEqual(array2[2], "Key2.3");
    }
  }
}
