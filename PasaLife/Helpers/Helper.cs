using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PasaLife.Helpers
{
    public static class Helper
    {
        public static string UploadImage(string imgCropped, string root, string folder)
        {
            string filename = GetUniqueFileName($"pasha-life-{DateTime.Now.ToString("ffffff")}.jpeg");
            string filewithFolder = Path.Combine(folder, filename);
            string fullPath = Path.Combine(root, filewithFolder);
            string base64 = imgCropped.Substring(imgCropped.IndexOf(',') + 1);
            SaveByteArrayAsImage(fullPath, base64);
            return filename;
        }
        public static async Task SendMessage(string messageSubject, string messageBody, string mailTo)
        {

            SmtpClient client = new SmtpClient("smtp.yandex.com", 587);
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("kamran.nabiyev@toogoo.az", "Lene1234");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage message = new MailMessage("kamran.nabiyev@toogoo.az", mailTo);
            message.Subject = messageSubject;
            message.Body = messageBody;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;


            await client.SendMailAsync(message);


        }
        public static void SaveByteArrayAsImage(string fullOutputPath, string base64String)
        {
            byte[] bytes = Convert.FromBase64String(base64String);

            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
                var i2 = new Bitmap(image);
                image.Save(fullOutputPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
        public static string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
        public static void DeleteImage(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);

            }
        }
    }
}
