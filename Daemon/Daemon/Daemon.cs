using System;
using System.IO;
using System.Net;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Daemon
{
    public static class Daemon
    {
        [FunctionName("Daemon")]
        public static void Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer, ILogger log)
        {
            //ACCESS TOKEN (POST)
            var url = "https://wso2-gw.ua.pt/token?grant_type=client_credentials&state=1234567890&scope=openid";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.ContentType = "application/x-www-form-urlencoded";
            httpRequest.Headers["Authorization"] = "Basic MXRCUEZCWjJmWV8yZElHZlowaERUWWhURmZvYTpWV21rOHRwWUNmWUYzYlN4N1pfa2tUX1F3Zjhh";
            httpRequest.Headers["Content-Length"] = "0";


            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                //OBTER ACCESS TOKEN
                var result = streamReader.ReadToEnd();
                char[] chars = result.ToCharArray();

                for (int i = 17; i < 53; i++)
                    Console.Write(chars[i]);
                myfunc(chars);
            }


            //GET WEBSITES
            void myfunc(char[] chars)
            {
                var url1 = "https://wso2-gw.ua.pt/scom/v1.0/WebSites";

                var httpRequest1 = (HttpWebRequest)WebRequest.Create(url1);

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                string resultado0 = "Bearer ";
                char resultado = chars[17];
                char resultado1 = chars[18];
                char resultado2 = chars[19];
                char resultado222 = chars[20]; char resultado3 = chars[21]; char resultado4 = chars[22]; char resultado5 = chars[23];
                char resultado6 = chars[24]; char resultado7 = chars[25]; char resultado8 = chars[26]; char resultado9 = chars[27];
                char resultado10 = chars[28]; char resultado11 = chars[29]; char resultado12 = chars[30]; char resultado13 = chars[31];
                char resultado14 = chars[32]; char resultado15 = chars[33]; char resultado16 = chars[34]; char resultado17 = chars[35];
                char resultado18 = chars[36]; char resultado19 = chars[37]; char resultado20 = chars[38]; char resultado21 = chars[39];
                char resultado22 = chars[40]; char resultado23 = chars[41]; char resultado24 = chars[42]; char resultado25 = chars[43];
                char resultado26 = chars[44]; char resultado27 = chars[45]; char resultado28 = chars[46]; char resultado29 = chars[47];
                char resultado30 = chars[48]; char resultado31 = chars[49]; char resultado32 = chars[50]; char resultado33 = chars[51];
                char resultado34 = chars[52]; char resultado35 = chars[53];


                httpRequest1.Headers["Authorization"] = resultado0 + resultado.ToString() + resultado1.ToString() + resultado2.ToString() + resultado222.ToString()
                     + resultado3.ToString() + resultado4.ToString() + resultado5.ToString() + resultado6.ToString() + resultado7.ToString()
                     + resultado8.ToString() + resultado9.ToString() + resultado10.ToString() + resultado11.ToString() + resultado12.ToString()
                     + resultado13.ToString() + resultado14.ToString() + resultado15.ToString() + resultado16.ToString() + resultado17.ToString()
                     + resultado18.ToString() + resultado19.ToString() + resultado20.ToString() + resultado21.ToString() + resultado22.ToString()
                     + resultado23.ToString() + resultado24.ToString() + resultado25.ToString() + resultado26.ToString() + resultado27.ToString()
                     + resultado28.ToString() + resultado29.ToString() + resultado30.ToString() + resultado31.ToString() + resultado32.ToString()
                     + resultado33.ToString() + resultado34.ToString();

                var httpResponse1 = (HttpWebResponse)httpRequest1.GetResponse();

                using (var streamReader = new StreamReader(httpResponse1.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(result);
                }
            }
        }
    }
}
