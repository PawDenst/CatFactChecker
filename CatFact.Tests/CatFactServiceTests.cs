using CatFact.Interfaces;
using CatFact.Services;
using Moq;
using Moq.Protected;
using System.Net;
using System.Text;

public class CatFactServiceTests
{
    private HttpClient CreateHttpClientWithResponse(string json)
    {
        var mock = new Mock<HttpMessageHandler>();

        mock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            });

        return new HttpClient(mock.Object);
    }

    [Fact]
    public async Task GetCatFactAsync_ValidJson()
    {
        var httpClient = CreateHttpClientWithResponse("{\"fact\": \"Baking chocolate is the most dangerous chocolate to your cat.\", \"length\": 61}");
        var service = new CatFactService(httpClient);
        var fact = await service.GetCatFactAsync();

        Assert.NotNull(fact);
        Assert.Equal("Baking chocolate is the most dangerous chocolate to your cat.", fact.Fact);
        Assert.Equal(61, fact.Length);
    }

    [Fact]
    public async Task GetCatFactAsync_EmptyJson()
    {
        var httpClient = CreateHttpClientWithResponse("{}");
        var service = new CatFactService(httpClient);
        var fact = await service.GetCatFactAsync();

        Assert.NotNull(fact);
        Assert.Null(fact.Fact);
        Assert.Equal(0, fact.Length);
    }
}