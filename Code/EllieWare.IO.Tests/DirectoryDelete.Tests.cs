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
  public class DirectoryDeleteTests
  {
    #region SetUp/TearDown

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
    public void DirectoryDelete_DoesNotExist_Succeeds()
    {
      var mockReader = Helper.GetMockReader(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), 1);
      var delDir = new DirectoryDelete();

      delDir.ReadXml(mockReader.Object);

      Assert.True(delDir.Run());
    }

    [Test]
    public void DirectoryDelete_Exists_Succeeds()
    {
      var cwd = Environment.CurrentDirectory;
      var tempDirName = Guid.NewGuid().ToString();
      var tempDirPath = Path.Combine(cwd, tempDirName);
      var mockReader = Helper.GetMockReader(tempDirPath, Guid.NewGuid().ToString(), 1);
      var delDir = new DirectoryDelete();

      delDir.ReadXml(mockReader.Object);
      Directory.CreateDirectory(tempDirPath);

      Assert.True(delDir.Run());
      Assert.True(!Directory.Exists(tempDirPath));
    }
  }
}
