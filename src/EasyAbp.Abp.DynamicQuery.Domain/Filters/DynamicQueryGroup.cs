using System.Collections.Generic;

namespace EasyAbp.Abp.DynamicQuery.Filters
{
    public abstract class DynamicQueryGroup : DynamicQueryFilter
    {
        public List<DynamicQueryFilter> Filters { get; set; }
    }
}