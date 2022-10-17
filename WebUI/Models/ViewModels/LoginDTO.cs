using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models.ViewModels
{
    public class LoginDTO
    {
        [Required(ErrorMessage = " --KULLANICI ADI BOŞ GEÇİLEMEZ")]
        public string Username { get; set; }

        [Required(ErrorMessage = " --ŞİFRE BOŞ GEÇİLEMEZ")]
        public string Password { get; set; }
    }
}
