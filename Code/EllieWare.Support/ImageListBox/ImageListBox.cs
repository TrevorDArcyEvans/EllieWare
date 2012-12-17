/// <copyright>
/// Copyright (C) 2002 by Alexander Yakovlev. All Rights Reserved.
/// </copyright>

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Runtime.Serialization;
using System.Reflection;

namespace Controls.Development
{
    /// <summary>
    /// List box with images that supports design-time editing
    /// </summary>
    [DefaultProperty("Items")]
    [DefaultEvent("SelectedIndexChanged")]
    public class ImageListBox : ListBox
    {
        #region ImageListBoxItemCollection class...

        /// <summary>
        /// The list box's items collection class
        /// </summary>
        public class ImageListBoxItemCollection : IList, ICollection, IEnumerable
        {
            ImageListBox owner = null;

            public ImageListBoxItemCollection(ImageListBox owner)
            {
                this.owner = owner;
            }

            #region ICollection implemented members...

            void ICollection.CopyTo(Array array, int index) 
            {
                for (IEnumerator e = this.GetEnumerator(); e.MoveNext();)
                    array.SetValue(e.Current, index++);
            }

            bool ICollection.IsSynchronized 
            {
                get { return false; }
            }

            object ICollection.SyncRoot 
            {
                get { return this; }
            }

            #endregion

            #region IList implemented members...

            object IList.this[int index] 
            {
                get { return this[index]; }
                set { this[index] = (ImageListBoxItem)value; }
            }

            bool IList.Contains(object item)
            {
                throw new NotSupportedException();
            }

            int IList.Add(object item)
            {
                return this.Add((ImageListBoxItem)item);
            }

            bool IList.IsFixedSize 
            {
                get { return false; }
            }

            int IList.IndexOf(object item)
            {
                throw new NotSupportedException();
            }

            void IList.Insert(int index, object item)
            {
                this.Insert(index, (ImageListBoxItem)item);
            }

            void IList.Remove(object item)
            {
                throw new NotSupportedException();
            }

            void IList.RemoveAt(int index)
            {
                this.RemoveAt(index);
            }

            #endregion

            [Browsable(false)]
            public int Count 
            {
                get { return owner.DoGetItemCount(); }
            }

            public bool IsReadOnly 
            {
                get { return false; }
            }

            public ImageListBoxItem this[int index]
            {
                get { return owner.DoGetElement(index); }
                set { owner.DoSetElement(index, value); }
            }

            public IEnumerator GetEnumerator() 
            {
                return owner.DoGetEnumerator(); 
            }

            public bool Contains(object item)
            {
                throw new NotSupportedException();
            }

            public int IndexOf(object item)
            {
                throw new NotSupportedException();
            }

            public void Remove(ImageListBoxItem item)
            {
                throw new NotSupportedException();
            }

            public void Insert(int index, ImageListBoxItem item)
            {
                owner.DoInsertItem(index, item);
            }

            public int Add(ImageListBoxItem item)
            {
                return owner.DoInsertItem(this.Count, item);
            }

            public void AddRange(ImageListBoxItem[] items)
            {
                for(IEnumerator e = items.GetEnumerator(); e.MoveNext();)
                    owner.DoInsertItem(this.Count, (ImageListBoxItem)e.Current);
            }

            public void Clear()
            {
                owner.DoClear();
            }

            public void RemoveAt(int index)
            {
                owner.DoRemoveItem(index);
            }
        }

        #endregion

        #region Methods to access base class items...

        private void DoSetElement(int index, ImageListBoxItem value)
        {
            base.Items[index] = value;
        }

        private ImageListBoxItem DoGetElement(int index)
        {
            return (ImageListBoxItem)base.Items[index];
        }

        private IEnumerator DoGetEnumerator()
        {
            return base.Items.GetEnumerator();
        }

        private int DoGetItemCount()
        {
            return base.Items.Count;
        }

        private int DoInsertItem(int index, ImageListBoxItem item)
        {
            item.imageList = this.imageList;
            item.itemIndex = index;
            base.Items.Insert(index, item);
            return index;
        }

        private void DoRemoveItem(int index)
        {
            base.Items.RemoveAt(index);
        }

        private void DoClear()
        {
            base.Items.Clear();
        }

        #endregion

        private ImageList imageList = null;
        ImageListBox.ImageListBoxItemCollection listItems = null;

        public ImageListBox()
        {
            // Set owner draw mode
            base.DrawMode = DrawMode.OwnerDrawFixed;
            this.listItems = new ImageListBox.ImageListBoxItemCollection(this);
        }

        /// <summary>
        /// Hides the parent DrawMode property from property browser
        /// </summary>
        [Browsable(false)]
        override public DrawMode DrawMode
        {
            get { return base.DrawMode; }
            set { }
        }

        /// <summary>
        /// The ImageList control from which this listbox takes the images
        /// </summary>
        [Category("Behavior")]  
        [Description("The ImageList control from which this list box takes the images")]
        [DefaultValue(null)]
        public ImageList ImageList
        {
            get { return this.imageList; }
            set { 
                this.imageList = value; 
                // Update the imageList field for the items
                for(int i = 0; i < this.listItems.Count; i++) 
                {
                    this.listItems[i].imageList = this.imageList;
                }
                // Invalidate the control
                this.Invalidate();
            }
        }

        /// <summary>
        /// The items in the list box
        /// </summary>
        [Category("Behavior")]  
        [Description("The items in the list box")]
        [Localizable(true)]
        [MergableProperty(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        new public ImageListBox.ImageListBoxItemCollection Items
        {
            get { return this.listItems; }
        }

        /// <summary>
        /// Overrides parent OnDrawItem method to perform custom painting
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnDrawItem(System.Windows.Forms.DrawItemEventArgs pe)
        {
            pe.DrawBackground();
            pe.DrawFocusRectangle();
            Rectangle bounds = pe.Bounds;
            // Check whether the index is valid
            if(pe.Index >= 0 && pe.Index < base.Items.Count) 
            {
                ImageListBoxItem item = (ImageListBoxItem)base.Items[pe.Index];
                int iOffset = 0;
                // If the image list is present and the image index is set, draw the image
                if(this.imageList != null)
                {
                    if (item.ImageIndex != -1 && item.ImageIndex < this.imageList.Images.Count) 
                    {
                        this.imageList.Draw(pe.Graphics, bounds.Left, bounds.Top, item.ImageIndex); 
                    }
                    iOffset += this.imageList.ImageSize.Width;
                }
                // Draw item text
                pe.Graphics.DrawString(item.Text, pe.Font, new SolidBrush(pe.ForeColor), 
                    bounds.Left + iOffset, bounds.Top);
            }
            base.OnDrawItem(pe);
        }
    }
}
