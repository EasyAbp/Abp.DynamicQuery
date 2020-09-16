using System.ComponentModel.DataAnnotations;

namespace EasyAbp.Abp.DynamicQuery
{
    public class DynamicQueryFilter
    {
        [Required]
        public string FieldName { get; set; }
        
        [Required]
        public DynamicQueryOperator DynamicQueryOperator { get; set; }
        
        [Required]
        public string Value { get; set; }
    }
}