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
  /// A series of parameterized values taken from a listing of files in a directory
  /// </summary>
  public interface IDirectoryBatchParameter : IBatchParameter
  {
    /// <summary>
    /// File mask when retrieving files from <see cref="Directory"/>
    /// </summary>
    string FileMask { get; set; }

    /// <summary>
    /// Fully qualified path to directory on disk
    /// </summary>
    string Directory { get; set; }
  }
}
