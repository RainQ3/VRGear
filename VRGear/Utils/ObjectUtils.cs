using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRC.SDKBase;

namespace VRGear.Utils
{
    public static class ObjectUtils
    {
        public static List<VRC_Pickup> AllPickups => Object.FindObjectsOfType<VRC_Pickup>().ToList();
    }
}