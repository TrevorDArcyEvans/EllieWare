//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

namespace EllieWare.Interfaces
{
  /// <summary>
  /// A series of parameterized values, one per line, taken from a text file on disk
  /// </summary>
  public interface IFileBatchParameter : IParameter
  {
    /// <summary>
    /// Fully qualified to text file on disk
    /// </summary>
    string FilePath { get; set; }
  }
}
