using System.Collections.Generic;
using EasyAbp.Abp.DynamicQuery.Dtos;
using EasyAbp.Abp.DynamicQuery.Filters;
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
            var input = new GetListInput
            {
                FilterGroup = new DynamicQueryGroup
                {
                    Type = GroupType.And,
                    Conditions = new List<DynamicQueryCondition>
                    {
                        new DynamicQueryCondition {FieldName = "1234", Operator = DynamicQueryOperator.Equal, Value = "a"},
                        new DynamicQueryCondition {FieldName = "a b", Operator = DynamicQueryOperator.Equal, Value = "a b"},
                    }
                }
            };

            // Act
            var ex = Assert.Throws<AbpValidationException>(() => _service.TestDynamicQueryInputValidationMethod(input));

            // Assert
            ex.ValidationErrors.Count.ShouldBe(2);
            ex.ValidationErrors[0].MemberNames.ShouldBe(new[] {nameof(DynamicQueryCondition.FieldName)});
            ex.ValidationErrors[0].ErrorMessage.ShouldBe("InvalidFieldName: 1234");
            ex.ValidationErrors[1].MemberNames.ShouldBe(new[] {nameof(DynamicQueryCondition.FieldName)});
            ex.ValidationErrors[1].ErrorMessage.ShouldBe("InvalidFieldName: a b");
        }
    }

    public class TestAppService : DynamicQueryAppService
    {
        public virtual void TestDynamicQueryInputValidationMethod(GetListInput input)
        {
        }
    }

    public class GetListInput : IDynamicQueryInput
    {
        public DynamicQueryGroup FilterGroup { get; set; }
    }
}