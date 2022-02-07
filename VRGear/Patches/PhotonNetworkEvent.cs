using System;
using HarmonyLib;
using Photon.Realtime;
using ExitGames.Client.Photon;

namespace VRGear.Patches
{
    [HarmonyPatch(typeof(LoadBalancingClient), nameof(LoadBalancingClient.OnEvent))]
    public class PhotonNetworkEvent
    {
        public static event Action<EventData> OnEnvent;

        private static bool Prefix(EventData param_1)
        {
            OnEnvent?.Invoke(param_1);
            return true;
        }
    }
}