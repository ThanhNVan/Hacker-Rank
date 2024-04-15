using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class ProductLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<Product, IProductDataProvider, ProductLogicProvider>
{
    #region [ CTor ]
    public ProductLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override ProductLogicProvider OnCreateLogicProvider(IProductDataProvider dataProvider, ILogger<ProductLogicProvider> logger) {
        return new ProductLogicProvider(logger, dataProvider);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByIsbnAsync_Success() {
        // Arrange
        var Isbn = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByEanAsync(Isbn);

        // Assert
        this._dataProvider.Verify(x => x.GetByEanAsync(Isbn), Times.Once);
    }

    [Fact]
    public async Task GetByIsbnAsync_Should_ThrowException_If_Isbn_IsNull() {
        // Arrange
        string Isbn = null;

        // Act
        var result = async () => await this._logicProvider.GetByEanAsync(Isbn);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByIsbnAsync_Should_ThrowException_If_Isbn_IsEmpty() {
        // Arrange
        var Isbn = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByEanAsync(Isbn);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByNurAsync_Success() {
        // Arrange
        var Nur = this._fixture.Create<int>();

        // Act
        await this._logicProvider.GetByNurAsync(Nur);

        // Assert
        this._dataProvider.Verify(x => x.GetByNurAsync(Nur), Times.Once);
    }

    [Fact]
    public async Task GetByUuidAsync_Success() {
        // Arrange
        var Uuid = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByUuidAsync(Uuid);

        // Assert
        this._dataProvider.Verify(x => x.GetByUuidAsync(Uuid), Times.Once);
    }

    [Fact]
    public async Task GetByUuidAsync_Should_ThrowException_If_Uuid_IsNull() {
        // Arrange
        string Uuid = null;

        // Act
        var result = async () => await this._logicProvider.GetByUuidAsync(Uuid);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByUuidAsync_Should_ThrowException_If_Uuid_IsEmpty() {
        // Arrange
        var Uuid = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByUuidAsync(Uuid);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByAfasProductIdAsync_Success() {
        // Arrange
        var AfasProductId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByAfasProductIdAsync(AfasProductId);

        // Assert
        this._dataProvider.Verify(x => x.GetByAfasProductIdAsync(AfasProductId), Times.Once);
    }

    [Fact]
    public async Task GetByAfasProductIdAsync_Should_ThrowException_If_AfasProductId_IsNull() {
        // Arrange
        string AfasProductId = null;

        // Act
        var result = async () => await this._logicProvider.GetByAfasProductIdAsync(AfasProductId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByAfasProductIdAsync_Should_ThrowException_If_AfasProductId_IsEmpty() {
        // Arrange
        var AfasProductId = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByAfasProductIdAsync(AfasProductId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    #endregion

    #region [ Public Methods - Custom - List ]
    [Fact]
    public async Task GetBookProductsAsync_Success() {
        // Act
        await this._logicProvider.GetBookProductsAsync();

        // Assert
        this._dataProvider.Verify(x => x.GetBookProductsAsync(), Times.Once);
    }
    
    [Fact]
    public async Task GetLicenseProductsAsync_Success() {
        // Act
        await this._logicProvider.GetLicenseProductsAsync();

        // Assert
        this._dataProvider.Verify(x => x.GetLicenseProductsAsync(), Times.Once);
    }
    
    [Fact]
    public async Task GetBundleProductsAsync_Success() {
        // Act
        await this._logicProvider.GetBundleProductsAsync();

        // Assert
        this._dataProvider.Verify(x => x.GetBundleProductsAsync(), Times.Once);
    }

    [Fact]
    public async Task GetProductsInBundleAsync_Success() {
        // Arrange
        var productId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetProductsInBundleAsync(productId);

        // Assert
        this._dataProvider.Verify(x => x.GetProductsInBundleAsync(productId), Times.Once);
    }

    [Fact]
    public async Task GetProductsInBundleAsync_Should_ThrowException_If_IsNull() {
        // Arrange
        string productId = null;

        // Act
        var result = async () => await this._logicProvider.GetProductsInBundleAsync(productId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetProductsInBundleAsync_Should_ThrowException_If_IsEmpty() {
        // Arrange
        var productId = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetProductsInBundleAsync(productId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    
    [Fact]
    public async Task GetProductsInBundleAsync_Should_ThrowException_If_Error() {
        // Arrange
        var productId = this._fixture.Create<string>();
        this._dataProvider.Setup(x => x.GetProductsInBundleAsync(productId)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetProductsInBundleAsync(productId);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }

    [Fact]
    public async Task GetByEansAsync_Success() {
        // Arrange
        var eans = this._fixture.Create<List<string>>();

        // Act
        await this._logicProvider.GetByEansAsync(eans);

        // Assert
        this._dataProvider.Verify(x => x.GetByEansAsync(eans), Times.Once);
    }

    [Fact]
    public async Task GetByEansAsync_Should_ThrowException_If_Error() {
        // Arrange
        var eans = this._fixture.Create<List<string>>();
        this._dataProvider.Setup(x => x.GetByEansAsync(eans)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByEansAsync(eans);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    
    
    [Fact]
    public async Task GetByEansAsync_Should_ThrowException_If_Null() {
        // Arrange
        var eans = default( List<string>);
        this._dataProvider.Setup(x => x.GetByEansAsync(eans));

        // Act
        var result = async () => await this._logicProvider.GetByEansAsync(eans);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    #endregion
}
