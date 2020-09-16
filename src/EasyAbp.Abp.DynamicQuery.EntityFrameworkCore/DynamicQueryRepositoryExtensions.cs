using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.DynamicQuery
{
    public static class DynamicQueryRepositoryExtensions
    {
        public static IQueryable<T> GetQueryByFilter<T>(this IEfCoreDbContext dbContext, IList<DynamicQueryFilter> filters) where T : class
        {
            if (filters.IsNullOrEmpty())
            {
                return dbContext.Set<T>().AsQueryable();
            }
            
            var sbWhere = new StringBuilder();
            int index = 0;
            foreach (var filter in filters)
            {
                if (index > 0)
                {
                    sbWhere.Append(" AND ");
                }

                sbWhere.Append(ConvertToCondition(filter, index));
                index++;
            }

            return dbContext.Set<T>()
                .Where(sbWhere.ToString(), filters.Select(f => f.Value).ToArray())
                ;
        }

        private static string ConvertToCondition(DynamicQueryFilter filter, int index)
        {
            string columnName = GetColumnName(filter);
            switch (filter.Operator)
            {
                case DynamicQueryOperator.Equal:
                    return $"{columnName} = @{index}";
                case DynamicQueryOperator.NotEqual:
                    return $"{columnName} != @{index}";
                case DynamicQueryOperator.Greater:
                    return $"{columnName} > @{index}";
                case DynamicQueryOperator.GreaterOrEqual:
                    return $"{columnName} >= @{index}";
                case DynamicQueryOperator.Less:
                    return $"{columnName} < @{index}";
                case DynamicQueryOperator.LessOrEqual:
                    return $"{columnName} <= @{index}";
                case DynamicQueryOperator.StartWith:
                    return $"{columnName}.StartsWith(@{index})";
                case DynamicQueryOperator.NotStartWith:
                    return $"!{columnName}.StartsWith(@{index})";
                case DynamicQueryOperator.EndWith:
                    return $"{columnName}.EndsWith(@{index})";
                case DynamicQueryOperator.NotEndWith:
                    return $"!{columnName}.EndsWith(@{index})";
                case DynamicQueryOperator.Contain:
                    return $"{columnName}.Contains(@{index})";
                case DynamicQueryOperator.NotContain:
                    return $"!{columnName}.Contains(@{index})";
                default:
                    throw new InvalidOperationException($"Unknown dynamic query operator: {filter.Operator}");
            }
        }

        private static string GetColumnName(DynamicQueryFilter filter)
        {
            return filter.FieldName;
        }
    }
}