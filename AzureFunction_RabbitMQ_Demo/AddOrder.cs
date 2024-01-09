using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AzureFunction_RabbitMQ_Demo.Models;

namespace AzureFunction_RabbitMQ_Demo
{
    public static class AddOrder
    {
        [FunctionName("AddOrder")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log,
             [RabbitMQ(QueueName = "orders", ConnectionStringSetting = "rbmq")] IAsyncCollector<Order> outputPocObj)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                Order order = JsonConvert.DeserializeObject<Order>(requestBody);
                await outputPocObj.AddAsync(order);
                log.LogInformation($"C# Order with ID: { order.Id} has been sent to service bus.");
                return new OkResult();

            }
            catch (Exception ex)
            {
                log.LogError(ex.Message, ex);
                return new BadRequestResult();
            }
        }
    }
}
