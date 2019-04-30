using System.Text.RegularExpressions;

namespace Ion.CognitiveServices
{
    public static class Pattern
    {
        public static Regex Integer = new Regex("[0-9]",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static Regex Decimal = new Regex(@"[0.9]\.[0-9]+");
    }
}