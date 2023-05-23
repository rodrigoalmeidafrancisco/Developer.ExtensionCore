using Developer.ExtensionCore.Enums;
using System.Globalization;

namespace Developer.ExtensionCore
{
    public static class DecimalExtension
    {
        /// <summary>
        /// Converte uma string em Decimal.
        /// Caso não consiga converter, retorna decimal.MinValue.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string val)
        {
            decimal valueReturn = decimal.MinValue;

            try
            {
                if (val.IsNullOrEmptyOrWhiteSpace() == false)
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

        /// <summary>
        /// Converte uma string em Decimal.
        /// Caso não consiga converter, retorna null.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static decimal? ToDecimalNull(this string val)
        {
            decimal? valueReturn = null;

            try
            {
                if (val.IsNullOrEmptyOrWhiteSpace() == false)
                {
                    if (decimal.TryParse(val, out decimal aux))
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
        /// Converte uma string em Decimal.
        /// Caso não consiga converter, retorna decimal.MinValue.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="style"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string val, NumberStyles style, string cultureInfo)
        {
            decimal valueReturn = decimal.MinValue;

            try
            {
                if (val.IsNullOrEmptyOrWhiteSpace() == false)
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

        /// <summary>
        /// Converte uma string em Decimal.
        /// Caso não consiga converter, retorna decimal.MinValue.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="style"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string val, NumberStyles style, EnumCultureInfo cultureInfo)
        {
            decimal valueReturn = val.ToDecimal(style, cultureInfo.GetDescription());
            return valueReturn;
        }

    }
}
