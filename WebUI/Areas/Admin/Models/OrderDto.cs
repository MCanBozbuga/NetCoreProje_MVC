using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Models
{
    public class OrderDto
    {
        public OrderDto()
        {
            Orders = new List<Order>();
            OrderDetails = new List<OrderDetail>();
        }
        public List<Order> Orders { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
