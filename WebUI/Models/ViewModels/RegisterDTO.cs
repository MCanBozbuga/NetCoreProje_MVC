using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models.ViewModels
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = " --KULLANICI ADI BOŞ GEÇİLEMEZ")]
        public string Username { get; set; }
        [Required(ErrorMessage = "  --EMAİL BOŞ GEÇİLEMEZ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "  --ŞİFRE BOŞ GEÇİLEMEZ")]
        public string Password { get; set; }

        [Required(ErrorMessage = " --ŞİFRE BOŞ GEÇİLEMEZ")]
        [Compare("Password", ErrorMessage = "  --ŞİFRELER UYUŞMUYOR")]
        public string ConfirmPassword { get; set; }
    }
}
