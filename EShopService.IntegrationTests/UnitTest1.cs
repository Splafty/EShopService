namespace EShopService.IntegrationTests;

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

public class WeatherControllerTests
{
    [Fact]
    public async Task Get_CheckBaseParams_ReturnsSuccessStatusCode()
    {
        // arange
        var factory = new WebApplicationFactory<Program>();
        HttpClient client = factory.CreateClient();

        // act
        var response = await client.GetAsync("/api/weather");

        // assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}