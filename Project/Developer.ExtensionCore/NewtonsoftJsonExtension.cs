using Newtonsoft.Json;

namespace Developer.ExtensionCore
{
    public static class NewtonsoftJsonExtension
    {
        /// <summary>
        /// Converte o Objeto em JSON usando a dll 'Newtonsoft.Json'
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToSerializeJson(this object obj)
        {
            try
            {
                JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                return JsonConvert.SerializeObject(obj, jsonSerializerSettings);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Converte o JSON usando a dll 'Newtonsoft.Json'
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T ToDeserializeJsonNewtonsoft<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }


    }
}
