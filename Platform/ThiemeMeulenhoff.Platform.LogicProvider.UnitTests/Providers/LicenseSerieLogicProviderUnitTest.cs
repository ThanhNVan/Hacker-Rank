using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class LicenseSerieLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<LicenseSerie, ILicenseSerieDataProvider, LicenseSerieLogicProvider>
{
    #region [ CTor ]
    public LicenseSerieLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Abstract Methods ]
    protected override LicenseSerieLogicProvider OnCreateLogicProvider(ILicenseSerieDataProvider dataProvider, ILogger<LicenseSerieLogicProvider> logger) {
        return new LicenseSerieLogicProvider(logger, dataProvider);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
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
        string OrderItemId = null;

        // Act
        var result = async () => await this._logicProvider.GetByOrderItemIdAsync(OrderItemId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByOrderItemIdAsync_Should_ThrowException_If_OrderItemId_IsEmpty() {
        // Arrange
        var OrderItemId = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByOrderItemIdAsync(OrderItemId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByOrderItemIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var OrderItemId = Guid.NewGuid().ToString();
        this._dataProvider.Setup(x => x.GetByOrderItemIdAsync(OrderItemId)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByOrderItemIdAsync(OrderItemId);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }

    [Fact]
    public async Task GetByAfasOrderItemIdAsync_Success() {
        // Arrange
        var AfasOrderItemId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByAfasOrderItemIdAsync(AfasOrderItemId);

        // Assert
        this._dataProvider.Verify(x => x.GetByAfasOrderItemIdAsync(AfasOrderItemId), Times.Once);
    }

    [Fact]
    public async Task GetByAfasOrderItemIdAsync_Should_ThrowException_If_AfasOrderItemId_IsNull() {
        // Arrange
        string AfasOrderItemId = null;

        // Act
        var result = async () => await this._logicProvider.GetByAfasOrderItemIdAsync(AfasOrderItemId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByAfasOrderItemIdAsync_Should_ThrowException_If_AfasOrderItemId_IsEmpty() {
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
        var AfasOrderItemId = Guid.NewGuid().ToString();
        this._dataProvider.Setup(x => x.GetByAfasOrderItemIdAsync(AfasOrderItemId)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByAfasOrderItemIdAsync(AfasOrderItemId);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    #endregion  
}
