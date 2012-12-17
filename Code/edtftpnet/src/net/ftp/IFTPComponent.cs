// edtFTPnet
// 
// Copyright (C) 2006 Enterprise Distributed Technologies Ltd
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
// $Log$
// Revision 1.2  2006/10/04 08:06:28  hans
// Fixed failure where a Container contains components that are not subclasses of Component.
//
// Revision 1.1  2006/07/31 07:59:34  hans
// Interface implemented by all FTP components.
//

using System;
using System.ComponentModel;

namespace EnterpriseDT.Net.Ftp
{
    /// <summary>
    /// Interface implemented by all FTP components.
    /// </summary>
	public interface IFTPComponent
	{
        /// <summary>
        /// Called by the given FTP component when it is added to a container.
        /// </summary>
        /// <remarks>
        /// This method allows FTP components to interlink themselves automatically.
        /// </remarks>
        /// <param name="component">FTP component just added to the container.</param>
		void LinkComponent(IFTPComponent component);
	}

    /// <summary>
    /// Utility class which assists FTP components to interlink.
    /// </summary>
    internal class FTPComponentLinker
    {
        /// <summary>
        /// Calls <see cref="IFTPComponent.LinkComponent"/> on all other 
        /// FTP components in the container of the given site.
        /// </summary>
        /// <param name="site">Site in the container whose FTP components are to be linked.</param>
        /// <param name="component">New components added to the containiner.</param>
        public static void Link(ISite site, IFTPComponent component)
        {
            if (site==null || !site.DesignMode || site.Container == null)
                return;
            foreach (object c in site.Container.Components)
                if (c!=component && c is IFTPComponent)
                    ((IFTPComponent)c).LinkComponent(component);
        }

		/// <summary>
		/// Searches the given site's container for a component of the given type.
		/// </summary>
		/// <param name="site">Site whose container is to be searched.</param>
		/// <param name="componentType">Type to search for.</param>
		/// <returns>Returns the first component found.</returns>
		public static Component Find(ISite site, Type componentType)
		{
			if (site==null || site.Container == null)
				return null;
            foreach (object c in site.Container.Components)
				if (componentType.IsInstanceOfType(c))
					return (Component)c;
			return null;
		}
    }
}
