using System.Text.Json;

namespace Developer.ExtensionCore
{
    public static class SystemTextJsonExtension
    {
        /// <summary>
        /// Converte o Objeto em JSON usando a dll 'System.Text.Json' (Microsoft .NetCore)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToSerializeJson(this object obj)
        {
            try
            {
                return JsonSerializer.Serialize(obj, new JsonSerializerOptions()
                {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true,
                    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
                });
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Converte o JSON usando a dll 'System.Text.Json' (Microsoft .NetCore)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T ToDeserializeJson<T>(this string json)
        {
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions()
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
            });
        }


    }
}
