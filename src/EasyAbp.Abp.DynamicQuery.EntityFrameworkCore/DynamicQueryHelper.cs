using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using EasyAbp.Abp.DynamicQuery.Extensions;
using EasyAbp.Abp.DynamicQuery.Filters;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.Abp.DynamicQuery
{
    public class DynamicQueryHelper : IDynamicQueryHelper, ITransientDependency
    {
        public virtual IQueryable<T> ExecuteDynamicQuery<T>(IQueryable<T> query, DynamicQueryGroup group) where T : class
        {
            if (group == null || group.Filters.IsNullOrEmpty())
            {
                return query;
            }

            int index = 0;
            var whereClause = GenerateWhereClause(group, ref index);
            var lstValues = new List<object>();
            group.Travel((_, condition) => lstValues.Add(condition.Value));
            return query.Where(whereClause, lstValues.ToArray());
        }

        protected virtual string GenerateWhereClause(DynamicQueryGroup group, ref int index)
        {
            var lstConditions = new List<string>();

            foreach (var filter in group.Filters)
            {
                if (filter is DynamicQueryCondition condition)
                {
                    lstConditions.Add(ConvertToCondition(condition, index++));
                }
                else
                {
                    lstConditions.Add(GenerateWhereClause((DynamicQueryGroup)filter, ref index));
                }
            }

            return $"({lstConditions.JoinAsString(group.Type == GroupType.Add ? " && " : " || ")})";
        }

        protected virtual string ConvertToCondition(DynamicQueryCondition condition, int index)
        {
            string left = GetLeft(condition, index);
            string right = GetRight(condition, index);
            switch (condition.Operator)
            {
                case DynamicQueryOperator.Equal:
                    return $"{left} == {right}";
                case DynamicQueryOperator.NotEqual:
                    return $"{left} != {right}";
                case DynamicQueryOperator.Greater:
                    return $"{left} > {right}";
                case DynamicQueryOperator.GreaterOrEqual:
                    return $"{left} >= {right}";
                case DynamicQueryOperator.Less:
                    return $"{left} < {right}";
                case DynamicQueryOperator.LessOrEqual:
                    return $"{left} <= {right}";
                case DynamicQueryOperator.StartWith:
                    return $"{left}.StartsWith({right})";
                case DynamicQueryOperator.NotStartWith:
                    return $"!{left}.StartsWith({right})";
                case DynamicQueryOperator.EndWith:
                    return $"{left}.EndsWith({right})";
                case DynamicQueryOperator.NotEndWith:
                    return $"!{left}.EndsWith({right})";
                case DynamicQueryOperator.Contain:
                    return $"{left}.Contains({right})";
                case DynamicQueryOperator.NotContain:
                    return $"!{left}.Contains({right})";
                default:
                    throw new InvalidOperationException($"Unknown dynamic query operator: {condition.Operator}");
            }
        }

        protected virtual string GetLeft(DynamicQueryCondition condition, int index)
        {
            return condition.FieldName;
        }

        protected virtual string GetRight(DynamicQueryCondition condition, int index)
        {
            return $"@{index}";
        }
    }
}