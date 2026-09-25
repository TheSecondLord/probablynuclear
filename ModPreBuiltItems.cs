
using Il2Cpp;
using MelonLoader;

namespace ProbablyNuclear
{
    public class ModPreBuiltItems
    {
        public static GameItem LootCrateSyndicate()
        {
            GameItem gameItem = Items.SyndicateBox();

            //GraphUtils.TryAcceptAll(gameItem.contentWindow.child, Items.HoloparasiteInjector());
            GraphNodeStorage box = new GraphNodeStorage(gameItem.Pointer);
            GraphUtils.TryAcceptAll(box , Items.HoloparasiteInjector());

            /*
            // Guarantee at least 1 high value item
            if (RNG.Roll(50))
                GraphUtils.TryAcceptAll(gameItem.contentWindow.child, Items.HoloparasiteInjector());
            else
                GraphUtils.TryAcceptAll(gameItem.children[0], Items.EnergySword());

            // Pick from 1 large item as to not fill the whole box
            if (RNG.Roll(30))
                GraphUtils.TryAcceptAll(gameItem.children[0], Items.Cobra());
            else if (RNG.Roll(50))
                GraphUtils.TryAcceptAll(gameItem.children[0], Items.SyndicateGasMask());
            else
                GraphUtils.TryAcceptAll(gameItem.children[0], DirectoryMaster.Item("c4"));

            if (RNG.Roll(40))
                GraphUtils.TryAcceptAll(gameItem.children[0], Items.ThrowingKnife());
            if (RNG.Roll(40))
                GraphUtils.TryAcceptAll(gameItem.children[0], Items.HyperzineInjector());
            if (RNG.Roll(25))
                GraphUtils.TryAcceptAll(gameItem.children[0], Items.HyperzineInjector());
            if (RNG.Roll(15))
                GraphUtils.TryAcceptAll(gameItem.children[0], Items.HyperzineInjector());
            if (RNG.Roll(40))
                GraphUtils.TryAcceptAll(gameItem.children[0], Items.Implanter());
            if (RNG.Roll(40))
                GraphUtils.TryAcceptAll(gameItem.children[0],Items.CybersunPen());
            if (RNG.Roll(90))
                GraphUtils.TryAcceptAll(gameItem.children[0], Items.InterdyneHerbals());
            if (RNG.Roll(50))
                GraphUtils.TryAcceptAll(gameItem.children[0], Items.Minibomb());
            if (RNG.Roll(25))
                GraphUtils.TryAcceptAll(gameItem.children[0], Items.Minibomb());
            if (RNG.Roll(80))
                GraphUtils.TryAcceptAll(gameItem.children[0], Items.SyndicateSoap());

            GraphUtils.TryAcceptAll(gameItem.children[0], Items.Telecrystal());
            if (RNG.Roll(85))
                GraphUtils.TryAcceptAll(gameItem.children[0], Items.Telecrystal());
            if (RNG.Roll(60))
                GraphUtils.TryAcceptAll(gameItem.children[0], Items.Telecrystal());
            if (RNG.Roll(35))
                GraphUtils.TryAcceptAll(gameItem.children[0], Items.Telecrystal());
            if (RNG.Roll(20))
                GraphUtils.TryAcceptAll(gameItem.children[0], Items.Telecrystal());
            if (RNG.Roll(5))
                GraphUtils.TryAcceptAll(gameItem.children[0], Items.Telecrystal());
            if (RNG.Roll(40))
                GraphUtils.TryAcceptAll(gameItem.children[0], DirectoryMaster.Item("smoke_grenade"));
            if (RNG.Roll(50))
                GraphUtils.TryAcceptAll(gameItem.children[0], DirectoryMaster.Item("heavy_pistol_ammo"));
            if (RNG.Roll(25))
                GraphUtils.TryAcceptAll(gameItem.children[0], DirectoryMaster.Item("heavy_pistol_ammo"));
            if (RNG.Roll(40))
                GraphUtils.TryAcceptAll(gameItem.children[0], DirectoryMaster.Item("heavy_pistol_ammo_p"));
            if (RNG.Roll(15))
                GraphUtils.TryAcceptAll(gameItem.children[0], DirectoryMaster.Item("heavy_pistol_ammo_p"));
            if (RNG.Roll(60))
                GraphUtils.TryAcceptAll(gameItem.children[0], DirectoryMaster.Item("zyanide_pill"));
            */
            LockHelper.LockUpContainer(gameItem);
            return gameItem;
        }

        public static GameItem SyndicateLootLow()
        {
            int rng = RNG.GetRandomInt(1, 100);

            return rng switch
            {
                <= 40 => Items.SyndicateSoap(),
                <= 60 => Items.HyperzineInjector(),
                <= 75 => Items.InterdyneHerbals(),
                <= 90 => Items.CybersunPen(),
                _ => Items.ThrowingKnife(),
            };
        }

        public static GameItem SyndicateLootMid()
        {
            int rng = RNG.GetRandomInt(1, 100);

            return rng switch
            {
                <= 30 => Items.Minibomb(),
                <= 45 => Items.HyperzineInjector(),
                <= 53 => Items.CybersunPen(),
                <= 61 => Items.ThrowingKnife(),
                <= 75 => Items.SyndicateGasMask(),
                <= 90 => Items.Implanter(),
                _ => Items.SuspiciousToolbox(),
            };
        }

        public static GameItem SyndicateLootHigh()
        {
            int rng = RNG.GetRandomInt(1, 100);

            return rng switch
            {
                <= 15 => Items.Minibomb(),
                <= 25 => Items.SuspiciousToolbox(),
                <= 45 => Items.HoloparasiteInjector(),
                <= 65 => Items.Cobra(),
                <= 85 => Items.EnergySword(),
                _ => Items.Emag(),
            };
        }
    }
}