using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class CompleteCart
    {
        public Order AddOrder(AppUser user , Cart cart , int number)
        {
            Order order = new();
            order.User = user;
            order.OrderNumber = number;

            decimal totalPrice = 0;

            foreach (var item in cart.MyCart)
            {
                totalPrice += item.SubTotal;
            }

            order.TotalPrice = totalPrice;
            return order;
        }
        public int RandomNumber()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 1000);
            return number;
        }
        public bool RandomNumberCheck(IEnumerable<Order> list , int number)
        {
            if (list.Where(x=>x.OrderNumber==number).Count()>0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
