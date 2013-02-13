// edtFTPnet
// 
// Copyright (C) 2011 Enterprise Distributed Technologies Ltd
// 
// www.enterprisedt.com
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
// 
// Bug fixes, suggestions and comments should posted on 
// http://www.enterprisedt.com/forums/index.php
// 
// Change Log:
// 
// $Log: LoggingLock.cs,v $
// Revision 1.1  2011-03-07 06:35:05  hans
// Utility for debugging deadlocks related to the "lock" keyword.
//

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace EnterpriseDT.Util.Debug
{
    /// <summary>
    /// Utility class for helping to debug deadlocks caused by lock synchronization.
    /// </summary>
    /// <remarks>
    /// When run in debug mode it will print logging information before entering and after leaving each lock-block.
    /// To use, replace all occurrances of <c>lock(xyz)</c> with <c>using(new LoggingLock(xyz))</c>.
    /// </remarks>
    public class Lock : IDisposable
    {
        private object syncObject;

        public Lock(object syncObject)
        {
            this.syncObject = syncObject;
            Monitor.Enter(syncObject);
        }

        public void Dispose()
        {
            Monitor.Exit(syncObject);
        }
    }
}
