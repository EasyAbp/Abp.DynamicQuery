using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace DynamicQuerySample.Pages
{
    public class Index_Tests : DynamicQuerySampleWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
