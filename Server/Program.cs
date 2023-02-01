using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://learn.microsoft.com/en-us/dotnet/api/system.net.httplistener?view=net-7.0
            Console.WriteLine("Welcome to Instachat server");

            // create a HTTP server that listens on port 8080
            // http://localhost:8080/
            const int port = 8080;
            string prefix = $"http://localhost:{port}/";

            Console.WriteLine($"Listening on {port}");
            HttpListener server = new HttpListener();
            server.Prefixes.Add(prefix);

            server.Start();
            
            bool running = true;
            while(running) 
            {

                HttpListenerContext context = server.GetContext();
                HttpListenerRequest request = context.Request();
                HttpListenerResponse response = context.Response();

                Console.WriteLine($"Request '{request.RawUrl}'");

                string html = $"";
                byte[] buffer = Encoding.UTF8.GetBytes(html);

                switch(request.Url)
                {
                    case "/":
                        buffer = File.ReadAllBytes("../../static/index.html");
                        break;
                    default:
                        string path = "../../ static" + request.RaUrl;
                        if(File.Exists(path))
                        {
                            buffer = File.ReadAllBytes(path);
                        }
                        else 
                        {
                            response.StatusCode = 404;
                            html = "Sorry - file not found";
                            buffer = Encoding.UTF8.GetBytes(html);
                            Console.WriteLine($"Unkown URL: {request.RawURL}");
                        }
                        break;
                }
                Console.WriteLine($"Sending: {buffer.length} bytes");
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);
                response.OutputStream.Close();
            }
            
            server.Stop();
        }
    }
}
