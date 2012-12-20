//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Globalization;
using System.Xml;
using Moq;

namespace EllieWare.IO.Tests
{
  public static class Helper
  {
    public static Mock<XmlReader> GetMockReader(string source, string destination, int exists)
    {
      var mockReader = new Mock<XmlReader>();
      mockReader.Setup(x => x.GetAttribute("Source")).Returns(source);
      mockReader.Setup(x => x.GetAttribute("Destination")).Returns(destination);
      mockReader.Setup(x => x.GetAttribute("Exists")).Returns(exists.ToString(CultureInfo.InvariantCulture));

      return mockReader;
    }
  }
}
