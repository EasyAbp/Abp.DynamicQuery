using System.Collections.Generic;

namespace EasyAbp.Abp.DynamicQuery.Filters
{
    public class DynamicQueryGroup : DynamicQueryFilter
    {
        public GroupType Type { get; set; }
        public List<DynamicQueryFilter> Filters { get; set; }
    }
}