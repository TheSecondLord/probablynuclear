using HarmonyLib;
using Il2Cpp;
using MelonLoader;
using UnityEngine;

namespace ProbablyNuclear
{
    [HarmonyPatch(typeof(GameItem), nameof(GameItem.SetSpriteAndShape))]
    public static class SpriteShapePatch
    {
        static bool Prefix(string spriteAtlasPath, string spritePath, ref GameItem __result, ref GameItem __instance)
        {
            if (spritePath == "syndicate_box.png_u") // Hardcoded string from box unlocking system
            {
                MelonLogger.Msg("a");
                __result = Items.ModdedShape(ref __instance, "syndicate_box_u.png");
                return false;
            }

            return true;
        }
    }
    [HarmonyPatch(typeof(GameItemElement), nameof(GameItemElement.ResolveSpriteByName))]
    public static class ResolveSpritePatch
    {
        static bool Prefix(string name, ref Sprite __result, ref GameItemElement __instance)
        {
            MelonLogger.Msg(__instance.spriteAtlasPath);
            MelonLogger.Msg(__instance.spritePath);
            if (__instance.spriteAtlasPath == "ModdedPath/")
            {
                __result = Items.LoadEmbeddedPng(__instance.spritePath);
                return false;
            }
            return true;
        }
    }
}