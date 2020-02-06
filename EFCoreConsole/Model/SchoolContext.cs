using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace EFCoreConsole.Model
{
    public class SchoolContext : DbContext
    {
        // The above context class includes two DbSet<TEntity> properties, for Student and Course, type which will be mapped to the Students and Courses tables in the underlying database.
        // NOTE: Following two properties do NOT affect database migration itself.
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        // ref: https://blog.bitscry.com/2017/05/30/appsettings-json-in-net-core-console-app/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyConnection"));
        }

        // data seed
        // ref: https://www.learnentityframeworkcore.com/migrations/seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    TeacherId = 1,
                    TeacherName = "William"
                }
            );

            // related data
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 3, TeacherId = 1, CourseName = "Hamlet" },
                new Course { CourseId = 4, TeacherId = 1, CourseName = "King Lear" },
                new Course { CourseId = 5, TeacherId = 1, CourseName = "Othello" }
            );
        }
    }
}
