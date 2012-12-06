using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace Controls.Development
{
    /// <summary>
    /// ImageListBox item class
    /// </summary>
    [ToolboxItem(false)]
    [DesignTimeVisible(false)]
    [DefaultProperty("Text")]
    public class ImageListBoxItem : Component, ICloneable
    {
        private string text;
        private int imageIndex;
        public ImageList imageList = null;
        public int itemIndex = -1;

        /// <summary>
        /// Item index. Used by collection editor
        /// </summary>
        [Browsable(false)]
        public int Index
        {
            get { return this.itemIndex; }
        }

        /// <summary>
        /// The image list for this item. Used by UI editor
        /// </summary>
        [Browsable(false)]
        public System.Windows.Forms.ImageList ImageList
        {
            get { return this.imageList; }
        }

        /// <summary>
        /// The item's text
        /// </summary>
        [Localizable(true)]
        public string Text
        {
            get { return this.text; }
            set { this.text = value; }
        }
        
        /// <summary>
        /// The item's image index
        /// </summary>
        [DefaultValue(-1)]
        [Localizable(true)]
        [TypeConverter(typeof(System.Windows.Forms.ImageIndexConverter))]
        [Editor("System.Windows.Forms.Design.ImageIndexEditor", typeof(System.Drawing.Design.UITypeEditor))]
        public int ImageIndex
        {
            get { return this.imageIndex; }
            set { this.imageIndex = value; }
        }

        /// <summary>
        /// Item constructors
        /// </summary>
        public ImageListBoxItem(string Text, int ImageIndex)
        {
            this.text = Text;
            this.imageIndex = ImageIndex;
        }

        public ImageListBoxItem(string Text) : this(Text, -1)
        {
        }

        public ImageListBoxItem() : this("")
        {
        }

        #region ICloneable implemented members...

        public object Clone() 
        {
            return new ImageListBoxItem(this.text, this.imageIndex);
        }

        #endregion

        /// <summary>
        /// Converts the item to string representation. Needed for property editor
        /// </summary>
        /// <returns>String representation of the item</returns>
        public override string ToString()
        {
            return "Item: {" + this.text + "}";
        }
    }
}
