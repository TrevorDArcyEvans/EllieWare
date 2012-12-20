//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Linq;
using EllieWare.Interfaces;
using NUnit.Framework;

namespace EllieWare.Common.Tests
{
  [TestFixture]
  public class ParameterManagerTests
  {
    private const string mKey1 = "A99B7E87-2589-4AE7-B500-31BBD43577F8";
    private const string mKey2 = "A99B7E87-2589-4AE7-B500-31BBD43577F8";
    private object mParam = "some string";
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

    #region Add/Contains

    [Test]
    public void ParameterManager_Contains_DoesNotContainRandomKey()
    {
      Assert.False(mParamMgr.Contains(Guid.NewGuid().ToString()));
    }

    [Test]
    public void ParameterManager_Add_ContainsKey()
    {
      mParamMgr.Add(mKey1, mParam);
      Assert.True(mParamMgr.Contains(mKey1));
    }

    [Test]
    [ExpectedException(typeof(ArgumentException))]
    public void ParameterManager_AddSameKey_ThrowsException()
    {
      mParamMgr.Add(mKey1, mParam);
      mParamMgr.Add(mKey1, mParam);
    }

    [Test]
    public void ParameterManager_Add_ReturnsSameObject()
    {
      mParamMgr.Add(mKey1, mParam);
      Assert.AreEqual(mParam, mParamMgr.Get(mKey1));
    }

    [Test]
    public void ParameterManager_Add_ContainsSameKey()
    {
      mParamMgr.Add(mKey1, mParam);
      Assert.True(mParamMgr.Contains(mKey1));
      Assert.True(mParamMgr.Contains(mKey2));
    }

    #endregion

    #region Get

    [Test]
    public void ParameterManager_GetSameKey_ReturnsSameParameter()
    {
      mParamMgr.Add(mKey1, mParam);
      Assert.AreSame(mParamMgr.Get(mKey1), mParamMgr.Get(mKey2));
    }

    [Test]
    public void ParameterManager_GetSameKey_ReturnsSameValue()
    {
      mParamMgr.Add(mKey1, mParam);
      Assert.AreSame(mParamMgr.Get(mKey1), mParamMgr.Get(mKey2));
    }

    [Test]
    public void ParameterManager_GetSameKey_ReturnsSameDisplayName()
    {
      mParamMgr.Add(mKey1, mParam);
      Assert.AreSame(mParamMgr.Get(mKey1), mParamMgr.Get(mKey2));
    }

    [Test]
    [ExpectedException(typeof(KeyNotFoundException))]
    public void ParameterManager_GetRandomKey_ThrowsException()
    {
      Assert.IsNull(mParamMgr.Get(Guid.NewGuid().ToString()));
    }

    #endregion

    #region DisplayNames

    [Test]
    public void ParameterManager_DisplayNames_ContainsExpectedDisplayName()
    {
      mParamMgr.Add(mKey1, mParam);
      Assert.True(mParamMgr.DisplayNames.Contains(mKey1));
    }

    [Test]
    public void ParameterManager_DisplayNames_ContainsExpectedCount()
    {
      mParamMgr.Add(mKey1, mParam);
      Assert.True(mParamMgr.DisplayNames.Count() == 1);
    }

    #endregion

    #region Remove

    [Test]
    public void ParameterManager_Remove_ReturnsTrue()
    {
      mParamMgr.Add(mKey1, mParam);
      Assert.True(mParamMgr.Remove(mKey1));
    }

    [Test]
    public void ParameterManager_RemoveTwice_ReturnsFalse()
    {
      mParamMgr.Add(mKey1, mParam);
      Assert.True(mParamMgr.Remove(mKey1));
      Assert.False(mParamMgr.Remove(mKey1));
    }

    #endregion

    #region Update

    [Test]
    public void ParameterManager_Update_UpdatesParameter()
    {
      mParamMgr.Add(mKey1, mParam);
      mParamMgr.Update(mKey1, "stuff");
      Assert.AreSame(mParamMgr.Get(mKey1), "stuff");
    }

    [Test]
    [ExpectedException(typeof(TypeAccessException))]
    public void ParameterManager_UpdateDifferentType_ThrowsException()
    {
      mParamMgr.Add(mKey1, mParam);
      mParamMgr.Update(mKey1, 7.0);
    }

    [Test]
    [ExpectedException(typeof(KeyNotFoundException))]
    public void ParameterManager_UpdateNotExists_ThrowsException()
    {
      mParamMgr.Add(mKey1, mParam);
      mParamMgr.Update("NotExists", 7.0);
    }

    #endregion
  }
}
