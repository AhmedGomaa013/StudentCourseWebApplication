using Microsoft.Extensions.Logging;
using StudentCourseProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCourseProject.Models
{
    public class CourseRepository : ICourseRepository
    {

        private readonly StudentCourseContext _studentCourseContext;
        private readonly ILogger<CourseRepository> _logger;

        public CourseRepository(StudentCourseContext studentCourseContext,
            ILogger<CourseRepository> logger)
        {
            _studentCourseContext = studentCourseContext;
            _logger = logger;
        }
        public List<Course> GetAllCourses()
        {
            try
            {
                return _studentCourseContext.Courses.ToList();
            }
            catch (Exception e)
            {
                _logger.LogError($"DateTime:{DateTime.Now} -- Error:{e.Message}\n{e.StackTrace}");
                return null;
            }
        }

        public Course GetCourseById(int courseId)
        {
            try
            {
                return _studentCourseContext.Courses
                    .Where(o => o.CourseId == courseId)
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                _logger.LogError($"DateTime:{DateTime.Now} -- Error:{e.Message}\n{e.StackTrace}");
                return null;
            }
        }
    }
}
