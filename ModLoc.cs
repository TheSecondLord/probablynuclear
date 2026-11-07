namespace ProbablyNuclear
{
    class ModLoc
    {
        public static string Localize(string id, params object[] args)
        {
            return ModHelper.GetLocalized("probably_nuclear", id, args);
        }
    }
}
