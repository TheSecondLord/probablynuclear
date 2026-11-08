using System.Collections.Generic;
using UnityEngine;

namespace ProbablyNuclear
{
    public class ModUplink
    {
        private static readonly Dictionary<string, int> UplinkWeapons = new Dictionary<string, int>()
        {
            { "throwing_knife", 3 },
            { "minibomb", 4 },
            { "energy_sword", 15 }
        };

        private static readonly Dictionary<string, int> UplinkGuns = new Dictionary<string, int>()
        {
            { "light_pistol_ammo_caseless", 1 },
            { "22mm_mag_smg", 2 },
            { "cobra", 10 },
            { "c20r", 18 }
        };

        private static readonly Dictionary<string, int> UplinkTools = new Dictionary<string, int>()
        {
            { "cybersun_pen", 3 },
            { "syndicate_gas_mask", 5},
            { "emag", 8},
            { "suspicious_toolbox", 8}
        };

        private static readonly Dictionary<string, int> UplinkMedical = new Dictionary<string, int>()
        {
            { "hyperzine_injector", 3 },
            { "implanter", 7 },
            { "holoparasite_injector", 16 }
        };

        private static readonly Dictionary<string, int> UplinkOther = new Dictionary<string, int>()
        {
            { "syndicate_soap", 1 },
            { "interdyne_herbals", 2 }
        };

        private static readonly Dictionary<string, Dictionary<string, int>> UplinkCatalog = new()
        {
            { "weapons", UplinkWeapons },
            { "guns", UplinkGuns },
            { "tools", UplinkTools },
            { "medical", UplinkMedical },
            { "other", UplinkOther }
        };
        public GameGridInventory input = new GameGridInventory(5, 4);
        public GameSlotInventory output = new GameSlotInventory();
        private MachineryText info = MachineryText.Status(ModLoc.Localize("string_info"), ModLoc.Localize("machine_uplink_info"));
        public GameItem gameItem;

        public ModUplink(GameItem gameItem)
        {
            this.gameItem = gameItem;
            MachineryButton menu = new MachineryButton(ModLoc.Localize("string_select_item"));
            MachineryStack stack = MachineryStack.Vertical(menu,info);
            MachineryPanel inputPanel = MachineHelper.Panel(ModLoc.Localize("string_input"), input, "input");
            MachineryPanel configPanel = MachineHelper.Panel(ModLoc.Localize("string_configure"), stack, "config");
            MachineryPanel outputPanel = MachineHelper.Panel(ModLoc.Localize("string_output"), output, "output");

            PixelWindow window = MachineHelper.CreateMachineryWindow(canMove: true, inputPanel, configPanel, outputPanel);
            gameItem.SetContentWindow(window);
            
            PixelWindow menuWindow = CreateMenu();
            gameItem.SetExamineWindow(menuWindow);
            menu.SetSize(110);
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

                    (float x, float y) = window.Size();
                    (float x2, float y2) = menuWindow.Size();
                    //menuWindow.rectTransform.anchoredPosition = new Vector2(-80, -110);
                    menuWindow.rectTransform.anchoredPosition = new Vector2(-(x2 / 2) + x / 2, -y);

                }
            });

            input.mayInventoryAddItemFunc = delegate (GameItem item, GameInventory _)
            {
                if (!GeneralHelper.IsItemOwned(item))
                {
                    return false;
                }
                return item.identifier == "telecrystal";
            };
            output.mayInventoryAddItemFunc = (GameItem _, GameInventory _) => false;
        }

        public PixelWindow CreateMenu()
        {
            List<MachineryPanel> panels = new List<MachineryPanel>();

            // Add each entry for each category to a vertical stack, then add each stack to a final horizontal stack
            foreach (string category in UplinkCatalog.Keys)
            {
                MachineryStack categoryStack = MachineryStack.Vertical();
                Dictionary<string, int> entries = UplinkCatalog[category];
                foreach (string entry in entries.Keys)
                {
                    string text;
                    if (entry == "light_pistol_ammo_caseless") // Needs a shorter name replacement to not extend past the button UI
                        text = ModLoc.Localize("machine_uplink_redeem_button", ModLoc.Localize("machine_uplink_alt_name_ammo_caseless"), entries[entry]);
                    else
                        text = ModLoc.Localize("machine_uplink_redeem_button", ModLoc.Localize("item_" + entry), entries[entry]);
                    MachineryButton button = new MachineryButton(text, delegate { Redeem(entry, entries[entry]); }, width: 100);
                    categoryStack.Add(button);

                }
                panels.Add(MachineHelper.Panel(ModLoc.Localize("machine_uplink_category_" + category), categoryStack, category));
            }

            return MachineHelper.CreateMachineryWindow(canMove: false, panels.ToArray());
        }

        private void Redeem(string id, int cost)
        {
            if (output.childItems.Count != 0)
            {
                info.SetStatus(ModLoc.Localize("string_warning"), ModLoc.Localize("machine_uplink_info_full"));
                return;
            }

            List<GameItem> tc = GraphUtils.FindAllChildrenType(input, (GameItem item) => item.identifier == "telecrystal");
            if (tc.Count < cost)
            {
                info.SetStatus(ModLoc.Localize("string_warning"), ModLoc.Localize("machine_uplink_info_insufficient"));
                return;
            }

            for (int i = 0; i < cost; i++)
                    tc[i].Destroy();

            output.mayInventoryAddItemFunc = (GameItem _, GameInventory _) => true;
            GraphUtils.TryAccept(output, ModHelper.SpawnItem(id));
            output.mayInventoryAddItemFunc = (GameItem _, GameInventory _) => false;
            PlayerStore.Instance.ModCash(0); // Stupid workaround to play the cash sound without importing unity resources
            info.SetStatus(ModLoc.Localize("string_success"), ModLoc.Localize("machine_uplink_info_success", ModLoc.Localize("item_" + id)));
            return;
        }
    }
}
