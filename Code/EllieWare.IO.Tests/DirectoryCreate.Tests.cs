using System;
using System.IO;
using NUnit.Framework;

namespace EllieWare.IO.Tests
{
  [TestFixture]
  public class DirectoryCreateTests
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
    public void DirectoryCreate_Exists_Succeeds()
    {
      var cwd = Environment.CurrentDirectory;
      var tempDirName = Guid.NewGuid().ToString();
      var tempDirPath = Path.Combine(cwd, tempDirName);
      var mockReader = Helper.GetMockReader(tempDirPath, Guid.NewGuid().ToString(), 1);
      var mkDir = new DirectoryCreate();

      try
      {
        mkDir.ReadXml(mockReader.Object);
        Directory.CreateDirectory(tempDirPath);

        Assert.True(mkDir.Run());
      }
      finally
      {
        Directory.Delete(tempDirPath);
      }
    }
  }
}
