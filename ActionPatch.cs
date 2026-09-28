using HarmonyLib;
using Il2Cpp;

namespace ProbablyNuclear
{
    [HarmonyPatch(typeof(GameItem), nameof(GameItem.MayActivateSlotItem))]
    internal static class GameItem_MayActivateSlotItem_Patch
    {
        private static bool Prefix(GameItem __instance, ref bool __result)
        {
            if (__instance == null || !Core.canActivateIds.Contains(__instance.identifier))
            {
                return true;
            }

            __result = true;
            return false;
        }
    }

    [HarmonyPatch(typeof(GameItem), nameof(GameItem.CanActivateSlotItem))]
    internal static class GameItem_CanActivateSlotItem_Patch
    {
        private static bool Prefix(GameItem __instance, ref bool __result)
        {
            if (__instance == null || !Core.canActivateIds.Contains(__instance.identifier))
            {
                return true;
            }

            __result = GeneralHelper.IsItemOwned(__instance);
            return false;
        }
    }

    [HarmonyPatch(typeof(GameItem), nameof(GameItem.MayTarget))]
    internal static class GameItem_MayTarget_Patch
    {
        private static bool Prefix(GameItem targetItem, GameItem __instance, ref bool __result)
        {
            if (__instance == null || !Core.canActivateIds.Contains(__instance.identifier))
            {
                return true;
            }

            __result = GeneralHelper.IsItemOwned(__instance) && GeneralHelper.IsItemOwned(targetItem) && LockHelper.IsLockedContainer(targetItem);
            return false;
        }
    }

    [HarmonyPatch(typeof(GameItem), nameof(GameItem.CanTarget))]
    internal static class GameItem_CanTarget_Patch
    {
        private static bool Prefix(GameItem targetItem, GameItem __instance, ref bool __result)
        {
            if (__instance == null || !Core.canActivateIds.Contains(__instance.identifier))
            {
                return true;
            }

            __result = GeneralHelper.IsItemOwned(__instance) && GeneralHelper.IsItemOwned(targetItem) && LockHelper.IsLockedContainer(targetItem);
            return false;
        }
    }
}