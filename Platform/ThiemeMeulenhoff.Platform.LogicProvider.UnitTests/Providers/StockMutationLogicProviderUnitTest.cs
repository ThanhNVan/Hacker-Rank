using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class StockMutationLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<StockMutation, IStockMutationDataProvider, StockMutationLogicProvider>
{
    #region [ CTor ]
    public StockMutationLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override StockMutationLogicProvider OnCreateLogicProvider(IStockMutationDataProvider dataProvider, ILogger<StockMutationLogicProvider> logger) {
        return new StockMutationLogicProvider(logger, dataProvider);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetLastBySourceAsync_Success() {
        // Arrange
        var productId = this._fixture.Create<string>();
        var source = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetLastBySourceAsync(productId, source);

        // Assert
        this._dataProvider.Verify(x => x.GetLastBySourceAsync(productId, source), Times.Once);
    }

    [Fact]
    public async Task GetLastBySourceAsync_Should_ThrowException_If_ProductId_IsNull() {
        // Arrange
        string ProductId = null;
        var source = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.GetLastBySourceAsync(ProductId, source);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetLastBySourceAsync_Should_ThrowException_If_ProductId_IsEmpty() {
        // Arrange
        var ProductId = string.Empty;
        var source = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.GetLastBySourceAsync(ProductId, source);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    
    [Fact]
    public async Task GetLastBySourceAsync_Should_ThrowException_If_Source_IsNull() {
        // Arrange
        string source = null;
        var ProductId = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.GetLastBySourceAsync(ProductId, source);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetLastBySourceAsync_Should_ThrowException_If_Source_IsEmpty() {
        // Arrange
        var source = string.Empty;
        var ProductId = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.GetLastBySourceAsync(ProductId, source);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetLastBySourceAsync_Should_ThrowException_If_Error() {
        // Arrange
        var ProductId = Guid.NewGuid().ToString();
        var source = this._fixture.Create<string>();
        this._dataProvider.Setup(x => x.GetLastBySourceAsync(ProductId, source)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetLastBySourceAsync(ProductId, source);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    #endregion

    #region [ Public Methods - Custom - List ]
    [Fact]
    public async Task GetByProductIdAsync_Success() {
        // Arrange
        var ProductId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByProductIdAsync(ProductId);

        // Assert
        this._dataProvider.Verify(x => x.GetByProductIdAsync(ProductId), Times.Once);
    }

    [Fact]
    public async Task GetByProductIdAsync_Should_ThrowException_If_ProductId_IsNull() {
        // Arrange
        string ProductId = null;

        // Act
        var result = async () => await this._logicProvider.GetByProductIdAsync(ProductId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByProductIdAsync_Should_ThrowException_If_ProductId_IsEmpty() {
        // Arrange
        var ProductId = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByProductIdAsync(ProductId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByProductIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var ProductId = Guid.NewGuid().ToString();
        this._dataProvider.Setup(x => x.GetByProductIdAsync(ProductId)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByProductIdAsync(ProductId);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }

    [Fact]
    public async Task GetByContactIdAsync_Success() {
        // Arrange
        var ContactId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByContactIdAsync(ContactId);

        // Assert
        this._dataProvider.Verify(x => x.GetByContactIdAsync(ContactId), Times.Once);
    }

    [Fact]
    public async Task GetByContactIdAsync_Should_ThrowException_If_ContactId_IsNull() {
        // Arrange
        string ContactId = null;

        // Act
        var result = async () => await this._logicProvider.GetByContactIdAsync(ContactId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByContactIdAsync_Should_ThrowException_If_ContactId_IsEmpty() {
        // Arrange
        var ContactId = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByContactIdAsync(ContactId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByContactIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var ContactId = Guid.NewGuid().ToString();
        this._dataProvider.Setup(x => x.GetByContactIdAsync(ContactId)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByContactIdAsync(ContactId);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }

    [Fact]
    public async Task GetByAfasWarehouseIdAsync_Success() {
        // Arrange
        var AfasWarehouseId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByAfasWarehouseIdAsync(AfasWarehouseId);

        // Assert
        this._dataProvider.Verify(x => x.GetByAfasWarehouseIdAsync(AfasWarehouseId), Times.Once);
    }

    [Fact]
    public async Task GetByAfasWarehouseIdAsync_Should_ThrowException_If_AfasWarehouseId_IsNull() {
        // Arrange
        string AfasWarehouseId = null;

        // Act
        var result = async () => await this._logicProvider.GetByAfasWarehouseIdAsync(AfasWarehouseId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByAfasWarehouseIdAsync_Should_ThrowException_If_AfasWarehouseId_IsEmpty() {
        // Arrange
        var AfasWarehouseId = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByAfasWarehouseIdAsync(AfasWarehouseId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByAfasWarehouseIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var AfasWarehouseId = Guid.NewGuid().ToString();
        this._dataProvider.Setup(x => x.GetByAfasWarehouseIdAsync(AfasWarehouseId)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByAfasWarehouseIdAsync(AfasWarehouseId);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    #endregion
}
