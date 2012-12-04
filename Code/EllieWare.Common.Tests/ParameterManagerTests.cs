using System;
using EllieWare.Interfaces;
using NUnit.Framework;

namespace EllieWare.Common.Tests
{
  [TestFixture]
  public class ParameterManagerTests
  {
    private const string LocalisedDisplayName = "Localised display name";

    private Guid mKey1 = new Guid("A99B7E87-2589-4AE7-B500-31BBD43577F8");
    private Guid mKey2 = new Guid("A99B7E87-2589-4AE7-B500-31BBD43577F8");
    private IParameter mParam = new StubParameter { DisplayName = LocalisedDisplayName, Value = "some string" };
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

    [Test]
    public void ParameterManager_DoesNotContainNewGuid()
    {
      Assert.False(mParamMgr.Contains(Guid.NewGuid()));
    }

    [Test]
    public void ParameterManager_Add_ContainsGuid()
    {
      mParamMgr.Add(mKey1, mParam);
      Assert.True(mParamMgr.Contains(mKey1));
    }

    [Test]
    public void ParameterManager_Add_ReturnsParameter()
    {
      mParamMgr.Add(mKey1, mParam);
      Assert.AreSame(mParam, mParamMgr.Get(mKey1));
    }

    [Test]
    public void ParameterManager_Add_ContainsSameGuid()
    {
      mParamMgr.Add(mKey1, mParam);
      Assert.True(mParamMgr.Contains(mKey1));
      Assert.True(mParamMgr.Contains(mKey2));
    }

    [Test]
    public void ParameterManager_GetSameGuid_ReturnsSameParameter()
    {
      mParamMgr.Add(mKey1, mParam);
      Assert.AreSame(mParamMgr.Get(mKey1), mParamMgr.Get(mKey2));
    }

    [Test]
    public void ParameterManager_GetSameGuid_ReturnsSameValue()
    {
      mParamMgr.Add(mKey1, mParam);
      Assert.AreSame(mParamMgr.Get(mKey1).Value, mParamMgr.Get(mKey2).Value);
    }

    [Test]
    public void ParameterManager_GetSameGuid_ReturnsSameDisplayName()
    {
      mParamMgr.Add(mKey1, mParam);
      Assert.AreSame(mParamMgr.Get(mKey1).DisplayName, mParamMgr.Get(mKey2).DisplayName);
    }
  }
}
