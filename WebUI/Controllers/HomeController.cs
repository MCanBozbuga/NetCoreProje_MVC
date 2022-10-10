using Business.Abstract;
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

        public HomeController(IProductService productService)
        {
            this.productService = productService;
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

            //Cart cartSession = SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet") == null ? new Cart() : SessionHelper.GetProductFromJson<Cart>(HttpContext.Session, "sepet");

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

    }

}

