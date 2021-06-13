using System;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Daemon
{
    public static class Daemon3
    {
        [FunctionName("Daemon3")]
        public static void Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log)
        {
            GetRequest("https://localhost:6001/api/service/v1");




            
        }
        
        async static void GetRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        Console.WriteLine(mycontent);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
