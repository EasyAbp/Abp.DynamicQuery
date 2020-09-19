using System.Collections.Generic;

namespace EasyAbp.Abp.DynamicQuery.Filters
{
    public class DynamicQueryGroup
    {
        public GroupType Type { get; set; }
        public List<DynamicQueryGroup> Groups { get; set; }
        public List<DynamicQueryCondition> Conditions { get; set; }
    }
}