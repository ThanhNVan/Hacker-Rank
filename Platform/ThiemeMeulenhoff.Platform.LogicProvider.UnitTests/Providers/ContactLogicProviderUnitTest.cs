using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class ContactLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<Contact, IContactDataProvider, ContactLogicProvider>
{
    #region [ CTor ]
    public ContactLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override ContactLogicProvider OnCreateLogicProvider(IContactDataProvider dataProvider, ILogger<ContactLogicProvider> logger) {
        return new ContactLogicProvider(logger, dataProvider);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
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
        string id = null;

        // Act
        var result = async () => await this._logicProvider.GetByAfasContactNumberAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ThrowException_If_AfasContactNumber_IsEmpty() {
        // Arrange
        var id = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByAfasContactNumberAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ThrowException_If_Error() {
        // Arrange
        var id = Guid.NewGuid().ToString();
        this._dataProvider.Setup(x => x.GetByAfasContactNumberAsync(id)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByAfasContactNumberAsync(id);

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
        string id = null;

        // Act
        var result = async () => await this._logicProvider.GetByCbPartijIdAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByCbPartijIdAsync_Should_ThrowException_If_CbPartijId_IsEmpty() {
        // Arrange
        var id = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByCbPartijIdAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByCbPartijIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var id = Guid.NewGuid().ToString();
        this._dataProvider.Setup(x => x.GetByCbPartijIdAsync(id)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByCbPartijIdAsync(id);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    
    [Fact]
    public async Task GetByAfasDebtorIdAsync_Success() {
        // Arrange
        var AfasDebtorId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByAfasDebtorIdAsync(AfasDebtorId);

        // Assert
        this._dataProvider.Verify(x => x.GetByAfasDebtorIdAsync(AfasDebtorId), Times.Once);
    }

    [Fact]
    public async Task GetByAfasDebtorIdAsync_Should_ThrowException_If_AfasDebtorId_IsNull() {
        // Arrange
        string id = null;

        // Act
        var result = async () => await this._logicProvider.GetByAfasDebtorIdAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByAfasDebtorIdAsync_Should_ThrowException_If_AfasDebtorId_IsEmpty() {
        // Arrange
        var id = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByAfasDebtorIdAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByAfasDebtorIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var id = Guid.NewGuid().ToString();
        this._dataProvider.Setup(x => x.GetByAfasDebtorIdAsync(id)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByAfasDebtorIdAsync(id);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    
    [Fact]
    public async Task GetByPropellerIdAsync_Success() {
        // Arrange
        var AfasDebtorId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByPropellerIdAsync(AfasDebtorId);

        // Assert
        this._dataProvider.Verify(x => x.GetByPropellerIdAsync(AfasDebtorId), Times.Once);
    }

    [Fact]
    public async Task GetByPropellerIdAsync_Should_ThrowException_If_AfasDebtorId_IsNull() {
        // Arrange
        string id = null;

        // Act
        var result = async () => await this._logicProvider.GetByPropellerIdAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByPropellerIdAsync_Should_ThrowException_If_AfasDebtorId_IsEmpty() {
        // Arrange
        var id = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByPropellerIdAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByPropellerIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var id = Guid.NewGuid().ToString();
        this._dataProvider.Setup(x => x.GetByPropellerIdAsync(id)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByPropellerIdAsync(id);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }

    [Fact]
    public async Task GetByAssuNumberAsync_Success() {
        // Arrange
        var assuNumberTemp = this._fixture.Create<int>();

        // Act
        await this._logicProvider.GetByAssuNumberAsync(assuNumberTemp);

        // Assert
        this._dataProvider.Verify(x => x.GetByAssuNumberAsync(assuNumberTemp), Times.Once);
    }

    [Fact]
    public async Task GetByAssuNumberAsync_Should_ThrowException_If_Error() {
        // Arrange
        var assuNumberTemp = new Random().Next(0, 1000);
        this._dataProvider.Setup(x => x.GetByAssuNumberAsync(assuNumberTemp)).Throws(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByAssuNumberAsync(assuNumberTemp);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    #endregion
}