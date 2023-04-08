using System.Globalization;

namespace Developer.ExtensionCore
{
    public static class FloatExtension
    {
        public static float ToFloat(this string val)
        {
            float valueReturn = 0;

            try
            {
                if (!val.IsNullOrEmptyOrWhiteSpace())
                {
                    if (float.TryParse(val, out float aux))
                    {
                        valueReturn = aux;
                    }
                }
            }
            catch
            {
                valueReturn = float.MinValue;
            }

            return valueReturn;
        }

        public static float ToFloat(this string val, NumberStyles style, string cultureInfo)
        {
            float valueReturn = 0;

            try
            {
                if (!val.IsNullOrEmptyOrWhiteSpace())
                {
                    if (float.TryParse(val, style, new CultureInfo(cultureInfo), out float aux))
                    {
                        valueReturn = aux;
                    }
                }
            }
            catch
            {
                valueReturn = float.MinValue;
            }

            return valueReturn;
        }


    }
}
