// 
// Copyright (C) 2006 Enterprise Distributed Technologies Ltd
// 
// www.enterprisedt.com
//

#region Change Log

// Change Log:
// 
// $Log$
// Revision 1.9  2011-03-07 06:34:15  hans
// Added methods taking an alternative path-separator.  Added EnsureTrailingSeparator method.
//
// Revision 1.8  2010-09-29 01:51:56  hans
// Fixed GetFileNameWithoutExtension.
//
// Revision 1.7  2010-09-27 04:13:34  hans
// Added GetExtension and GetFileNameWithoutExtension.
//
// Revision 1.6  2010-08-12 22:59:57  hans
// Made public.  Added comments.  Added IsRelative and GetAbsolutePath.
//
// Revision 1.5  2009-12-18 00:25:37  bruceb
// NETCF tweaks
//
// Revision 1.4  2009-10-01 01:32:00  hans
// Combine failed if pathRight was null.
//
// Revision 1.3  2009-09-30 03:34:13  hans
// Fixed numerous bugs.
//
// Revision 1.2  2009-09-25 05:56:25  bruceb
// remove Contains
//
// Revision 1.1  2009-09-25 05:21:27  hans
// Utility for dealing with FTP (i.e. UNIX) paths.
//
//
//

#endregion

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;

using EnterpriseDT.Util.Debug;

namespace EnterpriseDT.Util
{
    /// <summary>
    /// Provides methods for dealing with FTP paths.
    /// </summary>
    public class PathUtil
    {
        #region Fields

        //private static Logger log = Logger.GetLogger("PathUtil");
        private const char DEFAULT_SEPARATOR_CHAR = '/';
        private const string SAMEDIR_STRING = ".";
        private const string UPDIR_STRING = "..";

        #endregion

        #region Properties

        /// <summary>
        /// Separator character (i.e. '/').
        /// </summary>
        public static char DefaultSeparatorChar
        {
            get { return DEFAULT_SEPARATOR_CHAR; }
        }

        /// <summary>
        /// Separator character as a string (i.e. "/").
        /// </summary>
        public static string DefaultSeparator
        {
            get { return DEFAULT_SEPARATOR_CHAR.ToString(); }
        }

        #endregion

        #region Methods with no separator passed in

        /// <summary>
        /// Cleans up a path such that, for example, "/A/B/../C" becomes "/A/C".
        /// </summary>
        /// <param name="path">Path to clean up.</param>
        /// <returns>Cleaned up path.</returns>
        public static string Fix(string path)
        {
            return Implode(Fix(Explode(path)));
        }

        /// <summary>
        /// Cleans up a path such that, for example, "/A/B/../C" becomes "/A/C".
        /// </summary>
        /// <param name="path">Path to clean up as an array of strings where each string is a single directory.</param>
        /// <returns>Cleaned up path.</returns>
        public static string[] Fix(string[] path)
        {
            if (path.Length == 0)
                return path;
            ArrayList fixedPath = new ArrayList();
            for (int i = 0; i < path.Length; i++)
            {
                string p = path[i];
                if (p == DefaultSeparator)
                {
                    // add separator unless it's a duplicate (i.e. follows another sep - "//")
                    if (i == 0 || (fixedPath.Count>0 && ((string)fixedPath[fixedPath.Count - 1] != DefaultSeparator)))
                        fixedPath.Add(p);
                }
                else if (p == UPDIR_STRING)
                {
                    if (fixedPath.Count == 1)
                        throw new ArgumentException("Cannot change up a directory from the root");

                    // only remove parent directory if there is one and it's not another ".."
                    if (fixedPath.Count >= 2 && ((string)fixedPath[fixedPath.Count - 2] != UPDIR_STRING))
                    {
                        fixedPath.RemoveAt(fixedPath.Count - 1);  // remove separator
                        fixedPath.RemoveAt(fixedPath.Count - 1);  // remove parent
                    }
                    else
                        fixedPath.Add(p);   // add the ".." 
                }
                else if (p != "" && p != SAMEDIR_STRING)  // ignore empty strings and "."
                    fixedPath.Add(p);
            }

            // remove trailing slashes
            while (fixedPath.Count > 1 && ((string)fixedPath[fixedPath.Count - 1] == DefaultSeparator))
                fixedPath.RemoveAt(fixedPath.Count - 1);

            // if there's nothing then just return "."
            if (fixedPath.Count == 0)
                fixedPath.Add(SAMEDIR_STRING);

            return (string[])fixedPath.ToArray(typeof(string));
        }

