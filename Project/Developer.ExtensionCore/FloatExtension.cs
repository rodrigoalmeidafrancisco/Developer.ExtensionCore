using Developer.ExtensionCore.Enums;
using System.Globalization;

namespace Developer.ExtensionCore
{
    public static class FloatExtension
    {
        /// <summary>
        /// Converte uma string em float.
        /// Caso não consiga converter, retorna float.MinValue.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static float ToFloat(this string val)
        {
            float valueReturn = float.MinValue;

            try
            {
                if (val.IsNullOrEmptyOrWhiteSpace() == false)
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

        /// <summary>
        /// Converte uma string em float.
        /// Caso não consiga converter, retorna float.MinValue.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="style"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static float ToFloat(this string val, NumberStyles style, string cultureInfo)
        {
            float valueReturn = float.MinValue;

            try
            {
                if (val.IsNullOrEmptyOrWhiteSpace() == false)
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

        /// <summary>
        /// Converte uma string em float.
        /// Caso não consiga converter, retorna float.MinValue.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="style"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static float ToFloat(this string val, NumberStyles style, EnumCultureInfo cultureInfo)
        {
            float valueReturn = val.ToFloat(style, cultureInfo.GetDescription());
            return valueReturn;
        }

        /// <summary>
        /// Converte uma string em float.
        /// Caso não consiga converter, retorna null.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static float? ToFloatNull(this string val)
        {
            float? valueReturn = null;

            try
            {
                if (val.IsNullOrEmptyOrWhiteSpace() == false)
                {
                    if (float.TryParse(val, out float aux))
                    {
                        valueReturn = aux;
                    }
                }
            }
            catch
            {
                valueReturn = null;
            }

            return valueReturn;
        }

        /// <summary>
        /// Converte uma string em float.
        /// Caso não consiga converter, retorna null.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="style"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static float? ToFloatNull(this string val, NumberStyles style, string cultureInfo)
        {
            float? valueReturn = null;

            try
            {
                if (val.IsNullOrEmptyOrWhiteSpace() == false)
                {
                    if (float.TryParse(val, style, new CultureInfo(cultureInfo), out float aux))
                    {
                        valueReturn = aux;
                    }
                }
            }
            catch
            {
                valueReturn = null;
            }

            return valueReturn;
        }

        /// <summary>
        /// Converte uma string em float.
        /// Caso não consiga converter, retorna null.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="style"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static float? ToFloatNull(this string val, NumberStyles style, EnumCultureInfo cultureInfo)
        {
            float? valueReturn = val.ToFloatNull(style, cultureInfo.GetDescription());
            return valueReturn;
        }

    }
}
