using System.Collections.Generic;
using Shouldly;
using Volo.Abp.ObjectMapping;
using Xunit;

namespace EasyAbp.Abp.DynamicQuery
{
    public class AutoMapperProfileTests : DynamicQueryApplicationTestBase
    {
        private readonly IObjectMapper _objectMapper;

        public AutoMapperProfileTests()
        {
            _objectMapper = GetRequiredService<IObjectMapper>();
        }

        [Fact]
        public void DynamicQueryFilterMapShouldConfigured()
        {
            // Arrange
            var srcFilters = new List<Dtos.DynamicQueryFilter>
            {
                new Dtos.DynamicQueryFilter{FieldName = "A", Operator = DynamicQueryOperator.Equal, Value = "a"},
                new Dtos.DynamicQueryFilter{FieldName = "B", Operator = DynamicQueryOperator.NotEqual, Value = "b"},
            };
            
            // Act
            var destFilters = _objectMapper.Map<List<Dtos.DynamicQueryFilter>, List<DynamicQueryFilter>>(srcFilters);
            
            // Assert
            destFilters.Count.ShouldBe(2);
            destFilters[0].FieldName.ShouldBe("A");
            destFilters[0].Operator.ShouldBe(DynamicQueryOperator.Equal);
            destFilters[0].Value.ShouldBe("a");
            destFilters[1].FieldName.ShouldBe("B");
            destFilters[1].Operator.ShouldBe(DynamicQueryOperator.NotEqual);
            destFilters[1].Value.ShouldBe("b");
        }
    }
}