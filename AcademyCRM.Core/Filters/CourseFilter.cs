using System.Collections.Generic;
using AcademyCRM.Core.Models;

namespace AcademyCRM.Core.Filters
{
    public class CourseFilter
    {
        public string TitleContains { get; set; }
        public string DescriptionContains { get; set; }
        public string ProgramContains { get; set; }
        public string TopicNameContains { get; set; }
        public double? PriceFrom { get; set; }
        public double? PriceTo { get; set; }
        public CourseLevel? Level { get; set; }
        public int? DurationWeeksFrom { get; set; }
        public int? DurationWeeksTo { get; set; }

        public IEnumerable<ISpecification<Course>> Specifications { get; set; }
    }
}