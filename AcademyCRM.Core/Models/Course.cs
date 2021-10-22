using System.Collections.Generic;
using AcademyCRM.Core.Interfaces;

namespace AcademyCRM.Core.Models
{
    public class Course : IIdProperty
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int ProgramId { get; set; }
        public CourseProgram Program { get; set; }
        public int TopicId { get; set; }
        public CourseCategory CourseCategory { get; set; }

        public double? Price { get; set; }

        public CourseLevel Level { get; set; }

        public int DurationWeeks { get; set; }
    }

    public class CourseProgram : IIdProperty
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public IList<CourseTopic> Topics { get; set; }
    }

    public class CourseTopic : IIdProperty
    {
        public int Id { get; set; }

        public string Title { get; set; }
         
        public string Description { get; set; }

        public IEnumerable<CourseMaterial> Materials { get; set; }

        public int ProgramId { get; set; }
        public CourseProgram Program { get; set; }
    }

    public class CourseMaterial :IIdProperty
    {
        public int Id { get; set; }

        public int TopicId { get; set; }
        public CourseTopic Topic { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public byte[] File { get; set; }

    }
}
