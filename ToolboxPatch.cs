using HarmonyLib;

namespace ProbablyNuclear
{
    [HarmonyPatch(typeof(ToolboxHelper), "UpdateToolboxSprite")]
    public static class ToolboxPatch
    {
        public static bool Prefix(GameItem box)
        {
            if (box.identifier == "suspicious_toolbox")
                return false; // Don't update sprite
            else
                return true;
        }
    }
}