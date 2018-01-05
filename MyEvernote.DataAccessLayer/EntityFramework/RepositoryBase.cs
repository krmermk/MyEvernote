using MyEvernote.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Singleton Pattern

//Lock:New ile ürettiğimiz nesneyi static yaptığımız için 1 tane oluşacak.Fakat çok küçük bir ihtimal de olsa, nesne oluştu mu kontrolü yaptığımız if bloğu içerisine aynı anda (özellikle uygulamayı multi-thread yazdıysan - aynı anda 2 thread) girebilir.Dolayısı ile bu sefer nesneden 2 tane oluşur.Dolayısı ile onu önlemek için lock ile multi-thread uygulamalardaki bu duruma karşı tek thread in aynı anda nesne üretimine girmesini garantilemiş oluyoruz.
namespace MyEvernote.DataAccessLayer.EntityFramework
{
    public class RepositoryBase
    {
        protected static MyEverNoteDbContext db;
        private static object _lock = new object();

        protected RepositoryBase()
        {
            CreateContext();
        }

        public static void CreateContext()
        {
            if (db == null)
            {
                
                lock (_lock)
                {
                    if (db == null)
                    {
                        db = new MyEverNoteDbContext();
                    }
                }

            }
        }
    }
}
