using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        private readonly ICategoryService categoryService;


        public ProductController(IProductService productService , ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            TempData["Title"] = "PRODUCTS";
            var products = productService.GetProductDetails().ToList();
           

           
            return View(products);
        }
        public IActionResult Create()
        {
            ViewBag.Categories = categoryService.GetAllCategories()
                .Select(x => new SelectListItem()
                {
                    Text = x.CategoryName,
                    Value = x.Id.ToString()
                });
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
            ViewBag.Categories = categoryService.GetAllCategories()
               .Select(x => new SelectListItem()
               {
                   Text = x.CategoryName,
                   Value = x.Id.ToString()
               });
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
