using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShipperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(int id) //Orderin Id si
        {
            return View();
        }
    }
}
