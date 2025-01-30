using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace OldOneWayValve
{
    #region BepInEx
    [BepInEx.BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    public class BepInExOldOneWayValve : BepInEx.BaseUnityPlugin
    {
        public const string pluginGuid = "net.elmo.stationeers.OldOneWayValve";
        public const string pluginName = "OldOneWayValve";
        public const string pluginVersion = "1.0";
        public static void Log(string line)
        {
            Debug.Log("[" + pluginName + "]: " + line);
        }
        void Awake()
        {
            try
            {
                var harmony = new Harmony(pluginGuid);
                harmony.PatchAll();
                Log("Patch succeeded");

            }
            catch (Exception e)
            {

                Log("Patch Failed");
                Log(e.ToString());
            }
        }
    }
    #endregion
}
