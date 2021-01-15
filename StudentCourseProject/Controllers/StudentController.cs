using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentCourseProject.Models;
using StudentCourseProject.Models.Entities;
using StudentCourseProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCourseProject.Controllers
{
    [ApiController]
    [Route("api/{Controller}")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(IStudentRepository studentRepository,
            ICourseRepository courseRepository,
            ILogger<StudentsController> logger)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _logger = logger;
        }

        [HttpGet("{courseId}")]
        // Get => api/Students/courseId
        public ActionResult GetAllStudents(int courseId)
        {
            try
            {
                var students = _studentRepository.GetAllStudentsByCourseId(courseId);

                return Ok(students);
            }
            catch (Exception e)
            {
                _logger.LogError($"DateTime:{DateTime.Now} -- Error:{e.Message}\n{e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to retrieve data");
            }
        }

        [HttpPost()]
        // Post => api/Student/
        public ActionResult PostStudent(StudentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var student = new Student()
                    {
                        Name = model.Name,
                        Grade = model.Grade,
                        CourseIdentification = _courseRepository.GetCourseById(model.CourseId)
                    };

                    _studentRepository.AddStudent(student);

                    if (_studentRepository.SaveAll())
                    {
                        return Created("api/student", new { message = "Student Added" });
                    }
                    else
                    {
                        _logger.LogWarning($"DateTime: {DateTime.Now} -- Error: Couldn't save the question into database");
                        return BadRequest("Failed to save the student");
                    }
                }
                else
                {
                    _logger.LogWarning($"DateTime: {DateTime.Now} -- Error: Question Format isn't right from Post");
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"DateTime:{DateTime.Now} -- Error:{e.Message}\n{e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to retrieve data");
            }
        }

        [HttpPut("{studentId}")]
        // Put => api/Student/studentId
        public ActionResult Put(StudentViewModel model, int studentId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var student = _studentRepository.GetStudentById(studentId);

                    if (student == null) return NotFound();
                    student.Grade = model.Grade;
                    student.Name = model.Name;
                    student.CourseIdentification = _courseRepository.GetCourseById(model.CourseId);

                    if (_studentRepository.SaveAll())
                    {
                        return Ok();
                    }
                    else
                    {
                        _logger.LogWarning($"DateTime: {DateTime.Now} -- Error: Couldn't edit the question in the database");
                        return BadRequest("Failed to save student");
                    }
                }
                else
                {
                    _logger.LogWarning($"DateTime: {DateTime.Now} -- Error: Question Format isn't right from Put");
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"DateTime:{DateTime.Now} -- Error:{e.Message}\n{e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to retrieve data");
            }
        }

        [HttpDelete("{studentId}")]
        // Delete => api/Student/studentId
        public ActionResult Delete(int StudentId)
        {
            try
            {
                var student = _studentRepository.GetStudentById(StudentId);

                if (student == null) return NotFound();

                _studentRepository.DeleteStudent(student);

                if (_studentRepository.SaveAll())
                {
                    return Ok();
                }
                else
                {
                    _logger.LogWarning($"DateTime: {DateTime.Now} -- Error: Couldn't detele the question from the database");
                    return BadRequest("Failed to delete the Question");
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"DateTime:{DateTime.Now} -- Error:{e.Message}\n{e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get note");
            }
        }
    }
}
