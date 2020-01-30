using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreConsole.Model
{
    public class SchoolContext : DbContext
    {
        // The above context class includes two DbSet<TEntity> properties, for Student and Course, type which will be mapped to the Students and Courses tables in the underlying database.
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MW10CTJMHR2\SQLEXPRESS;Database=SchoolDBCodeFirst2;Trusted_Connection=True;");
        }
    }
}
