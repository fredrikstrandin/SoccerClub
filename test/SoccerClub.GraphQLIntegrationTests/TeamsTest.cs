using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SoccerClub.GraphQL.IntegrationTests
{
    public class TeamTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;

        public TeamTests(WebApplicationFactory<Startup> factory)
        {
            _httpClient = factory.CreateDefaultClient();
        }

        [Fact]
        public async Task HealthCheck_ReturnsOk()
        {
            HttpContent context = new StringContent("{\"query\": \"{teams{id, players {id, first_name, last_name, is_birthday}}}\"}",
                Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/graphql", context);

            response.EnsureSuccessStatusCode();

            string ret = await response.Content.ReadAsStringAsync();

            Assert.NotNull(ret);
        }
    }
}
