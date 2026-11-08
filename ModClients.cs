using System;

namespace ProbablyNuclear
{
    public class ModClients
    {
        public static void CreateClients(StoreClientManager manager)
        {
            if (StoreReputation.GetBMReputation() >= 40 &&
                StoreStation.Instance.dayCounter >= 14 &&
                StoreStation.Instance.dayCounter % 2 == 0 &&
                RNG.Roll(Math.Clamp(15 + (StoreReputation.GetBMReputation() / 2), 0, 50)))
            {
                manager.AddClient(CreateExSyndicateAgent());
            }
        }

        public static StoreClient CreateExSyndicateAgent()
        {
            StoreClient storeClient = new StoreClient();
            storeClient.identifier = "ex_syndicate_agent";
            storeClient.displayName = ModLoc.Localize("name_ex_syndicate_agent");
            storeClient.clientFaction = "FACTION_BLACK_MARKET";
            storeClient.spriteName = SpriteDict.GetRandomMercSpriteName();
            storeClient.clientIntent = StoreClient.ClientIntent.SELL;
            storeClient.mainDialogue
                .SetText(storeClient.displayName, ModLoc.Localize("dialog_ex_syndicate_agent_1"))
                .NextDialogue()
                .SetText(storeClient.displayName, ModLoc.Localize("dialog_ex_syndicate_agent_2"))
                .SetEndAction(delegate
                {
                    PlayerStore.Instance.AddDirectSellingItemToTable(DirectoryMaster.Item("uplink"));

                    // 3 to 9 TC, lower rolls favoured
                    PlayerStore.Instance.AddDirectSellingItemToTable(DirectoryMaster.Item("telecrystal"));
                    PlayerStore.Instance.AddDirectSellingItemToTable(DirectoryMaster.Item("telecrystal"));
                    PlayerStore.Instance.AddDirectSellingItemToTable(DirectoryMaster.Item("telecrystal"));
                    if (RNG.Roll(60))
                        PlayerStore.Instance.AddDirectSellingItemToTable(DirectoryMaster.Item("telecrystal"));
                    if (RNG.Roll(50))
                        PlayerStore.Instance.AddDirectSellingItemToTable(DirectoryMaster.Item("telecrystal"));
                    if (RNG.Roll(30))
                        PlayerStore.Instance.AddDirectSellingItemToTable(DirectoryMaster.Item("telecrystal"));
                    if (RNG.Roll(20))
                        PlayerStore.Instance.AddDirectSellingItemToTable(DirectoryMaster.Item("telecrystal"));
                    if (RNG.Roll(10))
                        PlayerStore.Instance.AddDirectSellingItemToTable(DirectoryMaster.Item("telecrystal"));
                    if (RNG.Roll(5))
                        PlayerStore.Instance.AddDirectSellingItemToTable(DirectoryMaster.Item("telecrystal"));

                    // 1 to 3 low-level loot
                    PlayerStore.Instance.AddDirectSellingItemToTable(ModPreBuiltItems.SyndicateLootLow());
                    if (RNG.Roll(50))
                        PlayerStore.Instance.AddDirectSellingItemToTable(ModPreBuiltItems.SyndicateLootLow());
                    if (RNG.Roll(25))
                        PlayerStore.Instance.AddDirectSellingItemToTable(ModPreBuiltItems.SyndicateLootLow());

                    // 0 to 1 mid-level loot, lower rolls favoured
                    PlayerStore.Instance.AddDirectSellingItemToTable(ModPreBuiltItems.SyndicateLootMid());
                    if (RNG.Roll(20))
                        PlayerStore.Instance.AddDirectSellingItemToTable(ModPreBuiltItems.SyndicateLootMid());
                });

            storeClient.AddBasicDialog();
            storeClient.CompleteClientCreation();
            return storeClient;
        }
    }
}
