using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AzureQueueDemo.Domain;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;

namespace AzureQueueDemo.Receiver
{
    class Program
    {
        private static string AZURE_SERVICE_BUS_CONNECTIONSTRING = "Endpoint=sb://servicebusua.servicebus" +
            ".windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAc" +
            "cessKey=0M5sv2N1VifxyVPpIo6uYgI+OWOEAUA0n/vvoJmByxY=";
        private static string QUEUE_NAME = "fila1";
        private static IQueueClient client;
        static async Task Main(string[] args)
        {
            await ReceiveMessagesAsync();
        }

        private static async Task ReceiveMessagesAsync()
        {
            await Task.Factory.StartNew(() =>
            {
                client = new QueueClient(AZURE_SERVICE_BUS_CONNECTIONSTRING, QUEUE_NAME);
                var options = new MessageHandlerOptions(ExceptionMethod)
                {
                    MaxConcurrentCalls = 1,
                    AutoComplete = false
                };
                client.RegisterMessageHandler(ExecuteMessageProcessing, options);
            });
            Console.Read();

        }

        private static async Task ExecuteMessageProcessing(Message message, CancellationToken arg2)
        {
            var result = JsonConvert.DeserializeObject<ServiceInformation>(Encoding.UTF8.GetString(message.Body));
            Console.WriteLine($"Service Id is {result.ServiceId}, Service name is {result.ServiceName} and his status is {result.ServiceStatus}");
            await client.CompleteAsync(message.SystemProperties.LockToken);
        }

        private static async Task ExceptionMethod(ExceptionReceivedEventArgs arg)
        {
            await Task.Run(() =>
           Console.WriteLine($"Error occured. Error is {arg.Exception.Message}")
           );
        }
    }
}
