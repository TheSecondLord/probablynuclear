using Il2Cpp;

namespace ProbablyNuclear
{
    public class ModClients
    {
        public static StoreClient CreateExSyndicateAgent()
        {
            StoreClient storeClient = new StoreClient();
            storeClient.identifier = "ex_syndicate_agent";
            storeClient.displayName = "Ex-Syndicate Agent";
            storeClient.clientFaction = "FACTION_BLACK_MARKET";
            storeClient.spriteName = SpriteDict.GetRandomMercSpriteName();
            storeClient.clientIntent = StoreClient.ClientIntent.SELL;
            storeClient.mainDialogue
                .SetText(storeClient.displayName, "I don't need these anymore, but I heard that you might.")
                .NextDialogue()
                .SetText(storeClient.displayName, "Don't let it fall into the wrong hands. If you do, They'll know.")
                .SetEndAction((Action)delegate
                {
                    PlayerStore.Instance.AddDirectSellingItemToTable(ModPreBuiltItems.LootCrateSyndicate());
                    PlayerStore.Instance.AddDirectSellingItemToTable(Items.Emag());
                    PlayerStore.Instance.AddDirectSellingItemToTable(Items.Uplink());
                    if (RNG.Roll(50))
                        PlayerStore.Instance.AddDirectSellingItemToTable(Items.Emag());

                    // 1 to 6 TC, lower rolls favoured
                    PlayerStore.Instance.AddDirectSellingItemToTable(Items.Telecrystal());
                    if (RNG.Roll(50))
                        PlayerStore.Instance.AddDirectSellingItemToTable(Items.Telecrystal());
                    if (RNG.Roll(33))
                        PlayerStore.Instance.AddDirectSellingItemToTable(Items.Telecrystal());
                    if (RNG.Roll(25))
                        PlayerStore.Instance.AddDirectSellingItemToTable(Items.Telecrystal());
                    if (RNG.Roll(15))
                        PlayerStore.Instance.AddDirectSellingItemToTable(Items.Telecrystal());
                    if (RNG.Roll(8))
                        PlayerStore.Instance.AddDirectSellingItemToTable(Items.Telecrystal());

                    // 1 to 3 low-level loot
                    PlayerStore.Instance.AddDirectSellingItemToTable(ModPreBuiltItems.SyndicateLootLow());
                    if (RNG.Roll(66))
                        PlayerStore.Instance.AddDirectSellingItemToTable(ModPreBuiltItems.SyndicateLootLow());
                    if (RNG.Roll(33))
                        PlayerStore.Instance.AddDirectSellingItemToTable(ModPreBuiltItems.SyndicateLootLow());

                    // 1 to 3 mid-level loot, lower rolls favoured
                    PlayerStore.Instance.AddDirectSellingItemToTable(ModPreBuiltItems.SyndicateLootMid());
                    if (RNG.Roll(50))
                        PlayerStore.Instance.AddDirectSellingItemToTable(ModPreBuiltItems.SyndicateLootMid());
                    if (RNG.Roll(20))
                        PlayerStore.Instance.AddDirectSellingItemToTable(ModPreBuiltItems.SyndicateLootMid());

                    // 20% change high-level loot
                    if (RNG.Roll(20))
                        PlayerStore.Instance.AddDirectSellingItemToTable(ModPreBuiltItems.SyndicateLootHigh());
                });

            storeClient.AddBasicDialog();
            storeClient.CompleteClientCreation();
            return storeClient;
        }
    }
}
