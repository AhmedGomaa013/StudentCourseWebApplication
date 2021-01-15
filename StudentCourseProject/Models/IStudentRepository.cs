﻿using StudentCourseProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCourseProject.Models
{
    public interface IStudentRepository
    {
        public Student GetStudentById(int studentId);
        public List<Student> GetAllStudentsByCourseId(int course);
        public void AddStudent(Student student);
        public void DeleteStudent(Student student);

        public bool SaveAll();
    }
}
