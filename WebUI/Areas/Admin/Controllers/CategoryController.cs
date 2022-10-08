using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
      
        public IActionResult Index()
        {
            TempData["Title"] = "CATEGORY";
            var categories = categoryService.GetCategoryDetails().ToList();
            return View(categories);
        }
        //[Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            TempData["Title"] = "CREATE CATEGORY";
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            categoryService.CreateCategory(category);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var deleteCategory = categoryService.Get(id);
            categoryService.DeleteCategory(deleteCategory);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var updateCategory = categoryService.Get(id);
            categoryService.UpdateCategory(updateCategory);
            return View(updateCategory);
        }
        [HttpPost]
        IActionResult Update(Category category)
        {
            categoryService.UpdateCategory(category);
            return RedirectToAction("Index");
        }

    }
}
