using HarmonyLib;
using System;

namespace ProbablyNuclear
{
    [HarmonyPatch(typeof(StoreClientList), nameof(StoreClientList.CreateThief))]
    public static class ThiefPatch
    {
        static void Postfix(ref StoreClient __result)
        {
            // Adds syndie crate to the START of the end action queue.
            // Thief's offering table quickly becomes so full that if I don't do this, it'll never appear because there will never be enough room.
            // This will almost always leave normal crates without enough room to spawn, which is fine because they'll still show up if you fail the roll.
            __result.mainDialogue.nextDialogue.endAction = AddSyndicateCrate + __result.mainDialogue.nextDialogue.endAction;
        }

        private static void AddSyndicateCrate()
        {
            // 1/4 at max rep
            if (StoreStation.Instance.dayCounter >= 18 && RNG.Roll(5 + Math.Clamp(StoreReputation.GetBMReputation() / 5, 0, 20)))
                PlayerStore.Instance.AddDirectSellingItemToTable(ModPreBuiltItems.LootCrateSyndicate(), isOwend: false, isStolen: true);
        }
    }
}
