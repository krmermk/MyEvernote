using MyEvernote.Common;
using MyEvernote.Entities;
using MyEvernote.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEvernote.Web.Init
{
    public class WebCommon : ICommon
    {
        public string GetUsername()
        {
            EvernoteUser user = SessionManager.User;
            string name = (user != null) ? user.UserName : "System";
            return name;

        }
    }
}