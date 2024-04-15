using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class PersonLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<Person, IPersonDataProvider, PersonLogicProvider>
{
    #region [ CTor ]
    public PersonLogicProviderUnitTest()
    {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override PersonLogicProvider OnCreateLogicProvider(IPersonDataProvider dataProvider, ILogger<PersonLogicProvider> logger)
    {
        return new PersonLogicProvider(logger, dataProvider);
    }
    #endregion

    #region [ Public Methods - Single ]
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
    public async Task GetByAssuNumberAsync_Should_ThrowException_If_Invalid() {
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
    public async Task GetByAssuNumberTempAsync_Success() {
        // Arrange
        var assuNumberTemp = this._fixture.Create<int>();

        // Act
        await this._logicProvider.GetByAssuNumberTempAsync(assuNumberTemp);

        // Assert
        this._dataProvider.Verify(x => x.GetByAssuNumberTempAsync(assuNumberTemp), Times.Once);
    }

    [Fact]
    public async Task GetByAssuNumberTempAsync_Should_ThrowException_If_Error() {
        // Arrange
        int assuNumberTemp = this._fixture.Create<int>();
        this._dataProvider.Setup(x => x.GetByAssuNumberTempAsync(assuNumberTemp)).Throws(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByAssuNumberTempAsync(assuNumberTemp);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
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
    #endregion
}