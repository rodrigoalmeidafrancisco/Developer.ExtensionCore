using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Developer.ExtensionCore
{
    public static class EnumExtension
    {
        /// <summary>
        /// Obtém o valor do atributo "Description" do Enum, caso não tenha retorna o texto do próprio Enum.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum val)
        {
            string result;

            try
            {
                FieldInfo fieldInfo = val.GetType().GetField(val.ToString());
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                result = attributes.Length > 0 ? attributes[0].Description : val.ToString();
            }
            catch
            {
                result = string.Empty;
            }

            return result;
        }

        /// <summary>
        /// Obtém a lista do valor do atributo "Description" de cada opção do Enum.
        /// Caso ocorra erro, retorna uma lista em branco.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> GetListDescription<T>()
        {
            List<string> listResult = new List<string>();

            try
            {
                FieldInfo fieldInfo = null;
                DescriptionAttribute[] attributes = null;

                foreach (T item in Enum.GetValues(typeof(T)))
                {
                    fieldInfo = item.GetType().GetField(item.ToString());
                    attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    listResult.Add(attributes.Length > 0 ? attributes[0].Description : item.ToString());
                };
            }
            catch
            {
                listResult = new List<string>();
            }

            return listResult.OrderBy(x => x);
        }

        /// <summary>
        /// Obtém a lista do valor do atributo "Description" de cada opção do Enum, para ser usado em um DropDown.
        /// Caso ocorra erro, retorna uma lista em branco.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="firstName"></param>
        /// <returns></returns>
        public static IEnumerable<KeyValuePair<int, string>> GetListDescriptionDropDown<T>(int firstVal = -1, string firstName = "Selecione...")
        {
            List<KeyValuePair<int, string>> listResult = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(firstVal, firstName)
            };

            try
            {
                List<KeyValuePair<int, string>> listAux = new List<KeyValuePair<int, string>>();

                int key = 0;
                string value = firstName;
                FieldInfo fieldInfo = null;
                DescriptionAttribute[] attributes = null;

                foreach (T item in Enum.GetValues(typeof(T)))
                {
                    fieldInfo = item.GetType().GetField(item.ToString());
                    attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                    key = (int)fieldInfo.GetValue(item);
                    value = attributes.Length > 0 ? attributes[0].Description : item.ToString();

                    listAux.Add(new KeyValuePair<int, string>(key, value));
                };

                listAux = listAux.OrderBy(x => x.Value).ToList();
                listAux.ForEach(item => listResult.Add(item));
            }
            catch
            {
                listResult = new List<KeyValuePair<int, string>>();
            }

            return listResult;
        }

    }
}
