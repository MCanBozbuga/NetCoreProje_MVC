using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Ogrenci")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            TempData["Title"] = "HOME PAGE";
            return View();
        }
    }
}
