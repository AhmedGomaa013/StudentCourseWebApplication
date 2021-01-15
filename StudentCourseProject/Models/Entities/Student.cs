using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCourseProject.Models.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(40)]
        public string Grade { get; set; }
        public Course CourseIdentification { get; set; }
    }
}
