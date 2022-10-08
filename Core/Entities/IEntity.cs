using Core.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public interface IEntity
    {
        //public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }
        public bool Discontinued { get; set; }
    }
}
