using ExitGames.Client.Photon;
using MelonLoader;
using VRGear.Attributes;

namespace VRGear.Modules
{
    [DontLoad]
    public class Test : Module
    {
        public override void OnEvent(EventData eventData)
        {
            if (eventData.sender != 0)
                MelonLogger.Msg($"OnEvent! [Sender: {eventData.Sender}, " +
                                    $"byte code: {eventData.Code}, " +
                                    $"SenderKey: {eventData.SenderKey}, " +
                                    $"CustomDataKey: {eventData.CustomDataKey}]");

            // foreach (var parameter in eventData.Parameters)
            // {
                // Logger.Instance.Log($"With Parameter: {parameter.Key}, {parameter.Value}");
            // }
        }
    }
}