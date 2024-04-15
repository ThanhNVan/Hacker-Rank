using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class OrganizationLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<Organization, IOrganizationDataProvider, OrganizationLogicProvider>
{
    #region [ CTor ]
    public OrganizationLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override OrganizationLogicProvider OnCreateLogicProvider(IOrganizationDataProvider dataProvider, ILogger<OrganizationLogicProvider> logger) {
        return new OrganizationLogicProvider(logger, dataProvider);
    }
    #endregion

    #region [ Public Methods - Custom Single ]
    [Fact]
    public async Task GetByAfasContactNumberAsync_Success() {
        // Arrange
        var afasContactNumber = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByAfasContactNumberAsync(afasContactNumber);

        // Assert
        this._dataProvider.Verify(x => x.GetByAfasContactNumberAsync(afasContactNumber), Times.Once);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ThrowException_If_AfasContactNumber_IsNull() {
        // Arrange
        string afasContactNumber = null;

        // Act
        var result = async () => await this._logicProvider.GetByAfasContactNumberAsync(afasContactNumber);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ThrowException_If_AfasContactNumber_IsEmpty() {
        // Arrange
        var afasContactNumber = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByAfasContactNumberAsync(afasContactNumber);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByAssuNumberAsync_Success() {
        // Arrange
        var AssuNumber = this._fixture.Create<int>();

        // Act
        await this._logicProvider.GetByAssuNumberAsync(AssuNumber);

        // Assert
        this._dataProvider.Verify(x => x.GetByAssuNumberAsync(AssuNumber), Times.Once);
    }

    [Fact]
    public async Task GetByAssuNumberAsync_Should_ThrowException_If_Error() {
        // Arrange
        var AssuNumber = new Random().Next(0, 1000);   
        this._dataProvider.Setup(x => x.GetByAssuNumberAsync(AssuNumber)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByAssuNumberAsync(AssuNumber);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    
    [Fact]
    public async Task GetByAssuNumberAsync_Should_ThrowException_If_Exception() {
        // Arrange
        var AssuNumber = new Random().Next(0, 1000);   
        this._dataProvider.Setup(x => x.GetByAssuNumberAsync(AssuNumber)).Throws(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByAssuNumberAsync(AssuNumber);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }

    [Fact]
    public async Task GetByCbPartijIdAsync_Success() {
        // Arrange
        var CbPartijId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByCbPartijIdAsync(CbPartijId);

        // Assert
        this._dataProvider.Verify(x => x.GetByCbPartijIdAsync(CbPartijId), Times.Once);
    }

    [Fact]
    public async Task GetByCbPartijIdAsync_Should_ThrowException_If_CbPartijId_IsNull() {
        // Arrange
        string CbPartijId = null;

        // Act
        var result = async () => await this._logicProvider.GetByCbPartijIdAsync(CbPartijId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByCbPartijIdAsync_Should_ThrowException_If_CbPartijId_IsEmpty() {
        // Arrange
        var CbPartijId = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByCbPartijIdAsync(CbPartijId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByPropellerIdAsync_Success() {
        // Arrange
        var PropellerId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByPropellerIdAsync(PropellerId);

        // Assert
        this._dataProvider.Verify(x => x.GetByPropellerIdAsync(PropellerId), Times.Once);
    }

    [Fact]
    public async Task GetByPropellerIdAsync_Should_ThrowException_If_PropellerId_IsNull() {
        // Arrange
        string PropellerId = null;

        // Act
        var result = async () => await this._logicProvider.GetByPropellerIdAsync(PropellerId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByPropellerIdAsync_Should_ThrowException_If_PropellerId_IsEmpty() {
        // Arrange
        var PropellerId = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByPropellerIdAsync(PropellerId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByPropellerIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var PropellerId = Guid.NewGuid().ToString();
        this._dataProvider.Setup(x => x.GetByPropellerIdAsync(PropellerId)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByPropellerIdAsync(PropellerId);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    
    [Fact]
    public async Task GetByOrganizationNameAsync_Success() {
        // Arrange
        var OrganizationName = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByOrganizationNameAsync(OrganizationName);

        // Assert
        this._dataProvider.Verify(x => x.GetByOrganizationNameAsync(OrganizationName), Times.Once);
    }

    [Fact]
    public async Task GetByOrganizationNameAsync_Should_ThrowException_If_OrganizationName_IsNull() {
        // Arrange
        string OrganizationName = null;

        // Act
        var result = async () => await this._logicProvider.GetByOrganizationNameAsync(OrganizationName);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByOrganizationNameAsync_Should_ThrowException_If_OrganizationName_IsEmpty() {
        // Arrange
        var OrganizationName = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByOrganizationNameAsync(OrganizationName);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByOrganizationNameAsync_Should_ThrowException_If_Error() {
        // Arrange
        var OrganizationName = Guid.NewGuid().ToString();
        this._dataProvider.Setup(x => x.GetByOrganizationNameAsync(OrganizationName)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByOrganizationNameAsync(OrganizationName);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    #endregion
}
