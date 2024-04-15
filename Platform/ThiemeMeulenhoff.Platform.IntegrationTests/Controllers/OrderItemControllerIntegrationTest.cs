using System.Net;
using Newtonsoft.Json;
using RCode;
using ThiemeMeulenhoff.Platform.WebApi;
using Xunit;

namespace ThiemeMeulenhoff.Platform.IntegrationTests;

public class OrderItemControllerIntegrationTest : BaseIntegrationTest<OrderItem, OrderItemController, IOrderItemLogicProvider>
{
    #region [ CTor ]
    public OrderItemControllerIntegrationTest(CustomWebApplicationFactoryClass<Program> appFactory) : base(appFactory, SeedProvider.Current.OrderItems) {

    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByAfasOrderItemIdAsync_Should_ReturnStatusCode200Ok_If_IsSuccess() {
        // Arrange
        var entity = SeedProvider.Current.Orders.LastOrDefault();
        var url = this.GetUrlEndpoint(typeof(OrderItemController), nameof(this._controller.GetByAfasOrderItemIdAsync), entity.AfasOrderId);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var result = default(OrderItem);
        if (response.IsSuccessStatusCode) {
            result = JsonConvert.DeserializeObject<OrderItem>(await response.Content.ReadAsStringAsync());
        }
        var dbEntities = await this._logicProvider.GetByAfasOrderItemIdAsync(entity.AfasOrderId);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(result.Id, dbEntities.Id);
    }

    [Fact]
    public async Task GetByAfasOrderItemIdAsync_Should_ReturnStatusCode404NotFound_If_IsNotFound() {
        //Arange
        var Id = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(OrderItemController), nameof(this._controller.GetByAfasOrderItemIdAsync), Id);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion

    #region [ Public Methods - Custom - List ]
    [Fact]
    public async Task GetByOrderIdAsync_Should_ReturnStatusCode200Ok_If_IsSuccess() {
        // Arrange
        var entity = SeedProvider.Current.Orders.LastOrDefault();
        var url = this.GetUrlEndpoint(typeof(OrderItemController), nameof(this._controller.GetByOrderIdAsync), entity.Id);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var result = default(List<OrderItem>);
        if (response.IsSuccessStatusCode) {
            result = JsonConvert.DeserializeObject<List<OrderItem>>(await response.Content.ReadAsStringAsync());
        }
        var dbEntities = await this._logicProvider.GetByOrderIdAsync(entity.Id);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(result.Count, dbEntities.Count());
    }

    [Fact]
    public async Task GetByOrderIdAsync_Should_ReturnStatusCode404NotFound_If_IsNotFound() {
        //Arange
        var Id = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(OrderItemController), nameof(this._controller.GetByOrderIdAsync), Id);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetByProductAsync_Should_ReturnStatusCode200k_If_IsSuccess() {

        //Arrange
        var entity = SeedProvider.Current.Products.FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof(OrderItemController), nameof(this._controller.GetByProductAsync), entity.Id);


        //Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var result = JsonConvert.DeserializeObject<List<OrderItem>>(await response.Content.ReadAsStringAsync());
        var dbEntites = await this._logicProvider.GetByProductAsync(entity.Id);

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(result.Count, dbEntites.Count());
    }

    [Fact]
    public async Task GetByProductAsync_Should_ReturnStatusCode404NotFound_If_IsNotFound() {
        //Arange
        var Id = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(OrderItemController), nameof(this._controller.GetByProductAsync), Id);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion
}

