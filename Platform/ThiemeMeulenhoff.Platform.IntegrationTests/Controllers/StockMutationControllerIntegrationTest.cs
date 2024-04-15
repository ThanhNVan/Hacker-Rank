using Newtonsoft.Json;
using RCode;
using System.Net;
using ThiemeMeulenhoff.Platform.WebApi;
using Xunit;

namespace ThiemeMeulenhoff.Platform.IntegrationTests;

public class StockMutationControllerIntegrationTest : BaseIntegrationTest<StockMutation, StockMutationController, IStockMutationLogicProvider>
{
    #region [ CTor ]
    public StockMutationControllerIntegrationTest(CustomWebApplicationFactoryClass<Program> appFactory) : base(appFactory, SeedProvider.Current.StockMutations) {

    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetLastBySourceAsync_Should_ReturnStatusCode200k_If_Option_Is_Found() {

        //Arrange
        var entity = SeedProvider.Current.StockMutations.FirstOrDefault();
        var expected = SeedProvider.Current.StockMutations.FirstOrDefault(x => x.ProductId == entity.ProductId && x.MutationSourceName == entity.MutationSourceName);
        var url = this.GetUrlEndpoint(typeof(StockMutationController), nameof(this._controller.GetLastBySourceAsync), expected.ProductId, expected.MutationSourceName);


        //Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<StockMutation>(await response.Content.ReadAsStringAsync());

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(actual.Id, expected.Id);
    }

    [Fact]
    public async Task GetLastBySourceAsync_Should_ReturnStatusCode404NotFound_If_Option_Is_NotFound() {
        //Arrange
        var productId = IdFactory.CreateId();
        var source = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(StockMutationController), nameof(this._controller.GetLastBySourceAsync), productId, source);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion

    #region [ Public Methods - Custom - List ]
    [Fact]
    public async Task GetByProductIdAsync_Should_ReturnStatusCode200k_If_Option_Is_Found() {

        //Arrange
        var entity = SeedProvider.Current.StockMutations.FirstOrDefault();
        var expected = SeedProvider.Current.StockMutations.Where(x => x.ProductId == entity.ProductId);
        var url = this.GetUrlEndpoint(typeof(StockMutationController), nameof(this._controller.GetByProductIdAsync), entity.ProductId);


        //Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<List<StockMutation>>(await response.Content.ReadAsStringAsync());

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(actual.Count, expected.Count());
    }

    [Fact]
    public async Task GetByProductIdAsync_Should_ReturnStatusCode404NotFound_If_Option_Is_NotFound() {
        //Arrange
        var productId = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(StockMutationController), nameof(this._controller.GetByProductIdAsync), productId);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    
    [Fact]
    public async Task GetByContactIdAsync_Should_ReturnStatusCode200k_If_Option_Is_Found() {

        //Arrange
        var entity = SeedProvider.Current.StockMutations.FirstOrDefault();
        var expected = SeedProvider.Current.StockMutations.Where(x => x.ContactId == entity.ContactId);
        var url = this.GetUrlEndpoint(typeof(StockMutationController), nameof(this._controller.GetByContactIdAsync), entity.ContactId);


        //Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<List<StockMutation>>(await response.Content.ReadAsStringAsync());

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(actual.Count, expected.Count());
    }

    [Fact]
    public async Task GetByContactIdAsync_Should_ReturnStatusCode404NotFound_If_Option_Is_NotFound() {
        //Arrange
        var contactId = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(StockMutationController), nameof(this._controller.GetByContactIdAsync), contactId);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    
    [Fact]
    public async Task GetByAfasWarehouseIdAsync_Should_ReturnStatusCode200k_If_Option_Is_Found() {

        //Arrange
        var entity = SeedProvider.Current.StockMutations.FirstOrDefault();
        var expected = SeedProvider.Current.StockMutations.Where(x => x.AfasWarehouseId == entity.AfasWarehouseId);
        var url = this.GetUrlEndpoint(typeof(StockMutationController), nameof(this._controller.GetByAfasWarehouseIdAsync), entity.AfasWarehouseId);


        //Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<List<StockMutation>>(await response.Content.ReadAsStringAsync());

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(actual.Count, expected.Count());
    }

    [Fact]
    public async Task GetByAfasWarehouseIdAsync_Should_ReturnStatusCode404NotFound_If_Option_Is_NotFound() {
        //Arrange
        var afasWarehouseId = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(StockMutationController), nameof(this._controller.GetByAfasWarehouseIdAsync), afasWarehouseId);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion
}
