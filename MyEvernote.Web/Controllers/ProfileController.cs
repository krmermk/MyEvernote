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

        [HttpPost]
        public ActionResult EditProfile(EvernoteUser data, HttpPostedFileBase ProfileImage)
        {
            if (ProfileImage != null && (ProfileImage.ContentType == "image/jpeg" || ProfileImage.ContentType == "image/jpg" || ProfileImage.ContentType == "image/png"))
            {
                string filename = $"user_{data.ID}.{ProfileImage.ContentType.Split('/')[1]}";
                ProfileImage.SaveAs(Server.MapPath($"~/Content/images/{filename}"));
                data.ImagesFileName = filename;
            }
            EvernoteUserManager eum = new EvernoteUserManager();
            Result<EvernoteUser> res = eum.UpdateProfile(data);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel err = new ErrorViewModel()
                {
                    Title = "Geçersiz İşlem",
                    Items = res.Errors,
                    RedirectingUrl= "/Profile/EditProfile"
                };
                return View("Error", err);
            }
            Session["login"] = res.Results; //Profil güncellendiği için Sessionda da güncelleme yapılır.
            return RedirectToAction("ShowProfile");
        }

        public ActionResult RemoveProfile()
        {
            return View();
        }

    }
}