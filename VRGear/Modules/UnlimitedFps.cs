using UnityEngine;

namespace VRGear.Modules
{
    internal class UnlimitedFps : Module
    {
        public UnlimitedFps()
        {
            Application.targetFrameRate = 300;
        }
    }
}