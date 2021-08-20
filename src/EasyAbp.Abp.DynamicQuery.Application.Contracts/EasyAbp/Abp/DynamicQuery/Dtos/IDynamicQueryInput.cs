using EasyAbp.Abp.DynamicQuery.Filters;

namespace EasyAbp.Abp.DynamicQuery.Dtos
{
    public interface IDynamicQueryInput
    {
        public DynamicQueryGroup FilterGroup { get; set; }
    }
}