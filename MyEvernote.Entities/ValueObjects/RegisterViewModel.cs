using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEvernote.Entities.ValueObjects
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ad alanı boş geçilemez."),
          StringLength(25, ErrorMessage = "Kullanıcı adı max.{0} karakter olmalı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş geçilemez."),
          StringLength(25, ErrorMessage = "Kullanıcı adı max.{0} karakter olmalı")]
        public string Surname { get; set; }

        [Required(ErrorMessage ="Kullanıcı Adı alanı boş geçilemez."),
            StringLength(30,ErrorMessage ="Kullanıcı adı max.{0} karakter olmalı")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email alanı boş geçilemez."),
            StringLength(100, ErrorMessage = "Email max.{0} karakter olmalı"),
            EmailAddress(ErrorMessage ="Email alnı için lütfen geçerli bir email giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş geçilemez."),
            StringLength(30, ErrorMessage = "Şifre max.{0} karakter olmalı")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre Tekrar alanı boş geçilemez."),
            StringLength(30, ErrorMessage = "Şifre Tekrar max.{1} karakter olmalı"),
            Compare("Password",ErrorMessage ="Şifre ile Şifre tekrar uyuşmuyor.")]
        public string RePassword { get; set; }
    }
}