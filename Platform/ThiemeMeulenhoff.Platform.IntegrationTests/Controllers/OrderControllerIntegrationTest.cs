using System.Net;
using Newtonsoft.Json;
using RCode;
using ThiemeMeulenhoff.Platform.WebApi;
using Xunit;

namespace ThiemeMeulenhoff.Platform.IntegrationTests;

public class OrderControllerIntegrationTest : BaseIntegrationTest<Order, OrderController, IOrderLogicProvider>
{
    #region [ CTor ]
    public OrderControllerIntegrationTest(CustomWebApplicationFactoryClass<Program> appFactory) : base(appFactory, SeedProvider.Current.Orders) {

    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByAfasOrderIdAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var entity = SeedProvider.Current.Orders.FirstOrDefault();
        var expected = await this._logicProvider.GetByAfasOrderIdAsync(entity.AfasOrderId);
        var url = this.GetUrlEndpoint(typeof(OrderController), nameof(this._controller.GetByAfasOrderIdAsync), entity.AfasOrderId);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<Order>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(actual.Id, expected.Id);
    }

    [Fact]
    public async Task GetByAfasOrderIdAsync_Should_ReturnStatusCode404NotFound_If_NotFound() {
        //Arange
        var Id = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(OrderController), nameof(this._controller.GetByAfasOrderIdAsync), Id);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion

    #region [ Public Methods - Custom - List ]
    [Fact]
    public async Task GetByContactAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var entity = SeedProvider.Current.Orders.FirstOrDefault();
        var expected = await this._logicProvider.GetByContactAsync(entity.ContactId);
        var url = this.GetUrlEndpoint(typeof(OrderController), nameof(this._controller.GetByContactAsync), entity.ContactId);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<List<Order>>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(actual.Count, expected.Count());
    }

    [Fact]
    public async Task GetByContactAsync_Should_ReturnStatusCode404NotFound_If_IsNotFound() {
        //Arange
        var Id = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(OrderController), nameof(this._controller.GetByContactAsync), Id);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion
}

