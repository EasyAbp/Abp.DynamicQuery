using System.Collections.Generic;
using EasyAbp.Abp.DynamicQuery.Dtos;

namespace EasyAbp.Abp.DynamicQuery
{
    public interface IDynamicQueryInput
    {
        public List<DynamicQueryFilter> FieldFilters { get; set; }
    }
}