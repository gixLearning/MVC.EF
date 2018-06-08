using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.EF.Models;

namespace MVC.EF.DAL
{
    public class SchoolDBContext : DbContext {
        //public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }


        public SchoolDBContext() : base("name=SchoolDBConnection") {
            this.Database.Log = (s) => { System.Diagnostics.Debug.WriteLine(s); };
            //Database.SetInitializer<SchoolContext>(new CreateDatabaseIfNotExists<SchoolContext>());
        }
    }
}
