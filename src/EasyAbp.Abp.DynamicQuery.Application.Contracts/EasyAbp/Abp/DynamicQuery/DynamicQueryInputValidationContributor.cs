using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

        public Task AddErrorsAsync(ObjectValidationContext context)
        {
            if (context.ValidatingObject is not IDynamicQueryInput dynamicQueryInput)
            {
                return Task.CompletedTask;
            }

            dynamicQueryInput.FilterGroup?.Travel((_, condition) =>
            {
                if (!_regFieldName.IsMatch(condition.FieldName))
                {
                    context.Errors.Add(new ValidationResult($"InvalidFieldName: {condition.FieldName}", new[] {nameof(DynamicQueryCondition.FieldName)}));
                }
            });
            
            return Task.CompletedTask;
        }
    }
}