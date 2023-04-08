using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace Developer.ExtensionCore
{
    public static class StreamExtension
    {
        public static Stream ToBitmapStream(this Bitmap bitmap, ImageFormat imageFormat)
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

        public static MemoryStream ToMemoryStream(this byte[] bytes)
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
