using System;

namespace Developer.ExtensionCore
{
    public static class IntExtension
    {
        public static int ToInt(this string val)
        {
            int valueReturn = 0;

            try
            {
                if (!val.IsNullOrEmptyOrWhiteSpace())
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

        public static int? ToIntNull(this string val)
        {
            int? valueReturn = null;

            try
            {
                if (!val.IsNullOrEmptyOrWhiteSpace())
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

        public static int ToInt(this Enum value)
        {
            int aux = 0;

            try
            {
                if (value != null)
                {
                    string valor = Convert.ChangeType(value, value.GetTypeCode()).ToString();
                    aux = valor == null ? "0".ToInt() : valor.ToInt();
                }
            }
            catch
            {
                aux = int.MinValue;
            }

            return aux;
        }

        public static int? ToIntNull(this Enum value)
        {
            int? aux = null;

            try
            {
                if (value != null)
                {
                    string valor = Convert.ChangeType(value, value.GetTypeCode()).ToString();
                    aux = valor == null ? "0".ToInt() : valor.ToInt();
                }
            }
            catch
            {
                aux = null;
            }

            return aux;
        }

    }
}
