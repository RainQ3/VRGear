using System;
using UnityEngine;
using Logger = VRGear.Utils.Logger;

namespace VRGear.Modules
{
    public class ForceClone : Module
    {
        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha9) == false) return;
            
            Logger.Instance.Log("Activated force clone", ConsoleColor.Yellow);
            
            foreach (var player in Utils.Player.Players)
                player.prop_APIUser_0.allowAvatarCopying = true;
        }
    }
}