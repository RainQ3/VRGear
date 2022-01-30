using System;

namespace VRGear.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    internal sealed class LoadOrder : Attribute
    {
        public LoadOrder(int order)
        {
            Order = order;
        }

        public int Order { get; }
    }
}