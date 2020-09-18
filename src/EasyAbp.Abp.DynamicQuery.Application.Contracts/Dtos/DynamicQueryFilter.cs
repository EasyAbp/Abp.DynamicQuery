using System.ComponentModel.DataAnnotations;

namespace EasyAbp.Abp.DynamicQuery.Dtos
{
    public class DynamicQueryFilter
    {
        [Required]
        public string FieldName { get; set; }
        
        [Required]
        public DynamicQueryOperator Operator { get; set; }
        
        [Required]
        public string Value { get; set; }
    }
}