using System.Collections;
using System.Collections.Generic;
using AcademyCRM.Core.Interfaces;

namespace AcademyCRM.Core.Models
{
    public class CourseCategory :IIdProperty
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public int? ParentId { get; set; }
        public CourseCategory Parent { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
