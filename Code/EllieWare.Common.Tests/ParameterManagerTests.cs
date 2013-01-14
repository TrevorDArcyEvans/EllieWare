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
      Assert.False(mParamMgr.Contains(new SerializableParameter(Guid.NewGuid().ToString(), mParam)));
    }

    [Test]
    public void ParameterManager_Add_ContainsKey()
    {
      mParamMgr.Add(new SerializableParameter(mKey1, mParam));
      Assert.True(mParamMgr.Contains(new SerializableParameter(mKey1, mParam)));
    }

    [Test]
    [ExpectedException(typeof(ArgumentException))]
    public void ParameterManager_AddSameKey_ThrowsException()
    {
      mParamMgr.Add(new SerializableParameter(mKey1, mParam));
      mParamMgr.Add(new SerializableParameter(mKey1, mParam));
    }

    [Test]
    public void ParameterManager_Add_ReturnsSameObject()
    {
      mParamMgr.Add(new SerializableParameter(mKey1, mParam));
      Assert.AreEqual(mParam, mParamMgr.Get(mKey1).ParameterValue);
    }

    [Test]
    public void ParameterManager_Add_ContainsSameKey()
    {
      mParamMgr.Add(new SerializableParameter(mKey1, mParam));
      Assert.True(mParamMgr.Contains(new SerializableParameter(mKey1, mParam)));
      Assert.True(mParamMgr.Contains(new SerializableParameter(mKey2, mParam)));
    }

    #endregion

    #region Get

    [Test]
    public void ParameterManager_GetSameKey_ReturnsSameParameter()
    {
      mParamMgr.Add(new SerializableParameter(mKey1, mParam));
      Assert.AreSame(mParamMgr.Get(mKey1), mParamMgr.Get(mKey2));
    }

    [Test]
    public void ParameterManager_GetSameKey_ReturnsSameValue()
    {
      mParamMgr.Add(new SerializableParameter(mKey1, mParam));
      Assert.AreSame(mParamMgr.Get(mKey1), mParamMgr.Get(mKey2));
    }

    [Test]
    public void ParameterManager_GetSameKey_ReturnsSameDisplayName()
    {
      mParamMgr.Add(new SerializableParameter(mKey1, mParam));
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
      mParamMgr.Add(new SerializableParameter(mKey1, mParam));
      Assert.True(mParamMgr.Contains(new SerializableParameter(mKey1, mParam)));
    }

    [Test]
    public void ParameterManager_DisplayNames_ContainsExpectedCount()
    {
      mParamMgr.Add(new SerializableParameter(mKey1, mParam));
      Assert.True(mParamMgr.Parameters.Count() == 1);
    }

    #endregion

    #region Remove

    [Test]
    public void ParameterManager_Remove_ReturnsTrue()
    {
      mParamMgr.Add(new SerializableParameter(mKey1, mParam));
      Assert.True(mParamMgr.Remove(new SerializableParameter(mKey1, mParam)));
    }

    [Test]
    public void ParameterManager_RemoveTwice_ReturnsFalse()
    {
      mParamMgr.Add(new SerializableParameter(mKey1, mParam));
      Assert.True(mParamMgr.Remove(new SerializableParameter(mKey1, mParam)));
      Assert.False(mParamMgr.Remove(new SerializableParameter(mKey1, mParam)));
    }

    #endregion

    #region Update

    [Test]
    public void ParameterManager_Update_UpdatesParameter()
    {
      mParamMgr.Add(new SerializableParameter(mKey1, mParam));
      mParamMgr.Update(new SerializableParameter(mKey1, "stuff"));
      Assert.AreSame(mParamMgr.Get(mKey1).ParameterValue, "stuff");
    }

    [Test]
    [ExpectedException(typeof(TypeAccessException))]
    public void ParameterManager_UpdateDifferentType_ThrowsException()
    {
      mParamMgr.Add(new SerializableParameter(mKey1, mParam));
      mParamMgr.Update(new SerializableParameter(mKey1, 7.0));
    }

    [Test]
    [ExpectedException(typeof(KeyNotFoundException))]
    public void ParameterManager_UpdateNotExists_ThrowsException()
    {
      mParamMgr.Add(new SerializableParameter(mKey1, mParam));
      mParamMgr.Update(new SerializableParameter("NotExists", 7.0));
    }

    #endregion
  }
}
