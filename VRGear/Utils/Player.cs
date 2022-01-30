using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRC;

namespace VRGear.Utils
{
    public static class Player
    {
        private static Camera _localPlayerCamera;

        public static List<VRC.Player> Players =>
            PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.ToArray().ToList();

        public static VRCPlayer CurrentPlayer => VRCPlayer.field_Internal_Static_VRCPlayer_0;
        public static Camera LocalPlayerCamera => _localPlayerCamera ??= GameObject.Find("Camera (eye)").GetComponent<Camera>();
    }
}