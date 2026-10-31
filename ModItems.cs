namespace ProbablyNuclear
{
    public class ModItems
    {
        public static void CreateItems(ModItemDirectory modItemDirectory)
        {
            modItemDirectory.Add("cobra", Cobra);
            modItemDirectory.Add("cybersun_pen", CybersunPen);
            modItemDirectory.Add("emag", Emag);
            modItemDirectory.Add("energy_sword", EnergySword);
            modItemDirectory.Add("holoparasite_injector", HoloparasiteInjector);
            modItemDirectory.Add("hyperzine_injector", HyperzineInjector);
            modItemDirectory.Add("implanter", Implanter);
            modItemDirectory.Add("interdyne_herbals", InterdyneHerbals);
            modItemDirectory.Add("minibomb", Minibomb);
            modItemDirectory.Add("nuke_disk", NukeDisk);
            modItemDirectory.Add("suspicious_toolbox", SuspiciousToolbox);
            modItemDirectory.Add("syndicate_box", SyndicateBox);
            modItemDirectory.Add("syndicate_business_card", SyndicateBusinessCard);
            modItemDirectory.Add("syndicate_gas_mask", SyndicateGasMask);
            modItemDirectory.Add("syndicate_soap", SyndicateSoap);
            modItemDirectory.Add("telecrystal", Telecrystal);
            modItemDirectory.Add("throwing_knife", ThrowingKnife);
            modItemDirectory.Add("uplink", Uplink);

            PreBuiltItemHelper.preBuiltItems.Add("loot_crate_syndicate", ModPreBuiltItems.LootCrateSyndicate);
        }

        public static GameItem Cobra()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("cobra");
            gameItem.SetSpriteAndShapeFromMod("probably_nuclear", gameItem.identifier);
            gameItem.SetName(ModHelper.GetLocalized("probably_nuclear", "item_cobra"));
            gameItem.shortDescription = ModHelper.GetLocalized("probably_nuclear", "item_cobra_desc");
            gameItem.flavorText = ModHelper.GetLocalized("probably_nuclear", "item_cobra_flavor");
            gameItem.EnableManufacturer("spacer");
            gameItem.SetGameItemType("WEAPON");
            gameItem.SetGameItemType("FIREARM");
            gameItem.SetGameItemType("MIDLINE");
            gameItem.SetValue(225L);
            gameItem.EnableManufacturer("waffle");
            ContrabandHelper.InitContrabandItem(gameItem, 3);
            AudioHelper.InitPistol(gameItem);

            // Cobra isn't meant to be customisable, but I'm keeping this code here for later

            //(PixelWindow, GameSlotInventory, GameSlotInventory, GameSlotInventory, GameSlotInventory, GameSlotInventory, GameSlotInventory, GameSlotInventory, GameSlotInventory) tuple = GunModHelper.CreateGunModWindow();
            //PixelWindow item = tuple.Item1;
            //GameSlotInventory item2 = tuple.Item2;
            //GameSlotInventory item3 = tuple.Item3;
            //GameSlotInventory item4 = tuple.Item4;
            //GameSlotInventory item5 = tuple.Item5;
            //GameSlotInventory item6 = tuple.Item6;
            //GameSlotInventory item7 = tuple.Item7;
            //GameSlotInventory item8 = tuple.Rest.Item1;
            //GameSlotInventory item9 = tuple.Rest.Item2;
            //gameItem.SetContentWindow(item);
            //GunModHelper.EnableStockSlot(item2);
            //GunModHelper.EnableRailSlot(item3);
            //GunModHelper.EnableBarrelSlot(item6);
            //GunModHelper.EnableMagazineSlot(item4, "pistol_reload_light");
            //GunModHelper.EnableUnderbarrelSlot(item5);
            //GunModHelper.EnableSpecialSlot(item7);
            //GunModHelper.EnableSpecialSlot(item8);
            //GunModHelper.EnableSpecialSlot(item9);
            GunHelper.InitGun(gameItem, 24, 35, 40, 80, 45, 28, 22, 50, false);
            GunHelper.SetEquipmentCondition(gameItem, ItemFeatureList.EquipmentCondition.New);

            return gameItem;
        }

        public static GameItem CybersunPen()
        {
            // Inherits screwdriver. Did you know you can use a cybersun pen as a screwdriver in ss14? Now you do!
            GameItem gameItem = DirectoryMaster.Item("screwdriver");
            gameItem.identifier = "cybersun_pen";
            gameItem.SetSpriteAndShapeFromMod("probably_nuclear", gameItem.identifier);
            gameItem.SetName(ModHelper.GetLocalized("probably_nuclear", "item_cybersun_pen"));
            gameItem.SetGameItemType("LUXURY_ITEM");
            gameItem.SetValue(90L);
            gameItem.shortDescription = ModHelper.GetLocalized("probably_nuclear", "item_cybersun_pen_desc");
            gameItem.flavorText = ModHelper.GetLocalized("probably_nuclear", "item_cybersun_pen_flavor");
            gameItem.EnableManufacturer("cybersun");
            ContrabandHelper.InitContrabandItem(gameItem, 2);

            return gameItem;
        }

        public static GameItem Emag()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("emag");
            gameItem.SetSpriteAndShapeFromMod("probably_nuclear", gameItem.identifier);
            gameItem.SetName(ModHelper.GetLocalized("probably_nuclear", "item_emag"));
            gameItem.SetValue(175L);
            gameItem.flavorText = ModHelper.GetLocalized("probably_nuclear", "item_emag_flavor");
            gameItem.shortDescription = ModHelper.GetLocalized("probably_nuclear", "item_emag_desc");
            gameItem.SetGameItemType("ACCESS_CARD");
            gameItem.EnableManufacturer("self");
            AudioHelper.InitPlasticCard(gameItem);
            ContrabandHelper.InitContrabandItem(gameItem, 4);

            gameItem.maySelectSlotItemFunc = (GameItem _, GameInventory _, SlotMarker _) => true;
            gameItem.canSelectSlotItemFunc = (GameItem item, GameInventory _, SlotMarker _) => true;
            gameItem.mayItemTargetItemFunc = (GameItem s, GameItem t) => GeneralHelper.IsItemOwned(s) && GeneralHelper.IsItemOwned(t) && LockHelper.IsLockedContainer(t);
            gameItem.canItemTargetItemFunc = (GameItem s, GameItem t) => GeneralHelper.IsItemOwned(s) && GeneralHelper.IsItemOwned(t) && LockHelper.IsLockedContainer(t);
            gameItem.onItemTargetItemFunc = delegate (GameItem s, GameItem t)
            {
                LockHelper.TryOpenLock(s, t, "LOCK_ID_EMAG");
            };

            return gameItem;
        }

        public static GameItem EnergySword()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("energy_sword");
            gameItem.SetSpriteAndShapeFromMod("probably_nuclear", gameItem.identifier);
            gameItem.SetName(ModHelper.GetLocalized("probably_nuclear", "item_energy_sword"));
            gameItem.SetGameItemType("WEAPON");
            gameItem.SetGameItemType("MELEE_WEAPON");
            gameItem.SetValue(350L);
            gameItem.flavorText = ModHelper.GetLocalized("probably_nuclear", "item_energy_sword_flavor");
            gameItem.EnableManufacturer("gorlex");
            ContrabandHelper.InitContrabandItem(gameItem, 3);

            return gameItem;
        }

        public static GameItem HoloparasiteInjector()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("holoparasite_injector");
            gameItem.SetSpriteAndShapeFromMod("probably_nuclear", gameItem.identifier);
            gameItem.SetName(ModHelper.GetLocalized("probably_nuclear", "item_holoparasite_injector"));
            gameItem.SetGameItemType("WEAPON");
            gameItem.SetGameItemType("MEDICAL");
            gameItem.EnableTag("ITEM_MEDICAL_TAG");
            gameItem.SetValue(320L);
            gameItem.flavorText = ModHelper.GetLocalized("probably_nuclear", "item_holoparasite_injector_flavor");
            gameItem.EnableManufacturer("cybersun");
            ContrabandHelper.InitContrabandItem(gameItem, 3);

            return gameItem;
        }

        public static GameItem HyperzineInjector()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("hyperzine_injector");
            gameItem.SetSpriteAndShapeFromMod("probably_nuclear", gameItem.identifier);
            gameItem.SetName(ModHelper.GetLocalized("probably_nuclear", "item_hyperzine_injector"));
            gameItem.SetGameItemType("MEDICAL");
            gameItem.SetGameItemType("NARCOTIC");
            gameItem.EnableTag("ITEM_MEDICAL_TAG");
            gameItem.EnableTag("injector");
            gameItem.SetValue(85L);
            gameItem.flavorText = ModHelper.GetLocalized("probably_nuclear", "item_hyperzine_injector_flavor");
            gameItem.EnableManufacturer("interdyne");
            AudioHelper.InitInjectorAudio(gameItem);
            ContrabandHelper.InitContrabandItem(gameItem, 2);

            return gameItem;
        }

        public static GameItem Implanter()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("implanter");
            gameItem.SetSpriteAndShapeFromMod("probably_nuclear", gameItem.identifier);
            gameItem.SetName(ModHelper.GetLocalized("probably_nuclear", "item_implanter"));
            gameItem.SetGameItemType("MEDICAL");
            gameItem.EnableTag("ITEM_MEDICAL_TAG");
            gameItem.SetValue(160L);
            gameItem.flavorText = ModHelper.GetLocalized("probably_nuclear", "item_implanter_flavor");
            gameItem.EnableManufacturer("cybersun");
            AudioHelper.InitInjectorAudio(gameItem);
            ContrabandHelper.InitContrabandItem(gameItem, 2);

            return gameItem;
        }

        public static GameItem InterdyneHerbals()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("interdyne_herbals");
            gameItem.SetSpriteAndShapeFromMod("probably_nuclear", gameItem.identifier);
            gameItem.SetName(ModHelper.GetLocalized("probably_nuclear", "item_interdyne_herbals"));
            gameItem.EnableTag("CIGARETTE_TAG");
            gameItem.SetGameItemType("SUBSTANCE");
            gameItem.SetValue(75L);
            gameItem.flavorText = ModHelper.GetLocalized("probably_nuclear", "item_interdyne_herbals_flavor");
            gameItem.EnableManufacturer("interdyne");
            ContrabandHelper.InitContrabandItem(gameItem, 1);
            ConsumableHelper.InitNicotine(gameItem, 3);

            return gameItem;
        }

        public static GameItem Minibomb()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("minibomb");
            gameItem.SetSpriteAndShapeFromMod("probably_nuclear", gameItem.identifier);
            gameItem.SetName(ModHelper.GetLocalized("probably_nuclear", "item_minibomb"));
            gameItem.SetGameItemType("WEAPON");
            gameItem.SetGameItemType("MUNITION");
            gameItem.SetValue(110L);
            gameItem.flavorText = ModHelper.GetLocalized("probably_nuclear", "item_minibomb_flavor");
            AudioHelper.InitGrenade(gameItem);
            ContrabandHelper.InitContrabandItem(gameItem, 3);

            return gameItem;
        }

        public static GameItem NukeDisk()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("nuke_disk");
            gameItem.SetSpriteAndShapeFromMod("probably_nuclear", gameItem.identifier);
            gameItem.SetName(ModHelper.GetLocalized("probably_nuclear", "item_nuke_disk"));
            gameItem.EnableTag("IMPORTANT_TAG");
            gameItem.flavorText = ModHelper.GetLocalized("probably_nuclear", "item_nuke_disk_flavor");
            AudioHelper.InitCassette(gameItem);
            ContrabandHelper.InitContrabandItem(gameItem, 4);

            return gameItem;
        }

        public static GameItem SuspiciousToolbox()
        {
            GameItem gameItem = DirectoryMaster.Item("toolbox");
            gameItem.identifier = "suspicious_toolbox";
            gameItem.SetSpriteAndShapeFromMod("probably_nuclear", "suspicious_toolbox_old");
            gameItem.SetName(ModHelper.GetLocalized("probably_nuclear", "item_suspicious_toolbox"));
            gameItem.SetGameItemType("WEAPON");
            gameItem.SetValue(175L);
            gameItem.flavorText = ModHelper.GetLocalized("probably_nuclear", "item_suspicious_toolbox_flavor");
            ContrabandHelper.InitContrabandItem(gameItem, 2);

            return gameItem;
        }

        public static GameItem SyndicateBox()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("syndicate_box");
            gameItem.SetSpriteAndShapeFromMod("probably_nuclear", gameItem.identifier);
            gameItem.SetName(ModHelper.GetLocalized("probably_nuclear", "item_syndicate_box"));
            gameItem.SetValue(325L);
            gameItem.shortDescription = ModHelper.GetLocalized("probably_nuclear", "item_syndicate_box_desc");
            gameItem.flavorText = ModHelper.GetLocalized("probably_nuclear", "item_syndicate_box_flavor");
            ContrabandHelper.InitContrabandItem(gameItem, 4);

            (PixelWindow, GameInventory) tuple = DirectoryUtils.CreateInventoryWindow(7, 5);
            PixelWindow item = tuple.Item1;
            GameInventory item2 = tuple.Item2;
            gameItem.SetContentWindow(item);
            LockHelper.InitLockedContainerItem(gameItem, "LOCK_ID_SYNDICATE", item2);

            return gameItem;
        }

        public static GameItem SyndicateBusinessCard()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("syndicate_business_card");
            gameItem.SetSpriteAndShapeFromMod("probably_nuclear", gameItem.identifier);
            gameItem.SetName(ModHelper.GetLocalized("probably_nuclear", "item_syndicate_business_card"));
            gameItem.EnableTag("IMPORTANT_TAG");
            gameItem.SetGameItemType("DOCUMENT");
            gameItem.flavorText = ModHelper.GetLocalized("probably_nuclear", "item_syndicate_business_card_flavor");
            AudioHelper.InitCartonCard(gameItem);

            //gameItem.canActivateSlotItemFunc = (GameItem _, GameInventory _, SlotMarker _) => true;
            //gameItem.mayActivateSlotItemFunc = (GameItem _, GameInventory _, SlotMarker _) => true;

            //ModPaperUI ui = new();
            //gameItem.onActivateSlotItemFunc = delegate
            //{

            //    ui.ToggleSyndicateCard();
            //};



            return gameItem;
        }

        public static GameItem SyndicateGasMask()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("syndicate_gas_mask");
            gameItem.identifier = "syndicate_gas_mask";
            gameItem.SetSpriteAndShapeFromMod("probably_nuclear", gameItem.identifier);
            gameItem.SetName(ModHelper.GetLocalized("probably_nuclear", "item_syndicate_gas_mask"));
            gameItem.SetGameItemType("ARMOR");
            gameItem.SetValue(120L);
            gameItem.flavorText = ModHelper.GetLocalized("probably_nuclear", "item_syndicate_gas_mask_flavor");
            AudioHelper.InitArmour(gameItem);
            ContrabandHelper.InitContrabandItem(gameItem, 2);

            return gameItem;
        }

        public static GameItem SyndicateSoap()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("syndicate_soap");
            gameItem.SetSpriteAndShapeFromMod("probably_nuclear", gameItem.identifier);
            gameItem.SetName(ModHelper.GetLocalized("probably_nuclear", "item_syndicate_soap"));
            gameItem.SetValue(20L);
            gameItem.flavorText = ModHelper.GetLocalized("probably_nuclear", "item_syndicate_soap_flavor");
            gameItem.SetGameItemType("HOUSEHOLD_GOOD");
            gameItem.EnableManufacturer("donk");
            AudioHelper.InitSoftPlasticItem(gameItem);
            ContrabandHelper.InitContrabandItem(gameItem, 1);

            return gameItem;
        }

        public static GameItem Telecrystal()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("telecrystal");
            gameItem.SetSpriteAndShapeFromMod("probably_nuclear", gameItem.identifier);
            gameItem.SetName(ModHelper.GetLocalized("probably_nuclear", "item_telecrystal"));
            gameItem.SetValue(25L);
            gameItem.flavorText = ModHelper.GetLocalized("probably_nuclear", "item_telecrystal_flavor");
            AudioHelper.InitGunMod(gameItem);
            ContrabandHelper.InitContrabandItem(gameItem, 2);

            return gameItem;
        }

        public static GameItem ThrowingKnife()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("throwing_knife");
            gameItem.SetSpriteAndShapeFromMod("probably_nuclear", gameItem.identifier);
            gameItem.SetName(ModHelper.GetLocalized("probably_nuclear", "item_throwing_knife"));
            gameItem.SetValue(80L);
            gameItem.flavorText = ModHelper.GetLocalized("probably_nuclear", "item_throwing_knife_flavor");
            gameItem.SetGameItemType("WEAPON");
            AudioHelper.InitBlade(gameItem);
            ContrabandHelper.InitContrabandItem(gameItem, 2);

            return gameItem;
        }

        public static GameItem Uplink()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("uplink");
            gameItem.SetSpriteAndShapeFromMod("probably_nuclear", gameItem.identifier);
            gameItem.SetName(ModHelper.GetLocalized("probably_nuclear", "item_uplink"));
            gameItem.SetValue(300L);
            gameItem.shortDescription = ModHelper.GetLocalized("probably_nuclear", "item_uplink_desc");
            gameItem.flavorText = ModHelper.GetLocalized("probably_nuclear", "item_uplink_flavor");
            gameItem.EnableTag("STANDARD_MACHINE_TAG");
            AudioHelper.InitPlasticMachinery(gameItem);
            ContrabandHelper.InitContrabandItem(gameItem, 3);

            // ModMachines.CreateUplinkMachine(gameItem);

            return gameItem;
        }
    }
}