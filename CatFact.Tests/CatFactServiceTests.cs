using CatFactsApp.Interfaces;
using CatFactsApp.Services;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

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
        var httpClient = CreateHttpClientWithResponse("{\"fact\": \"Baking chocolate is the most dangerous chocolate to yourcat.\", \"length\": 61}");
        var service = new CatFactService(httpClient);
        var fact = await service.GetCatFactAsync();

        Assert.Equal("Baking chocolate is the most dangerous chocolate to yourcat.", fact);
    }

    [Fact]
    public async Task GetCatFactAsync_EmptyJson()
    {
        var httpClient = CreateHttpClientWithResponse("{}");
        var service = new CatFactService(httpClient);
        var fact = await service.GetCatFactAsync();

        Assert.Equal("No Data.", fact);
    }
}