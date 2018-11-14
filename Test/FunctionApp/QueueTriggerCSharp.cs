using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionApp
{
    public static class QueueTriggerCSharp
    {
        /// <summary>
        /// https://docs.microsoft.com/ko-kr/azure/azure-functions/functions-develop-vs#add-bindings
        /// </summary>
        /// <param name="myQueueItem"></param>
        /// <param name="myQueueItemCopy"></param>
        /// <param name="log"></param>
        //[FunctionName("QueueTriggerCSharp")]
        //public static void Run(
        //    [QueueTrigger("myqueue-items-source", Connection = "AzureWebJobsStorage")] string myQueueItem, 
        //    [QueueTrigger("myqueue-items-destination", Connection = "AzureWebJobsStorage")]string myQueueItemCopy, ILogger log)
        //{
        //    log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        //    myQueueItemCopy = myQueueItem;
        //}
    }
}
