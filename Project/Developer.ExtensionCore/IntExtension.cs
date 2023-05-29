using Developer.ExtensionCore.Enums;
using System;
using System.Globalization;

namespace Developer.ExtensionCore
{
    public static class IntExtension
    {
        /// <summary>
        /// Converte uma string em int.
        /// Caso não consiga converter, retorna int.MinValue.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int ToInt(this string val)
        {
            int valueReturn = int.MinValue;

            try
            {
                if (val.IsNullOrEmptyOrWhiteSpace() == false)
                {
                    if (int.TryParse(val, out int aux))
                    {
                        valueReturn = aux;
                    }
                }
            }
            catch
            {
                valueReturn = int.MinValue;
            }

            return valueReturn;
        }

        /// <summary>
        /// Converte uma string em int.
        /// Caso não consiga converter, retorna int.MinValue.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="style"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static int ToInt(this string val, NumberStyles style, string cultureInfo)
        {
            int valueReturn = int.MinValue;

            try
            {
                if (val.IsNullOrEmptyOrWhiteSpace() == false)
                {
                    if (int.TryParse(val, style, new CultureInfo(cultureInfo), out int aux))
                    {
                        valueReturn = aux;
                    }
                }
            }
            catch
            {
                valueReturn = int.MinValue;
            }

            return valueReturn;
        }

        /// <summary>
        /// Converte uma string em int.
        /// Caso não consiga converter, retorna int.MinValue.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="style"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static int ToInt(this string val, NumberStyles style, EnumCultureInfo cultureInfo)
        {
            int valueReturn = val.ToInt(style, cultureInfo.GetDescription());
            return valueReturn;
        }

        /// <summary>
        /// Obtém o valor do item do enum.
        /// Caso não consiga converter, retorna int.MinValue.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt(this Enum value)
        {
            int valueReturn = int.MinValue;

            try
            {
                if (value != null)
                {
                    string valor = Convert.ChangeType(value, value.GetTypeCode()).ToString();
                    valueReturn = valor == null ? int.MinValue : valor.ToInt();
                }
            }
            catch
            {
                valueReturn = int.MinValue;
            }

            return valueReturn;
        }

        /// <summary>
        /// Converte uma string em int.
        /// Caso não consiga converter, retorna null.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int? ToIntNull(this string val)
        {
            int? valueReturn = null;

            try
            {
                if (val.IsNullOrEmptyOrWhiteSpace() == false)
                {
                    if (int.TryParse(val, out int aux))
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
        /// Converte uma string em int.
        /// Caso não consiga converter, retorna null.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="style"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static int? ToIntNull(this string val, NumberStyles style, string cultureInfo)
        {
            int? valueReturn = null;

            try
            {
                if (val.IsNullOrEmptyOrWhiteSpace() == false)
                {
                    if (int.TryParse(val, style, new CultureInfo(cultureInfo), out int aux))
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
        /// Converte uma string em int.
        /// Caso não consiga converter, retorna null.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="style"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static int? ToIntNull(this string val, NumberStyles style, EnumCultureInfo cultureInfo)
        {
            int? valueReturn = val.ToIntNull(style, cultureInfo.GetDescription());
            return valueReturn;
        }

        /// <summary>
        /// Obtém o valor do item do enum.
        /// Caso não consiga converter, retorna null.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int? ToIntNull(this Enum val)
        {
            int? valueReturn = null;

            try
            {
                if (val != null)
                {
                    string valor = Convert.ChangeType(val, val.GetTypeCode()).ToString();
                    valueReturn = valor.ToIntNull();
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
