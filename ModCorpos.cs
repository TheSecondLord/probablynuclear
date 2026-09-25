using Il2Cpp;

namespace ProbablyNuclear
{
    public static class ModCorpos
    {
        public static void DisplayCorpo(RichTextBuilder builder, string manufacturer)
        {
            if (manufacturer.Equals("interdyne"))
                builder.AddLine("Interdyne Pharmaceuticals", ignoreEmpty: true, RenderHandler.ColorPalette.Blue, bold: false, italic: false, underline: true);
            else if (manufacturer.Equals("gorlex"))
                builder.AddLine("Gorlex Marauders", ignoreEmpty: true, RenderHandler.ColorPalette.DarkRed, bold: false, italic: false, underline: true);
            else if (manufacturer.Equals("waffle"))
                builder.AddLine("Waffle Co.", ignoreEmpty: true, RenderHandler.ColorPalette.DarkOrange, bold: false, italic: false, underline: true);
            else if (manufacturer.Equals("self"))
                builder.AddLine("S.E.L.F.", ignoreEmpty: true, RenderHandler.ColorPalette.LightBlue, bold: false, italic: false, underline: true);
            else if (manufacturer.Equals("donk"))
                builder.AddLine("Donk Co.", ignoreEmpty: true, RenderHandler.ColorPalette.LightPurple, bold: false, italic: false, underline: true);
            else if (manufacturer.Equals("cybersun"))
                builder.AddLine("Cybersun Industries", ignoreEmpty: true, RenderHandler.ColorPalette.Red, bold: false, italic: false, underline: true);
        }
    }
}
