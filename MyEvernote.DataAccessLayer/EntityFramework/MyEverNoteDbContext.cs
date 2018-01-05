using MyEvernote.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.DataAccessLayer.EntityFramework
{
    public class MyEverNoteDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<EvernoteUser> EverNoteUsers { get; set; }
        public DbSet<EvernoteComment> EvernoteCommnets { get; set; }
        public DbSet<Category> Cateories { get; set; }
        public DbSet<Liked> Likes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public MyEverNoteDbContext()
        {
            Database.SetInitializer(new MyInitializer());
        }
    }

}
