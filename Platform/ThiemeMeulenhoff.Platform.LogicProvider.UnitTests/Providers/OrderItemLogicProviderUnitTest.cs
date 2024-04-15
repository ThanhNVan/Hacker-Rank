using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class OrderItemLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<OrderItem, IOrderItemDataProvider, OrderItemLogicProvider>
{
    #region [ CTor ]
    public OrderItemLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override OrderItemLogicProvider OnCreateLogicProvider(IOrderItemDataProvider dataProvider, ILogger<OrderItemLogicProvider> logger) {
        return new OrderItemLogicProvider(logger, dataProvider);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByAfasOrderItemIdAsync_AfasOrderItemId_Success() {
        // Arrange
        var AfasOrderItemId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByAfasOrderItemIdAsync(AfasOrderItemId);

        // Assert
        this._dataProvider.Verify(x => x.GetByAfasOrderItemIdAsync(AfasOrderItemId), Times.Once);
    }

    [Fact]
    public async Task GetByAfasOrderItemIdAsync_AfasOrderItemId_Should_ThrowException_If_AfasOrderItemId_IsNull() {
        // Arrange
        string AfasOrderItemId = null;

        // Act
        var result = async () => await this._logicProvider.GetByAfasOrderItemIdAsync(AfasOrderItemId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByAfasOrderItemIdAsync_AfasOrderItemId_Should_ThrowException_If_AfasOrderItemId_IsEmpty() {
        // Arrange
        var AfasOrderItemId = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByAfasOrderItemIdAsync(AfasOrderItemId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByAfasOrderItemIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var id = Guid.NewGuid().ToString();
        this._dataProvider.Setup(x => x.GetByAfasOrderItemIdAsync(id)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByAfasOrderItemIdAsync(id);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    
    [Fact]
    public async Task GetByCbOwnerReferenceAsync_AfasOrderItemId_Success() {
        // Arrange
        var AfasOrderItemId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByCbOwnerReferenceAsync(AfasOrderItemId);

        // Assert
        this._dataProvider.Verify(x => x.GetByCbOwnerReferenceAsync(AfasOrderItemId), Times.Once);
    }

    [Fact]
    public async Task GetByCbOwnerReferenceAsync_AfasOrderItemId_Should_ThrowException_If_AfasOrderItemId_IsNull() {
        // Arrange
        string AfasOrderItemId = null;

        // Act
        var result = async () => await this._logicProvider.GetByCbOwnerReferenceAsync(AfasOrderItemId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByCbOwnerReferenceAsync_AfasOrderItemId_Should_ThrowException_If_AfasOrderItemId_IsEmpty() {
        // Arrange
        var AfasOrderItemId = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByCbOwnerReferenceAsync(AfasOrderItemId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByCbOwnerReferenceAsync_Should_ThrowException_If_Error() {
        // Arrange
        var id = Guid.NewGuid().ToString();
        this._dataProvider.Setup(x => x.GetByCbOwnerReferenceAsync(id)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByCbOwnerReferenceAsync(id);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    #endregion

    #region [ Public Methods - Custom - List ]
    [Fact]
    public async Task GetByOrderIdAsync_OrderId_Success() {
        // Arrange
        var OrderId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByOrderIdAsync(OrderId);

        // Assert
        this._dataProvider.Verify(x => x.GetByOrderIdAsync(OrderId), Times.Once);
    }

    [Fact]
    public async Task GetByOrderIdAsync_OrderId_Should_ThrowException_If_OrderId_IsNull() {
        // Arrange
        string OrderId = null;

        // Act
        var result = async () => await this._logicProvider.GetByOrderIdAsync(OrderId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByOrderIdAsync_OrderId_Should_ThrowException_If_OrderId_IsEmpty() {
        // Arrange
        var OrderId = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByOrderIdAsync(OrderId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByOrderIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var id = Guid.NewGuid().ToString();
        this._dataProvider.Setup(x => x.GetByOrderIdAsync(id)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByOrderIdAsync(id);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }

    [Fact]
    public async Task GetByProductAsync_ProductId_Success() {
        // Arrange
        var ProductId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByProductAsync(ProductId);

        // Assert
        this._dataProvider.Verify(x => x.GetByProductAsync(ProductId), Times.Once);
    }

    [Fact]
    public async Task GetByProductAsync_ProductId_Should_ThrowException_If_ProductId_IsNull() {
        // Arrange
        string ProductId = null;

        // Act
        var result = async () => await this._logicProvider.GetByProductAsync(ProductId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByProductAsync_ProductId_Should_ThrowException_If_ProductId_IsEmpty() {
        // Arrange
        var ProductId = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByProductAsync(ProductId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByProductAsync_Should_ThrowException_If_Error() {
        // Arrange
        var id = Guid.NewGuid().ToString();
        this._dataProvider.Setup(x => x.GetByProductAsync(id)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByProductAsync(id);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    
    [Fact]
    public async Task GetBatchByOrderIdAsync_OrderIds_Success() {
        // Arrange
        var OrderIds = this._fixture.Create<List<string>>();

        // Act
        await this._logicProvider.GetBatchByOrderIdAsync(OrderIds);

        // Assert
        this._dataProvider.Verify(x => x.GetBatchByOrderIdAsync(OrderIds), Times.Once);
    }

    [Fact]
    public async Task GetBatchByOrderIdAsync_OrderIds_Should_ThrowException_If_OrderIds_IsNull() {
        // Arrange
        List<string> OrderIds = null;

        // Act
        var result = async () => await this._logicProvider.GetBatchByOrderIdAsync(OrderIds);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetBatchByOrderIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var ids = this._fixture.Create<List<string>>();
        this._dataProvider.Setup(x => x.GetBatchByOrderIdAsync(ids)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetBatchByOrderIdAsync(ids);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    
    [Fact]
    public async Task GetChangesAsync_OrderIds_Success() {
        // Arrange
        var OrderIds = this._fixture.Create<List<string>>();
        var date = DateTime.UtcNow.AddDays(-1);

        // Act
        await this._logicProvider.GetChangesAsync(date, OrderIds);

        // Assert
        this._dataProvider.Verify(x => x.GetChangesAsync(date, OrderIds), Times.Once);
    }

    [Fact]
    public async Task GetChangesAsync_OrderIds_Should_ThrowException_If_OrderIds_IsNull() {
        // Arrange
        List<string> OrderIds = null;
        var date = DateTime.UtcNow.AddDays(-1);

        // Act
        var result = async () => await this._logicProvider.GetChangesAsync(date, OrderIds);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetChangesAsync_Should_ThrowException_If_Error() {
        // Arrange
        var ids = this._fixture.Create<List<string>>();
        var date = DateTime.UtcNow.AddDays(-1);
        this._dataProvider.Setup(x => x.GetChangesAsync(date, ids)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetChangesAsync(date, ids);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }

    [Fact]
    public async Task GetChangesBookProductsAsync_Success() {
        // Arrange
        var date = DateTime.UtcNow.AddDays(-1);

        // Act
        await this._logicProvider.GetChangesBookProductsAsync(date);

        // Assert
        this._dataProvider.Verify(x => x.GetChangesBookProductsAsync(date), Times.Once);
    }
    
    [Fact]
    public async Task GetChangesLicenseProductsAsync_Success() {
        // Arrange
        var date = DateTime.UtcNow.AddDays(-1);

        // Act
        await this._logicProvider.GetChangesLicenseProductsAsync(date);

        // Assert
        this._dataProvider.Verify(x => x.GetChangesLicenseProductsAsync(date), Times.Once);
    }
    #endregion
}
