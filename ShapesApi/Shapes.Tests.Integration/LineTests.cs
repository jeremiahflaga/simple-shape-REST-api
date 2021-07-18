using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Shapes.Api.Controllers.Shapes;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Shapes.Tests.Integration
{
    public class LineTests
    {
        [Fact]
        public async Task CreatesLine()
        {
            using var api = new SelfHostedApi();
            var client = api.CreateClient();

            var lineInputModel = new ShapeInputModel { Type = "line", Length = 123 };
            var camelSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            string json = JsonConvert.SerializeObject(lineInputModel, camelSettings);
            using var content = new StringContent(json);
            content.Headers.ContentType.MediaType = "application/json";
            var response = await client.PostAsync("shapes", content);

            response.EnsureSuccessStatusCode(); // Status Code 200-299
            var shape = JsonConvert.DeserializeObject<LineViewModel>(await response.Content.ReadAsStringAsync());
            Assert.Equal(123, shape.Length);
        }
    }
}
