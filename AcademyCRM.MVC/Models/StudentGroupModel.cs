using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyCRM.MVC.Models
{
    public class StudentGroupModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int? CourseId { get; set; }
        public CourseModel Course { get; set; }

        public int? TeacherId { get; set; }
        public TeacherModel Teacher { get; set; }

        public string StartDate { get; set; }

        public string Status { get; set; }
        public IEnumerable<StudentModel> Students { get; set; }
    }
}
