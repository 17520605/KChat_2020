using CHAT_WPF.Models;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CHAT_WPF.Utilities
{
    class Ultilities
    {
        public static BitmapImage ConvertStreamToBitmapImage(Stream stream)
        {
            if(stream != null)
            {
                var source = new BitmapImage();
                source.BeginInit();
                source.StreamSource = stream;
                source.EndInit();
                return source;
            }

            return null;
        }

        public static BitmapImage ConvertBase64StringToBitmapImage(string base64String)
        {
            if (!string.IsNullOrEmpty(base64String))
            {
                byte[] byteBuffer = Convert.FromBase64String(base64String);
                BitmapImage biImg = new BitmapImage();
                MemoryStream ms = new MemoryStream(byteBuffer);
                biImg.BeginInit();
                biImg.StreamSource = ms;
                biImg.EndInit();
                return biImg;
            }
            return null;
        }

        public static string GetRootPath()
        {
            return System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName((Environment.CurrentDirectory)));
        }

        public static string ConvertEmojiToCode(string emoji)
        {
            if (SystemValues.Emojis != null)
            {
                foreach (var  item in SystemValues.Emojis)
                {
                    if(item.Value == emoji)
                    {
                        return item.Key;
                    }

                }
            }
            return null;
        }

        public static string ConvertCodeToEmoji(string code)
        {
            if(SystemValues.Emojis != null)
            {
                string emoji = null;
                SystemValues.Emojis.TryGetValue(code, out emoji);
                return emoji;
            }
            return null;
        }

        public static Dictionary<string, string> SearchEmojiByCode(string code)
        {
            Dictionary<string, string> emojis = new Dictionary<string, string>();
            foreach (var emoji in SystemValues.Emojis)
            {
                if (emoji.Key.StartsWith(code))
                {
                    emojis.Add(emoji.Key, emoji.Value);
                }
            }
            return emojis;
        }



        public static string GetDefaultAvatarBase64String()
        {
            return "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";
        }

        public static string GetDefaultGroupImageBase64String()
        {
            return "R0lGODlhlgCWANUAAMLCwsPDw+Pj49LS0uXl5cHBwc3Nzf7+/t/f39ra2ujo6MXFxfz8/Pr6+sjIyNDQ0Ovr69bW1tPT0+fn58/Pz8zMzN7e3sbGxtnZ2dzc3MfHx+Li4uTk5PLy8vX19fHx8e3t7cTExNfX1+Hh4dvb29TU1MnJyfT09PPz8/v7+9XV1dHR0ff39+np6ezs7O/v7/39/djY2M7OzsrKysvLy93d3fDw8ODg4Pb29vj4+Orq6u7u7vn5+ebm5v///8DAwCH/C1hNUCBEYXRhWE1QPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4gPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS41LWMwMjEgNzkuMTU0OTExLCAyMDEzLzEwLzI5LTExOjQ3OjE2ICAgICAgICAiPiA8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPiA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIiB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIgeG1sbnM6c3RSZWY9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZVJlZiMiIHhtbG5zOnhtcD0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLyIgeG1wTU06T3JpZ2luYWxEb2N1bWVudElEPSJ4bXAuZGlkOjAyODAxMTc0MDcyMDY4MTE4MDgzQTdDQTI2MzU4OUI5IiB4bXBNTTpEb2N1bWVudElEPSJ4bXAuZGlkOjE0MzRFQzVBNDc0QjExRTQ4RDc1RDdCM0U3NUU3MkIzIiB4bXBNTTpJbnN0YW5jZUlEPSJ4bXAuaWlkOjE0MzRFQzU5NDc0QjExRTQ4RDc1RDdCM0U3NUU3MkIzIiB4bXA6Q3JlYXRvclRvb2w9IkFkb2JlIFBob3Rvc2hvcCBDUzYgKE1hY2ludG9zaCkiPiA8eG1wTU06RGVyaXZlZEZyb20gc3RSZWY6aW5zdGFuY2VJ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";
        }

        public static void SaveUserInfor(string userID, string username, string  password)
        { 
            string json = JsonConvert.SerializeObject(new LoginModel()
            {
                UserID = userID,
                Username = username,
                Password = password
            }); 

            //write string to file
            System.IO.File.WriteAllText(GetRootPath() + @"\login.txt", json);
        }

        public static LoginModel ReadUserInfor()
        {
            using (StreamReader r = new StreamReader((GetRootPath() + @"\login.txt")))
            {
                string json = r.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                LoginModel login = jss.Deserialize<LoginModel>(json);
                return login;
            }
        }
    }
}
