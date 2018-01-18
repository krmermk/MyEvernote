using MyEvernote.BusinessLayer;
using MyEvernote.Entities;
using MyEvernote.Entities.Messages;
using MyEvernote.Entities.ValueObjects;
using MyEvernote.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEvernote.Web.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                EvernoteUserManager eum = new EvernoteUserManager();
                Result<EvernoteUser> res = eum.RegisterUser(model);
                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(model);
                }
                SuccessViewModel succ = new SuccessViewModel()
                {
                    Title="Kayıt Başarılı",
                    RedirectingUrl="/Login/Login",
                };
                succ.Items.Add("Lütfen e-posta adresine gönderdiğimiz aktivasyon link'ine tıklayarak hesabınızı aktve ediniz. Hesabınızı aktive etmeden iriş yapmaz,not yazamaz ve beğenip yorumyapamazsınız");
                return View("Success",succ);
            }
            return View(model);

        }

        public ActionResult UserActivate(Guid id)
        {
            if (ModelState.IsValid)
            {
                EvernoteUserManager eum = new EvernoteUserManager();
                Result<EvernoteUser> res = eum.ActivateUser(id);
                if (res.Errors.Count>0)
                {
                    ErrorViewModel err = new ErrorViewModel()
                    {
                        Title="Geçersiz İşlem",
                        Items=res.Errors
                    };
                    return View("Error",err);
                }

                SuccessViewModel succ = new SuccessViewModel()
                {
                    Title = "Hesap Aktifleştirildi",
                    RedirectingUrl = "/Login/Login",
                };
                succ.Items.Add("Hesabınınz aktifleştirildi. Artık siteme giriş yapabilir,not yazabilir ve beğenip yorum yapabilirsiniz");
                return View("Success", succ);
            }

            return View();
        }

    }
}