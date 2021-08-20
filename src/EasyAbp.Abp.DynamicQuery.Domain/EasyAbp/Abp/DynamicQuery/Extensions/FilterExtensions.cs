using System;
using System.Collections.Generic;
using EasyAbp.Abp.DynamicQuery.Filters;

namespace EasyAbp.Abp.DynamicQuery.Extensions
{
    public static class FilterExtensions
    {
        public static void Travel(this DynamicQueryGroup group,
            Action<DynamicQueryGroup, DynamicQueryCondition> conditionAction
        )
        {
            if (!group.Conditions.IsNullOrEmpty())
            {
                foreach (var condition in group.Conditions)
                {
                    conditionAction(group, condition);
                }
            }

            if (!group.Groups.IsNullOrEmpty())
            {
                foreach (var subGroup in group.Groups)
                {
                    Travel(subGroup, conditionAction);
                }
            }
        }
    }
}