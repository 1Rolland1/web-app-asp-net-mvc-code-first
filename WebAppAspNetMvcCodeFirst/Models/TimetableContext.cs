using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAppAspNetMvcCodeFirst.Models
{
    public class TimetableContext : DbContext
    {

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<TeacherImage> TeacherImages { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public TimetableContext() : base("TimetableEntity")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lesson>().HasOptional(x => x.TeacherImage).WithRequired().WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
        }


    }
}