using Newtonsoft.Json;
using RCode;
using System.Net;
using ThiemeMeulenhoff.Platform.WebApi;
using Xunit;

namespace ThiemeMeulenhoff.Platform.IntegrationTests;

public class ProductBundleItemControllerIntegrationTest : BaseIntegrationTest<ProductBundleItem, ProductBundleItemController, IProductBundleItemLogicProvider>
{
    #region [ CTor ]
    public ProductBundleItemControllerIntegrationTest(CustomWebApplicationFactoryClass<Program> appFactory) : base(appFactory, SeedProvider.Current.ProductBundleItems) {

    }
    #endregion

    #region [ Public Methods - Custom - Lists ]
    [Fact]
    public async Task GetByOwnerProductIdAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var entity = SeedProvider.Current.ProductBundleItems.FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof(ProductBundleItemController), nameof(this._controller.GetByOwnerProductIdAsync), entity.OwnerProductId);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<List<ProductBundleItem>>(await response.Content.ReadAsStringAsync());
        var expected = await this._logicProvider.GetByOwnerProductIdAsync(entity.OwnerProductId);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected.Count, actual.Count);
    }

    [Fact]
    public async Task GetByOwnerProductIdAsync_Should_ReturnStatusCode404NotFound_If_NotFound() {
        // Arrange
        var afasContactNumber = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(ProductBundleItemController), nameof(this._controller.GetByOwnerProductIdAsync), afasContactNumber);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    
    [Fact]
    public async Task GetByRelatedProductIdAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var entity = SeedProvider.Current.ProductBundleItems.FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof(ProductBundleItemController), nameof(this._controller.GetByRelatedProductIdAsync), entity.OwnerProductId);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<List<ProductBundleItem>>(await response.Content.ReadAsStringAsync());
        var expected = await this._logicProvider.GetByRelatedProductIdAsync(entity.OwnerProductId);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected.Count, actual.Count);
    }

    [Fact]
    public async Task GetByRelatedProductIdAsync_Should_ReturnStatusCode404NotFound_If_NotFound() {
        // Arrange
        var afasContactNumber = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(ProductBundleItemController), nameof(this._controller.GetByRelatedProductIdAsync), afasContactNumber);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion
}
