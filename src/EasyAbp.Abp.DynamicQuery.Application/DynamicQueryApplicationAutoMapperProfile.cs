using AutoMapper;

namespace EasyAbp.Abp.DynamicQuery
{
    public class DynamicQueryApplicationAutoMapperProfile : Profile
    {
        public DynamicQueryApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<EasyAbp.Abp.DynamicQuery.Dtos.DynamicQueryFilter, DynamicQueryFilter>();
        }
    }
}