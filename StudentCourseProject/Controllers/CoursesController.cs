using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentCourseProject.Models;
using StudentCourseProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCourseProject.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CoursesController: ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ILogger<CoursesController> _logger;

        public CoursesController(ICourseRepository courseRepository,
            ILogger<CoursesController> logger)
        {
            _courseRepository = courseRepository;
            _logger = logger;
        }

        [HttpGet]
        // Get => api/Courses
        public ActionResult Get()
        {
            try
            {
                var courses = _courseRepository.GetAllCourses();
                List<CourseViewModel> coursesNamesAndId = new List<CourseViewModel>();
                foreach(var course in courses)
                {

                    coursesNamesAndId.Add(new CourseViewModel
                    {
                        CourseId = course.CourseId,
                        CourseName = course.CourseName
                    });
                }
                return Ok(coursesNamesAndId);
            }
            catch (Exception e)
            {
                _logger.LogError($"DateTime:{DateTime.Now} -- Error:{e.Message}\n{e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to retrieve data");
                throw;
            }
        }
    }
}
