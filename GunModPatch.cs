using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;

namespace ProbablyNuclear
{
    [HarmonyPatch(typeof(GunModDirectory), nameof(GunModDirectory.SetRDSMod))]
    public static class GunModPatchRDS
    {
        static void Postfix(ref GameItem parent, ref List<ItemSpriteModifier> list)
        {
            if (parent.IsID("c20r"))
                list.Add(new ItemSpriteModifier(RenderHandler.LoadFromAtlas("Items/items_mod", "rds_view2"), new Vector2(47f, -2f)));
        }
    }

    [HarmonyPatch(typeof(GunModDirectory), nameof(GunModDirectory.SetMakeshiftRDSMod))]
    public static class GunModPatchMakeshiftRDS
    {
        static void Postfix(ref GameItem parent, ref List<ItemSpriteModifier> list)
        {
            if (parent.IsID("c20r"))
                list.Add(new ItemSpriteModifier(RenderHandler.LoadFromAtlas("Items/items_mod", "rds_makeshift_view"), new Vector2(48f, -1f)));
        }
    }

    // Amba then got bored and started making these methods private for some reason
    [HarmonyPatch(typeof(GunModDirectory), "SetSilencerModShape")]
    public static class GunModPatchSilencerShape
    {
        static void Postfix(ref GameItem parent, ref GameItem item, ref GridShapeBuilder __result)
        {
            if (parent.IsID("c20r"))
                __result = new GridShapeBuilder().SetDataFill(item.modifiedShape.width, item.modifiedShape.height, 1).SetTransform(6, 1, flipped: false, 0);
        }
    }

    [HarmonyPatch(typeof(GunModDirectory), "SetSilencerMod")]
    public static class GunModPatchSilencer
    {
        static void Postfix(ref GameItem parent, ref List<ItemSpriteModifier> list)
        {
            if (parent.IsID("c20r"))
                list.Add(new ItemSpriteModifier(RenderHandler.LoadFromAtlas("Items/items_mod", "silencer_view"), new Vector2(95f, -13f)));
        }
    }

    [HarmonyPatch(typeof(GunModDirectory), "SetSilencerAdvShape")]
    public static class GunModPatchSilencerAdvShape
    {
        static void Postfix(ref GameItem parent, ref GameItem item, ref GridShapeBuilder __result)
        {
            if (parent.IsID("c20r"))
                __result = new GridShapeBuilder().SetDataFill(item.modifiedShape.width, item.modifiedShape.height, 1).SetTransform(6, 1, flipped: false, 0);
        }
    }

    [HarmonyPatch(typeof(GunModDirectory), "SetSilencerAdvMod")]
    public static class GunModPatchSilencerAdv
    {
        static void Postfix(ref GameItem parent, ref List<ItemSpriteModifier> list)
        {
            if (parent.IsID("c20r"))
                list.Add(new ItemSpriteModifier(RenderHandler.LoadFromAtlas("Items/items_mod", "silencer2_view"), new Vector2(93f, -14f)));
        }
    }

    [HarmonyPatch(typeof(GunModDirectory), nameof(GunModDirectory.SetSilencerMakeshiftShape))]
    public static class GunModPatchSilencerMakeshiftShape
    {
        static void Postfix(ref GameItem parent, ref GameItem item, ref GridShapeBuilder __result)
        {
            if (parent.IsID("c20r"))
                __result = new GridShapeBuilder().SetDataFill(item.modifiedShape.width, item.modifiedShape.height, 1).SetTransform(6, 1, flipped: false, 0);
        }
    }

    [HarmonyPatch(typeof(GunModDirectory), nameof(GunModDirectory.SetSilencerMakeshiftMod))]
    public static class GunModPatchSilencerMakeshift
    {
        static void Postfix(ref GameItem parent, ref List<ItemSpriteModifier> list)
        {
            if (parent.IsID("c20r"))
                list.Add(new ItemSpriteModifier(RenderHandler.LoadFromAtlas("Items/items_mod", "bottle_view"), new Vector2(94f, -13f)));
        }
    }

    [HarmonyPatch(typeof(GunModDirectory), nameof(GunModDirectory.SetBarrelShape))]
    public static class GunModPatchBarrelShape
    {
        static void Postfix(ref GameItem parent, ref GameItem item, ref GridShapeBuilder __result)
        {
            if (parent.IsID("c20r"))
                __result = new GridShapeBuilder().SetDataFill(item.modifiedShape.width, item.modifiedShape.height, 1).SetTransform(6, 1, flipped: false, 0);
        }
    }

    [HarmonyPatch(typeof(GunModDirectory), nameof(GunModDirectory.SetBarrelMod))]
    public static class GunModPatchBarrel
    {
        static void Postfix(ref GameItem parent, ref List<ItemSpriteModifier> list)
        {
            if (parent.IsID("c20r"))
                list.Add(new ItemSpriteModifier(RenderHandler.LoadFromAtlas("Items/items_mod", "barrel_view"), new Vector2(94f, -14f)));
        }
    }

    [HarmonyPatch(typeof(GunModDirectory), "CreateBarrel")]
    public static class GunModPatchAllowBarrel
    {
        static void Postfix(ref GameItem __result)
        {
            GunModHelper.AllowOnlyWeapon(["smg", "c20r"], __result);
        }
    }

    [HarmonyPatch(typeof(GunModDirectory), nameof(GunModDirectory.SetCompensatorShape))]
    public static class GunModPatchCompensatorShape
    {
        static void Postfix(ref GameItem parent, ref GameItem item, ref GridShapeBuilder __result)
        {
            if (parent.IsID("c20r"))
                __result = new GridShapeBuilder().SetDataFill(item.modifiedShape.width, item.modifiedShape.height, 1).SetTransform(6, 1, flipped: false, 0);
        }
    }