        /// <summary>
        /// Indicates whether or not a path is absolute (i.e. starts with '/').
        /// </summary>
        /// <param name="path">Path to check</param>
        /// <returns><c>true</c> if path is absolute</returns>
        public static bool IsAbsolute(string path)
        {
            return path != null && path.StartsWith("/");
        }

        /// <summary>
        /// Indicates whether or not a path is relative (i.e. does not start with '/').
        /// </summary>
        /// <param name="path">Path to check</param>
        /// <returns><c>true</c> if path is relative.</returns>
        public static bool IsRelative(string path)
        {
            return !IsAbsolute(path);
        }

        /// <summary>
        /// Return the fixed absolute path for the given directory based on the given base directory.
        /// </summary>
        /// <param name="baseDirectory"></param>
        /// <param name="directory"></param>
        /// <returns></returns>
        public static string GetAbsolutePath(string baseDirectory, string directory)
        {
            if (IsAbsolute(directory))
                return Fix(directory);
            else
                return Fix(Combine(baseDirectory, directory));
        }

        /// <summary>
        /// Gets the file-name without its path.
        /// </summary>
        /// <param name="path">Absolute or relative path</param>
        /// <returns>File-name</returns>
        public static string GetFileName(string path)
        {
            if (path.IndexOf(DEFAULT_SEPARATOR_CHAR.ToString()) >= 0)
                return path.Substring(path.LastIndexOf(DEFAULT_SEPARATOR_CHAR) + 1);
            else
                return path;
        }

        /// <summary>
        /// Returns the filename of the specified path without the extension.
        /// </summary>
        /// <param name="path">Absolute or relative path</param>
        /// <returns>Filename of the specified path without the extension.</returns>
        public static string GetFileNameWithoutExtension(string path)
        {
            string fileName = GetFileName(path);
            string extension = GetExtension(fileName);
            return fileName.Substring(0, fileName.Length - extension.Length);
        }

        /// <summary>
        /// Gets the extension of the filename.
        /// </summary>
        /// <param name="path">Absolute or relative path</param>
        /// <returns>Extension</returns>
        public static string GetExtension(string path)
        {
            string fileName = GetFileName(path);
            int dotPos = fileName.LastIndexOf('.');
            if (dotPos < 0)
                return "";
            return fileName.Substring(dotPos);
        }


        /// <summary>
        /// Gets the folder-path without the file-name
        /// </summary>
        /// <param name="path">Absolute or relative path</param>
        /// <returns>Folder path</returns>
        public static string GetFolderPath(string path)
        {
            return GetFolderPath(DEFAULT_SEPARATOR_CHAR, path);
        }

        /// <summary>
        /// Combines two paths.
        /// </summary>
        /// <param name="pathLeft">Left part of path.</param>
        /// <param name="pathRight">Right part of path.</param>
        /// <returns>Combined path.</returns>
        public static string Combine(string pathLeft, string pathRight)
        {
            if (pathLeft == null)
                pathLeft = "/";
            if (pathRight == null || pathRight == "" || pathRight == ".")
                return pathLeft;
            if (pathRight.StartsWith(DefaultSeparator))
                throw new ArgumentException("Second argument cannot be absolute", "pathRight");
            if (pathLeft.EndsWith(DefaultSeparator))
                pathLeft = pathLeft.Substring(0, pathLeft.Length - 1);
            return Fix(pathLeft + DefaultSeparator + pathRight);
        }

        /// <summary>
        /// Combines an arbitrary number of paths.
        /// </summary>
        /// <param name="path1">Left part of path.</param>
        /// <param name="path2">Second-from-left part of path.</param>
        /// <param name="pathN">Rest of path.</param>
        /// <returns>Combined path.</returns>
        public static string Combine(string path1, string path2, params string[] pathN)
        {
            string path = Combine(path1, path2);
            foreach (string p in pathN)
                path = Combine(path, p);
            return path;
        }

        /// <summary>
        /// Splits the path into parts.
        /// </summary>
        /// <param name="path">Full path</param>
        /// <returns>Parts of the path.</returns>
        public static string[] Explode(string path)
        {
            ArrayList elements = new ArrayList();
            int pos1 = 0;
            while (true)
            {
                int pos2 = path.IndexOf(DefaultSeparatorChar, pos1);
                if (pos2 < 0)
                    break;
                if (pos1 == pos2)
                {
                    elements.Add(DefaultSeparator);
                    pos1 = pos2 + 1;
                }
                else
                {
                    elements.Add(path.Substring(pos1, pos2 - pos1));
                    pos1 = pos2;
                }
            }
            if (pos1<path.Length)
                elements.Add(path.Substring(pos1));
            return (string[])elements.ToArray(typeof(string));
        }

