

using HarmonyLib;
using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppSystem;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UIElements;

namespace ProbablyNuclear.UI
{
    internal class DebugPanel
    {

        private static PixelWindow _window;
        private static RichTextElement _statusText;
        private static ButtonElement _debugInventory;
        private static readonly Hotkey _toggleHotkey = new Hotkey(KeyCode.BackQuote, (Il2CppSystem.Action)toggleWindow);

        private static void toggleWindow()
        {
            buildWindow();

            if (_window.IsVisible())
            {
                _window.Hide();
                _window.handler.SetParentTempRoot();
                return;
            }
            _window.Show();
            _window.handler.SetParentWindowRoot();
            _window.rectTransform.anchoredPosition = Vector2.zero;
            _window.ToFront();
        }

        private static void buildWindow()
        {
            // See RustItemListWindow.ensureWindow for why handler (not just _window) is checked.
            if (_window != null && _window.handler != null)
            {
                return;
            }

            _window = new PixelWindow(canMove: true);

            GridPixelElement content = new GridPixelElement(1, 2);
            content.SetSpacing(0, 6);

            _statusText = new RichTextElement();
            GridPixelElement innerContent = new GridPixelElement(4, 4);
            innerContent.SetSpacing(12, 4);

            _statusText.SetText("Nuclear Debug Panel", color: RenderHandler.ColorPalette.EGreen);
            innerContent.Attach(_statusText?.TryCast<PixelElement>());

            _debugInventory = new ButtonElement("Debug Inventory", callback: DelegateSupport.ConvertDelegate<Il2CppSystem.Action>(() => DebugInventory.toggleWindow()));
            innerContent.Attach(_debugInventory?.TryCast<PixelElement>());

            content.Attach(innerContent?.TryCast<PixelElement>());
            _window.Attach(content?.TryCast<PixelElement>());
            _window.SetTitle("TheRust Debug");
            _window.Validate();
        }

        [HarmonyPatch(typeof(StoreUIManager), "Update")]
        public class StoreUIManagerUpdatePatch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                if (_toggleHotkey.poll())
                {
                    return;
                }
            }
        }



    }

    internal class Hotkey
    {
        private readonly KeyCode _key;
        private readonly Il2CppSystem.Action _onPressed;

        public Hotkey(KeyCode key, Il2CppSystem.Action onPressed)
        {
            _key = key;
            _onPressed = onPressed;
        }
        public bool poll()
        {
            if (Input.GetKeyDown(_key))
            {
                _onPressed?.Invoke();
                return true;
            }

            return false;
        }
    }
}
