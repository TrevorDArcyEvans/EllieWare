﻿namespace Xsd2Code.Extras
{
    public class PropertyValueState
    {
        public string PropertyName { get; set; }
        public object OriginalValue { get; set; }
        public object CurrentValue { get; set; }
        public ObjectState State { get; set; }
    }
}
