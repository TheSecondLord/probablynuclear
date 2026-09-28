using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using UnityEngine;
using System.Reflection;
namespace ProbablyNuclear
{
    public class Items
    {
        public static GameItem ModdedShape(ref GameItem item, string path)
        {
            path += ".png";
            Sprite sprite = LoadEmbeddedPng(path);
            item.TryCast<GameItemElement>().background.image.sprite = sprite;
            item.TryCast<GameItemElement>().background.image.SetNativeSize();
            item.TryCast<GameItemElement>().fakeBackground.image.sprite = item.TryCast<GameItemElement>().background.image.sprite;
            item.TryCast<GameItemElement>().fakeBackground.image.SetNativeSize();

            item.spriteAtlasPath = "ModdedPath/";
            item.spritePath = path;
            Rect rect = sprite.rect;
            int gridSize = UISettings.current.gridSize;
            int mipLevel = (int)Math.Sqrt((double)gridSize);
            int num = (int)rect.width / gridSize;
            int num2 = (int)rect.height / gridSize;
            byte[] array = new byte[num * num2];
            for (int i = 0; i < num2; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    int num3 = i * num + j;

                    int x = (int)rect.xMin / gridSize + j;
                    int y = (int)rect.yMin / gridSize + (num2 - 1 - i);
                    if (sprite.texture.GetPixel(x, y, mipLevel).a > 0f)
                    {
                        array[num3] = 1;
                    }
                }
            }
            GridShapeBuilder gridShapeBuilder = new GridShapeBuilder().SetData(array, num);
            GridShape finalShape = new GridShape(gridShapeBuilder.Pointer);
            item.SetShape(finalShape);
            return item;
        }

        public static Sprite LoadEmbeddedPng(string resourceSuffix)
        {
            Assembly assembly = typeof(Core).Assembly;
            string text = null;
            foreach (string text2 in assembly.GetManifestResourceNames())
            {
                MelonLogger.Msg("Searched " + text2);
                if (text2.EndsWith(resourceSuffix, StringComparison.OrdinalIgnoreCase))
                {
                    text = text2;
                    break;
                }
            }
            if (text == null)
            {
                MelonLogger.Warning("Embedded icon '" + resourceSuffix + "' was not found.");
                return null;
            }
            Sprite result;
            using (Stream manifestResourceStream = assembly.GetManifestResourceStream(text))
            {
                if (manifestResourceStream == null)
                {
                    return null;
                }


                byte[] array = new byte[manifestResourceStream.Length];
                if (manifestResourceStream.Read(array, 0, array.Length) <= 0)
                {
                    result = null;
                }
                else
                {
                    Texture2D texture2D = new Texture2D(2, 2, TextureFormat.RGBA32, false, false)
                    {
                        filterMode = FilterMode.Point,
                        wrapMode = TextureWrapMode.Clamp,
                        hideFlags = HideFlags.HideAndDontSave
                    };
                    if (!ImageConversion.LoadImage(texture2D, array))
                    {
                        UnityEngine.Object.Destroy(texture2D);
                        MelonLogger.Warning("Failed to decode icon '" + resourceSuffix + "'.");
                        result = null;
                    }
                    else
                    {
                        Sprite sprite = Sprite.Create(texture2D, new Rect(0f, 0f, (float)texture2D.width, (float)texture2D.height), new Vector2(0.5f, 0.5f));
                        sprite.hideFlags = HideFlags.HideAndDontSave;
                        result = sprite;
                    }

                }
            }
            return result;
        }
          
