using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace DynamicQuerySample.Books
{
    public class BookAppServiceTests : DynamicQuerySampleApplicationTestBase
    {
        private readonly IBookAppService _bookAppService;

        public BookAppServiceTests()
        {
            _bookAppService = GetRequiredService<IBookAppService>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            // Arrange

            // Act

            // Assert
        }
        */
    }
}
