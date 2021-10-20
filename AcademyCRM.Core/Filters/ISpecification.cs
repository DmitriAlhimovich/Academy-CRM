using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AcademyCRM.Core.Filters
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T item);

        Expression<Func<T, bool>> ApplyFilter();
    }
}