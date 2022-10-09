using Core.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class CategoryDetailDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public short UnitsInStock { get; set; }
        public string ProductName { get; set; }
        public DataStatus  Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteData { get; set; }
    }
}
