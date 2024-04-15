using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class PriceInfoLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<PriceInfo, IPriceInfoDataProvider, PriceInfoLogicProvider>
{
    #region [ CTor ]
    public PriceInfoLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override PriceInfoLogicProvider OnCreateLogicProvider(IPriceInfoDataProvider dataProvider, ILogger<PriceInfoLogicProvider> logger) {
        return new PriceInfoLogicProvider(logger, dataProvider);
    }
    #endregion

    #region [ Public Methods - Custom - Lists ]
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
    #endregion
}
