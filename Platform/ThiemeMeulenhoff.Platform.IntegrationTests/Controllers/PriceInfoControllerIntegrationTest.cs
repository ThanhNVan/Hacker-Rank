using Newtonsoft.Json;
using System.Net;
using ThiemeMeulenhoff.Platform.WebApi;
using Xunit;

namespace ThiemeMeulenhoff.Platform.IntegrationTests;

public class PriceInfoControllerIntegrationTest : BaseIntegrationTest<PriceInfo, PriceInfoController, IPriceInfoLogicProvider>
{
    #region [ CTor ]
    public PriceInfoControllerIntegrationTest(CustomWebApplicationFactoryClass<Program> appFactory) : base(appFactory, SeedProvider.Current.PriceInfo) {

    }
    #endregion

    #region [ Public Methods - Cutom - Single ]
    [Fact]
    public async Task GetByProductIdAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var ProductId = this.Entities.FirstOrDefault().Id;
        var expected = await this._logicProvider.GetByProductIdAsync(ProductId);
        var url = this.GetUrlEndpoint(typeof(PriceInfoController), nameof(this._controller.GetByProductIdAsync), ProductId);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<PriceInfo>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(actual.Id, expected.Id);
        Assert.Equal(expected.CreatedAt.ToShortDateString(), actual.CreatedAt.ToShortDateString());
        Assert.Equal(actual.IsActive, expected.IsActive);
    }

    [Fact]
    public async Task GetByProductIdAsync_Should_ReturnStatusCode404NotFound_If_IsNotFound() {
        // Arrange
        var ProductId = this.Entities.FirstOrDefault().Id.Substring(0, new Random().Next(1, 16));
        var url = this.GetUrlEndpoint(typeof(PriceInfoController), nameof(this._controller.GetByProductIdAsync), ProductId);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion
}