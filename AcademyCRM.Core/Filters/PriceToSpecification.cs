using System;
using System.Linq.Expressions;
using AcademyCRM.Core.Models;

namespace AcademyCRM.Core.Filters
{
    public class PriceToSpecification : ISpecification<Course>
    {
        private readonly double _priceTo;

        public PriceToSpecification(double priceTo)
        {
            _priceTo = priceTo;
        }

        public bool IsSatisfied(Course item)
        {
            return item.Price <= _priceTo;
        }

        public Expression<Func<Course, bool>> ApplyFilter()
        {
            return c => c.Price <= _priceTo;
        }
    }
}