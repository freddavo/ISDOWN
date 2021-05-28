using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AzureQueueDemo.Domain;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;

namespace AzureQueueDemo.Sender
{
    class Program
    {
        private static string AZURE_SERVICE_BUS_CONNECTIONSTRING = "Endpoint=sb://servicebus-servicesatus.servicebus.windows.net/;S" +
            "haredAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=OgxwUGyscSbN5tJmJKslYgbSClPCjXvE/FBMq7ahi9M=";
        private static string QUEUE_NAME = "fila1";

        static List<ServiceInformation> Services = new List<ServiceInformation>()
           {
               new ServiceInformation()
               {
                   ServiceId = Guid.NewGuid(),
                   ServiceName = "E-Learning",
                   ServiceStatus = "Ativo"

               },
                new ServiceInformation()
               {
                   ServiceId = Guid.NewGuid(),
                   ServiceName = "PACO",
                   ServiceStatus = "Ativo"

               },
                 new ServiceInformation()
               {
                   ServiceId = Guid.NewGuid(),
                   ServiceName = "GLUA",
                   ServiceStatus = "Não Ativo"

               },
                  new ServiceInformation()
               {
                   ServiceId = Guid.NewGuid(),
                   ServiceName = "Ua.pt",
                   ServiceStatus = "Ativo"

               }

           };

        static async Task Main(string[] args)
        {
            Console.WriteLine("Do you want to send Services Information? If Yes , Press Y.");
            var result = Console.ReadLine();
            if (result.Equals("Y"))
            {
                IQueueClient client = new QueueClient(AZURE_SERVICE_BUS_CONNECTIONSTRING, QUEUE_NAME);
                foreach (var item in Services)
                {
                    var messageBody = JsonConvert.SerializeObject(item);
                    var message = new Message(Encoding.UTF8.GetBytes(messageBody));
                    await client.SendAsync(message);
                    Console.WriteLine($"Sending Message : {item.ServiceName.ToString()} ");

                }
            }
            Console.Read();
        }
    }
}
