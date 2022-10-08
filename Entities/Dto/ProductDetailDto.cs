using Core.Entities;
using Core.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class ProductDetailDto/* : IDto*/
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public DataStatus Status { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

    }
}
