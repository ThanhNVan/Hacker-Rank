using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class InvoiceLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<Invoice, IInvoiceDataProvider, InvoiceLogicProvider>
{
    #region [ CTor ]
    public InvoiceLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override InvoiceLogicProvider OnCreateLogicProvider(IInvoiceDataProvider dataProvider, ILogger<InvoiceLogicProvider> logger) {
        return new InvoiceLogicProvider(logger, dataProvider);
    }
    #endregion

    #region [ Public Methods - Custom - Lists ]
    [Fact]
    public async Task GetByOrderIdAsync_Success() {
        // Arrange
        var OrderId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByOrderIdAsync(OrderId);

        // Assert
        this._dataProvider.Verify(x => x.GetByOrderIdAsync(OrderId), Times.Once);
    }

    [Fact]
    public async Task GetByOrderIdAsync_Should_ThrowException_If_OrderId_IsNull() {
        // Arrange
        string id = null;

        // Act
        var result = async () => await this._logicProvider.GetByOrderIdAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByOrderIdAsync_Should_ThrowException_If_OrderId_IsEmpty() {
        // Arrange
        var id = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByOrderIdAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
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
        string id = null;

        // Act
        var result = async () => await this._logicProvider.GetByContactIdAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByContactIdAsync_Should_ThrowException_If_ContactId_IsEmpty() {
        // Arrange
        var id = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByContactIdAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    #endregion
}
