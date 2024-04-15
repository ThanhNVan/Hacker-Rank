using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class PrintInfoLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<PrintInfo, IPrintInfoDataProvider, PrintInfoLogicProvider>
{
    #region [ CTor ]
    public PrintInfoLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override PrintInfoLogicProvider OnCreateLogicProvider(IPrintInfoDataProvider dataProvider, ILogger<PrintInfoLogicProvider> logger) {
        return new PrintInfoLogicProvider(logger, dataProvider);
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
    #endregion
}