        public static GameItem Cobra()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("cobra");
            ModdedShape(ref gameItem, gameItem.identifier);
            gameItem.SetName("Cobra");
            gameItem.shortDescription = "Has a built-in silencer. Chambered in custom-made 10mm Caseless ammunition.";
            gameItem.flavorText = "A silenced pistol designed for stealthy assassinations.";
            gameItem.EnableManufacturer("spacer");
            gameItem.SetGameItemType("WEAPON");
            gameItem.SetGameItemType("FIREARM");
            gameItem.SetValue(225L);
            gameItem.EnableManufacturer("waffle");
            ContrabandHelper.InitContrabandItem(gameItem, 3);
            AudioHelper.InitGun(gameItem);
            return gameItem;
        }

        public static GameItem CybersunPen()
        {
            // Inherits screwdriver. Did you know you can use a cybersun pen as a screwdriver in ss14? Now you do!
            GameItem gameItem = DirectoryMaster.Item("screwdriver");
            gameItem.identifier = "cybersun_pen";
            ModdedShape(ref gameItem, gameItem.identifier);
            gameItem.SetName("Cybersun Pen");
            gameItem.SetGameItemType("LUXURY_ITEM");
            gameItem.SetValue(90L);
            gameItem.shortDescription = "Functions as a screwdriver.";
            gameItem.flavorText = "Uses advanced technology and a hardlight tip to erase ink and forge documents.";
            gameItem.EnableManufacturer("cybersun");
            ContrabandHelper.InitContrabandItem(gameItem, 2);

            return gameItem;
        }

        public static GameItem Emag()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("emag");
            ModdedShape(ref gameItem, gameItem.identifier);
            gameItem.SetName("EMAG");
            gameItem.SetValue(175L);
            gameItem.flavorText = "The Syndicate's iconic EMAG, created from a hacked ID card.";
            gameItem.shortDescription = "Opens all locks, no exceptions.";
            gameItem.SetGameItemType("ACCESS_CARD");
            gameItem.EnableManufacturer("self");
            AudioHelper.InitPlasticCard(gameItem);
            ContrabandHelper.InitContrabandItem(gameItem, 4);

            //gameItem.maySelectSlotItemFunc = (GameItem item, GameInventory _, SlotMarker _) => true;
            //gameItem.canSelectSlotItemFunc = (GameItem item, GameInventory _, SlotMarker _) => true;
            //gameItem.mayItemTargetItemFunc = (GameItem s, GameItem t) => GeneralHelper.IsItemOwned(s) && GeneralHelper.IsItemOwned(t) && LockHelper.IsLockedContainer(t);
            //gameItem.canItemTargetItemFunc = (GameItem s, GameItem t) => GeneralHelper.IsItemOwned(s) && GeneralHelper.IsItemOwned(t) && LockHelper.IsLockedContainer(t);
            /*
            gameItem.maySelectSlotItemFunc = (Func<GameItem, GameInventory, SlotMarker, bool>) delegate (GameItem _, GameInventory _, SlotMarker _) { return true; };
            gameItem.canSelectSlotItemFunc = (Func<GameItem, GameInventory, SlotMarker, bool>)delegate (GameItem _, GameInventory _, SlotMarker _) { return true; };
            gameItem.mayItemTargetItemFunc = (Func<GameItem, GameItem, bool>)delegate (GameItem s, GameItem t) 
            { 
                return GeneralHelper.IsItemOwned(s) && GeneralHelper.IsItemOwned(t) && LockHelper.IsLockedContainer(t); 
            };
            gameItem.canItemTargetItemFunc = (Func<GameItem, GameItem, bool>)delegate (GameItem s, GameItem t) 
            { 
                return GeneralHelper.IsItemOwned(s) && GeneralHelper.IsItemOwned(t) && LockHelper.IsLockedContainer(t); 
            };
            gameItem.onItemTargetItemFunc = (Action<GameItem, GameItem>)delegate (GameItem s, GameItem t)
            {
                LockHelper.TryOpenLock(s, t, "LOCK_ID_EMAG");
            };*/

            //EMAG either needs proper Delegate Support of to override the item on use.

            return gameItem;
        }

        public static GameItem EnergySword()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("energy_sword");
            ModdedShape(ref gameItem, gameItem.identifier);
            gameItem.SetName("Energy Sword");
            gameItem.SetGameItemType("WEAPON");
            gameItem.SetGameItemType("MELEE_WEAPON");
            gameItem.SetValue(350L);
            gameItem.flavorText = "An iconic weapon wielded by countless Syndicate operatives. Activating it would certainly attract unwanted attention.";
            gameItem.EnableManufacturer("gorlex");
            ContrabandHelper.InitContrabandItem(gameItem, 3);

            return gameItem;
        }

        public static GameItem HoloparasiteInjector()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("holoparasite_injector");
            ModdedShape(ref gameItem, gameItem.identifier);
            gameItem.SetName("Holoparasite Injector");
            gameItem.SetGameItemType("WEAPON");
            gameItem.SetGameItemType("MEDICAL");
            gameItem.EnableTag("ITEM_MEDICAL_TAG");
            gameItem.SetValue(320L);
            gameItem.flavorText = "The pride and joy of Cybersun. Embeds a bioengineered parasite below the skin capable of manifesting a hardlight guardian to defend its host.";
            gameItem.EnableManufacturer("cybersun");
            ContrabandHelper.InitContrabandItem(gameItem, 3);

            return gameItem;
        }

        public static GameItem HyperzineInjector()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("hyperzine_injector");
            ModdedShape(ref gameItem, gameItem.identifier);
            gameItem.SetName("Hyperzine Injector");
            gameItem.SetGameItemType("MEDICAL");
            gameItem.EnableTag("ITEM_MEDICAL_TAG");
            gameItem.EnableTag("injector");
            gameItem.SetValue(85L);
            gameItem.flavorText = "A powerful mixture of combat stimulants produces by Interdyne. Far more potent than Oxymore.";
            gameItem.EnableManufacturer("interdyne");
            AudioHelper.InitInjectorAudio(gameItem);
            ContrabandHelper.InitContrabandItem(gameItem, 2);

            return gameItem;
        }

        public static GameItem Implanter()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("implanter");
            ModdedShape(ref gameItem, gameItem.identifier);
            gameItem.SetName("Implanter");
            gameItem.SetGameItemType("MEDICAL");
            gameItem.EnableTag("ITEM_MEDICAL_TAG");
            gameItem.SetValue(160L);
            gameItem.flavorText = "Contains one of the Syndicate's wide range of subdermal implants.";
            gameItem.EnableManufacturer("cybersun");
            AudioHelper.InitInjectorAudio(gameItem);
            ContrabandHelper.InitContrabandItem(gameItem, 2);

            return gameItem;
        }

        public static GameItem InterdyneHerbals()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("interdyne_herbals");
            ModdedShape(ref gameItem, gameItem.identifier);
            gameItem.SetName("Interdyne Herbals");
            gameItem.EnableTag("CIGARETTE_TAG");
            gameItem.SetGameItemType("SUBSTANCE");
            gameItem.SetValue(75L);
            gameItem.flavorText = "Medicine-laced cigarettes, for agents who need to recover from fights and look cool doing so.";
            gameItem.EnableManufacturer("interdyne");
            ContrabandHelper.InitContrabandItem(gameItem, 1);
            ConsumableHelper.InitNicotine(gameItem, 3);

            return gameItem;
        }

        public static GameItem Minibomb()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("minibomb");
            ModdedShape(ref gameItem, gameItem.identifier);
            gameItem.SetName("Minibomb");
            gameItem.SetGameItemType("WEAPON");
            gameItem.SetGameItemType("MUNITION");
            gameItem.SetValue(110L);
            gameItem.flavorText = "An easily concealed grenade which creates a short-ranged yet devastatingly powerful explosion.";
            AudioHelper.InitGrenade(gameItem);
            ContrabandHelper.InitContrabandItem(gameItem, 3);

            return gameItem;
        }

        public static GameItem NukeDisk()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("nuke_disk");
            ModdedShape(ref gameItem, gameItem.identifier);
            gameItem.SetName("Nuke Disk");
            gameItem.EnableTag("IMPORTANT_TAG");
            gameItem.flavorText = "Are you sure that whatever you're doing is really worth it?";
            AudioHelper.InitCassette(gameItem);
            ContrabandHelper.InitContrabandItem(gameItem, 4);

            return gameItem;
        }

        public static GameItem SuspiciousToolbox()
        {
            GameItem gameItem = DirectoryMaster.Item("toolbox");
            gameItem.identifier = "suspicious_toolbox";
            ModdedShape(ref gameItem, "suspicious_toolbox_old");
            gameItem.SetName("Suspicious Toolbox");
            gameItem.SetGameItemType("WEAPON");
            gameItem.SetValue(175L);
            gameItem.flavorText = "Designed both for holding tools and for violently swinging at people's heads.";
            ContrabandHelper.InitContrabandItem(gameItem, 2);

            return gameItem;
        }

        public static GameItem SyndicateBox()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("syndicate_box");
            ModdedShape(ref gameItem, gameItem.identifier);
            gameItem.SetName("Syndicate Armory Crate");
            gameItem.SetValue(325L);
            gameItem.shortDescription = "A locked crate. Painted with the Syndicate logo. Full of supplies. Unlikely to be opened by any standard station keycards.";
            gameItem.flavorText = "A cache of highly illegal Syndicate gear. Possession alone is treason against the station.";
            ContrabandHelper.InitContrabandItem(gameItem, 4);

            Il2CppSystem.ValueTuple<PixelWindow, GameInventory> tuple = DirectoryUtils.CreateInventoryWindow(7, 5);
            PixelWindow item = tuple.Item1;
            GameInventory item2 = tuple.Item2;
            gameItem.SetContentWindow(item);
            LockHelper.InitLockedContainerItem(gameItem, "LOCK_ID_SYNDICATE", item2);

            return gameItem;
        }

        public static GameItem SyndicateBusinessCard()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("syndicate_business_card");
            ModdedShape(ref gameItem, gameItem.identifier);
            gameItem.SetName("Syndicate Business Card");
            gameItem.EnableTag("IMPORTANT_TAG");
            gameItem.SetGameItemType("DOCUMENT");
            gameItem.flavorText = "A slip of Syndicate-branded paper.";
            AudioHelper.InitCartonCard(gameItem);

            return gameItem;
        }

        public static GameItem SyndicateGasMask()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("syndicate_gas_mask");
            gameItem.identifier = "syndicate_gas_mask";
            ModdedShape(ref gameItem, gameItem.identifier);
            gameItem.SetName("Syndicate Gas Mask");
            gameItem.SetValue(120L);
            gameItem.flavorText = "The visor is made from a protective material capable of both resisting impacts and shielding the wearer from bright lights.";
            ContrabandHelper.InitContrabandItem(gameItem, 2);

            return gameItem;
        }

        public static GameItem SyndicateSoap()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("syndicate_soap");
            ModdedShape(ref gameItem, gameItem.identifier);
            gameItem.SetName("Syndicate Soap");
            gameItem.SetValue(20L);
            gameItem.flavorText = "A bar of scented soap. Deemed to be contraband for its Syndicate branding.";
            gameItem.SetGameItemType("HOUSEHOLD_GOOD");
            gameItem.EnableManufacturer("donk");
            AudioHelper.InitSoftPlasticItem(gameItem);
            ContrabandHelper.InitContrabandItem(gameItem, 1);

            return gameItem;
        }

        public static GameItem Telecrystal()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("telecrystal");
            ModdedShape(ref gameItem, gameItem.identifier);
            gameItem.SetName("Telecrystal");
            gameItem.SetValue(25L);
            gameItem.flavorText = "It hums with energy and glows a faint red.";
            ContrabandHelper.InitContrabandItem(gameItem, 2);

            return gameItem;
        }

        public static GameItem ThrowingKnife()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("throwing_knife");
            ModdedShape(ref gameItem, gameItem.identifier);
            gameItem.SetName("Throwing Knife");
            gameItem.SetValue(80L);
            gameItem.flavorText = "A lightweight knife with an aerodynamic design and a point sharp enough to pierce armor.";
            AudioHelper.InitBlade(gameItem);
            ContrabandHelper.InitContrabandItem(gameItem, 2);

            return gameItem;
        }

        public static GameItem Uplink()
        {
            GameItem gameItem = ItemDirectory.CreateEmptyItem("uplink");
            ModdedShape(ref gameItem, gameItem.identifier);
            gameItem.SetName("Uplink");
            gameItem.SetValue(300L);
            //gameItem.shortDescription = "Can be used to trade Telecrystals for high-value Syndicate items.";
            gameItem.flavorText = "An old radio, tuned into the Syndicate Uplink network.";
            gameItem.EnableTag("STANDARD_MACHINE_TAG");
            AudioHelper.InitPlasticMachinery(gameItem);
            ContrabandHelper.InitContrabandItem(gameItem, 3);

            return gameItem;
        }
    }
}