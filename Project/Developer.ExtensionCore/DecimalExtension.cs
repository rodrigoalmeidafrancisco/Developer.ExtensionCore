using System.Globalization;

namespace Developer.ExtensionCore
{
    public static class DecimalExtension
    {
        public static decimal ToDecimal(this string val)
        {
            decimal valueReturn = 0;

            try
            {
                if (!val.IsNullOrEmptyOrWhiteSpace())
                {
                    if (decimal.TryParse(val, out decimal aux))
                    {
                        valueReturn = aux;
                    }
                }
            }
            catch
            {
                valueReturn = decimal.MinValue;
            }

            return valueReturn;
        }

        public static decimal ToDecimal(this string val, NumberStyles style, string cultureInfo)
        {
            decimal valueReturn = 0;

            try
            {
                if (!val.IsNullOrEmptyOrWhiteSpace())
                {
                    if (decimal.TryParse(val, style, new CultureInfo(cultureInfo), out decimal aux))
                    {
                        valueReturn = aux;
                    }
                }
            }
            catch
            {
                valueReturn = decimal.MinValue;
            }

            return valueReturn;
        }

    }
}
