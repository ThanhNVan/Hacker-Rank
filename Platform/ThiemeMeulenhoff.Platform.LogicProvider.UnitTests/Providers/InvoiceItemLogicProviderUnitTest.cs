using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class InvoiceItemLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<InvoiceItem, IInvoiceItemDataProvider, InvoiceItemLogicProvider>
{
    #region [ CTor ]
    public InvoiceItemLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override InvoiceItemLogicProvider OnCreateLogicProvider(IInvoiceItemDataProvider dataProvider, ILogger<InvoiceItemLogicProvider> logger) {
        return new InvoiceItemLogicProvider(logger, dataProvider);
    }
    #endregion

    #region [ Public Methods - Custom - Lists ]
    [Fact]
    public async Task GetByInvoiceIdAsync_Success() {
        // Arrange
        var InvoiceId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByInvoiceIdAsync(InvoiceId);

        // Assert
        this._dataProvider.Verify(x => x.GetByInvoiceIdAsync(InvoiceId), Times.Once);
    }

    [Fact]
    public async Task GetByInvoiceIdAsync_Should_ThrowException_If_InvoiceId_IsNull() {
        // Arrange
        string id = null;

        // Act
        var result = async () => await this._logicProvider.GetByInvoiceIdAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByInvoiceIdAsync_Should_ThrowException_If_InvoiceId_IsEmpty() {
        // Arrange
        var id = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByInvoiceIdAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

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
        string id = null;

        // Act
        var result = async () => await this._logicProvider.GetByProductIdAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByProductIdAsync_Should_ThrowException_If_ProductId_IsEmpty() {
        // Arrange
        var id = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByProductIdAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    [Fact]
    public async Task GetByOrderItemIdAsync_Success() {
        // Arrange
        var OrderItemId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByOrderItemIdAsync(OrderItemId);

        // Assert
        this._dataProvider.Verify(x => x.GetByOrderItemIdAsync(OrderItemId), Times.Once);
    }

    [Fact]
    public async Task GetByOrderItemIdAsync_Should_ThrowException_If_OrderItemId_IsNull() {
        // Arrange
        string id = null;

        // Act
        var result = async () => await this._logicProvider.GetByOrderItemIdAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByOrderItemIdAsync_Should_ThrowException_If_OrderItemId_IsEmpty() {
        // Arrange
        var id = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByOrderItemIdAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    #endregion
}
