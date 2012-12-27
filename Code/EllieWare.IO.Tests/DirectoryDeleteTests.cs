using System;
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
    public void DirectoryDelete_DoesNotExist_ThrowsException()
    {
      var mockReader = Helper.GetMockReader(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), 1);
      var delDir = new DirectoryDelete();
      delDir.ReadXml(mockReader.Object);

      var bRet = delDir.Run();
    }
  }
}
