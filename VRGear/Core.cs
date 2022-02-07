using System;
using VRC.UI.Core;
using MelonLoader;
using UnityEngine;
using System.Collections;
using VRGear.Utils;
using Player = VRC.Player;

[assembly: MelonGame("VRChat", "VRChat")]
[assembly: MelonInfo(typeof(VRGear.Core), nameof(VRGear), "0.0.0", "Rai#3279")]

namespace VRGear
{
    public class Core : MelonMod
    {
        private ModuleManager _moduleManager;

        private void ApplyPatches()
        {
            Patches.PhotonNetworkEvent.OnEnvent += _moduleManager.OnEvent;
        }
        
        private void RemovePatches()
        {
            Patches.PhotonNetworkEvent.OnEnvent -= _moduleManager.OnEvent;
        }
        
        public override void OnApplicationStart()
        {
            _moduleManager = new ModuleManager();
            MelonCoroutines.Start(WaitForUiInit());
            MelonCoroutines.Start(NetworkInit());
            
            ApplyPatches();
        }
        
        private IEnumerator WaitForUiInit()
        {
            while (VRCUiManager.field_Private_Static_VRCUiManager_0 == null) yield return null;
            while (UIManager.field_Private_Static_UIManager_0 == null) yield return null;
            while (GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) == null) yield return null;

            _moduleManager.UiInit();
        }
        
        private IEnumerator NetworkInit()
        {
            while (NetworkManager.field_Internal_Static_NetworkManager_0 == null)
                yield return null;

            NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_0
                .field_Private_HashSet_1_UnityAction_1_T_0.Add((Action<Player>) delegate(Player player)
                {
                    if (player != null)
                        _moduleManager.PlayerJoin(player);
                });

            NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_1
                .field_Private_HashSet_1_UnityAction_1_T_0.Add((Action<Player>) delegate(Player player)
                {
                    if (player != null)
                        _moduleManager.PlayerLeft(player);
                });
        }

        public override void OnUpdate() => _moduleManager.Update();
        public override void OnLateUpdate() => _moduleManager.LateUpdate();
        public override void OnPreferencesSaved() => _moduleManager.Save();
        public override void OnPreferencesLoaded() => _moduleManager.Load();

        public override void OnApplicationQuit()
        {
            RemovePatches();
            _moduleManager.Quit();
        }
    }
}