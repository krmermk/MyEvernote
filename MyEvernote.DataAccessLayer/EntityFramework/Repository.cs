using MyEvernote.Common;
using MyEvernote.Core.DataAccess;
using MyEvernote.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MyEvernote.DataAccessLayer.EntityFramework
{

    public class Repository<T>:RepositoryBase, IDataAccess<T> where T : class
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

           

        public List<T> List(Expression<Func<T,bool>> where)=> _set.Where(where).ToList();     

        public int Insert(T obj)
        {
            if (obj is BaseEntity)
            {
                BaseEntity be = obj as BaseEntity;
                be.ModifiedUser = App.Cmn.GetUsername();
            }
            _set.Add(obj);
            return Save();
        }

        public int Update(T obj)
        {
            if (obj is BaseEntity)
            {
                BaseEntity be = obj as BaseEntity;
                be.ModifiedUser = App.Cmn.GetUsername();
            }
            return Save();
        }

        public int Delete(T obj)
        {
            if (obj is BaseEntity)
            {
                BaseEntity be = obj as BaseEntity;
                be.ModifiedUser = App.Cmn.GetUsername();
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

       public IQueryable<T> ListQueryable(Expression<Func<T, bool>> where) => _set.Where(where).AsQueryable<T>();

        public IQueryable<T> ListQueryable()
        {
           return _set.AsQueryable<T>();
        }
    }
}
