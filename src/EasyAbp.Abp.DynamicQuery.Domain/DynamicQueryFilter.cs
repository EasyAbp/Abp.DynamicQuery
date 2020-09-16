namespace EasyAbp.Abp.DynamicQuery
{
    public class DynamicQueryFilter
    {
        public string FieldName { get; set; }
        public DynamicQueryOperator Operator { get; set; }
        public object Value { get; set; }
    }
}