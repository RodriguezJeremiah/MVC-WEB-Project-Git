using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVC_WEB_Project.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Customer Customer { get; set; }
        //public int ID []

        //Navigation property for OrderItems
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
