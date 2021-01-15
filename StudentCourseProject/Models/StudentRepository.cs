using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentCourseProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCourseProject.Models
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentCourseContext _studentCourseContext;
        private readonly ILogger<StudentRepository> _logger;

        public StudentRepository(StudentCourseContext studentCourseContext,
            ILogger<StudentRepository> logger)
        {
            _studentCourseContext = studentCourseContext;
            _logger = logger;
        }
        public void AddStudent(Student student)
        {
            try
            {
                _studentCourseContext.Add(student);
            }
            catch(Exception e)
            {
                _logger.LogError($"DateTime:{DateTime.Now} -- Error:{e.Message}\n{e.StackTrace}");
            }
        }

        public void DeleteStudent(Student student)
        {
            try
            {
                _studentCourseContext.Remove(student);
            }
            catch (Exception e)
            {
                _logger.LogError($"DateTime:{DateTime.Now} -- Error:{e.Message}\n{e.StackTrace}");
            }
        }

        public Student GetStudentById(int studentId)
        {
            try
            {
                return _studentCourseContext.Students
                    .Where(o => o.StudentId == studentId)
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                _logger.LogError($"DateTime:{DateTime.Now} -- Error:{e.Message}\n{e.StackTrace}");
                return null;
            }
        }
        public List<Student> GetAllStudentsByCourseId(int course)
        {
            try
            {
                return _studentCourseContext.Students
                    .Where(o => o.CourseIdentification.CourseId == course)
                    .ToList();
            }
            catch (Exception e)
            {
                _logger.LogError($"DateTime:{DateTime.Now} -- Error:{e.Message}\n{e.StackTrace}");
                return null;
            }
        }

        public bool SaveAll()
        {
            try
            {
                return _studentCourseContext.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                _logger.LogError($"DateTime:{DateTime.Now} -- Error:{e.Message}\n{e.StackTrace}");
                return false;
            }
        }
    }
}
