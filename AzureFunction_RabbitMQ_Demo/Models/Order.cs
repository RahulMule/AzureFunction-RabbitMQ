using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunction_RabbitMQ_Demo.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        [Range(0, int.MaxValue)]

        public int Quantity { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
    }
}
