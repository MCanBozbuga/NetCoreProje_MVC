using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDetailDal : EfEntityRepositoryBase<OrderDetail, ProjectContext>, IOrderDetailDal
    {
        private readonly ProjectContext context;

        public EfOrderDetailDal(ProjectContext context) : base(context)
        {
            this.context = context;
        }

        public List<OrderDetailDto> GetOrderDetails()
        {
            var result = from o in context.Orders
                         join od in context.OrderDetails
                         on o.Id equals od.OrderId
                         join p in context.Products
                         on od.ProductId equals p.Id
                         select new OrderDetailDto
                         {
                             ProductId = p.Id,
                             OrderDetailId = od.Id,
                             OrderId = o.Id,
                             Quantity = od.Quantity,
                             UnitPrice = od.UnitPrice
                         };
            return result.ToList();
        }
    }
}
