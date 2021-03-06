using System.Collections.Generic;
using AcademyCRM.Core.Models;

namespace AcademyCRM.MVC.Models
{
    public class CourseModel 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Program { get; set; }
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public double? Price { get; set; }
        public CourseLevel Level { get; set; }

        public int DurationWeeks { get; set; }
        public int RequestsCount { get; set; }
        public IEnumerable<StudentRequestModel> Requests { get; set; }
    }
}