        /// <summary>
        /// Combines parts into a single path.
        /// </summary>
        /// <param name="parts">Parts</param>
        /// <param name="start">Start at part</param>
        /// <param name="length">Number of parts to combine</param>
        /// <returns>Single path</returns>
        public static string Implode(string[] parts, int start, int length)
        {
            StringBuilder path = new StringBuilder();
            int i = 0;
            foreach (string p in parts)
            {
                if (i >= start && (length < 0 || i < start + length))
                    path.Append(p);
                i++;
            }
            return path.ToString();
        }

        /// <summary>
        /// Combines parts into a single path.
        /// </summary>
        /// <param name="parts">Parts</param>
        /// <param name="start">Start at part</param>
        /// <returns>Single path</returns>
        public static string Implode(string[] parts, int start)
        {
            return Implode(parts, start, -1);
        }

        /// <summary>
        /// Combines parts into a single path.
        /// </summary>
        /// <param name="parts">Parts</param>
        /// <returns>Single path</returns>
        public static string Implode(string[] parts)
        {
            return Implode(parts, 0, -1);
        }

        /// <summary>
        /// Ensures that the last character is a separator character
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string EnsureTrailingSeparator(string path)
        {
            return EnsureTrailingSeparator(DefaultSeparatorChar, path);
        }

        #endregion

        #region Methods with separator passed in

        /// <summary>
        /// Cleans up a path such that, for example, "/A/B/../C" becomes "/A/C".
        /// </summary>
        /// <param name="path">Path to clean up.</param>
        /// <returns>Cleaned up path.</returns>
        public static string Fix(char separator, string path)
        {
            return Implode(Fix(separator, Explode(separator, path)));
        }

        /// <summary>
        /// Cleans up a path such that, for example, "/A/B/../C" becomes "/A/C".
        /// </summary>
        /// <param name="path">Path to clean up as an array of strings where each string is a single directory.</param>
        /// <returns>Cleaned up path.</returns>
        public static string[] Fix(char separator, string[] path)
        {
            if (path.Length == 0)
                return path;
            ArrayList fixedPath = new ArrayList();
            for (int i = 0; i < path.Length; i++)
            {
                string p = path[i];
                if (p == separator.ToString())
                {
                    // add separator unless it's a duplicate (i.e. follows another sep - "//")
                    if (i == 0 || (fixedPath.Count > 0 && ((string)fixedPath[fixedPath.Count - 1] != separator.ToString())))
                        fixedPath.Add(p);
                }
                else if (p == UPDIR_STRING)
                {
                    if (fixedPath.Count == 1)
                        throw new ArgumentException("Cannot change up a directory from the root");

                    // only remove parent directory if there is one and it's not another ".."
                    if (fixedPath.Count >= 2 && ((string)fixedPath[fixedPath.Count - 2] != UPDIR_STRING))
                    {
                        fixedPath.RemoveAt(fixedPath.Count - 1);  // remove separator
                        fixedPath.RemoveAt(fixedPath.Count - 1);  // remove parent
                    }
                    else
                        fixedPath.Add(p);   // add the ".." 
                }
                else if (p != "" && p != SAMEDIR_STRING)  // ignore empty strings and "."
                    fixedPath.Add(p);
            }

            // remove trailing slashes
            while (fixedPath.Count > 1 && ((string)fixedPath[fixedPath.Count - 1] == separator.ToString()))
                fixedPath.RemoveAt(fixedPath.Count - 1);

            // if there's nothing then just return "."
            if (fixedPath.Count == 0)
                fixedPath.Add(SAMEDIR_STRING);

            return (string[])fixedPath.ToArray(typeof(string));
        }

        /// <summary>
        /// Indicates whether or not a path is absolute (i.e. starts with '/').
        /// </summary>
        /// <param name="path">Path to check</param>
        /// <returns><c>true</c> if path is absolute</returns>
        public static bool IsAbsolute(char separator, string path)
        {
            return path != null && path.StartsWith(separator.ToString());
        }

        /// <summary>
        /// Indicates whether or not a path is relative (i.e. does not start with '/').
        /// </summary>
        /// <param name="path">Path to check</param>
        /// <returns><c>true</c> if path is relative.</returns>
        public static bool IsRelative(char separator, string path)
        {
            return !IsAbsolute(separator, path);
        }

