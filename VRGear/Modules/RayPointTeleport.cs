using UnityEngine;

namespace VRGear.Modules
{
    public class RayPointTeleport : Module
    {
        public override void Update()
        {
            if (!Input.GetKey(KeyCode.LeftControl) || !Input.GetMouseButtonDown(0)) return;
            if (Physics.Raycast(Utils.Player.LocalPlayerCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out var hit))
                Utils.Player.CurrentPlayer.transform.position = hit.point;
        }
    }
}