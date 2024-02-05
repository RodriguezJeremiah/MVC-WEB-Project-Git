using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVC_WEB_Project.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int StockOnHand { get; set; }
        public decimal Price { get; set; }
    }
}
