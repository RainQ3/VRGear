using UnityEngine;
using Logger = VRGear.Utils.Logger;

namespace VRGear.Modules
{
    internal class UnlimitedFps : Module
    {
        public UnlimitedFps()
        {
            const int frameRate = 300;
            Application.targetFrameRate = frameRate;
            Logger.Instance.Log($"Application max frame rate set to {frameRate}");
        }
    }
}