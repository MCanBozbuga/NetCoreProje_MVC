using Business.Abstract;
using Core.Common;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;
using WebUI.Utilities;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IOrderDetailService orderDetailService;
        private readonly IOrderService orderService;

        public HomeController(IProductService productService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IOrderDetailService orderDetailService, IOrderService orderService)
        {
            this.productService = productService;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.orderDetailService = orderDetailService;
            this.orderService = orderService;
        }

        public IActionResult Index()
        {
            TempData["sepet"] = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");
            var products = productService.GetProductDetails().ToList();
            return View(productService.GetProductDetails().ToList());
        }
      
        public IActionResult AddToCart(int id)
        {
            Cart cartSession;

            if (SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet") == null)
            {
                cartSession = new Cart();
            }
            else
            {
                cartSession = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");
            }

            var newProduct = productService.Get(id);

            CartItem cartItem = new CartItem()
            {
                Id = newProduct.Id,
                ProductName = newProduct.ProductName,
                UnitPrice = newProduct.UnitPrice

            };
            cartSession.AddItem(cartItem);

            SessionHelper.SetProductJson(HttpContext.Session, "sepet", cartSession);

            return RedirectToAction("Index");
        }

        public IActionResult MyCart()
        {
            if (SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet") != null)
            {
                Cart c = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");
                return View(c.MyCart);
            }
            return RedirectToAction("Index");
        }

        //public async Task <IActionResult> CompleteCard()
        //{
        //    Cart cart = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        Random rnd = new Random();
        //        var user = await userManager.GetUserAsync(User);
        //        Order order = new Order();
        //        order.User = user;
        //        order.OrderNumber = rnd.Next(1, 10000).ToString();
        //        OrderDetail orderDetail = new OrderDetail();


        //        foreach (var item in cart.MyCart)
        //        {
        //            Product product = productService.Get(item.Id);
        //            product.ProductName = item.ProductName;
        //            product.UnitPrice = item.UnitPrice;
        //            orderDetail.Product = product;
        //            orderDetail.Quantity = Convert.ToInt16(item.Quantity);
        //            orderDetail.UnitPrice = item.UnitPrice;
        //            //orderDetail.Product.ProductName = item.ProductName;
        //            //orderDetail.Quantity = Convert.ToInt16(item.Quantity);

        //        }
        //        order.OrderDetails.Add(orderDetail);
        //        orderService.CreateOrder(order);
        //        orderDetailService.CreateOrderDetail(orderDetail);
        //        MailSender.SendEmail(user.Email, "Siparişiniz Oluşturuldu", $"#{order.OrderNumber} numaralı siparişiniz oluşturuldu. Kargoya verdiğimizde sizi bilgilendireceğiz!");
        //        SessionHelper.RemoveSession(HttpContext.Session, "sepet");
        //        return View(order);
        //    }
        //    return RedirectToAction("Index");
        //}
    }

 }



