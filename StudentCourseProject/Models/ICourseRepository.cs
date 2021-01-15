using StudentCourseProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCourseProject.Models
{
    public interface ICourseRepository
    {
        public Course GetCourseById(int courseId);
        public List<Course> GetAllCourses();
    }
}
