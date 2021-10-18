using AcademyCRM.Core.Interfaces;

namespace AcademyCRM.Core.Models
{
    public class Course : IIdProperty
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Program { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }

        public double? Price { get; set; }

        public CourseLevel Level { get; set; }

        public int DurationWeeks { get; set; }
    }
}
