using System.Linq;
using ExitGames.Client.Photon;
using VRGear.Utils;

namespace VRGear.Modules
{
    public class AntiBlock : Module
    {
        public override void OnEvent(EventData eventData)
        {
            if (eventData.Code != 33) return;

            foreach (var player in Player.Players.Where(
                player => player.prop_VRCPlayerApi_0.playerId == eventData.sender
                          && eventData.sender != Player.CurrentPlayer.prop_VRCPlayerApi_0.playerId))
            {
                Logger.Instance.Log($"Block event received from [{player.prop_APIUser_0.displayName}]");
            }
        }
    }
}