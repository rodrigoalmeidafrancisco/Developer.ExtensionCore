using Developer.ExtensionCore.Enums;
using System;
using System.Globalization;

namespace Developer.ExtensionCore
{
    public static class LongExtension
    {
        /// <summary>
        /// Converte uma string em long.
        /// Caso não consiga converter, retorna long.MinValue.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static long ToLong(this string val)
        {
            long valueReturn = long.MinValue;

            try
            {
                if (val.IsNullOrEmptyOrWhiteSpace() == false)
                {
                    if (long.TryParse(val, out long aux))
                    {
                        valueReturn = aux;
                    }
                }
            }
            catch
            {
                valueReturn = long.MinValue;
            }

            return valueReturn;
        }

        /// <summary>
        /// Converte uma string em long.
        /// Caso não consiga converter, retorna long.MinValue.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="style"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static long ToLong(this string val, NumberStyles style, string cultureInfo)
        {
            long valueReturn = 0;

            try
            {
                if (val.IsNullOrEmptyOrWhiteSpace() == false)
                {
                    if (long.TryParse(val, style, new CultureInfo(cultureInfo), out long aux))
                    {
                        valueReturn = aux;
                    }
                }
            }
            catch
            {
                valueReturn = long.MinValue;
            }

            return valueReturn;
        }

        /// <summary>
        /// Converte uma string em long.
        /// Caso não consiga converter, retorna long.MinValue.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="style"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static long ToLong(this string val, NumberStyles style, EnumCultureInfo cultureInfo)
        {
            long valueReturn = val.ToLong(style, cultureInfo.GetDescription());
            return valueReturn;
        }

        /// <summary>
        /// Obtém o enum e retorna o valor do item do enum em long.
        /// Caso não consiga converter, retorna long.MinValue.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToLong(this Enum value)
        {
            long valueReturn = long.MinValue;

            try
            {
                if (value != null)
                {
                    string valor = Convert.ChangeType(value, value.GetTypeCode()).ToString();
                    valueReturn = valor == null ? long.MinValue : valor.ToLong();
                }
            }
            catch
            {
                valueReturn = long.MinValue;
            }

            return valueReturn;
        }

        /// <summary>
        /// Converte uma string em long.
        /// Caso não consiga converter, retorna null.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static long? ToLongNull(this string val)
        {
            long? valueReturn = null;

            try
            {
                if (val.IsNullOrEmptyOrWhiteSpace() == false)
                {
                    if (long.TryParse(val, out long aux))
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
        /// Converte uma string em long.
        /// Caso não consiga converter, retorna null.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="style"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static long? ToLongNull(this string val, NumberStyles style, string cultureInfo)
        {
            long? valueReturn = null;

            try
            {
                if (val.IsNullOrEmptyOrWhiteSpace() == false)
                {
                    if (long.TryParse(val, style, new CultureInfo(cultureInfo), out long aux))
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
        /// Converte uma string em long.
        /// Caso não consiga converter, retorna null.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="style"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static long? ToLongNull(this string val, NumberStyles style, EnumCultureInfo cultureInfo)
        {
            long? valueReturn = val.ToLongNull(style, cultureInfo.GetDescription());
            return valueReturn;
        }

        /// <summary>
        /// Obtém o enum e retorna o valor do item do enum em long.
        /// Caso não consiga converter, retorna null.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static long? ToLongNull(this Enum val)
        {
            long? valueReturn = null;

            try
            {
                if (val != null)
                {
                    string valor = Convert.ChangeType(val, val.GetTypeCode()).ToString();
                    valueReturn = valor.ToLongNull();
                }
            }
            catch
            {
                valueReturn = null;
            }

            return valueReturn;
        }

    }
}
