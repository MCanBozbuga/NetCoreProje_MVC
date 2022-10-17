using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
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
        public async Task<IActionResult> Create(Product product, IFormFile imageFile) 
        {

            try
            {
                string path;
                if (imageFile == null)
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\", "no-image.jpg");
                    product.ImagePath = "no-image.jpg";
                    return View();
                }
                else
                {
                    //görsel ismi değiştirme
                    var newFileName = "";
                    var uniqeName = Guid.NewGuid();
                    var fileArray = imageFile.FileName.Split('.');
                    var extension = fileArray[fileArray.Length - 1].ToLower();
                    newFileName = uniqeName + "." + extension;


                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\", imageFile.FileName);

                    //FileStream stream = new FileStream(path, FileMode.Create);
                    //await imageFile.CopyToAsync(stream);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                    product.ImagePath = newFileName;
                    productService.CreateProduct(product);
                    TempData["result"] = "ürün eklendi";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["result"] = ex.Message;
                return View();
            }

            //productService.CreateProduct(product);
            //return View();
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
