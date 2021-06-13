using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Daemon
{
    public static class Daemon3
    {
        [FunctionName("Daemon3")]
        public static void Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log)
        {
            
            
        }
    }
}
