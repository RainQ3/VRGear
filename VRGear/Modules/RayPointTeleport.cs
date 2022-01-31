using UnityEngine;
using Logger = VRGear.Utils.Logger;

namespace VRGear.Modules
{
    public class RayPointTeleport : Module
    {
        public override void Update()
        {
            if (!Input.GetKey(KeyCode.LeftControl) || !Input.GetMouseButtonDown(0)) return;
            if (Physics.Raycast(Utils.Player.LocalPlayerCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition),
                out var hit) == false) return;

            Logger.Instance.Log($"Teleported to {hit.point.ToString()}");
            Utils.Player.CurrentPlayer.transform.position = hit.point;
        }
    }
}