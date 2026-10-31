namespace ProbablyNuclear
{
    /// <summary>
    /// Entry point of the mod. The loader finds the one class implementing IMod, creates it,
    /// applies the [HarmonyPatch] classes of this assembly, then calls Init and OnEnable.
    /// All of that happens in the main menu: no save is loaded yet, so do not touch game
    /// state here. Subscribe to ModHook events instead (see ModdingGuide.md, "Hook Points").
    /// </summary>
    public class ModEntry : IMod
    {
        public static ModEntry Instance { get; private set; }
        public ModManifest Manifest { get; private set; }
        public ModLog Log { get; private set; }

        public void Init(ModManifest manifest)
        {
            Instance = this;
            Manifest = manifest;
            Log = new ModLog(manifest);
            Log.Log($"{manifest.Name} v{manifest.ModVersion} loaded.");
        }

        public void OnEnable()
        {
            // Runs right after Init, still in the main menu. Register hooks, items, loot edits,
            // options and configuration here. Examples:
            //   ModHook.OnGameLoadedInit += OnGameLoaded;
            //   ModHelper.AddLootEntry(Manifest.ID, "junkTable", "my_item", 10);

            ModHook.OnModItemDirectoryInit += ModItems.CreateItems;

            ModHook.OnCreateTooltipEarly += ModCorpos.DisplayCorpo;

            ModHook.OnGenerateCustomerNormal += ModClients.CreateClients;

            ModHelper.AddDebugFunction("probably_nuclear", ModHelper.DEBUG_CATEGORY_SPAWN, "Spawn ProbablyNuclear Crate Kit", ModDebug.SpawnCrates);
            ModHelper.AddDebugFunction("probably_nuclear", ModHelper.DEBUG_CATEGORY_SPAWN, "Spawn ProbablyNuclear Items", ModDebug.SpawnItems);

            Log.Log("Probably Nuclear Enabled.");
        }

        public void OnDisable()
        {
            // Runs when the game shuts down. Unsubscribe what you subscribed in OnEnable.
            //   ModHook.OnGameLoadedInit -= OnGameLoaded;
            ModHook.OnModItemDirectoryInit -= ModItems.CreateItems;
            ModHook.OnCreateTooltipEarly -= ModCorpos.DisplayCorpo;
            ModHook.OnGenerateCustomerNormal -= ModClients.CreateClients;
            ModHelper.RemoveDebugFunctions("probably_nuclear");
            Log.Log("Probably Nuclear Disabled.");

        }

        // private void OnGameLoaded()
        // {
        //      A save is loaded: game systems exist from here on.
        // }
    }
}
