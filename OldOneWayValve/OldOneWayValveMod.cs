using Assets.Scripts.Objects;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldOneWayValve
{
    [HarmonyPatch(typeof(Prefab), "LoadCorePrefabs")]
    public class AddStructureIntoKit
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            MultiConstructor pipeKit = Prefab.Find<MultiConstructor>("ItemPipeValve");
            Structure oldValve = Prefab.Find<Structure>("StructurePipeOneWayValve");
            if (pipeKit != null && oldValve != null)
            {
                pipeKit.Constructables.Add(oldValve);
                oldValve.BuildStates[0].Tool.ToolEntry = pipeKit;
            }
            MultiConstructor liquidipeKit = Prefab.Find<MultiConstructor>("ItemLiquidPipeValve");
            Structure oldLiquidValve = Prefab.Find<Structure>("StructureLiquidPipeOneWayValve");
            if (liquidipeKit != null && oldLiquidValve != null)
            {
                liquidipeKit.Constructables.Add(oldLiquidValve);
                oldLiquidValve.BuildStates[0].Tool.ToolEntry = liquidipeKit;
            }
        }
    }
}
