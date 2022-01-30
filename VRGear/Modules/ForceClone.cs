using UnityEngine;

namespace VRGear.Modules
{
    public class ForceClone : Module
    {
        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha9) == false) return;
            
            foreach (var player in Utils.Player.Players)
                player.prop_APIUser_0.allowAvatarCopying = true;
        }
    }
}