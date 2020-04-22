using System;
using System.Drawing;
using System.IO;

namespace Core.Helpers
{
    public static class ImageHelper
    {
        public static string EncodeImage(string path)
        {
            using var image = Image.FromFile(path);
            using var m = new MemoryStream();
            image.Save(m, image.RawFormat);
            // Convert byte[] to Base64 String
            return Convert.ToBase64String(m.ToArray());
        }
    }
}