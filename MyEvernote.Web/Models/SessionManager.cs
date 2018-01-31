﻿using MyEvernote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEvernote.Web.Models
{
    //Bu class'ı login olan kullanıcıyı bu class yardımıyla gerekli yerlerde kullanmak için oluşturuldu
    //Metodu statik yaparak instance almadan(new'lemeden) kulanmak. 
    public class SessionManager
    {
        public static EvernoteUser User
        {
            get
            {
              
                return Get<EvernoteUser>("login");
            }
        }

        public static void Set<T>(string key, T obj)
        {
            HttpContext.Current.Session[key] = obj;
        }
        public static T Get<T>(string key)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                return (T)HttpContext.Current.Session[key];
            }
            return default(T);
        }

        public static void Remove(string key)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                HttpContext.Current.Session.Remove(key);
            }
        }

        public static void Clear()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}