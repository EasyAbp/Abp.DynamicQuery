using System;
using EasyAbp.Abp.DynamicQuery.Filters;

namespace EasyAbp.Abp.DynamicQuery.Extensions
{
    public static class FilterExtensions
    {
        public static void Travel(this DynamicQueryGroup group,
            Action<DynamicQueryGroup, DynamicQueryCondition> conditionAction
        )
        {
            foreach (var filter in group.Filters)
            {
                if (filter is DynamicQueryCondition condition)
                {
                    conditionAction(group, condition);
                }
                else
                {
                    var subGroup = (DynamicQueryGroup) filter;
                    Travel(subGroup, conditionAction);
                }
            }
        }
    }
}