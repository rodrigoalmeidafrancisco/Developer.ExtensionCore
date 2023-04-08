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
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            string result;

            try
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes.Length > 0)
                {
                    result = attributes[0].Description;
                }
                else
                {
                    result = value.ToString();
                }
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
        public static IEnumerable<string> GetListDescriptionEnum<T>()
        {
            List<string> listResult = new List<string>();

            try
            {
                foreach (T item in Enum.GetValues(typeof(T)))
                {
                    FieldInfo fi = item.GetType().GetField(item.ToString());
                    DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                    if (attributes.Length > 0)
                    {
                        listResult.Add(attributes[0].Description);
                    }
                    else
                    {
                        listResult.Add(item.ToString());
                    }
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
        //public static IEnumerable<KeyValuePair<int, string>> GetListDescriptionEnumDropDown<T>(string firstName = "Selecionar...")
        //{
        //    List<KeyValuePair<int, string>> listResult = new List<KeyValuePair<int, string>>
        //    {
        //        new KeyValuePair<int, string>(-1, firstName)
        //    };

        //    try
        //    {
        //        List<KeyValuePair<int, string>> listAux = new List<KeyValuePair<int, string>>();

        //        int key = 0;
        //        string value = firstName;

        //        foreach (T item in Enum.GetValues(typeof(T)))
        //        {
        //            Enum.TryParse(item.ToString(), out object resultEnum);
        //            key = (int)resultEnum;

        //            FieldInfo fi = item.GetType().GetField(item.ToString());
        //            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

        //            if (attributes.Length > 0)
        //            {
        //                value = attributes[0].Description;
        //            }
        //            else
        //            {
        //                value = item.ToString();
        //            }

        //            listAux.Add(new KeyValuePair<int, string>(key, value));
        //        };

        //        listAux = listAux.OrderBy(x => x.Value).ToList();
        //        listAux.ForEach(item => listResult.Add(item));
        //    }
        //    catch
        //    {
        //        listResult = new List<KeyValuePair<int, string>>();
        //    }

        //    return listResult;
        //}

    }
}
