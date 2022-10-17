using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;


        public UserController(UserManager<AppUser> userManager, UserManager<AppUserRole> userManager1)
        {
            this.userManager = userManager;

        }
        public IActionResult Index()
        {
         
            return View(userManager.Users);
        }
    }
}
