using System.Text.Json;

namespace Developer.ExtensionCore
{
    public static class SystemTextJsonExtension
    {
        /// <summary>
        /// Serializa o Objeto em JSON usando a dll 'System.Text.Json' (Microsoft .NetCore)
        /// Caso não consiga converter, retorna null.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToSystemTextJsonSerializeJson(this object obj)
        {
            string valueReturn = obj.ToSystemTextJsonSerializeJson(new JsonSerializerOptions()
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
            });

            return valueReturn;
        }

        /// <summary>
        /// Serializa o Objeto em JSON usando a dll 'System.Text.Json' (Microsoft .NetCore)
        /// Caso não consiga converter, retorna null.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToSystemTextJsonSerializeJson(this object obj, JsonSerializerOptions options)
        {
            string valueReturn = null;

            try
            {
                if (obj != null)
                {
                    valueReturn = JsonSerializer.Serialize(obj, options);
                }
            }
            catch
            {
                return null;
            }

            return valueReturn;
        }

        /// <summary>
        /// Desserializa o JSON usando a dll 'System.Text.Json' (Microsoft .NetCore)
        /// Caso não consiga converter, retorna null. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T ToSystemTextJsonDeserializeJson<T>(this string json) where T : class
        {
            T obj = json.ToSystemTextJsonDeserializeJson<T>(new JsonSerializerOptions()
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
            });

            return obj;
        }

        /// <summary>
        /// Desserializa o JSON usando a dll 'System.Text.Json' (Microsoft .NetCore)
        /// Caso não consiga converter, retorna null. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static T ToSystemTextJsonDeserializeJson<T>(this string json, JsonSerializerOptions options) where T : class
        {
            T obj = null;

            try
            {
                if (json.IsNullOrEmptyOrWhiteSpace() == false)
                {
                    obj = JsonSerializer.Deserialize<T>(json, options);
                }
            }
            catch
            {
                return null;
            }

            return obj;
        }

    }
}
