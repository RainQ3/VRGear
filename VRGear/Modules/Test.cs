using VRGear.Attributes;
using VRGear.Utils;

namespace VRGear.Modules
{
    [DontLoad]
    [LoadOrder(2)]
    public class Test : Module
    {
        public Test()
        {
            Logger.Instance.Log("Ctor");
        }

        public override void UiInit()
        {
            Logger.Instance.Log("UiInit");
        }

        public override void Update()
        {
            Logger.Instance.Log("Update");
        }
    }
}