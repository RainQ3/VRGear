using System;

namespace VRGear.Attributes.Log
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    internal sealed class PriorityLogAttribute : Attribute
    {
        public PriorityLogAttribute()
        {
        }
    }
}