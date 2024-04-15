using Newtonsoft.Json;
using RCode;
using System.Net;
using ThiemeMeulenhoff.Platform.WebApi;
using Xunit;

namespace ThiemeMeulenhoff.Platform.IntegrationTests;

public class PrintOrderControllerIntegrationTest : BaseIntegrationTest<PrintOrder, PrintOrderController, IPrintOrderLogicProvider>
{
    #region [ CTor ]
    public PrintOrderControllerIntegrationTest(CustomWebApplicationFactoryClass<Program> appFactory) : base(appFactory, SeedProvider.Current.PrintOrders) {

    }
    #endregion

    #region [ Public Methods - Custom - Lists ]
    [Fact]
    public async Task GetByProductIdAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var entity = this.Entities.FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof(PrintOrderController), nameof(this._controller.GetByProductIdAsync), entity.ProductId);
        var expected = await this._logicProvider.GetByProductIdAsync(entity.ProductId);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<List<PrintOrder>>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected.Count, actual.Count);
    }

    [Fact]
    public async Task GetByProductIdAsync_Should_ReturnStatusCode404NotFound_If_NotFound() {
        // Arrange
        var id = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(PrintOrderController), nameof(this._controller.GetByProductIdAsync), id);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetByEanAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var entity = this.Entities.FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof(PrintOrderController), nameof(this._controller.GetByEanAsync), entity.Ean);
        var expected = await this._logicProvider.GetByEanAsync(entity.Ean);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<List<PrintOrder>>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected.Count, actual.Count);
    }

    [Fact]
    public async Task GetByEanAsync_Should_ReturnStatusCode404NotFound_If_NotFound() {
        // Arrange
        var id = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(PrintOrderController), nameof(this._controller.GetByEanAsync), id);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetByStatusAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var entity = this.Entities.FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof(PrintOrderController), nameof(this._controller.GetByStatusAsync), entity.Status);
        var expected = await this._logicProvider.GetByStatusAsync(entity.Status);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<List<PrintOrder>>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected.Count, actual.Count);
    }

    [Fact]
    public async Task GetByStatusAsync_Should_ReturnStatusCode404NotFound_If_NotFound() {
        // Arrange
        var id = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(PrintOrderController), nameof(this._controller.GetByStatusAsync), id);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion
}
