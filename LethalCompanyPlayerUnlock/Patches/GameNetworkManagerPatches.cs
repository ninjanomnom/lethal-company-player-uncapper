using HarmonyLib;
using Steamworks.Data;

namespace LethalCompanyPlayerUnlock.Patches {
    [HarmonyPatch(typeof(GameNetworkManager))]
    internal static class GameNetworkManagerPatches {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(GameNetworkManager.LobbyDataIsJoinable))]
        public static bool IsJoinablePostfix(bool allowed, ref Lobby lobby) {
            if(allowed) {
                return true;
            }
            var data = lobby.GetData("vers");
            if(data != GameNetworkManager.Instance.gameVersionNum.ToString()) {
                return false;
            }
            if(lobby.GetData("joinable") == "false") {
                return false;
            }
            if(lobby.MemberCount >= 4 || lobby.MemberCount < 1) {
                return true;
            }
            return false;
        }
    }
}
