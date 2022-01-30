using UnityEngine;
using VRC.SDKBase;

namespace VRGear.Modules
{
    public class RayObjectTeleport : Module
    {
        public override void Update()
        {
            if (Input.GetKey(KeyCode.LeftControl) == false || Input.GetKeyDown(KeyCode.Alpha1) == false) return;
            
            foreach (var pickup in Resources.FindObjectsOfTypeAll<VRC_Pickup>())
            {
                if (pickup.gameObject.active)
                    Networking.SetOwner(Utils.Player.CurrentPlayer.field_Private_VRCPlayerApi_0, pickup.gameObject);
                if (Physics.Raycast(Utils.Player.LocalPlayerCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition),
                    out var hit))
                    pickup.transform.position = hit.point;
            }
        }
    }
}