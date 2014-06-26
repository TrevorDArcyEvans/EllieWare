//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using EllieWare.Interfaces;
using EllieWare.Support;

namespace EllieWare.Common
{
  public partial class Adder : Form
  {
    private readonly IList<Factory> mFactories;

    public Adder()
    {
      InitializeComponent();
    }

    public Adder(IEnumerable<Factory> factories) :
      this()
    {
      mFactories = factories.Where(x => x.IsLicensed).ToList();

      lbSteps.Items.Clear();

      var categories = new List<string> { "(All)" };
      lbSteps.DataSource = mFactories;

      foreach (var thisFactory in mFactories)
      {
        foreach (var thisCat in thisFactory.Categories)
        {
          if (!categories.Contains(thisCat))
          {
            categories.Add(thisCat);
          }
        }
      }
      ddlCategories.DataSource = categories.ToList();
    }

    private void Steps_SelectedIndexChanged(object sender, EventArgs e)
    {
      txtDescription.Text = ((Factory)lbSteps.SelectedItem).Description;
    }

    private void Categories_SelectedIndexChanged(object sender, EventArgs e)
    {
      var searchTxt = SearchBox.Text.ToLower(CultureInfo.CurrentCulture);
      if (ddlCategories.SelectedIndex == 0 && string.IsNullOrEmpty(searchTxt))
      {
        lbSteps.DataSource = mFactories;

        return;
      }

      IEnumerable<Factory> factsByCat;
      if (ddlCategories.SelectedIndex == 0)
      {
        factsByCat = mFactories.ToList();
      }
      else
      {
        var selCat = (string)ddlCategories.SelectedItem;
        factsByCat = from thisFact in mFactories where thisFact.Categories.Contains(selCat) select thisFact;
      }

      IEnumerable<Factory> factsBySearch;
      if (string.IsNullOrEmpty(searchTxt))
      {
        factsBySearch = factsByCat.ToList();
      }
      else
      {
        factsBySearch = from thisFact in factsByCat
                        where
                          (thisFact.Keywords.ToLower(CultureInfo.CurrentCulture).Contains(searchTxt) ||
                          thisFact.Title.ToLower(CultureInfo.CurrentCulture).Contains(searchTxt))
                        select thisFact;
      }

      lbSteps.DataSource = factsBySearch.ToList();
    }

    private void SearchBox_TextChanged(object sender, EventArgs e)
    {
      Categories_SelectedIndexChanged(sender, e);
    }

    public Factory SelectedFactory
    {
      get
      {
        return (Factory)lbSteps.SelectedItem;
      }
    }

    private void Steps_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      DialogResult = DialogResult.OK;
      Close();
    }

    private void Adder_Shown(object sender, EventArgs e)
    {
      SearchBox.Focus();
    }

    private void Adder_Load(object sender, EventArgs e)
    {
      WindowPersister.Restore(Assembly.GetExecutingAssembly(), this);
    }

    private void Adder_FormClosed(object sender, FormClosedEventArgs e)
    {
      WindowPersister.Record(Assembly.GetExecutingAssembly(), this);
    }
  }
}
