using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using EasyAbp.Abp.DynamicQuery.Dtos;
using EasyAbp.Abp.DynamicQuery.Extensions;
using EasyAbp.Abp.DynamicQuery.Filters;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Validation;

namespace EasyAbp.Abp.DynamicQuery
{
    public class DynamicQueryInputValidationContributor : IObjectValidationContributor, ITransientDependency
    {
        private readonly Regex _regFieldName = new Regex(@"^[a-zA-Z_][a-zA-Z0-9_]*$", RegexOptions.Compiled);

        public void AddErrors(ObjectValidationContext context)
        {
            if (!(context.ValidatingObject is IDynamicQueryInput dynamicQueryInput))
            {
                return;
            }
            
            if (dynamicQueryInput.FilterGroup != null && !dynamicQueryInput.FilterGroup.Filters.IsNullOrEmpty())
            {
                dynamicQueryInput.FilterGroup.Travel((_, condition) =>
                {
                    if (!_regFieldName.IsMatch(condition.FieldName))
                    {
                        context.Errors.Add( new ValidationResult($"InvalidFieldName: {condition.FieldName}", new[] {nameof(DynamicQueryCondition.FieldName)}));
                    }
                });
            }
        }
    }
}