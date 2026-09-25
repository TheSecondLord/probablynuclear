using HarmonyLib;
using Il2Cpp;

namespace ProbablyNuclear
{
    [HarmonyPatch(typeof(ToolboxHelper), "UpdateToolboxSprite")]
    public static class ToolboxPatch
    {
        public static bool Prefix(GameItem box)
        {
            foreach (LoadedMod mod in ModLoader.Mods)
            {
                if (mod.Manifest.ID.Equals(box.spriteAtlasPath))
                {
                    bool flag = ToolboxHelper.GetUnlockedSlots(box) >= 9;
                    Items.ModdedShape(ref box, flag ? $"{box.spritePath}_new" : $"{box.spritePath}_old");
                    return false;
                }
            }
            return true;
        }
    }
}