        /// <summary>
        /// Return the fixed absolute path for the given directory based on the given base directory.
        /// </summary>
        /// <param name="baseDirectory"></param>
        /// <param name="directory"></param>
        /// <returns></returns>
        public static string GetAbsolutePath(char separator, string baseDirectory, string directory)
        {
            if (IsAbsolute(separator, directory))
                return Fix(separator, directory);
            else
                return Fix(separator, Combine(separator, baseDirectory, directory));
        }

        /// <summary>
        /// Gets the file-name without its path.
        /// </summary>
        /// <param name="path">Absolute or relative path</param>
        /// <returns>File-name</returns>
        public static string GetFileName(char separator, string path)
        {
            if (path.IndexOf(separator.ToString()) >= 0)
                return path.Substring(path.LastIndexOf(separator) + 1);
            else
                return path;
        }

        /// <summary>
        /// Returns the filename of the specified path without the extension.
        /// </summary>
        /// <param name="path">Absolute or relative path</param>
        /// <returns>Filename of the specified path without the extension.</returns>
        public static string GetFileNameWithoutExtension(char separator, string path)
        {
            string fileName = GetFileName(separator, path);
            string extension = GetExtension(separator, fileName);
            return fileName.Substring(0, fileName.Length - extension.Length);
        }

        /// <summary>
        /// Gets the extension of the filename.
        /// </summary>
        /// <param name="path">Absolute or relative path</param>
        /// <returns>Extension</returns>
        public static string GetExtension(char separator, string path)
        {
            string fileName = GetFileName(separator, path);
            int dotPos = fileName.LastIndexOf('.');
            if (dotPos < 0)
                return "";
            return fileName.Substring(dotPos);
        }


        /// <summary>
        /// Gets the folder-path without the file-name
        /// </summary>
        /// <param name="path">Absolute or relative path</param>
        /// <returns>Folder path</returns>
        public static string GetFolderPath(char separator, string path)
        {
            if (path.EndsWith(separator.ToString()) && path.Length>1)
                path = path.Substring(0, path.Length - 1);
            if (path.IndexOf(separator.ToString()) >= 0)
                return path.Substring(0, path.LastIndexOf(separator));
            else
                return path;
        }

        /// <summary>
        /// Combines two paths.
        /// </summary>
        /// <param name="pathLeft">Left part of path.</param>
        /// <param name="pathRight">Right part of path.</param>
        /// <returns>Combined path.</returns>
        public static string Combine(char separator, string pathLeft, string pathRight)
        {
            if (pathLeft == null)
                pathLeft = "/";
            if (pathRight == null || pathRight == "" || pathRight == ".")
                return pathLeft;
            if (pathRight.StartsWith(separator.ToString()))
                throw new ArgumentException("Second argument cannot be absolute", "pathRight");
            if (pathLeft.EndsWith(separator.ToString()))
                pathLeft = pathLeft.Substring(0, pathLeft.Length - 1);
            return Fix(separator, pathLeft + separator + pathRight);
        }

        /// <summary>
        /// Combines an arbitrary number of paths.
        /// </summary>
        /// <param name="path1">Left part of path.</param>
        /// <param name="path2">Second-from-left part of path.</param>
        /// <param name="pathN">Rest of path.</param>
        /// <returns>Combined path.</returns>
        public static string Combine(char separator, string path1, string path2, params string[] pathN)
        {
            string path = Combine(separator, path1, path2);
            foreach (string p in pathN)
                path = Combine(separator, path, p);
            return path;
        }

        /// <summary>
        /// Splits the path into parts.
        /// </summary>
        /// <param name="path">Full path</param>
        /// <returns>Parts of the path.</returns>
        public static string[] Explode(char separator, string path)
        {
            ArrayList elements = new ArrayList();
            int pos1 = 0;
            while (true)
            {
                int pos2 = path.IndexOf(separator, pos1);
                if (pos2 < 0)
                    break;
                if (pos1 == pos2)
                {
                    elements.Add(separator.ToString());
                    pos1 = pos2 + 1;
                }
                else
                {
                    elements.Add(path.Substring(pos1, pos2 - pos1));
                    pos1 = pos2;
                }
            }
            if (pos1 < path.Length)
                elements.Add(path.Substring(pos1));
            return (string[])elements.ToArray(typeof(string));
        }

        /// <summary>
        /// Ensures that the last character is a separator character.
        /// </summary>
        /// <param name="separatorChar"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string EnsureTrailingSeparator(char separatorChar, string path)
        {
            return path.EndsWith(separatorChar.ToString()) ? path : path + separatorChar;
        }

        #endregion
    }
}
