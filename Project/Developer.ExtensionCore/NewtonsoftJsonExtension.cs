using Newtonsoft.Json;

namespace Developer.ExtensionCore
{
    public static class NewtonsoftJsonExtension
    {
        /// <summary>
        /// Serializa o Objeto em JSON usando a dll 'Newtonsoft.Json'.
        /// Caso não consiga converter, retorna null.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToNewtonsoftSerializeJson(this object obj)
        {
            string valueReturn = obj.ToNewtonsoftSerializeJson(new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return valueReturn;
        }

        /// <summary>
        /// Serializa o Objeto em JSON usando a dll 'Newtonsoft.Json'.
        /// Caso não consiga converter, retorna null.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static string ToNewtonsoftSerializeJson(this object obj, JsonSerializerSettings settings)
        {
            string valueReturn = null;

            try
            {
                if (obj != null)
                {
                    valueReturn = JsonConvert.SerializeObject(obj, settings);
                }
            }
            catch
            {
                return null;
            }

            return valueReturn;
        }

        /// <summary>
        /// Desserializa o JSON usando a dll 'Newtonsoft.Json'.
        /// Caso não consiga converter, retorna null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T ToNewtonsoftDeserializeJson<T>(this string json) where T : class
        {
            T obj = json.ToNewtonsoftDeserializeJson<T>(new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return obj;
        }

        /// <summary>
        /// Desserializa o JSON usando a dll 'Newtonsoft.Json'.
        /// Caso não consiga converter, retorna null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static T ToNewtonsoftDeserializeJson<T>(this string json, JsonSerializerSettings settings) where T : class
        {
            T obj = null;

            try
            {
                if (json.IsNullOrEmptyOrWhiteSpace() == false)
                {
                    obj = JsonConvert.DeserializeObject<T>(json, settings);
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
