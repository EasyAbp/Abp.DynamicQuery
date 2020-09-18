using System.Collections.Generic;
using System.Linq;

namespace EasyAbp.Abp.DynamicQuery
{
    public interface IDynamicQueryHelper
    {
        IQueryable<T> GetQueryByFilter<T>(IQueryable<T> query, IList<DynamicQueryFilter> filters) where T : class;
    }
}