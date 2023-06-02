using Developer.ExtensionCore.Enums;
using System;
using System.Globalization;

namespace Developer.ExtensionCore
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// Retorna um DateTime, caso não consiga converter retorna DateTime.MinValue.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string val, string culture = null)
        {
            DateTime result = DateTime.MinValue;

            try
            {
                if (val.IsNullOrEmptyOrWhiteSpace() == false)
                {
                    if (culture.IsNullOrEmptyOrWhiteSpace() == false)
                    {
                        result = Convert.ToDateTime(val, new CultureInfo(culture));
                    }
                    else if (DateTime.TryParse(val, out DateTime newDateTime))
                    {
                        result = newDateTime;
                    }
                }

                return result;
            }
            catch
            {
                return result;
            }
        }

        /// <summary>
        /// Retorna um DateTime, caso não consiga converter retorna DateTime.MinValue.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string val, EnumCultureInfo culture)
        {
            DateTime result = val.ToDateTime(culture.GetDescription());
            return result;
        }

        /// <summary>
        /// Retorna um DateTime, caso não consiga converter retorna null.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static DateTime? ToDateTimeNull(this string val, string culture = null)
        {
            DateTime? result = null;

            try
            {
                if (val.IsNullOrEmptyOrWhiteSpace() == false)
                {
                    if (culture.IsNullOrEmptyOrWhiteSpace() == false)
                    {
                        result = Convert.ToDateTime(val, new CultureInfo(culture));
                    }
                    else if (DateTime.TryParse(val, out DateTime newDateTime))
                    {
                        result = newDateTime;
                    }
                }

                return result;
            }
            catch
            {
                return result;
            }
        }

        /// <summary>
        /// Retorna um DateTime, caso não consiga converter retorna null.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static DateTime? ToDateTimeNull(this string val, EnumCultureInfo culture)
        {
            DateTime? result = val.ToDateTimeNull(culture.GetDescription());
            return result;
        }

        /// <summary>
        /// Retorna data do dia informado com a última hora do dia. Exemplo: 07/09/2021 23:59:59.
        /// Caso ocorra erro, irá retornar a mesma data e hora informada.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static DateTime ToDateTimeDayEnd(this DateTime val)
        {
            DateTime result;

            try
            {
                DateTime newDateTime = new DateTime(val.Year, val.Month, val.Day);
                result = newDateTime.AddDays(1).AddMilliseconds(-1);
            }
            catch
            {
                result = val;
            }

            return result;
        }
    }
}
