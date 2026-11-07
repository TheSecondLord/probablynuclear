using HarmonyLib;

namespace ProbablyNuclear
{
    [HarmonyPatch(typeof(GunHelper), nameof(GunHelper.DisassembleWeapon))]
    public static class GunDeconstructPatch
    {
        static void Postfix(ref GameItem targetItem)
        {
            GameInventory parentInventory = targetItem.parentInventory;

            if (targetItem.IsID("cobra"))
            {
                GraphUtils.EmporiumTryAdd(parentInventory, DirectoryMaster.Item("gun_part"));
                GraphUtils.EmporiumTryAdd(parentInventory, DirectoryMaster.Item("gun_part"));
                GraphUtils.EmporiumTryAdd(parentInventory, DirectoryMaster.Item("gun_part"));
                GraphUtils.EmporiumTryAdd(parentInventory, DirectoryMaster.Item("gun_part"));
            }
            else if (targetItem.IsID("smg"))
            {
                GraphUtils.EmporiumTryAdd(parentInventory, DirectoryMaster.Item("gun_part"));
                GraphUtils.EmporiumTryAdd(parentInventory, DirectoryMaster.Item("gun_part"));
                GraphUtils.EmporiumTryAdd(parentInventory, DirectoryMaster.Item("gun_part"));
                GraphUtils.EmporiumTryAdd(parentInventory, DirectoryMaster.Item("gun_part"));
                GraphUtils.EmporiumTryAdd(parentInventory, DirectoryMaster.Item("gun_part"));
                GraphUtils.EmporiumTryAdd(parentInventory, DirectoryMaster.Item("gun_part"));
            }
        }
    }
}
