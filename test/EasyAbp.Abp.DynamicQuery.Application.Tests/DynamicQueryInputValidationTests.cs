using System.Collections.Generic;
using Shouldly;
using Volo.Abp.Application.Services;
using Volo.Abp.Validation;
using Xunit;

namespace EasyAbp.Abp.DynamicQuery
{
    public class DynamicQueryInputValidationTests : DynamicQueryApplicationTestBase
    {
        private readonly TestAppService _service;

        public DynamicQueryInputValidationTests()
        {
            _service = GetRequiredService<TestAppService>();
        }

        [Fact]
        public void DynamicQueryFilterShouldBeValidated()
        {
            // Arrange
            var input = new DynamicQueryInput
            {
                FieldFilters = new List<Dtos.DynamicQueryFilter>
                {
                    new Dtos.DynamicQueryFilter {FieldName = "1234", Operator = DynamicQueryOperator.Equal, Value = "a"},
                    new Dtos.DynamicQueryFilter {FieldName = "a b", Operator = DynamicQueryOperator.Equal, Value = "a b"},
                }
            };

            // Act
            var ex = Assert.Throws<AbpValidationException>(() => _service.TestDynamicQueryInputValidationMethod(input));

            // Assert
            ex.ValidationErrors.Count.ShouldBe(2);
            ex.ValidationErrors[0].MemberNames.ShouldBe(new[] {nameof(IDynamicQueryInput.FieldFilters)});
            ex.ValidationErrors[0].ErrorMessage.ShouldBe("InvalidFieldName: 1234");
            ex.ValidationErrors[1].MemberNames.ShouldBe(new[] {nameof(IDynamicQueryInput.FieldFilters)});
            ex.ValidationErrors[1].ErrorMessage.ShouldBe("InvalidFieldName: a b");
        }
    }

    public class TestAppService : ApplicationService
    {
        public virtual void TestDynamicQueryInputValidationMethod(DynamicQueryInput input)
        {
        }
    }

    public class DynamicQueryInput : IDynamicQueryInput
    {
        public List<Dtos.DynamicQueryFilter> FieldFilters { get; set; }
    }
}