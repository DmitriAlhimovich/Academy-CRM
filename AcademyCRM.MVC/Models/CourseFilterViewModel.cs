using System.Collections.Generic;
using AcademyCRM.Core.Models;
using System.ComponentModel.DataAnnotations;
using AcademyCRM.Core.Filters;

namespace AcademyCRM.MVC.Models
{
    public class CourseFilterViewModel
    {
        public string TitleContains { get; set; }
        public string DescriptionContains { get; set; }
        public string ProgramContains { get; set; }
        public string TopicNameContains { get; set; }
        
        [Display(Name = "Price Should Be From")]
        public double? PriceFrom { get; set; }
        public double? PriceTo { get; set; }
        public CourseLevel? Level { get; set; }
        public int? DurationWeeksFrom { get; set; }
        public int? DurationWeeksTo { get; set; }

        public CourseFilter MapToEntity()
        {
            var specifications = new List<ISpecification<Course>>();
            if (!string.IsNullOrWhiteSpace(TitleContains))
                specifications.Add(new TitleContainsSpecification(TitleContains));
            if (PriceTo.HasValue)
                specifications.Add(new PriceToSpecification(PriceTo.Value));

            return new CourseFilter() {Specifications = specifications};
        }
    }
}