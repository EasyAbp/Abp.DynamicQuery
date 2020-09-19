using System.Linq;
using EasyAbp.Abp.DynamicQuery.Filters;

namespace EasyAbp.Abp.DynamicQuery
{
    public interface IDynamicQueryHelper
    {
        IQueryable<T> ExecuteDynamicQuery<T>(IQueryable<T> query, DynamicQueryGroup group) where T : class;
    }
}