using QRCoder;

namespace SOVOS.IST.QRGenerator.API.Helpers
{
    public static class QRCoderHelper
    {
        private static QRCodeGenerator _codeGenerator = new();
        public static byte[] Generate(string input)
        {
            QRCodeData qrCodeData = _codeGenerator.CreateQrCode(input, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new(qrCodeData);
            byte[] qrCodeImage = qrCode.GetGraphic(5);
            return qrCodeImage;
        }
    }
}
