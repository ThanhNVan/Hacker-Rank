using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class LicenceInfoLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<LicenceInfo, ILicenceInfoDataProvider, LicenceInfoLogicProvider>
{
    #region [ CTor ]
    public LicenceInfoLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Abstract Methods ]
    protected override LicenceInfoLogicProvider OnCreateLogicProvider(ILicenceInfoDataProvider dataProvider, ILogger<LicenceInfoLogicProvider> logger) {
        return new LicenceInfoLogicProvider(logger, dataProvider);
    }
    #endregion

    #region [ Public Methods - Custom Single ]
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

    #endregion
}