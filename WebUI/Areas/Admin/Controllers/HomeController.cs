using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult Index()
        {
            TempData["Title"] = "HOME PAGE";
            ViewBag.SiparisSayisi = 100;
            ViewBag.UrunSayisi = productService.GetAllProducts().Count();
            ViewBag.KullaniciSayisi = 100;
            ViewBag.Gelir = 100;
            return View();
        }
    }
}
