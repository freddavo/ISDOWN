using System;
namespace AzureQueueDemo.Domain
{
    public class ServiceInformation
    {
        public Guid ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceStatus{ get; set; }
    }
}
