using AzureFunction_RabbitMQ_Demo.Data;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;


[assembly:FunctionsStartup(typeof(AzureFunction_RabbitMQ_Demo.Startup))]
namespace AzureFunction_RabbitMQ_Demo
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string conn = Environment.GetEnvironmentVariable("SQL");
            builder.Services.AddDbContext<OrderDbContext>(options => options.UseSqlServer(conn));
        }
    }
}
