using System.Globalization;

namespace Pdbc.Shopping.Common.Extensions
{
    public static class LanguageExtensions
    {
        public static CultureInfo ToCultureInfo(this string language)
        {
            switch (language?.ToLowerInvariant())
            {
                case "nl":
                case "nl-be":
                case "nl-nl":
                    return new CultureInfo("nl");
                case "fr":
                case "fr-be":
                case "fr-fr":
                    return new CultureInfo("fr");
                case "de":
                    return new CultureInfo("de");
                case "en":
                case "en-gb":
                case "en-us":
                    return new CultureInfo("en");
                default:
                    return new CultureInfo("en");
            }
        }

    }
}