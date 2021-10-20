using System;
using System.Linq.Expressions;
using AcademyCRM.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademyCRM.Core.Filters
{
    public class TitleContainsSpecification : ISpecification<Course>
    {
        private readonly string _searchString;

        public TitleContainsSpecification(string searchString)
        {
            _searchString = searchString;
        }

        public bool IsSatisfied(Course course)
        {
            return course.Title.Contains(_searchString, StringComparison.OrdinalIgnoreCase);
        }

        public Expression<Func<Course, bool>> ApplyFilter()
        {
            return c => EF.Functions.Like(c.Title, $"%{_searchString}%" );
        }
    }
}