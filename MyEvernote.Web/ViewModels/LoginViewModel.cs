using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEvernote.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Kullanıcı Adı alanı boş geçilemez.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifre alanı boş geçilemez."),DataType(DataType.Password)]
        public string Password { get; set; }
    }
}