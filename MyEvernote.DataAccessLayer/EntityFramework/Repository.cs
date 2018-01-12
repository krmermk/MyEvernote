using MyEvernote.DataAccessLayer;
using MyEvernote.DataAccessLayer.Interface;
using MyEvernote.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.DataAccessLayer.EntityFramework
{

    public class Repository<T>:RepositoryBase, IRepository<T> where T : class
    {
        
        private DbSet<T> _set;

        public Repository()
        {
           
            _set = db.Set<T>();
        }

        public List<T> List()
        {
            return _set.ToList();

        }

        public IQueryable<T> ListQueryable()
        {
            return _set.AsQueryable<T>();
        }

        public List<T> List(Expression<Func<T,bool>> where)=> _set.Where(where).ToList();     

        public int Insert(T obj)
        {
            if (obj is BaseEntity)
            {
                BaseEntity be = obj as BaseEntity;
                be.ModifiedUser = "system";
            }
            _set.Add(obj);
            return Save();
        }

        public int Update(T obj)
        {
            return Save();
        }

        public int Delete(T obj)
        {
            if (obj is BaseEntity)
            {
                BaseEntity be = obj as BaseEntity;
                be.ModifiedUser = "system";
                be.IsDeleted = true;

            }
            return Save();
        }
            
        public int Save()
        {
            return db.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _set.FirstOrDefault(where);
        }

       
    }
}
