using MyEvernote.Entities;
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
            return View();
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