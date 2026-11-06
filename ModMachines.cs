using System.Collections.Generic;
using UnityEngine;

namespace ProbablyNuclear
{
    public class ModMachines
    {
        private static readonly Dictionary<string, int> UplinkWeapons = new Dictionary<string, int>()
        {
            { "throwing_knife", 3 },
            { "minibomb", 5 },
            { "cobra", 12 },
            { "energy_sword", 16 }
        };

        private static readonly Dictionary<string, int> UplinkTools = new Dictionary<string, int>()
        {
            { "cybersun_pen", 4 },
            { "syndicate_gas_mask", 5},
            { "emag", 8},
            { "suspicious_toolbox", 8}
        };

        private static readonly Dictionary<string, int> UplinkMedical = new Dictionary<string, int>()
        {
            { "hyperzine_injector", 4 },
            { "implanter", 7 },
            { "holoparasite_injector", 15 }
        };

        private static readonly Dictionary<string, int> UplinkOther = new Dictionary<string, int>()
        {
            { "syndicate_soap", 1 },
            { "interdyne_herbals", 3 }
        };

        private static readonly Dictionary<string, Dictionary<string, int>> UplinkCatalog = new()
        {
            { "Weapons", UplinkWeapons },
            { "Tools", UplinkTools },
            { "Medical", UplinkMedical },
            { "Other", UplinkOther }
        };

        public static void CreateUplinkMachine(GameItem gameItem)
        {
            GameGridInventory input = new GameGridInventory(5, 4);
            GameSlotInventory output = new GameSlotInventory();
            MachineryText info = MachineryText.Status("Info", "Open the uplink catalog to\nselect an item to trade for.");
            MachineryButton menu = new MachineryButton("Select Item");
            MachineryStack stack = MachineryStack.Vertical(menu,info);
            MachineryPanel inputPanel = MachineHelper.Panel("Input", input, "input");
            MachineryPanel configPanel = MachineHelper.Panel("Configure", stack, "config");
            MachineryPanel outputPanel = MachineHelper.Panel("Output", output, "output");

            PixelWindow window = MachineHelper.CreateMachineryWindow(canMove: true, inputPanel, configPanel, outputPanel);
            gameItem.SetContentWindow(window);
            
            PixelWindow menuWindow = CreateMenu(gameItem, input, output);
            gameItem.SetExamineWindow(menuWindow);

            menu.SetCallback(delegate
            {
                if (menuWindow.IsVisible())
                {
                    menuWindow.Hide();
                }
                else
                {
                    menuWindow.Show();
                    if (menuWindow.rectTransform.parent != window.rectTransform)
                        menuWindow.rectTransform.SetParent(window.rectTransform, worldPositionStays: true);

                    menuWindow.rectTransform.anchoredPosition = new Vector2(-80, -110);

                }
            });
        }

        public static PixelWindow CreateMenu(GameItem gameItem, GameGridInventory input, GameSlotInventory output)
        {
            List<MachineryPanel> panels = new List<MachineryPanel>();

            // Add each entry for each category to a vertical stack, then add each stack to a final horizontal stack
            foreach (string category in UplinkCatalog.Keys)
            {
                MachineryStack categoryStack = MachineryStack.Vertical();
                Dictionary<string, int> entries = UplinkCatalog[category];
                foreach (string entry in entries.Keys)
                {
                    string text = ModHelper.GetLocalized("probably_nuclear", "item_" + entry) + " - " + entries[entry] + "TC";
                    MachineryButton button = new MachineryButton(text, delegate { Redeem(entry, entries[entry], gameItem, input, output); }, width: 100);
                    categoryStack.Add(button);

                }
                panels.Add(MachineHelper.Panel(category, categoryStack, category));
            }

            return MachineHelper.CreateMachineryWindow(canMove: false, panels.ToArray());
        }

        private static void Redeem(string id, int cost, GameItem gameItem, GameInventory input, GameInventory output)
        {
            if (output.childItems.Count != 0)
            {
                return;
            }

            List<GameItem> tc = GraphUtils.FindAllChildrenType(input, (GameItem item) => item.identifier == "telecrystal");
            if (tc.Count < cost)
                return;

            for (int i = 0; i < cost; i++)
                    tc[i].Destroy();

            GraphUtils.TryAccept(output, ModHelper.SpawnItem(id));
            PlayerStore.Instance.ModCash(0); // Stupid workaround to play the cash sound without importing unity resources
            return;
        }
    }
}
