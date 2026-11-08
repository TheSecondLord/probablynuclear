using HarmonyLib;

namespace ProbablyNuclear
{
    [HarmonyPatch(typeof(GunHelper), nameof(GunHelper.GetCaliberName))]
    public static class CalibreNamePatch
    {
        static void Postfix(ref int caliber, ref string __result)
        {
            if (caliber == 220)
                __result = ModLoc.Localize("item_light_pistol_ammo_caseless");
        }
    }
}
