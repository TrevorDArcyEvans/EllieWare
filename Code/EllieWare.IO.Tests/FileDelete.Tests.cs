//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.IO;
using NUnit.Framework;

namespace EllieWare.IO.Tests
{
  [TestFixture]
  public class FileDeleteTests
  {
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
    }

    [TearDown]
    public void TearDown()
    {
    }

    #endregion

    [Test]
    public void FileDelete_DoesNotExist_Succeeds()
    {
      var mockReader = Helper.GetMockReader(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), 1);
      var delFile = new FileDelete();

      delFile.ReadXml(mockReader.Object);

      Assert.IsTrue(delFile.Run());
    }

    [Test]
    public void FileDelete_Exists_Succeeds()
    {
      var cwd = Environment.CurrentDirectory;
      var tempFileName = Guid.NewGuid().ToString();
      var tempFilePath = Path.Combine(cwd, tempFileName);
      var mockReader = Helper.GetMockReader(tempFilePath, Guid.NewGuid().ToString(), 1);
      var delFile = new FileDelete();

      delFile.ReadXml(mockReader.Object);
      File.WriteAllText(tempFilePath, "to be deleted");

      Assert.True(delFile.Run());
      Assert.True(!Directory.Exists(tempFilePath));
    }
  }
}
