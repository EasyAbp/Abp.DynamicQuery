using EasyAbp.Abp.DynamicQuery.Dtos;
using EasyAbp.Abp.DynamicQuery.Filters;
using Volo.Abp.Application.Dtos;

namespace DynamicQuerySample.Books.Dtos
{
    public class GetListInput : PagedAndSortedResultRequestDto, IDynamicQueryInput
    {
        public DynamicQueryGroup FilterGroup { get; set; }
    }
}