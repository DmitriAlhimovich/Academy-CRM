﻿using AcademyCRM.Core.Models;
using System.ComponentModel.DataAnnotations;

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
    }
}