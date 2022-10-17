using Business.Abstract;
using Core.Common;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;
using WebUI.Utilities;

namespace WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IOrderDetailService orderDetailService;
        private readonly UserManager<AppUser> userManager;
        private readonly IProductService productService;

        public OrderController(IOrderService orderService, IOrderDetailService orderDetailService, UserManager<AppUser> userManager, IProductService productService)
        {
            this.orderService = orderService;
            this.orderDetailService = orderDetailService;
            this.userManager = userManager;
            this.productService = productService;
        }
        public IActionResult Index()
        {
            Cart cart = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");
            return View(cart.MyCart);
        }
        public async Task<IActionResult> CompleteCart()
        {
            Cart cart = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");
            if (User.Identity.IsAuthenticated)
            {
                CompleteCart completeCart = new();
                int rndNumber = completeCart.RandomNumber();
                var user = await userManager.GetUserAsync(User);
                while (true)
                {
                    if (completeCart.RandomNumberCheck(orderService.GetAllOrders(),rndNumber))
                    {
                        break;
                    }
                    rndNumber = completeCart.RandomNumber();
                }
                Order order = completeCart.AddOrder(user, cart, rndNumber);
                orderService.CreateOrder(order);

                foreach (var item in cart.MyCart)
                {
                    OrderDetail orderDetail = new();
                    orderDetail.ProductId = item.Id;
                    orderDetail.UnitPrice = item.UnitPrice;
                    orderDetail.Quantity = item.Quantity;
                    orderDetail.OrderId = orderService.GetAllOrders().Max(x => x.Id);

                    //stok eksiltme;

                    Product product = productService.Get(orderDetail.ProductId);
                    product.UnitsInStock = Convert.ToInt16(product.UnitsInStock - orderDetail.Quantity);
                    productService.UpdateProduct(product);

                    orderDetailService.CreateOrderDetail(orderDetail);
                };
                MailSender.SendEmail(user.Email, "Siparişiniz Oluşturuldu", $"#{order.OrderNumber} numaralı siparişiniz oluşturuldu. Kargoya verdiğimizde sizi bilgilendireceğiz!");
                SessionHelper.RemoveSession(HttpContext.Session, "sepet");
                return View(order);

            }
            return RedirectToAction("Index");
        }
    }
}
