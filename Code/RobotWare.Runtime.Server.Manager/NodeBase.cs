//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Windows.Forms;

namespace RobotWare.Runtime.Server.Manager
{
  public class NodeBase : TreeNode
  {
    public NodeBase(string name, int imgIdx) :
      base(name, imgIdx, imgIdx)
    {
      Name = Text = name;
    }

    public NodeBase(string name) :
      this(name, 100)
    {
    }
  }
}
