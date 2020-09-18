namespace EasyAbp.Abp.DynamicQuery.Filters
{
    public class DynamicQueryCondition : DynamicQueryFilter
    {
        public string FieldName { get; set; }
        public DynamicQueryOperator Operator { get; set; }
        public object Value { get; set; }
    }
}