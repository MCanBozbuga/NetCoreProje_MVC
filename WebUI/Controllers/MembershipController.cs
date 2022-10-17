using Core.Common;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models.ViewModels;

namespace WebUI.Controllers
{
    public class MembershipController : Controller
    {
        // UsserManager ve SignInManager , => Identity Kütüphanesinden geliyor. Projeyi kurarken Identity kütüphanesini ekleyerek kurmuştuk.
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public MembershipController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (ModelState.IsValid) //giriş doğruysa, yeni bir kullanıcı oluştur => Dto içindeki username'i aktar.
            {
                AppUser newUser = new AppUser()
                {
                    UserName = registerDTO.Username,
                    Email = registerDTO.Email,
                    // Şifre buraya değil , oluştururken veriliyor.
                };
                var result = await userManager.CreateAsync(newUser, registerDTO.Password);

                var registerToken = "";
                int sayac = 0;
                if (result.Succeeded)
                {

                    while (true)
                    {
                        registerToken =  userManager.GenerateEmailConfirmationTokenAsync(newUser).Result;
                        
                        if (!registerToken.Contains("/"))
                        {
                            break;
                        }
                        sayac++;
                    }



                    MailSender.SendEmail(registerDTO.Email, "Register", $"Merhaba {registerDTO.Username}! kayıt işleminiz başarılı şekilde oluşturuldu! Üyeliği tamamlamak için linke tıklayın https://localhost:5001/membership/confirmation/" + newUser.Id + "/" + registerToken);

                    TempData["result"] = $"{newUser.Email} adresine aktivasyon maili gönderdik. Üyeliğinizi aktif hale getirmek için ilgili linki tıklayın.";

                    //return RedirectToAction("Confirmation", new { id = newUser.Id, registerCode = registerToken.Result });
                    return View(registerDTO);
                }
                else
                {
                    return View(registerDTO);
                }

            }
            return View(registerDTO);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(loginDTO.Username);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, loginDTO.Password, false, false);
                    if (result.Succeeded)
                    {
                        return View();
                        //return RedirectToAction("Index");
                    }
                }
                return View();
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            //return View();
            return RedirectToAction("Login");
        }


        #region çalıtı
        public async Task<IActionResult> Confirmation(string id, string registerCode)
        {
            if (id != null && registerCode != null)
            {
                var user = await userManager.FindByIdAsync(id);
                var confirm = await userManager.ConfirmEmailAsync(user, registerCode);
                if (confirm.Succeeded)
                {
                    return RedirectToAction("Login");
                }

            }
            return View();
        }
        #endregion
    }
}

