
using Il2Cpp;

namespace ProbablyNuclear
{
    public class ModPreBuiltItems
    {
        public static GameItem LootCrateSyndicate()
        {
            GameItem gameItem = Items.SyndicateBox();
            GraphNodeStorage box = new GraphNodeStorage(gameItem.Pointer);


            // Guarantee at least 1 high value item
            if (RNG.Roll(50))
                GraphUtils.TryAcceptAll(box, Items.HoloparasiteInjector());
            else
                GraphUtils.TryAcceptAll(box, Items.EnergySword());

            // Pick from 1 large item as to not fill the whole box
            if (RNG.Roll(30))
                GraphUtils.TryAcceptAll(box, Items.Cobra());
            else if (RNG.Roll(50))
                GraphUtils.TryAcceptAll(box, Items.SyndicateGasMask());
            else
                GraphUtils.TryAcceptAll(box, DirectoryMaster.Item("c4"));

            if (RNG.Roll(40))
                GraphUtils.TryAcceptAll(box, Items.ThrowingKnife());
            if (RNG.Roll(40))
                GraphUtils.TryAcceptAll(box, Items.HyperzineInjector());
            if (RNG.Roll(25))
                GraphUtils.TryAcceptAll(box, Items.HyperzineInjector());
            if (RNG.Roll(15))
                GraphUtils.TryAcceptAll(box, Items.HyperzineInjector());
            if (RNG.Roll(40))
                GraphUtils.TryAcceptAll(box, Items.Implanter());
            if (RNG.Roll(40))
                GraphUtils.TryAcceptAll(box,Items.CybersunPen());
            if (RNG.Roll(90))
                GraphUtils.TryAcceptAll(box, Items.InterdyneHerbals());
            if (RNG.Roll(50))
                GraphUtils.TryAcceptAll(box, Items.Minibomb());
            if (RNG.Roll(25))
                GraphUtils.TryAcceptAll(box, Items.Minibomb());
            if (RNG.Roll(80))
                GraphUtils.TryAcceptAll(box, Items.SyndicateSoap());

            GraphUtils.TryAcceptAll(box, Items.Telecrystal());
            if (RNG.Roll(85))
                GraphUtils.TryAcceptAll(box, Items.Telecrystal());
            if (RNG.Roll(60))
                GraphUtils.TryAcceptAll(box, Items.Telecrystal());
            if (RNG.Roll(35))
                GraphUtils.TryAcceptAll(box, Items.Telecrystal());
            if (RNG.Roll(20))
                GraphUtils.TryAcceptAll(box, Items.Telecrystal());
            if (RNG.Roll(5))
                GraphUtils.TryAcceptAll(box, Items.Telecrystal());
            if (RNG.Roll(40))
                GraphUtils.TryAcceptAll(box, DirectoryMaster.Item("smoke_grenade"));
            if (RNG.Roll(50))
                GraphUtils.TryAcceptAll(box, DirectoryMaster.Item("heavy_pistol_ammo"));
            if (RNG.Roll(25))
                GraphUtils.TryAcceptAll(box, DirectoryMaster.Item("heavy_pistol_ammo"));
            if (RNG.Roll(40))
                GraphUtils.TryAcceptAll(box, DirectoryMaster.Item("heavy_pistol_ammo_p"));
            if (RNG.Roll(15))
                GraphUtils.TryAcceptAll(box, DirectoryMaster.Item("heavy_pistol_ammo_p"));
            if (RNG.Roll(60))
                GraphUtils.TryAcceptAll(box, DirectoryMaster.Item("zyanide_pill"));

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
                <= 80 => Items.SyndicateGasMask(),
                _ => Items.Implanter()
            };
        }

        public static GameItem SyndicateLootHigh()
        {
            int rng = RNG.GetRandomInt(1, 100);

            return rng switch
            {
                <= 15 => Items.Minibomb(),
                <= 35 => Items.HoloparasiteInjector(),
                <= 60 => Items.Cobra(),
                <= 85 => Items.EnergySword(),
                _ => Items.Emag(),
            };
        }
    }
}