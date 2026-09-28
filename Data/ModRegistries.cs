using Il2Cpp;
using Il2CppInterop.Runtime;
using Il2CppNewtonsoft.Json.Serialization;
using Il2CppSystem.Reflection;
using MelonLoader;

#pragma warning disable CS0162
namespace ProbablyNuclear.Data
{
    internal class ModRegistries
    {

        private const bool DEBUGE = false;
        private static Il2CppSystem.Collections.Generic.List<GameItem> nuclearItems;

        public static Il2CppSystem.Collections.Generic.List<GameItem> NuclearItems { get => nuclearItems; private set => nuclearItems = value; }

        public static void Build()
        {
            NuclearItems = new Il2CppSystem.Collections.Generic.List<GameItem>();
            CalculateNuclearItems(NuclearItems);

        }


        private static void CalculateNuclearItems(Il2CppSystem.Collections.Generic.List<GameItem> items)
        {
            System.Reflection.MethodInfo[] itemsMethods = typeof(Items).GetMethods(
                System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Static);
            foreach (System.Reflection.MethodInfo method in itemsMethods)
            {
                if (method.ReturnType == typeof(GameItem) && method.GetParameters().Length == 0)
                {

                    if (DEBUGE)
                        MelonLogger.Msg($"Method: {method.Name} Return Type: {method.ReturnType}");

                    GameItem gameItem = (GameItem)method.Invoke(null, null);
                    if (gameItem != null)
                    {
                        items.Add(gameItem);
                    }

                }

            }
        }
    }
}

