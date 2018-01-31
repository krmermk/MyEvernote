using MyEvernote.BusinessLayer;
using MyEvernote.BusinessLayer.ResultManager;
using MyEvernote.Entities;
using MyEvernote.Web.Models;
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
        private EvernoteUserManager eum = new EvernoteUserManager();
        // GET: Profile
        public ActionResult ShowProfile()
        {
           
            Result<EvernoteUser> res = eum.GetUserById(SessionManager.User.ID);
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
            Result<EvernoteUser> res = eum.GetUserById(SessionManager.User.ID);
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
            ModelState.Remove("ModifiedUser");
            if (ModelState.IsValid)
            {
                if (ProfileImage != null && (ProfileImage.ContentType == "image/jpeg" || ProfileImage.ContentType == "image/jpg" || ProfileImage.ContentType == "image/png"))
                {
                    string filename = $"user_{data.ID}.{ProfileImage.ContentType.Split('/')[1]}";
                    ProfileImage.SaveAs(Server.MapPath($"~/Content/images/{filename}"));
                    data.ImagesFileName = filename;
                }
                Result<EvernoteUser> res = eum.UpdateProfile(data);
                if (res.Errors.Count > 0)
                {
                    ErrorViewModel err = new ErrorViewModel()
                    {
                        Title = "Geçersiz İşlem",
                        Items = res.Errors,
                        RedirectingUrl = "/Profile/EditProfile"
                    };
                    return View("Error", err);
                }
                SessionManager.Set<EvernoteUser>("login",res.Results); //Profil güncellendiği için Sessionda da güncelleme yapılır.
                return RedirectToAction("ShowProfile");
            }
            return View(data);

        }

        public ActionResult RemoveProfile()
        {
          
            Result<EvernoteUser> res = eum.RemoveUserById(SessionManager.User.ID);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel err = new ErrorViewModel()
                {
                    Title = "Profil Silinemedi",
                    Items = res.Errors,
                    RedirectingUrl = "/Profile/EditProfile"
                };
                return View("Error", err);
            }
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}