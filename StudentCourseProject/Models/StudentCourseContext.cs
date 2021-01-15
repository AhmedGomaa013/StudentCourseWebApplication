using Microsoft.EntityFrameworkCore;
using StudentCourseProject.Models.Entities;
using System;

namespace StudentCourseProject.Models
{
    public class StudentCourseContext: DbContext
    {
        public StudentCourseContext(DbContextOptions options): base(options)
        {

        }


        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 1,
                CourseName = "Math",
                CreatedDate = DateTime.Now,
                StartDate = new DateTime(2021, 3, 1),
                EndDate = new DateTime(2021, 7, 1)
            });

            modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 2,
                CourseName = "Programming",
                CreatedDate = DateTime.Now,
                StartDate = new DateTime(2021, 3, 1),
                EndDate = new DateTime(2021, 7, 1)
            });

            modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 3,
                CourseName = "Data Structures",
                CreatedDate = DateTime.Now,
                StartDate = new DateTime(2021, 3, 1),
                EndDate = new DateTime(2021, 7, 1)
            });
        }
    }
}
