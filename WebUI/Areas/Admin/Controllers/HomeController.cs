using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        private readonly IOrderDetailService orderDetailService;
        private readonly IOrderService orderService;
        private readonly UserManager<AppUser> userManager;

        public HomeController(IProductService productService , IOrderDetailService orderDetailService, IOrderService orderService, UserManager<AppUser> userManager)
        {
            this.productService = productService;
            this.orderDetailService = orderDetailService;
            this.orderService = orderService;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            TempData["Title"] = "HOME PAGE";
            ViewBag.SiparisSayisi = orderService.GetAllOrders().Count();
            ViewBag.UrunSayisi = productService.GetAllProducts().Count();
            ViewBag.KullaniciSayisi = userManager.Users.Count();
            ViewBag.Gelir = orderDetailService.GetAllOrderDetails().Sum(x=>x.UnitPrice*x.Quantity);

            //OrderDto orderDto = new OrderDto();
            //orderDto.Orders = orderService.GetAllOrders().OrderByDescending(x => x.Id).ToList();
            //orderDto.OrderDetails = orderDetailService.GetAllOrderDetails().ToList();

            return View(orderService.GetAllOrders().OrderByDescending(x=>x.Id));
        }
    }
}
