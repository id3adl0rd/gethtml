using System;
using System.Net;
using System.Text;

namespace html
{
    class Program
    {
        static void Main()
        {
            WebRequest webr = WebRequest.Create("https://lfwb.ru/index.php?title=Main_Page");
            HttpWebResponse resp = null;

            try
            {
                resp = (HttpWebResponse)webr.GetResponse();
            }
            catch (WebException e)
            {
                resp = (HttpWebResponse)e.Response;
            }

            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream, Encoding.GetEncoding(resp.CharacterSet));

            string sReadData = sr.ReadToEnd();

            switch (resp.StatusCode)
            {
                case HttpStatusCode.OK:
                    Console.WriteLine("Соединение имеется");
                    break;
                case HttpStatusCode.Forbidden:
                    Console.WriteLine("Доступ запрещен");
                    break;
                case HttpStatusCode.NotFound:
                    Console.WriteLine("Документ не найден");
                    break;
                case HttpStatusCode.Moved:
                    Console.WriteLine("Документ перемещен");
                    break;
                default:
                    Console.WriteLine("Что-то пошло не так");
                    break;
            }
        }
    }
}
