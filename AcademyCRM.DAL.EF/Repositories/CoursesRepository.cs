using System;
using System.Collections.Generic;
using System.Linq;
using AcademyCRM.Core.Models;
using AcademyCRM.Core.Models.Filters;
using AcademyCRM.DAL.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AcademyCRM.DAL.EF.Repositories
{
    public class CoursesRepository : BaseRepository<Course>, ICourseRepository
    {
        private readonly AcademyContext _context;

        public CoursesRepository(AcademyContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Course> Filter(CourseFilter filter)
        {
            var filteredCourses = _context.Courses.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.TitleContains))
                filteredCourses = filteredCourses.Where(c =>
                c.Title.Contains(filter.TitleContains));

            if (!string.IsNullOrWhiteSpace(filter.DescriptionContains))
                filteredCourses = filteredCourses.Where(c =>
                c.Description.Contains(filter.DescriptionContains));

            if (!string.IsNullOrWhiteSpace(filter.ProgramContains))
                filteredCourses = filteredCourses.Where(c =>
                c.Program.Contains(filter.ProgramContains));

            if (filter.PriceFrom.HasValue)
                filteredCourses = filteredCourses.Where(c => c.Price >= filter.PriceFrom.Value);

            if (filter.PriceTo.HasValue)
                filteredCourses = filteredCourses.Where(c => c.Price <= filter.PriceTo.Value);

            if (filter.DurationWeeksFrom.HasValue)
                filteredCourses = filteredCourses.Where(c => c.DurationWeeks >= filter.DurationWeeksFrom.Value);

            if (filter.DurationWeeksTo.HasValue)
                filteredCourses = filteredCourses.Where(c => c.DurationWeeks <= filter.DurationWeeksTo.Value);

            return filteredCourses.ToList();
        }

        public override IEnumerable<Course> GetAll()
        {
            return _context.Courses
                .Include(c => c.Topic)
                .ToList();
        }
    }
}