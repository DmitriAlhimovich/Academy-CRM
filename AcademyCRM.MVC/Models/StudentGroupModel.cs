using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyCRM.MVC.Models
{
    public class StudentGroupModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int TeacherId { get; set; }
        public TeacherModel Teacher { get; set; }

        public string StartDate { get; set; }

        public string Status { get; set; }
    }
}
