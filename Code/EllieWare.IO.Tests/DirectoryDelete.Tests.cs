using System;
using System.IO;
using NUnit.Framework;

namespace EllieWare.IO.Tests
{
  [TestFixture]
  public class DirectoryDeleteTests
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
    [ExpectedException(typeof(DirectoryNotFoundException))]
    public void DirectoryDelete_DoesNotExist_ThrowsException()
    {
      var mockReader = Helper.GetMockReader(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), 1);
      var delDir = new DirectoryDelete();

      delDir.ReadXml(mockReader.Object);

      var bRet = delDir.Run();
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
