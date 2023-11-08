using BepInEx;
using HarmonyLib;
using System;

namespace LethalCompanyPlayerUnlock {
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin {
        public void Awake() {
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loading...");
            var time = DateTime.Now;
            Setup();
            var timePassed = DateTime.Now - time;
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded in {timePassed.TotalSeconds} seconds!");
        }

        private void Setup() {
            var harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll();
        }
    }
}
