using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        //[Required(ErrorMessage = "Boş geçme")]
        //[MaxLength(50, ErrorMessage = "20 haneli olmalı")]
        public string Description { get; set; }
        public string ImagePath { get; set; }

        //Relational Mapping
        public virtual Category Category { get; set; } //todo: Lazy Load Nedir?
    }
}
