//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Windows.Forms;

namespace SampleAddin
{
  public partial class SampleAddinCtrl : UserControl
  {
    // external event to let people know that the control has changed
    public event EventHandler ConfigurationChanged;

    public SampleAddinCtrl()
    {
      InitializeComponent();
    }

    // helper method to return text in textbox
    public string GetText()
    {
      return mText.Text;
    }

    // helper method to set text in textbox
    public void SetText(string value)
    {
      mText.Text = value;
    }

    // called when text in textbox changes
    private void Text_TextChanged(object sender, EventArgs e)
    {
      // notify any external listeners that control has changed
      var handler = ConfigurationChanged;
      if (handler != null)
      {
        handler(this, new EventArgs());
      }
    }
  }
}
