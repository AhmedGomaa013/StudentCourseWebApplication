using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCourseProject.ViewModels
{
    public class StudentViewModel
    {

        public int StudentId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(40)]
        public string Grade { get; set; }

        [Required]
        public int CourseId { get; set; }
    }
}
