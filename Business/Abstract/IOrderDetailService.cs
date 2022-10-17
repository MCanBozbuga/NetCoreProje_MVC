using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderDetailService
    {
        IEnumerable<OrderDetail> GetAllOrderDetails();
        //Create
        void CreateOrderDetail(OrderDetail orderDetail);
        //Delete
        void DeleteOrderDetail(OrderDetail orderDetail);
        //Update
        void UpdateOrderDetail(OrderDetail orderDetail);
        //Get
        OrderDetail Get(int id);
        void CartDetail(OrderDetail orderDetail);
    }
}
