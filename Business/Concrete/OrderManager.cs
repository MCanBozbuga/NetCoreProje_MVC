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
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            this._orderDal = orderDal;
        }
        public void CreateOrder(Order order)
        {
            _orderDal.Create(order);
        }

        public void DeleteOrder(Order order)
        {
            _orderDal.Delete(order);
        }

        public Order Get(int id)
        {
            return _orderDal.Get(id);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderDal.GetAll().ToList();
        }

        //public List<OrderDetailDto> GetOrderDetails()
        //{
        //    return _orderDal.GetOrderDetails();
        //}

        public void UpdateOrder(Order order)
        {
            _orderDal.Update(order);
        }
    }
}
