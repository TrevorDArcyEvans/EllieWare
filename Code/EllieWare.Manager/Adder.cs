using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using EllieWare.Interfaces;

namespace EllieWare.Manager
{
  public partial class Adder : Form
  {
    private readonly IEnumerable<IFactory> mFactories;

    public Adder()
    {
      InitializeComponent();
    }

    public Adder(IEnumerable<IFactory> factories) :
      this()
    {
      mFactories = factories;

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

    private void lbSteps_SelectedIndexChanged(object sender, EventArgs e)
    {
      txtDescription.Text = ((IFactory)lbSteps.SelectedItem).Description;
    }

    private void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
      var searchTxt = txtSearchBox.Text.ToLower(CultureInfo.CurrentCulture);
      if (ddlCategories.SelectedIndex == 0 && string.IsNullOrEmpty(searchTxt))
      {
        lbSteps.DataSource = mFactories;

        return;
      }

      IEnumerable<IFactory> factsByCat;
      if (ddlCategories.SelectedIndex == 0)
      {
        factsByCat = mFactories.ToList();
      }
      else
      {
        var selCat = (string)ddlCategories.SelectedItem;
        factsByCat = from thisFact in mFactories where thisFact.Categories.Contains(selCat) select thisFact;
      }

      IEnumerable<IFactory> factsBySearch;
      if (string.IsNullOrEmpty(searchTxt))
      {
        factsBySearch = factsByCat.ToList();
      }
      else
      {
        factsBySearch = from thisFact in factsByCat where thisFact.Keywords.ToLower(CultureInfo.CurrentCulture).Contains(searchTxt) select thisFact;
      }

      lbSteps.DataSource = factsBySearch.ToList();
    }

    private void txtSearchBox_TextChanged(object sender, EventArgs e)
    {
      ddlCategories_SelectedIndexChanged(sender, e);
    }

    public IFactory SelectedFactory
    {
      get
      {
        return (IFactory)lbSteps.SelectedItem;
      }
    }
  }
}
