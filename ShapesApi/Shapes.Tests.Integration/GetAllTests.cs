using Newtonsoft.Json;
using Shapes.Api.Controllers.Shapes;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Shapes.Tests.Integration
{
    public class GetAllTests
    {
        [Fact]
        public async Task GetAllReturnsCorrectResult()
        {
            using var api = new SelfHostedApi();
            var client = api.CreateClient();

            var response = await client.GetAsync("shapes");
            
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            var shapes = JsonConvert.DeserializeObject<ShapeViewModel[]>(await response.Content.ReadAsStringAsync());
            Assert.Equal(4, shapes.Length);
        }
    }
}
