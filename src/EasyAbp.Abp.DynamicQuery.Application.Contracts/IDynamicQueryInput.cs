using System.Collections.Generic;

namespace EasyAbp.Abp.DynamicQuery
{
    public interface IDynamicQueryInput
    {
        public List<DynamicQueryFilter> FieldFilters { get; set; }
    }
}