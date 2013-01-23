//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public partial class AddSelectionToGroup : SpaceClaimMutableRunnableBase
  {
    public AddSelectionToGroup()
    {
      InitializeComponent();
    }

    public AddSelectionToGroup(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();

      // populate group combo if we have a doc
      if (Window.ActiveWindow != null)
      {
        var groupNames = Window.ActiveWindow.Groups.Select(g => g.Name);
        SelectedGroup.Items.AddRange(groupNames.ToArray());
      }
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Add the current selection(s) to {0}", SelectedGroup.SelectedItem);

        return descrip;
      }
    }

    public override void ReadXml(XmlReader reader)
    {
      SelectedGroup.SelectedItem = reader.GetAttribute("SelectedGroup");
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("SelectedGroup", (string)SelectedGroup.SelectedItem);
    }

    public override Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }

    public override bool CanRun
    {
      get
      {
        var retVal = Window.ActiveWindow.Groups.Count(g => g.Name == (string)SelectedGroup.SelectedItem) == 1;

        return retVal;
      }
    }

    protected override bool DoRun(Document doc)
    {
      var selGroup = Window.ActiveWindow.Groups.Single(g => g.Name == (string) SelectedGroup.SelectedItem);
      var currSel = Window.ActiveWindow.ActiveContext.Selection;
      foreach (var docObject in currSel)
      {
        selGroup.Members.Add(docObject);
      }

      return true;
    }

    private void SelectedGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}
