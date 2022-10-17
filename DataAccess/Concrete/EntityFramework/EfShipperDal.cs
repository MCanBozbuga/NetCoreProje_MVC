using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfShipperDal : EfEntityRepositoryBase<Shipper, ProjectContext>, IShipperDal
    {
        public EfShipperDal(ProjectContext context) : base(context)
        {
        }
    }
}
