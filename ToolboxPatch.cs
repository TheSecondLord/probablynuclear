using HarmonyLib;
using Il2Cpp;
using MelonLoader;

namespace ProbablyNuclear
{
    [HarmonyPatch(typeof(ToolboxHelper), "UpdateToolboxSprite")]
    public static class ToolboxPatch
    {
        public static bool Prefix(GameItem box)
        {
            MelonLogger.Msg(box.spriteAtlasPath);
            MelonLogger.Msg(box.spritePath);
            if (box.spritePath == "syndicate_toolbox_old.png" || box.spritePath == "syndicate_toolbox_new.png")
            { 
                bool flag = ToolboxHelper.GetUnlockedSlots(box) >= 9;
                Items.ModdedShape(ref box, flag ? "syndicate_toolbox_new" : "syndicate_toolbox_old");
                return false;
            }
            return true;
        }
    }
}