using Core.Entities;
using Core.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Order : BaseEntity
    {
        //Bir siparişin içerisinde birden fazla detay bulunur
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
            //OrderDetail ile Order'i ilişkilendirmemize yarıyor. ctor yapmasaydık manuel girecektik.
            ShipperStatus = ShipStatus.NotShipped;
        }
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public decimal TotalPrice { get; set; }

        public ShipStatus ShipperStatus { get; set; }
        public DateTime? ShippedDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public AppUser User { get; set; }
        public int? ShipperId { get; set; }
        public Shipper Shipper { get; set; }
    }
}
