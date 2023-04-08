using System;

namespace Developer.ExtensionCore
{
    public static class LongExtension
    {
        public static long Tolong(this string val)
        {
            long valueReturn = 0;

            try
            {
                if (!val.IsNullOrEmptyOrWhiteSpace())
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

        public static long Tolong(this Enum value)
        {
            long aux = 0;

            try
            {
                if (value != null)
                {
                    string valor = Convert.ChangeType(value, value.GetTypeCode()).ToString();
                    aux = valor == null ? "0".Tolong() : valor.Tolong();
                }
            }
            catch
            {
                aux = long.MinValue;
            }

            return aux;
        }
    }
}
