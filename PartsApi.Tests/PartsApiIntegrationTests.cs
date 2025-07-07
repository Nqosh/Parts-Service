using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using PartsAPI.Core.Entities;
using Xunit;

public class PartsApiIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public PartsApiIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Health_ReturnsHealthy()
    {
        var response = await _client.GetAsync("/health");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Post_Then_Get_Part()
    {
        var part = new Part
        {
            PartNumber = "INT1",
            Description = "Integration Test",
            QuantityOnHand = 15,
            LocationCode = "INT",
            LastStockTake = DateTime.UtcNow
        };

        var postResponse = await _client.PostAsJsonAsync("/api/part/CreatePart", part);
        Assert.Equal(HttpStatusCode.Created, postResponse.StatusCode);

        var getResponse = await _client.GetAsync("/api/part/GetPart?Id=INT1");
        Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

        var resultPart = await getResponse.Content.ReadFromJsonAsync<Part>();
        Assert.Equal("Integration Test", resultPart.Description);
    }
}