    [HarmonyPatch(typeof(GunModDirectory), nameof(GunModDirectory.SetCompensatorMod))]
    public static class GunModPatchCompensator
    {
        static void Postfix(ref GameItem parent, ref List<ItemSpriteModifier> list)
        {
            if (parent.IsID("c20r"))
                list.Add(new ItemSpriteModifier(RenderHandler.LoadFromAtlas("Items/items_mod", "compensator_view"), new Vector2(94f, -16f)));
        }
    }

    [HarmonyPatch(typeof(GunModDirectory), nameof(GunModDirectory.SetLaserMod))]
    public static class GunModPatchLaser
    {
        static void Postfix(ref GameItem parent, ref List<ItemSpriteModifier> list)
        {
            if (parent.IsID("c20r"))
                list.Add(new ItemSpriteModifier(RenderHandler.LoadFromAtlas("Items/items_mod", "laser_view"), new Vector2(79f, -24f)));
        }
    }

    [HarmonyPatch(typeof(GunModDirectory), nameof(GunModDirectory.SetLaser2Mod))]
    public static class GunModPatchLaser2
    {
        static void Postfix(ref GameItem parent, ref List<ItemSpriteModifier> list)
        {
            if (parent.IsID("c20r"))
                list.Add(new ItemSpriteModifier(RenderHandler.LoadFromAtlas("Items/items_mod", "laser2_view"), new Vector2(79f, -24f)));
        }
    }

    [HarmonyPatch(typeof(GunModDirectory), nameof(GunModDirectory.SetLaserToyMod))]
    public static class GunModPatchLaserToy
    {
        static void Postfix(ref GameItem parent, ref List<ItemSpriteModifier> list)
        {
            if (parent.IsID("c20r"))
                list.Add(new ItemSpriteModifier(RenderHandler.LoadFromAtlas("Items/items_mod", "laser_toy_view"), new Vector2(67f, -23f)));
        }
    }

    [HarmonyPatch(typeof(GunModDirectory), "CreateBipod")]
    public static class GunModPatchBipod
    {
        static void Postfix(ref GameItem __result)
        {
            __result.parentItemShapeModifierForItemFunc = AddGunMod.AddBipodShape;
            __result.parentItemSpriteModifierForItemFunc = AddGunMod.AddBipodSprite;
            GunModHelper.AllowOnlyWeapon(["smg", "c20r"], __result);
        }
    }

    [HarmonyPatch(typeof(GunModDirectory), "CreateGL")]
    public static class GunModPatchGL
    {
        static void Postfix(ref GameItem __result)
        {
            __result.parentItemShapeModifierForItemFunc = AddGunMod.AddGLShape;
            __result.parentItemSpriteModifierForItemFunc = AddGunMod.AddGLSprite;
            GunModHelper.AllowOnlyWeapon(["smg", "c20r"], __result);
        }
    }

    // For the few methods that are defined as lambdas for some reason
    static class AddGunMod
    {
        public static GridShapeBuilder AddBipodShape(GameItem item, GameInventory inventory, SlotMarker a, GridShape b, TagSystem c, GameItem parent)
        {
            if (parent.IsID("smg"))
                return new GridShapeBuilder().SetDataFill(item.modifiedShape.width, item.modifiedShape.height, 1).SetTransform(3, 2, flipped: false, 0);
            else if (parent.IsID("c20r"))
                return new GridShapeBuilder().SetDataFill(item.modifiedShape.width, item.modifiedShape.height, 1).SetTransform(3, 3, flipped: false, 0);
            return null;
        }

        public static List<ItemSpriteModifier> AddBipodSprite(GameItem item, GameInventory inventory, SlotMarker a, GridShape b, TagSystem c, GameItem parent)
        {
            List<ItemSpriteModifier> list = new List<ItemSpriteModifier>();
            if (parent.IsID("smg"))
                list.Add(new ItemSpriteModifier(RenderHandler.LoadFromAtlas("Items/items_mod", "bipod_view"), new Vector2(58f, -17f)));
            else if (parent.IsID("c20r"))
                list.Add(new ItemSpriteModifier(RenderHandler.LoadFromAtlas("Items/items_mod", "bipod_view"), new Vector2(45f, -25f)));
            return list;
        }

        public static GridShapeBuilder AddGLShape(GameItem item, GameInventory inventory, SlotMarker a, GridShape b, TagSystem c, GameItem parent)
        {
            if (parent.IsID("smg"))
                return new GridShapeBuilder().SetDataFill(item.modifiedShape.width, item.modifiedShape.height, 1).SetTransform(3, 2, flipped: false, 0);
            else if (parent.IsID("c20r"))
                return new GridShapeBuilder().SetDataFill(item.modifiedShape.width, item.modifiedShape.height, 1).SetTransform(3, 3, flipped: false, 0);
            return null;
        }

        public static List<ItemSpriteModifier> AddGLSprite(GameItem item, GameInventory inventory, SlotMarker a, GridShape b, TagSystem c, GameItem parent)
        {
            List<ItemSpriteModifier> list = new List<ItemSpriteModifier>();
            if (parent.IsID("smg"))
                list.Add(new ItemSpriteModifier(RenderHandler.LoadFromAtlas("Items/items_mod", "gl_view"), new Vector2(54f, -17f)));
            else if (parent.IsID("c20r"))
                list.Add(new ItemSpriteModifier(RenderHandler.LoadFromAtlas("Items/items_mod", "gl_view"), new Vector2(44f, -22f)));
            return list;
        }
    }
}
