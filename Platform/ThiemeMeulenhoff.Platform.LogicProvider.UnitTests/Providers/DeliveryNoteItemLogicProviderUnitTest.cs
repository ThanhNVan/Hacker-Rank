using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class DeliveryNoteItemLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<DeliveryNoteItem, IDeliveryNoteItemDataProvider, DeliveryNoteItemLogicProvider>
{
    #region [ CTor ]
    public DeliveryNoteItemLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override DeliveryNoteItemLogicProvider OnCreateLogicProvider(IDeliveryNoteItemDataProvider dataProvider, ILogger<DeliveryNoteItemLogicProvider> logger) {
        return new DeliveryNoteItemLogicProvider(logger, dataProvider);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByOrderIdAndOrderItemIdAsync_Success() {
        // Arrange
        var orderId = this._fixture.Create<string>();
        var orderItemId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByOrderIdAndOrderItemIdAsync(orderId, orderItemId);

        // Assert
        this._dataProvider.Verify(x => x.GetByOrderIdAndOrderItemIdAsync(orderId, orderItemId), Times.Once);
    }

    [Fact]
    public async Task GetByOrderIdAndOrderItemIdAsync_Should_ThrowException_If_OrderId_IsNull() {
        // Arrange
        string orderId = null;
        var orderItemId = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.GetByOrderIdAndOrderItemIdAsync(orderId, orderItemId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByOrderIdAndOrderItemIdAsync_Should_ThrowException_If_OrderId_IsEmpty() {
        // Arrange
        var orderId = string.Empty;
        var orderItemId = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.GetByOrderIdAndOrderItemIdAsync(orderId, orderItemId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    
    [Fact]
    public async Task GetByOrderIdAndOrderItemIdAsync_Should_ThrowException_If_OrderItemId_IsNull() {
        // Arrange
        string orderItemId = null;
        var orderId = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.GetByOrderIdAndOrderItemIdAsync(orderId, orderItemId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByOrderIdAndOrderItemIdAsync_Should_ThrowException_If_OrderItemId_IsEmpty() {
        // Arrange
        var orderItemId = string.Empty;
        var orderId = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.GetByOrderIdAndOrderItemIdAsync(orderId, orderItemId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByOrderIdAndOrderItemIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var orderId = this._fixture.Create<string>();
        var orderItemId = this._fixture.Create<string>();
        this._dataProvider.Setup(x => x.GetByOrderIdAndOrderItemIdAsync(orderId, orderItemId)).Throws(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByOrderIdAndOrderItemIdAsync(orderId, orderItemId);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    #endregion
}
