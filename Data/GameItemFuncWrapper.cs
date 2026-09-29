using Il2Cpp;
using Il2CppInterop.Runtime;
using MelonLoader;

namespace ProbablyNuclear.Data
{
    public class GameItemFuncWrapper
    {

        public static void ApplyChangeWrapper(GameItem item)
        {
            if (item == null) return;

            var original = item.onSlotChangeAmountItemFunc;

            item.onSlotChangeAmountItemFunc =
                DelegateSupport.ConvertDelegate<Il2CppSystem.Action<GameItem, GameInventory, SlotMarker>>(
                    new System.Action<GameItem, GameInventory, SlotMarker>((itemInner, inv, slot) =>
                    {
                        original?.Invoke(itemInner, inv, slot);

                        try
                        {
                            if (itemInner != null && itemInner.isDebugMenu)
                                MelonCoroutines.Start(SetAmountNextFrame(itemInner));
                        }
                        catch (System.Exception e)
                        {
                            MelonLogger.Error("SlotChange hook failed: " + e);
                        }
                    }));
        }

        private static IEnumerator<GameItem> SetAmountNextFrame(GameItem item)
        {
            yield return null;

            if (item == null || item.WasCollected) yield break;

            MelonLogger.Msg($"Before: {item.unitCount}  ptr={item.Pointer}");
            item.SetAmount(2);
            MelonLogger.Msg($"After:  {item.unitCount}");
        }


    }
}

