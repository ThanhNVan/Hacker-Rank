using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class LicenseSerieItemLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<LicenseSerieItem, ILicenseSerieItemDataProvider, LicenseSerieItemLogicProvider>
{
    #region [ CTor ]
    public LicenseSerieItemLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Abstract Methods ]
    protected override LicenseSerieItemLogicProvider OnCreateLogicProvider(ILicenseSerieItemDataProvider dataProvider, ILogger<LicenseSerieItemLogicProvider> logger) {
        return new LicenseSerieItemLogicProvider(logger, dataProvider);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByLicenseKey_Success() {
        // Arrange
        var LicenseKey = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByLicenseKey(LicenseKey);

        // Assert
        this._dataProvider.Verify(x => x.GetByLicenseKey(LicenseKey), Times.Once);
    }

    [Fact]
    public async Task GetByLicenseKey_Should_ThrowException_If_LicenseKey_IsNull() {
        // Arrange
        string LicenseKey = null;

        // Act
        var result = async () => await this._logicProvider.GetByLicenseKey(LicenseKey);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByLicenseKey_Should_ThrowException_If_LicenseKey_IsEmpty() {
        // Arrange
        var LicenseKey = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByLicenseKey(LicenseKey);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByLicenseKey_Should_ThrowException_If_Error() {
        // Arrange
        var LicenseKey = Guid.NewGuid().ToString();
        this._dataProvider.Setup(x => x.GetByLicenseKey(LicenseKey)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByLicenseKey(LicenseKey);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }

    [Fact]
    public async Task GetByLicenseSerieId_Success() {
        // Arrange
        var LicenseSerieId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByLicenseSerieId(LicenseSerieId);

        // Assert
        this._dataProvider.Verify(x => x.GetByLicenseSerieId(LicenseSerieId), Times.Once);
    }

    [Fact]
    public async Task GetByLicenseSerieId_Should_ThrowException_If_LicenseSerieId_IsNull() {
        // Arrange
        string LicenseSerieId = null;

        // Act
        var result = async () => await this._logicProvider.GetByLicenseSerieId(LicenseSerieId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByLicenseSerieId_Should_ThrowException_If_LicenseSerieId_IsEmpty() {
        // Arrange
        var LicenseSerieId = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByLicenseSerieId(LicenseSerieId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByLicenseSerieId_Should_ThrowException_If_Error() {
        // Arrange
        var LicenseSerieId = Guid.NewGuid().ToString();
        this._dataProvider.Setup(x => x.GetByLicenseSerieId(LicenseSerieId)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByLicenseSerieId(LicenseSerieId);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    #endregion
}
