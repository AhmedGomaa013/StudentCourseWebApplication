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
        public int AddStudent(Student student)
        {
            try
            {
                var createdEntity = _studentCourseContext.Add(student);
                if (SaveAll())
                { 
                    return createdEntity.Entity.StudentId; 
                }

                return -1;
            }
            catch(Exception e)
            {
                _logger.LogError($"DateTime:{DateTime.Now} -- Error:{e.Message}\n{e.StackTrace}");
                return -1;
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
                    .Include(o=>o.CourseIdentification)
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                _logger.LogError($"DateTime:{DateTime.Now} -- Error:{e.Message}\n{e.StackTrace}");
                return null;
            }
        }
        public List<Student> GetAllStudentsByCourseName(string course)
        {
            try
            {
                return _studentCourseContext.Students
                    .Where(o => o.CourseIdentification.CourseName == course)
                    .Include(o => o.CourseIdentification)
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
