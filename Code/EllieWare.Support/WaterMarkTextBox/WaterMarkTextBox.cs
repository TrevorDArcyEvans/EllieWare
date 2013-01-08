// stolen from:
//    http://www.codeproject.com/Articles/27849/WaterMark-TextBox-For-Desktop-Applications-Using-C

using System;
using System.Drawing;
using System.Windows.Forms;

namespace wmgCMS
{
  public class WaterMarkTextBox : TextBox
  {
    private Font oldFont = null;
    private Boolean waterMarkTextEnabled = false;

    #region Attributes

    private Color _waterMarkColor = Color.Gray;
    public Color WaterMarkColor
    {
      get
      {
        return _waterMarkColor;
      }
      set
      {
        _waterMarkColor = value; 
        Invalidate();/*thanks to Bernhard Elbl for Invalidate()*/
      }
    }

    private string _waterMarkText = "Water Mark";
    public string WaterMarkText
    {
      get
      {
        return _waterMarkText;
      }
      set
      {
        _waterMarkText = value; 
        Invalidate();
      }
    }

    #endregion

    //Default constructor
    public WaterMarkTextBox()
    {
      JoinEvents(true);
    }

    //Override OnCreateControl ... thanks to  "lpgray .. codeproject guy"
    protected override void OnCreateControl()
    {
      base.OnCreateControl();

      WaterMark_Toggle(null, null);
    }

    //Override OnPaint
    protected override void OnPaint(PaintEventArgs args)
    {
      // Use the same font that was defined in base class
      Font drawFont = new Font(Font.FontFamily, Font.Size, Font.Style, Font.Unit);

      //Create new brush with gray color or 
      SolidBrush drawBrush = new SolidBrush(WaterMarkColor);//use Water mark color

      //Draw Text or WaterMark
      args.Graphics.DrawString((waterMarkTextEnabled ? WaterMarkText : Text), drawFont, drawBrush, new PointF(0.0F, 0.0F));

      base.OnPaint(args);
    }

    private void JoinEvents(Boolean join)
    {
      if (join)
      {
        TextChanged += WaterMark_Toggle;
        LostFocus += WaterMark_Toggle;
        FontChanged += WaterMark_FontChanged;

        //No one of the above events will start immediately 
        //TextBox control still in constructing, so,
        //Font object (for example) couldn't be catched from within WaterMark_Toggle
        //So, call WaterMark_Toggle through OnCreateControl after TextBox is totally created
        //No doupt, it will be only one time call

        //Old solution uses Timer.Tick event to check Create property
      }
    }

    private void WaterMark_Toggle(object sender, EventArgs args)
    {
      if (Text.Length <= 0)
      {
        EnableWaterMark();
      }
      else
      {
        DisableWaterMark();
      }
    }

    private void EnableWaterMark()
    {
      //Save current font until returning the UserPaint style to false (NOTE: It is a try and error advice)
      oldFont = new Font(Font.FontFamily, Font.Size, Font.Style, Font.Unit);

      //Enable OnPaint event handler
      SetStyle(ControlStyles.UserPaint, true);

      waterMarkTextEnabled = true;

      //Triger OnPaint immediatly
      Refresh();
    }

    private void DisableWaterMark()
    {
      //Disbale OnPaint event handler
      waterMarkTextEnabled = false;

      SetStyle(ControlStyles.UserPaint, false);

      //Return back oldFont if existed
      if (oldFont != null)
      {
        Font = new Font(oldFont.FontFamily, oldFont.Size, oldFont.Style, oldFont.Unit);
      }
    }

    private void WaterMark_FontChanged(object sender, EventArgs args)
    {
      if (waterMarkTextEnabled)
      {
        oldFont = new Font(Font.FontFamily, Font.Size, Font.Style, Font.Unit);
        Refresh();
      }
    }
  }
}
