namespace SmartPharm.Extension
{
    internal static class ExtensionAdmin
    {
        public static string Capitalize(this string word)
        {
            return word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
        }
    }
}
