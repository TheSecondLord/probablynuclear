using HarmonyLib;
using Il2Cpp;

namespace ProbablyNuclear
{
    [HarmonyPatch(typeof(GameItem), nameof(GameItem.SetSpriteAndShape))]
    public static class SpriteShapePatch
    {
        static bool Prefix(string spriteAtlasPath, string spritePath, ref GameItem __result, ref GameItem __instance)
        {
            if (spritePath == "syndicate_box.png_u")
            {
                __result = Items.ModdedShape(ref __instance, "syndicate_box_u");
                return false;
            }
            return true;
        }
    }
}