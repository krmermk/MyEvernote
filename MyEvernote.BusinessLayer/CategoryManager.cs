using MyEvernote.DataAccessLayer.EntityFramework;
using MyEvernote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.BusinessLayer
{
   public class CategoryManager
    {
        private Repository<Category> repoCategory = new Repository<Category>();

        public List<Category> GetCategory()
        {
            return repoCategory.List();
        }
    }
}
