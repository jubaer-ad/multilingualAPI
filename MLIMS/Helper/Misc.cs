using System.Globalization;

namespace MLIMS.Helper
{
    public static class Misc
    {
        public static string GetLanguageCode()
        {
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;

            var fullCultureCode = cultureInfo.Name;

            return cultureInfo.TwoLetterISOLanguageName ?? "en";
        }
    }
}
