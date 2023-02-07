using System;
using System.ComponentModel;
using Intersect.Attributes;
using Intersect.GameObjects;

namespace Intersect.Enums
{

    public enum CustomEditorType
    {
        [Description("Map Type")]
        [AmbientValue(typeof(Guid), "749e73c0-ba25-4f69-9f81-ec21d9942e52")]
        [Entity(typeof(MapTypeBase))]
        MapType = 0,

    }

}
