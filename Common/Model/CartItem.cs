using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model
{
    public class CartItem
    {
        //bir sepetin ......'sı olur.
        public CartItem()
        {
            Quantity = 1;
        }
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get { return Quantity * UnitPrice; } }


    }
}
