using Il2Cpp;
using MelonLoader;
using System.Reflection;

[assembly: MelonInfo(typeof(ProbablyNuclear.Core), "ProbablyNuclear", "0.1.0", "Lord", null)]
[assembly: MelonGame("Questing Goose Studio", "Probably Stolen")]

namespace ProbablyNuclear;

public class Core : MelonMod
{
    public override void OnInitializeMelon()
    {
        LoggerInstance.Msg("Probably Nuclear initialized.");

        ModHook.OnCreateTooltipEarly += (Action<RichTextBuilder, GameItem>) delegate (RichTextBuilder builder, GameItem gameItem)
        {
            if (gameItem.IsTag("manufacturer"))
                ModCorpos.DisplayCorpo(builder, gameItem.GetTagReadonly("manufacturer").GetString());
        };

        ModHook.OnGenerateCustomerNormal += (Action<StoreClientManager>) delegate (StoreClientManager manager)
        {
            PlayerStore.Instance.ModCash(1000);
            Assembly assembly = typeof(Core).Assembly;

            /*
            if (StoreReputation.GetBMReputation() >= 40 &&
                StoreStation.Instance.dayCounter >= 14 &&
                StoreStation.Instance.dayCounter % 2 == 0 &&
                RNG.Roll(Math.Clamp(15 + (StoreReputation.GetBMReputation() / 2), 0, 50)))
            {
                StoreClient client = ModClients.CreateExSyndicateAgent();
                manager.AddClient(client);
            }
            */
            StoreClient client = ModClients.CreateExSyndicateAgent();
            manager.AddClient(client);
        };

    }
}