using MyEvernote.BusinessLayer;
using MyEvernote.Entities;
using MyEvernote.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEvernote.Web.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult ShowProfile()
        {
            EvernoteUser currentUser = Session["login"] as EvernoteUser;
            EvernoteUserManager eum = new EvernoteUserManager();
            Result<EvernoteUser> res = eum.GetUserById(currentUser.ID);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel err = new ErrorViewModel()
                {
                    Title = "Hata Oluştu",
                    Items = res.Errors
                };
                return View("Error", err);
            }
            return View(res.Results);
        }
        public ActionResult EditProfile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditProfile(EvernoteUser data)
        {
            return View();
        }

        public ActionResult RemoveProfile()
        {
            return View();
        }

    }
}