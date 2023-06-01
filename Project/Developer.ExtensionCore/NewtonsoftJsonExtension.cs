using Newtonsoft.Json;
using System;

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
            string valueReturn = null;

            try
            {
                if (obj != null)
                {
                    valueReturn = JsonConvert.SerializeObject(obj, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
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
            T obj = null;

            try
            {
                if (json.IsNullOrEmptyOrWhiteSpace() == false)
                {
                    obj = JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
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
