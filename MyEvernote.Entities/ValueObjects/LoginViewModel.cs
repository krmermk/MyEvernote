using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEvernote.Entities.ValueObjects
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Kullanıcı Adı alanı boş geçilemez."),
            StringLength(30, ErrorMessage = "Kullanıcı adı max.{0} karakter olmalı")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Şifre alanı boş geçilemez."),
            DataType(DataType.Password),
            StringLength(30, ErrorMessage = "Şifre max.{0} karakter olmalı")]
        public string Password { get; set; }
    }
}