using Developer.ExtensionCore.Enums;
using System.Globalization;

namespace Developer.ExtensionCore
{
    public static class DoubleExtension
    {
        /// <summary>
        /// Converte uma string em double.
        /// Caso não consiga converter, retorna double.MinValue.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static double ToDouble(this string val)
        {
            double valueReturn = double.MinValue;

            try
            {
                if (val.IsNullOrEmptyOrWhiteSpace() == false)
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

        /// <summary>
        /// Converte uma string em double.
        /// Caso não consiga converter, retorna double.MinValue.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="style"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static double ToDouble(this string val, NumberStyles style, string cultureInfo)
        {
            double valueReturn = double.MinValue;

            try
            {
                if (val.IsNullOrEmptyOrWhiteSpace() == false)
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

        /// <summary>
        /// Converte uma string em double.
        /// Caso não consiga converter, retorna double.MinValue.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="style"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static double ToDouble(this string val, NumberStyles style, EnumCultureInfo cultureInfo)
        {
            double valueReturn = val.ToDouble(style, cultureInfo.GetDescription());
            return valueReturn;
        }

        /// <summary>
        /// Converte uma string em double.
        /// Caso não consiga converter, retorna null.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static double? ToDoubleNull(this string val)
        {
            double? valueReturn = null;

            try
            {
                if (val.IsNullOrEmptyOrWhiteSpace() == false)
                {
                    if (double.TryParse(val, out double aux))
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
        /// Converte uma string em double.
        /// Caso não consiga converter, retorna null.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="style"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static double? ToDoubleNull(this string val, NumberStyles style, string cultureInfo)
        {
            double? valueReturn = null;

            try
            {
                if (val.IsNullOrEmptyOrWhiteSpace() == false)
                {
                    if (double.TryParse(val, style, new CultureInfo(cultureInfo), out double aux))
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
        /// Converte uma string em double.
        /// Caso não consiga converter, retorna null.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="style"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static double? ToDoubleNull(this string val, NumberStyles style, EnumCultureInfo cultureInfo)
        {
            double? valueReturn = val.ToDoubleNull(style, cultureInfo.GetDescription());
            return valueReturn;
        }

    }
}
