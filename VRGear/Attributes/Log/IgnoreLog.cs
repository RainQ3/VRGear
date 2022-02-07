using System;

namespace VRGear.Attributes.Log
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    internal sealed class IgnoreLogAttribute : Attribute
    {
        public IgnoreLogAttribute()
        {
        }
    }
}