using System;

namespace VRGear.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    internal sealed class DontLoadAttribute : Attribute
    {
        public DontLoadAttribute()
        {
        }
    }
}