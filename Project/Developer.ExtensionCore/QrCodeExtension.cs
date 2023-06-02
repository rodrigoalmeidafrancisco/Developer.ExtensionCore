using QRCoder;
using System;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace Developer.ExtensionCore
{
    public static class QrCodeExtension
    {
        /// <summary>
        /// Cria um QRCode a partir do valor informado.
        /// Caso não tenha sido passado um valor irá retornar um QRCode com a frase "Not found..."
        /// Caso ocorra erro na criação, retorna null.
        /// </summary>
        /// <param name="valueQrCode"></param>
        /// <returns></returns>
        public static byte[] ToCreateQrCode(this string valueQrCode)
        {
            byte[] imageQrCode = null;

            try
            {
                valueQrCode = valueQrCode.IsNullOrEmptyOrWhiteSpace() == false ? valueQrCode : "Not found...";

                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                {
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(valueQrCode, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    Bitmap qrCodeImage = qrCode.GetGraphic(20);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        qrCodeImage.Save(memoryStream, ImageFormat.Png);
                        imageQrCode = memoryStream.ToArray();
                    }
                }
            }
            catch
            {
                imageQrCode = null;
            }

            return imageQrCode;
        }

        /// <summary>
        /// Cria um QRCode a partir do valor informado.
        /// Caso não tenha sido passado um valor irá retornar um QRCode com a frase "Not found..."
        /// Caso ocorra erro na criação, retorna null.
        /// </summary>
        /// <param name="valueQrCode"></param>
        /// <returns></returns>
        public static string ToCreateQrCodeBase64(this string valueQrCode, bool complete)
        {
            byte[] imageQrCode = valueQrCode.ToCreateQrCode();
            string imageConvert = imageQrCode.ToBase64String();
            return complete ? $"data:image/png;base64,{imageConvert}" : imageConvert;
        }



    }
}
