using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult Index()
        {
            TempData["Title"] = "PRODUCTS";
            var products = productService.GetProductDetails().ToList();
           

           
            return View(products);
        }
        public IActionResult Create()
        {
            TempData["Title"] = "CREATE PRODUCT";
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            productService.CreateProduct(product);
            return View();
        }
        public IActionResult Delete(int id)
        {
            var product = productService.Get(id);
            productService.DeleteProduct(product);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var product = productService.Get(id);
            productService.UpdateProduct(product);
            return View(product);
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            productService.UpdateProduct(product);
            return RedirectToAction("Index");
        }
        
    }
}
