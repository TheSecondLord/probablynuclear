using HarmonyLib;
using Il2Cpp;

namespace ProbablyNuclear
{
    [HarmonyPatch(typeof(GameItem), nameof(GameItem.SetSpriteAndShape))]
    public static class SpriteShapePatch
    {
        static bool Prefix(string spriteAtlasPath, string spritePath, ref GameItem __result, ref GameItem __instance)
        {
            foreach (LoadedMod mod in ModLoader.Mods)
            {
                if (mod.Manifest.ID.Equals(spriteAtlasPath))
                {
                    //__result = __instance.SetSpriteAndShapeFromMod(spriteAtlasPath, spritePath);
                    __result = Items.ModdedShape(ref __instance, spriteAtlasPath);
                    return false;
                }
            }
            return true;
        }
    }
}