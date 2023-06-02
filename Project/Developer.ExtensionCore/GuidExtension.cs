using System;

namespace Developer.ExtensionCore
{
    public static class GuidExtension
    {
        /// <summary>
        /// Converte uma string em Guid.
        /// Caso não consiga converter, retorna Guid.Empty.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static Guid ToGuid(this string val)
        {
            Guid valueReturn = Guid.Empty;

            try
            {
                if (val.IsNullOrEmptyOrWhiteSpace() == false)
                {
                    if (Guid.TryParse(val, out Guid aux))
                    {
                        valueReturn = aux;
                    }
                }
            }
            catch
            {
                valueReturn = Guid.Empty;
            }

            return valueReturn;
        }

        /// <summary>
        /// Converte uma string em Guid.
        /// Caso não consiga converter, retorna null.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static Guid? ToGuidNull(this string val)
        {
            Guid? valueReturn = null;

            try
            {
                if (val.IsNullOrEmptyOrWhiteSpace() == false)
                {
                    if (Guid.TryParse(val, out Guid aux))
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

    }
}
