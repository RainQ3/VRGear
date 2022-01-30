using UnityEngine;
using VRGear.Utils;
using Player = VRC.Player;

namespace VRGear.Modules
{
    public class CustomNamePlate : Module
    {
        public override void PlayerJoin(Player player)
        {
            if (player == Utils.Player.CurrentPlayer.prop_Player_0)
                return;

            var namePlate = GameObject.Find($"{player.gameObject.name}/Player Nameplate/Canvas/Nameplate/Contents/Main/Background");

            if (namePlate != null)
                namePlate.GetComponent<ImageThreeSlice>().m_Color = Trust.GetTrustColor(Trust.GetTrustLevel(player.prop_APIUser_0));
        }
    }
}