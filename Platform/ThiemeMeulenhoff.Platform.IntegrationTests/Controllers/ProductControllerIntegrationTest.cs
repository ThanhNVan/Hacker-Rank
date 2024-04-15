using System.Net;
using Newtonsoft.Json;
using ThiemeMeulenhoff.Platform.WebApi;
using Xunit;

namespace ThiemeMeulenhoff.Platform.IntegrationTests;

public class ProductControllerIntegrationTest : BaseIntegrationTest<Product, ProductController, IProductLogicProvider>
{
    #region [ CTor ]
    public ProductControllerIntegrationTest(CustomWebApplicationFactoryClass<Program> appFactory) : base(appFactory, SeedProvider.Current.Products) {

    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByIsbnAsync_Should_ReturnStatusCode200Ok_If_Item_Is_Found() {
        // Arrange
        var entity = SeedProvider.Current.Products.FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof(ProductController), nameof(this._controller.GetByIsbnAsync), entity.Ean);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetByIsbnAsync_Should_ReturnStatusCode404NotFound_If_Option_Is_NotFound() {
        //Arange
        var isbn = Guid.NewGuid().ToString();
        var url = this.GetUrlEndpoint(typeof(ProductController), nameof(this._controller.GetByIsbnAsync), isbn);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetByUuidAsync_Should_ReturnStatusCode200Ok_If_Item_Is_Found() {
        // Arrange
        var entity = SeedProvider.Current.Products.FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof(ProductController), nameof(this._controller.GetByUuidAsync), entity.Ean);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetByUuidAsync_Should_ReturnStatusCode404NotFound_If_Option_Is_NotFound() {
        //Arange
        var uuid = Guid.NewGuid().ToString();
        var url = this.GetUrlEndpoint(typeof(ProductController), nameof(this._controller.GetByUuidAsync), uuid);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetByNurAsync_Should_ReturnStatusCode200Ok_If_Item_Is_Found() {
        // Arrange
        var entity = SeedProvider.Current.Products.FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof(ProductController), nameof(this._controller.GetByNurAsync), entity.Nur.ToString());

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var dbEntities = await this._logicProvider.GetByNurAsync(entity.Nur);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetByNurAsync_Should_ReturnStatusCode404NotFound_If_Option_Is_NotFound() {
        //Arange
        var rnd = new Random();
        var nur = rnd.Next();
        var url = this.GetUrlEndpoint(typeof(ProductController), nameof(this._controller.GetByNurAsync), nur.ToString());

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    
    [Fact]
    public async Task GetByAfasProductIdAsync_Should_ReturnStatusCode200Ok_If_Item_Is_Found() {
        // Arrange
        var expected = SeedProvider.Current.Products.FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof(ProductController), nameof(this._controller.GetByAfasProductIdAsync), expected.AfasProductId);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(actual.Id, expected.Id);
        Assert.Equal(expected.CreatedAt.ToShortDateString(), actual.CreatedAt.ToShortDateString());
        Assert.Equal(actual.IsActive, expected.IsActive);
    }

    [Fact]
    public async Task GetByAfasProductIdAsync_Should_ReturnStatusCode404NotFound_If_Option_Is_NotFound() {
        //Arange
        var rnd = new Random();
        var afasProductId = rnd.Next();
        var url = this.GetUrlEndpoint(typeof(ProductController), nameof(this._controller.GetByAfasProductIdAsync), afasProductId.ToString());

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion
}
