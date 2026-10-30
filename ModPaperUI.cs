using UnityEngine;

namespace ProbablyNuclear
{
    public class ModPaperUI
    {
        // Todo: change this whole thing to use new custom UI api
        private static Sprite cardSyndicateSprite = GetSprite("probably_nuclear", "card_syndicate");
        private CustomUIWindow cardSyndicate = CreateUI();

        private static Sprite GetSprite(string mod, string name)
        {
            LoadedMod loadedMod = ModLoader.Mods.Find((LoadedMod m) => m.Manifest.ID == mod);
            if (loadedMod != null && loadedMod.Sprites.TryGetValue(name, out var value))
                return value;
            else
                return null;
        }

        private static CustomUIWindow CreateUI()
        {
            CustomUIWindow window = CustomUIManager.Window("probably_nuclear.cardSyndicate", "Syndicate Business Card", CustomUIManager.LAYER_PAPER)
                .SetSize(400, 200)
                .SetDraggable(true)
                .SetCloseOnEscape()
                .AddImage(cardSyndicateSprite, 420f, 210f)
                .GetWindow();

            window.Center();
            return window;
        }

        public void ToggleSyndicateCard()
        {
            this.cardSyndicate ??= CreateUI();

            this.cardSyndicate.Toggle();
            if (this.cardSyndicate.IsVisible)
                AudioManager.Instance.Play("paper_sheet_drag");
            else
                AudioManager.Instance.Play("paper_sheet_drop");
        }
    }
}
