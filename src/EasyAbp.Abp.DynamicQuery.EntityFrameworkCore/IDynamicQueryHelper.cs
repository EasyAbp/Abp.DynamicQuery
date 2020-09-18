using System.Collections.Generic;
using System.Linq;
using EasyAbp.Abp.DynamicQuery.Filters;

namespace EasyAbp.Abp.DynamicQuery
{
    public interface IDynamicQueryHelper
    {
        IQueryable<T> GetQueryByFilter<T>(IQueryable<T> query, DynamicQueryGroup group) where T : class;
    }
}