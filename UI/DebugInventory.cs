using Il2Cpp;
using Il2CppInterop.Runtime;
using MelonLoader;
using ProbablyNuclear.Data;
using System.Reflection.Metadata.Ecma335;
using UnityEngine;

namespace ProbablyNuclear.UI
{
    internal class DebugInventory
    {
        private static PixelWindow _window;
        private static GameGridScrollableInventory _inventory;
        private static bool _populated;

        internal static void toggleWindow()
        {
            buildWindow();

            if (_window.IsVisible())
            {
                _window.Hide();
                _window.handler.SetParentTempRoot();
                return;
            }

            populateInventory();
            _window.Show();
            _window.handler.SetParentWindowRoot();
            _window.rectTransform.anchoredPosition = Vector2.zero;
            _window.ToFront();
            _inventory.SetScroll(0f);
        }

        private static void buildWindow()
        {
            if (_window != null && _window.handler != null)
            {
                return;
            }

            _window = new PixelWindow(canMove: true);
            _inventory = new GameGridScrollableInventory(10, 15);
            _window.Attach(_inventory?.TryCast<PixelElement>());
            _window.SetTitle("Nuclear Items");
            _window.Validate();
            _populated = false;
        }
        private static void populateInventory()
        {

            if (_populated)
            {
                return;
            }

            Il2CppSystem.Collections.Generic.List<GameItem> items = ModRegistries.NuclearItems;
            _inventory.AddFastUnchecked(items);

            foreach (GameItem item in _inventory.childItems)
            {
                item.shortDescription = "ID: " + item.identifier + ((item.shortDescription.Length > 0) ? ("\n" + item.shortDescription) : "");
                item.SetAmount(1);
                GeneralHelper.SetItemOwned(item, true);
             }
            
            _inventory.Validate();
            _populated = true;
        }

    }
}
