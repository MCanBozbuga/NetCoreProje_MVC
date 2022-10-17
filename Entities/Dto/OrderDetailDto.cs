using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class OrderDetailDto
    {

        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int OrderDetailId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
