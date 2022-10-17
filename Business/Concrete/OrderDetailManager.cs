using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailDal _orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal )
        {
         
            this._orderDetailDal = orderDetailDal;
        }

        public void CartDetail(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }

        public void CreateOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailDal.Create(orderDetail);
        }

        public void DeleteOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailDal.Delete(orderDetail);
        }

        public OrderDetail Get(int id)
        {
            return _orderDetailDal.Get(id);
        }

        public IEnumerable<OrderDetail> GetAllOrderDetails()
        {
            return _orderDetailDal.GetAll().ToList();
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailDal.Update(orderDetail);
        }
    }
}
