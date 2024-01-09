using System;
using AzureFunction_RabbitMQ_Demo.Data;
using AzureFunction_RabbitMQ_Demo.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFunction_RabbitMQ_Demo
{
    public class OrderProcessorFunction
    {
        private readonly OrderDbContext _context;
        public OrderProcessorFunction(OrderDbContext context)
        {
            _context =  context;
        }
        [FunctionName("OrderProcessorFunction")]
        public void Run([RabbitMQTrigger("orders", ConnectionStringSetting = "rbmq")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
            try
            {
                Order order = JsonConvert.DeserializeObject<Order>(myQueueItem);
                _context.Orders.Add(order);
                _context.SaveChanges();
                log.LogInformation("order processed successsfully");
            }
        catch (Exception ex)
            {
                log.LogError($"Error Occurred:{ex.Message}");
            }

        }

    }
}
