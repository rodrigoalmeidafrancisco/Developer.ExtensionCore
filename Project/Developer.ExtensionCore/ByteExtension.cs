using System;
using System.IO;

namespace Developer.ExtensionCore
{
    public static class ByteExtension
    {
        /// <summary>
        /// Retorna o valor de uma "string" em byte. 
        /// Caso não consiga converter, irá retornar 0.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static byte ToByte(this string val)
        {
            byte result = 0;

            try
            {
                if (!val.IsNullOrEmptyOrWhiteSpace())
                {
                    if (byte.TryParse(val, out byte aux))
                    {
                        result = aux;
                    }
                }
            }
            catch
            {
                result = 0;
            }

            return result;
        }

        /// <summary>
        /// Retorna o valor de um "Enum" em byte. 
        /// Caso não consiga converter, irá retornar 0.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte ToByte(this Enum value)
        {
            byte result = 0;

            try
            {
                if (value != null)
                {
                    string valor = Convert.ChangeType(value, value.GetTypeCode()).ToString();
                    result = valor == null ? (byte)0 : valor.ToByte();
                }
            }
            catch
            {
                result = 0;
            }

            return result;
        }

        /// <summary>
        /// Obtém os bytes[] de Stream
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] ToBytes(this Stream stream)
        {
            byte[] result = null;

            try
            {
                if (stream is MemoryStream)
                {
                    result = ((MemoryStream)stream).ToArray();
                }

                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    result = memoryStream.ToArray();
                }
            }
            catch
            {
                result = null;
            }

            return result;
        }

        /// <summary>
        /// Retorna os bytes[] de um arquivo, conforme o path informado.
        /// Caso não consiga obter os bytes[], irá retornar null.
        /// </summary>
        /// <param name="pathFile"></param>
        /// <returns></returns>
        public static byte[] ToBytesPathFile(this string pathFile)
        {
            byte[] result = null;

            try
            {
                if (!pathFile.IsNullOrEmptyOrWhiteSpace())
                {
                    using (FileStream imageFileStream = File.OpenRead(pathFile))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            imageFileStream.CopyTo(ms);
                            result = ms.ToArray();
                        }
                    }
                }
            }
            catch
            {
                result = null;
            }

            return result;
        }

        /// <summary>
        /// Converte um imagem em uma determinada scala.
        /// </summary>
        /// <param name="imageSource"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        //public static byte[] ToBytesScaleImage(this byte[] imageSource, int scale)
        //{
        //    byte[] retorno = null;
        //    try
        //    {
        //        if (imageSource != null)
        //        {
        //            //SixLabors.ImageSharp não está funcionando
        //            using (Image image = Image.Load(imageSource))
        //            {
        //                image.Mutate(x => x.Resize(image.Width / scale, image.Height / scale));
        //                using (var stream = new MemoryStream())
        //                {
        //                    image.SaveAsPng(stream);
        //                    retorno = stream.GetBuffer();
        //                }
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        retorno = null;
        //    }
        //    return retorno;
        //}

    }
}
