using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace Developer.ExtensionCore
{
    public static class StreamExtension
    {
        /// <summary>
        /// Converte um Bitmap (System.Drawing) para Stream (System.IO).
        /// Caso não consiga converter, retorna null.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="imageFormat"></param>
        /// <returns></returns>
        public static Stream ToBitmapForStream(this Bitmap bitmap, ImageFormat imageFormat)
        {
            try
            {
                Image image = bitmap;

                using (Stream stream = new MemoryStream())
                {
                    image.Save(stream, imageFormat);
                    stream.Position = 0;
                    return stream;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Converte um byte[] para MemoryStream (System.IO).
        /// Caso não consiga converter, retorna null.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static MemoryStream ToBytesForMemoryStream(this byte[] bytes)
        {
            try
            {
                return new MemoryStream(bytes);
            }
            catch
            {
                return null;
            }
        }

    }
}
