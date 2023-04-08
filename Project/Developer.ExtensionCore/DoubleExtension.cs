using System.Globalization;

namespace Developer.ExtensionCore
{
    public static class DoubleExtension
    {
        public static double ToDouble(this string val)
        {
            double valueReturn = 0;

            try
            {
                if (!val.IsNullOrEmptyOrWhiteSpace())
                {
                    if (double.TryParse(val, out double aux))
                    {
                        valueReturn = aux;
                    }
                }
            }
            catch
            {
                valueReturn = double.MinValue;
            }

            return valueReturn;
        }

        public static double ToDouble(this string val, NumberStyles style, string cultureInfo)
        {
            double valueReturn = 0;

            try
            {
                if (!val.IsNullOrEmptyOrWhiteSpace())
                {
                    if (double.TryParse(val, style, new CultureInfo(cultureInfo), out double aux))
                    {
                        valueReturn = aux;
                    }
                }
            }
            catch
            {
                valueReturn = double.MinValue;
            }

            return valueReturn;
        }

    }
}
