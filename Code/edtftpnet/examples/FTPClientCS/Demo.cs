// 
// Copyright (C) 2000-2004 Enterprise Distributed Technologies Ltd
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
// $Log: Demo.cs,v $
// Revision 1.1  2005/09/30 17:20:27  bruceb
// from demo
//
// Revision 1.4  2005/02/25 18:34:54  bruceb
// cleaned exception logging
//
// Revision 1.3  2004/11/06 22:45:11  bruceb
// remove msg collector
//
// Revision 1.2  2004/10/29 14:29:10  bruceb
// tidied
//
// Revision 1.1  2004/10/23 16:13:10  bruceb
// first cut
//
// Revision 1.2  2004/10/20 20:51:55  bruceb
// first release
// 
using System;
using EnterpriseDT.Util.Debug;
using EnterpriseDT.Net.Ftp;

/// <summary>
/// Simple test class for FTPClient
/// </summary>
/// <author>              
/// Bruce Blackshaw
/// </author>
/// <author>              
/// Hans Andersen
/// </author>
/// <version>         
/// $Revision: 1.1 $
/// </version>
public class Demo {
    
    /// <summary>   
	/// Test harness
	/// </summary>
	public static void Main(string[] args)
	{              
        // we want remote host, user name and password
        if (args.Length < 3) {
            Usage();
            System.Environment.Exit(1);
        }
            
        Logger log = Logger.GetLogger(typeof(Demo));

        // assign args to make it clear
        string host = args[0];
        string user = args[1];
        string password = args[2];
        
        Logger.CurrentLevel = Level.ALL;

        FTPClient ftp = null;

        try {
            // set up client
            log.Info("Connecting");

            ftp = new FTPClient(host);

             // login
            log.Info("Logging in");
            ftp.Login(user, password);

            // set up passive ASCII transfers
            log.Debug("Setting up passive, ASCII transfers");
            ftp.ConnectMode = FTPConnectMode.PASV;
            ftp.TransferType = FTPTransferType.ASCII;

            // get directory and print it to console            
            log.Debug("Directory before put:");
            string[] files = ftp.Dir(".", true);
            for (int i = 0; i < files.Length; i++)
                log.Debug(files[i]);

            // copy file to server 
            log.Info("Putting file");
            ftp.Put("readme.txt", "readme.txt");

            // get directory and print it to console            
            log.Debug("Directory after put");
            files = ftp.Dir(".", true);
            for (int i = 0; i < files.Length; i++)
                log.Debug(files[i]);

            // copy file from server
            log.Info("Getting file");
            ftp.Get("readme.txt.copy", "readme.txt");

            // delete file from server
            log.Info("Deleting file");
            ftp.Delete("readme.txt");

            // get directory and print it to console            
            log.Debug("Directory after delete");
            files = ftp.Dir("", true);
            for (int i = 0; i < files.Length; i++)
                log.Debug(files[i]);

            // Shut down client                
            log.Info("Quitting client");
            ftp.Quit();
            
            log.Info("Test complete");
        } catch (Exception e) {
            log.Debug(e.Message, e);
        }
    }   
    
    /// <summary>  
	/// Basic usage statement
	/// </summary>
    public static void Usage() {
        System.Console.Out.WriteLine("Usage: Demo remotehost user password");
    }
}
