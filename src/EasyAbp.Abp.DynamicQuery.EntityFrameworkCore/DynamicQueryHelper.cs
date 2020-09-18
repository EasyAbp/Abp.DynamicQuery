using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.Abp.DynamicQuery
{
    public class DynamicQueryHelper : IDynamicQueryHelper, ITransientDependency
    {
        public virtual IQueryable<T> GetQueryByFilter<T>(IQueryable<T> query, IList<DynamicQueryFilter> filters) where T : class
        {
            if (filters.IsNullOrEmpty())
            {
                return query;
            }
            
            var whereClause = GenerateWhereClause<T>(filters);
            return query.Where(whereClause, filters.Select(f => f.Value).ToArray());
        }

        protected virtual string GenerateWhereClause<T>(IList<DynamicQueryFilter> filters) where T : class
        {
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

            return sbWhere.ToString();
        }

        protected virtual string ConvertToCondition(DynamicQueryFilter filter, int index)
        {
            string left = GetLeft(filter, index);
            string right = GetRight(filter, index);
            switch (filter.Operator)
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
                    throw new InvalidOperationException($"Unknown dynamic query operator: {filter.Operator}");
            }
        }

        protected virtual string GetLeft(DynamicQueryFilter filter, int index)
        {
            return filter.FieldName;
        }

        protected virtual string GetRight(DynamicQueryFilter filter, int index)
        {
            return $"@{index}";
        }
    }
}