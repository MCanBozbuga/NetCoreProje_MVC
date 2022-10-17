using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class OrderDetail : BaseEntity
    {
        public int Id { get; set; }
        public Product Product { get; set; }

        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }


        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
