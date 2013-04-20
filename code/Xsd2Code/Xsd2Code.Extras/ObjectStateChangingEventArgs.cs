using System;
using System.Collections.Generic;
using System.Text;

namespace Xsd2Code.Extras
{
    public class ObjectStateChangingEventArgs : EventArgs
    {
        public ObjectState NewState { get; set; }
    }
}
