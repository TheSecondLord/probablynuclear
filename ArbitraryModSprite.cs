using UnityEngine;

namespace ProbablyNuclear
{
    class ArbitraryModSprite
    {
        // Finds a non-item sprite from a mod.
        public static Sprite GetSprite(string mod, string id)
        {
            LoadedMod loadedMod = ModLoader.Mods.Find((LoadedMod m) => m.Manifest.ID == mod);
            if (loadedMod != null && loadedMod.Sprites.TryGetValue(id, out var value))
                return value;
            Debug.LogWarning("Mod sprite '" + id + "' from mod '" + mod + "' not found. Loading dummy sprite.");
            return RenderHandler.unknownSprite;
        }
    }
}
