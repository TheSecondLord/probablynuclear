namespace ProbablyNuclear
{
    public static class ModDebug
    {
        public static void SpawnCrates()
        {
            ModHelper.MoveItemToInventory(ModHelper.SpawnItem("emag"));
            ModHelper.MoveItemToInventory(ModPreBuiltItems.LootCrateSyndicate());
        }

        public static void SpawnItems()
        {
            ModHelper.MoveItemToInventory(ModHelper.SpawnItem("cobra"));
            ModHelper.MoveItemToInventory(ModHelper.SpawnItem("cybersun_pen"));
            ModHelper.MoveItemToInventory(ModHelper.SpawnItem("emag"));
            ModHelper.MoveItemToInventory(ModHelper.SpawnItem("energy_sword"));
            ModHelper.MoveItemToInventory(ModHelper.SpawnItem("holoparasite_injector"));
            ModHelper.MoveItemToInventory(ModHelper.SpawnItem("hyperzine_injector"));
            ModHelper.MoveItemToInventory(ModHelper.SpawnItem("implanter"));
            ModHelper.MoveItemToInventory(ModHelper.SpawnItem("interdyne_herbals"));
            ModHelper.MoveItemToInventory(ModHelper.SpawnItem("minibomb"));
            ModHelper.MoveItemToInventory(ModHelper.SpawnItem("suspicious_toolbox"));
            ModHelper.MoveItemToInventory(ModHelper.SpawnItem("syndicate_business_card"));
            ModHelper.MoveItemToInventory(ModHelper.SpawnItem("syndicate_gas_mask"));
            ModHelper.MoveItemToInventory(ModHelper.SpawnItem("syndicate_soap"));
            ModHelper.MoveItemToInventory(ModHelper.SpawnItem("telecrystal"));
            ModHelper.MoveItemToInventory(ModHelper.SpawnItem("throwing_knife"));
            ModHelper.MoveItemToInventory(ModHelper.SpawnItem("uplink"));
        }
    }
}
