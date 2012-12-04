using EllieWare.Interfaces;
using NUnit.Framework;

namespace EllieWare.Common.Tests
{
  [TestFixture]
  public class ParameterTests
  {
    private const string LocalisedDisplayName = "Localised display name";

    private readonly string mValue = "new object()";
    private IParameter mParam;

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
      mParam = new Parameter(LocalisedDisplayName, mValue);
    }

    [TearDown]
    public void TearDown()
    {
    }

    #endregion

    [Test]
    public void Parameter_DisplayName_Same()
    {
      Assert.AreSame(mParam.DisplayName, LocalisedDisplayName);
    }

    [Test]
    public void Parameter_Value_Same()
    {
      Assert.AreSame(mParam.Value, mValue);
    }
  }
}
