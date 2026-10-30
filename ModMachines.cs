namespace ProbablyNuclear
{
    public class ModMachines
    {
        public static void CreateUplinkMachine(GameItem gameItem)
        {
            // Todo: redo this with new machine stuff

            PixelWindow pixelWindow = new PixelWindow(canMove: true);
            GridPixelElement gridPixelElement = new GridPixelElement(3, 3, isCentered: true);
            GridPixelElement buttonGridElement = new GridPixelElement(1, 2, isCentered: true);
            //GameGridInventory gameGridInventory = new GameGridInventory(4, 4);
            GameGridInventory inputGrid = new GameGridInventory(4, 4);
            GameSlotInventory outputSlot = new GameSlotInventory();
            AdvButtonElement selectButton = new AdvButtonElement(null, "Select");
            AdvButtonElement purchaseButton = new AdvButtonElement(null, "Purchase");
            //inputGrid.slotPriorityFunc = (GameItem _, GameInventory _, SlotMarker _) => 2;
            outputSlot.slotPriorityFunc = (GameItem _, GameInventory _, SlotMarker _) => 3;
            //TagElement element = new TagElement().SetText(LocHelper.GetLocalizedMechani`c("mech_blender_label_module"));
            TagElement inputLabel = new TagElement().SetText("Input");
            //TagElement element3 = new TagElement().SetText(LocHelper.GetLocalizedMechanic("mech_blender_label_container"));
            TagElement selectionLabel = new TagElement().SetText("Selection");
            TagElement outputLabel = new TagElement().SetText("Output");
            buttonGridElement.Attach(selectButton, 1, 1);
            buttonGridElement.Attach(purchaseButton, 1, 2);

            gridPixelElement.Attach(inputLabel, 1, 0);
            gridPixelElement.Attach(selectionLabel, 2, 0);
            gridPixelElement.Attach(outputLabel, 3, 0);
            gridPixelElement.Attach(inputGrid, 1, 1);
            gridPixelElement.Attach(buttonGridElement, 2, 1);
            gridPixelElement.Attach(outputSlot, 3, 1);

            pixelWindow.Attach(gridPixelElement);

            gameItem.SetContentWindow(pixelWindow);
        }
    }
}
