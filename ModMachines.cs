using System.Collections.Generic;
using System.Linq;

namespace ProbablyNuclear
{
    public class ModMachines
    {
        private static readonly Dictionary<string, int> UplinkCatalog = new Dictionary<string, int>()
        {
            { "cobra", 4 },
            { "cybersun_pen", 2 },
            { "emag", 5}
        };

        public static void CreateUplinkMachine(GameItem gameItem)
        {
            GameGridInventory input = new GameGridInventory(5, 4);
            GameSlotInventory output = new GameSlotInventory();
            MachineryButton menu = new MachineryButton("Select Item");
            MachineryButton confirm = new MachineryButton("Redeem");
            MachineryText info = MachineryText.Status("Info", "Press 'Redeem' to trade \ntelecrystals for the selected item.");
            //info.WidthPixelsClamp(50);
            confirm.SetSize(50);
            MachineryStack stack = MachineryStack.Vertical(menu,info,confirm);
            MachineryPanel inputPanel = MachineHelper.Panel("Input", input, "input");
            MachineryPanel configPanel = MachineHelper.Panel("Configure", stack, "config");
            MachineryPanel outputPanel = MachineHelper.Panel("Output", output, "output");

            PixelWindow window = MachineHelper.CreateMachineryWindow(canMove: true, inputPanel, configPanel, outputPanel);
            gameItem.SetContentWindow(window);
            
            PixelWindow menuWindow = CreateMenu();
            gameItem.SetExamineWindow(menuWindow);

            menuWindow.Center(); // todo fix it uncentering when shown

            menu.SetCallback(delegate
            {
                if (menuWindow.IsVisible() )
                    menuWindow.Hide();
                else
                    menuWindow.Show();
            });
        }

        public static PixelWindow CreateMenu()
        {
            MachineryRadioList menuSelection = new MachineryRadioList(UplinkCatalog.Keys.ToList());

            MachineryPanel menuPanel = MachineHelper.Panel("Selection", menuSelection, "menuSelection");
            return MachineHelper.CreateMachineryWindow(canMove: true, menuPanel);
        }
    }
}
