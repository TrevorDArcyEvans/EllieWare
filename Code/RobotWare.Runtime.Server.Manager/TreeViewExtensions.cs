using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RobotWare.Runtime.Server.Manager
{
  /// <summary>
  /// Stolen from:
  ///   https://gist.github.com/grumly57/7665247
  /// </summary>
  internal static class TreeViewExtensions
  {
    internal static List<string> GetExpansionState(this TreeNodeCollection nodes)
    {
      return nodes.Descendants()
              .Where(n => n.IsExpanded)
              .Select(n => n.GetNamesFullPath())
              .ToList();
    }

    internal static void SetExpansionState(this TreeNodeCollection nodes, List<string> savedExpansionState)
    {
      foreach (var node in nodes.Descendants()
        .Where(n => savedExpansionState.Contains(n.GetNamesFullPath())))
      {
        node.Expand();
      }
    }

    /// <summary>
    /// Returns a node path composed by the node names
    /// </summary>
    /// <param name="node"></param>
    /// <param name="separator"></param>
    /// <returns></returns>
    internal static string GetNamesFullPath(this TreeNode node, string separator = null)
    {
      return string.Join(separator ?? node.TreeView.PathSeparator, node.Ancestors(n => n.Parent).Select(n => n.Name).Reverse().ToArray());
    }

    /// <summary>
    /// Find a node from its full path
    /// </summary>
    /// <param name="nodes"></param>
    /// <param name="path"></param>
    /// <param name="comparison"></param>
    /// <returns></returns>
    internal static TreeNode FindByNamesFullPath(this TreeNodeCollection nodes, string path, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
    {
      if (path == null)
      {
        return null;
      }

      return nodes.Descendants().FirstOrDefault(n => n.GetNamesFullPath().Equals(path, comparison));
    }

    internal static IEnumerable<TreeNode> Descendants(this TreeNodeCollection c)
    {
      foreach (var node in c.OfType<TreeNode>())
      {
        yield return node;

        foreach (var child in node.Nodes.Descendants())
        {
          yield return child;
        }
      }
    }

    public static IEnumerable<T> Ancestors<T>(this T o, Func<T, T> action)
    {
      while (o != null)
      {
        yield return o;
        o = action(o);
      }
    }
  }
}
