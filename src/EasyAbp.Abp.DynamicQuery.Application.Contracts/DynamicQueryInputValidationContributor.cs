using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Validation;

namespace EasyAbp.Abp.DynamicQuery
{
    public class DynamicQueryInputValidationContributor : IObjectValidationContributor, ITransientDependency
    {
        private readonly Regex _regFieldName = new Regex(@"^[a-zA-Z_][a-zA-Z0-9_]*$", RegexOptions.Compiled);

        public void AddErrors(ObjectValidationContext context)
        {
            var dynamicQueryInput = context.ValidatingObject as IDynamicQueryInput;
            if (dynamicQueryInput == null) return;
            
            if (!dynamicQueryInput.FieldFilters.IsNullOrEmpty())
            {
                foreach (var filter in dynamicQueryInput.FieldFilters)
                {
                    if (!_regFieldName.IsMatch(filter.FieldName))
                    {
                        context.Errors.Add( new ValidationResult($"InvalidFieldName: {filter.FieldName}", new[] {nameof(IDynamicQueryInput.FieldFilters)}));
                    }
                }
            }
        }
    }
}