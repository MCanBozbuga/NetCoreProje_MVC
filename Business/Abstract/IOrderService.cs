using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrders();
        //Create
        void CreateOrder(Order Order);
        //Delete
        void DeleteOrder(Order Order);
        //Update
        void UpdateOrder(Order Order);
        //Get
        Order Get(int id);

    }
}
