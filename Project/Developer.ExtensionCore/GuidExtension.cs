using System;

namespace Developer.ExtensionCore
{
    public static class GuidExtension
    {
        public static Guid ToGuid(this string val)
        {
            Guid valueReturn = Guid.Empty;

            try
            {
                if (!val.IsNullOrEmptyOrWhiteSpace())
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

    }
}
