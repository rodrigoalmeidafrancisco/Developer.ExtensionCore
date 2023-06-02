using Developer.ExtensionCore.Enums;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Developer.ExtensionCore
{
    public static class StringExtension
    {
        /// <summary>
        /// Retorna a data no formato informado, por padrão irá retornar a data e hora do Brasil "dd/MM/yyyy HH:mm:ss".
        /// Caso ocorra algum erro, irá retornar string.Empty;
        /// </summary>
        /// <param name="val"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string ToDateFormat(this DateTime val, string format = "dd/MM/yyyy HH:mm:ss")
        {
            string result;

            try
            {
                result = val.ToString(format);
            }
            catch
            {
                result = string.Empty;
            }

            return result;
        }

        /// <summary>
        /// Retorna a data no formato da cultura informada.
        /// Caso ocorra algum erro, irá retornar string.Empty;
        /// </summary>
        /// <param name="val"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static string ToDateCulture(this DateTime val, string culture)
        {
            string result;

            try
            {
                result = val.ToString(CultureInfo.CreateSpecificCulture(culture));
            }
            catch
            {
                result = string.Empty;
            }

            return result;
        }

        /// <summary>
        /// Retorna a data no formato da cultura informada.
        /// Caso ocorra algum erro, irá retornar string.Empty;
        /// </summary>
        /// <param name="val"></param>
        /// <param name="enumCultureInfo"></param>
        /// <returns></returns>
        public static string ToDateCulture(this DateTime val, EnumCultureInfo enumCultureInfo)
        {
            string result;

            try
            {
                string cultInfo = enumCultureInfo.GetDescription();
                result = val.ToString(CultureInfo.CreateSpecificCulture(cultInfo));
            }
            catch
            {
                result = string.Empty;
            }

            return result;
        }

        /// <summary>
        /// Caso tenha um texto maior do que o máximo de caracteres informado, o texto será reduzido para o máximo de caracteres informado.
        /// Caso ocorra algum erro, irá retornar string.Empty;
        /// </summary>
        /// <param name="val"></param>
        /// <param name="maxCaracteres"></param>
        /// <returns></returns>
        public static string ReduceText(this string val, int maxCaracteres, bool ellipsis)
        {
            string result;

            try
            {
                if (val.IsNullOrEmptyOrWhiteSpace() == false && val.Length > maxCaracteres)
                {
                    if (ellipsis == false)
                    {
                        result = $"{val.Substring(0, maxCaracteres).Trim()}";
                    }
                    else
                    {
                        result = $"{val.Substring(0, maxCaracteres).Trim()}...";
                    }
                }
                else
                {
                    result = val;
                }
            }
            catch
            {
                result = string.Empty;
            }

            return result;
        }

        /// <summary>
        /// Retorna a data por extenso, Exemplo: Terça, 07 de Setembro de 2021
        /// Culturas aceitas: pt-BR
        /// </summary>
        /// <param name="val"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static string ToDateExtensive1(this DateTime val, string culture)
        {
            string result = string.Empty;

            try
            {
                if (culture.Equals(EnumCultureInfo.Portuguese_Brazil.GetDescription(), StringComparison.OrdinalIgnoreCase))
                {
                    CultureInfo cultureInfo = new CultureInfo(culture);
                    DateTimeFormatInfo dif = cultureInfo.DateTimeFormat;

                    string day = val.Day.ToString();
                    string year = val.Year.ToString();
                    string month = cultureInfo.TextInfo.ToTitleCase(dif.GetMonthName(val.Month));
                    string weekday = cultureInfo.TextInfo.ToTitleCase(dif.GetDayName(val.DayOfWeek));

                    result = $"{weekday}, {day} de {month} de {year}";
                }
            }
            catch
            {
                result = string.Empty;
            }

            return result;
        }

        /// <summary>
        /// Retorna a data por extenso, Exemplo: Terça, 07 de Setembro de 2021
        /// Culturas aceitas: pt-BR
        /// </summary>
        /// <param name="val"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static string ToDateExtensive1(this DateTime val, EnumCultureInfo culture)
        {
            string result = val.ToDateExtensive1(culture.GetDescription());
            return result;
        }

        /// <summary>
        /// Retorna a data por extenso, Exemplo: 07 de Setembro de 2021
        /// Culturas aceitas: pt-BR
        /// </summary>
        /// <param name="val"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static string ToDateExtensive2(this DateTime val, string culture)
        {
            string result = string.Empty;

            try
            {
                if (culture.Equals("pt-BR", StringComparison.OrdinalIgnoreCase))
                {
                    CultureInfo cultureInfo = new CultureInfo(culture);
                    DateTimeFormatInfo dif = cultureInfo.DateTimeFormat;

                    string day = val.Day.ToString();
                    string year = val.Year.ToString();
                    string month = cultureInfo.TextInfo.ToTitleCase(dif.GetMonthName(val.Month));

                    result = $"{day} de {month} de {year}";
                }
            }
            catch
            {
                result = string.Empty;
            }

            return result;
        }

        /// <summary>
        /// Retorna a data por extenso, Exemplo: 07 de Setembro de 2021
        /// Culturas aceitas: pt-BR
        /// </summary>
        /// <param name="val"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static string ToDateExtensive2(this DateTime val, EnumCultureInfo culture)
        {
            string result = val.ToDateExtensive2(culture.GetDescription());
            return result;
        }

        /// <summary>
        /// Elimina qualquer caracter que não seja número;
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string OnlyNumbers(this string val)
        {
            string result = val;

            try
            {
                if (val.IsNullOrEmptyOrWhiteSpace() == false)
                {
                    Regex regex = new Regex(@"[^\d]");
                    result = regex.Replace(val, "");
                }
            }
            catch
            {
                result = val;
            }

            return result;
        }

        /// <summary>
        /// Converte um array de bytes em Base64String
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToBase64String(this byte[] val)
        {
            return Convert.ToBase64String(val);
        }

        /// <summary>
        /// Troca os caracteres acentuados por não acentuados;
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string RemoveAccents(this string val)
        {
            string original = val;
            string result = val;

            try
            {
                if (!val.IsNullOrEmptyOrWhiteSpace())
                {
                    string[] accents = new string[] { "ç", "Ç", "á", "é", "í", "ó", "ú", "ý", "Á", "É", "Í", "Ó", "Ú", "Ý", "à", "è", "ì", "ò", "ù", "À", "È", "Ì", "Ò", "Ù", "ã", "õ", "ñ", "ä", "ë", "ï", "ö", "ü", "ÿ", "Ä", "Ë", "Ï", "Ö", "Ü", "Ã", "Õ", "Ñ", "â", "ê", "î", "ô", "û", "Â", "Ê", "Î", "Ô", "Û" };
                    string[] noAccents = new string[] { "c", "C", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "Y", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U", "a", "o", "n", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "A", "O", "N", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U" };

                    for (int i = 0; i < accents.Length; i++)
                    {
                        val = val.Replace(accents[i], noAccents[i]);
                    }

                    result = val;
                }
            }
            catch
            {
                result = original;
            }

            return result;
        }

        /// <summary>
        /// Obtém o valor do Stopwatch em string (hh:mm:ss:mm)
        /// </summary>
        /// <param name="val"></param>
        /// <param name="finalizeStopwatch">True = para o tempo do objeto</param>
        /// <returns></returns>
        public static string ToString(this Stopwatch val, bool finalizeStopwatch)
        {
            string result = val.Elapsed.ToString();

            if (finalizeStopwatch)
            {
                val.Stop();
            }

            return result;
        }
    }
}
