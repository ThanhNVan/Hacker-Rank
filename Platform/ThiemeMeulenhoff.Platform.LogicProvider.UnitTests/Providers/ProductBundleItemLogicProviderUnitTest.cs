using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class ProductBundleItemLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<ProductBundleItem, IProductBundleItemDataProvider, ProductBundleItemLogicProvider>
{
    #region [ CTor ]
    public ProductBundleItemLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Abstract Methods ]
    protected override ProductBundleItemLogicProvider OnCreateLogicProvider(IProductBundleItemDataProvider dataProvider, ILogger<ProductBundleItemLogicProvider> logger) {
        return new ProductBundleItemLogicProvider(logger, dataProvider);
    }
    #endregion

    #region [ Public Methods - Custom Lists ]
    [Fact]
    public async Task GetByOwnerProductIdAsync_Success() {
        // Arrange
        var OwnerProductId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByOwnerProductIdAsync(OwnerProductId);

        // Assert
        this._dataProvider.Verify(x => x.GetByOwnerProductIdAsync(OwnerProductId), Times.Once);
    }

    [Fact]
    public async Task GetByOwnerProductIdAsync_Should_ThrowException_If_OwnerProductId_IsNull() {
        // Arrange
        string OwnerProductId = null;

        // Act
        var result = async () => await this._logicProvider.GetByOwnerProductIdAsync(OwnerProductId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByOwnerProductIdAsync_Should_ThrowException_If_OwnerProductId_IsEmpty() {
        // Arrange
        var OwnerProductId = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByOwnerProductIdAsync(OwnerProductId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByOwnerProductIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var OwnerProductId = Guid.NewGuid().ToString();
        this._dataProvider.Setup(x => x.GetByOwnerProductIdAsync(OwnerProductId)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByOwnerProductIdAsync(OwnerProductId);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }

    [Fact]
    public async Task GetByRelatedProductIdAsync_Success() {
        // Arrange
        var RelatedProductId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByRelatedProductIdAsync(RelatedProductId);

        // Assert
        this._dataProvider.Verify(x => x.GetByRelatedProductIdAsync(RelatedProductId), Times.Once);
    }

    [Fact]
    public async Task GetByRelatedProductIdAsync_Should_ThrowException_If_RelatedProductId_IsNull() {
        // Arrange
        string RelatedProductId = null;

        // Act
        var result = async () => await this._logicProvider.GetByRelatedProductIdAsync(RelatedProductId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByRelatedProductIdAsync_Should_ThrowException_If_RelatedProductId_IsEmpty() {
        // Arrange
        var RelatedProductId = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByRelatedProductIdAsync(RelatedProductId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByRelatedProductIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var RelatedProductId = Guid.NewGuid().ToString();
        this._dataProvider.Setup(x => x.GetByRelatedProductIdAsync(RelatedProductId)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByRelatedProductIdAsync(RelatedProductId);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }

    [Fact]
    public async Task GetBatchByOwnerProductIdAsync_Success() {
        // Arrange
        var ownerProductIds = this._fixture.Create<List<string>>();

        // Act
        await this._logicProvider.GetBatchByOwnerProductIdAsync(ownerProductIds);

        // Assert
        this._dataProvider.Verify(x => x.GetBatchByOwnerProductIdAsync(ownerProductIds), Times.Once);
    }

    [Fact]
    public async Task GetBatchByOwnerProductIdAsync_Should_ThrowException_If_ownerProductIds_IsNull() {
        // Arrange
        List<string> ownerProductIds = null;

        // Act
        var result = async () => await this._logicProvider.GetBatchByOwnerProductIdAsync(ownerProductIds);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetBatchByOwnerProductIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var ownerProductIds = this._fixture.Create<List<string>>();
        this._dataProvider.Setup(x => x.GetBatchByOwnerProductIdAsync(ownerProductIds)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetBatchByOwnerProductIdAsync(ownerProductIds);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }

    [Fact]
    public async Task GetBatchByRelatedProductIdAsync_Success() {
        // Arrange
        var RelatedProductId = this._fixture.Create<List<string>>();

        // Act
        await this._logicProvider.GetBatchByRelatedProductIdAsync(RelatedProductId);

        // Assert
        this._dataProvider.Verify(x => x.GetBatchByRelatedProductIdAsync(RelatedProductId), Times.Once);
    }

    [Fact]
    public async Task GetBatchByRelatedProductIdAsync_Should_ThrowException_If_RelatedProductId_IsNull() {
        // Arrange
        List<string> RelatedProductId = null;

        // Act
        var result = async () => await this._logicProvider.GetBatchByRelatedProductIdAsync(RelatedProductId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetBatchByRelatedProductIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var RelatedProductId = this._fixture.Create<List<string>>();
        this._dataProvider.Setup(x => x.GetBatchByRelatedProductIdAsync(RelatedProductId)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetBatchByRelatedProductIdAsync(RelatedProductId);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    #endregion
}
