using AutoFixture;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class AddressLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<Address, IAddressDataProvider, AddressLogicProvider>
{
    #region [ CTor ]
    public AddressLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override AddressLogicProvider OnCreateLogicProvider(IAddressDataProvider dataProvider, ILogger<AddressLogicProvider> logger) {
        return new AddressLogicProvider(logger, dataProvider);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByAfasAddressIdAsync_Success() {
        // Arrange
        var afasAddressId = this._fixture.Create<string>();
        var afasContactNumber = this._fixture.Create<string>();

        
        // Act
        await this._logicProvider.GetByAfasAddressIdAsync(afasAddressId, afasContactNumber, AddressType.Unknown);

        // Assert
        this._dataProvider.Verify(x => x.GetByAfasAddressIdAsync(afasAddressId, afasContactNumber, AddressType.Unknown), Times.Once);
    }

    [Fact]
    public async Task GetByAfasAddressIdAsync_Should_ThrowException_If_AfasAddressId_IsNull() {
        // Arrange
        string id = null;

        // Act
        var result = async () => await this._logicProvider.GetByAfasAddressIdAsync(id, string.Empty, AddressType.Unknown);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    
    [Fact]
    public async Task GetByAfasAddressIdAsync_Should_ThrowException_If_AfasAddressId_IsEmpty() {
        // Arrange
        var id = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByAfasAddressIdAsync(id, string.Empty, AddressType.Unknown);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByAfasAddressIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var afasAddressId = this._fixture.Create<string>();
        var afasContactNumber = this._fixture.Create<string>();
        this._dataProvider.Setup(x => x.GetByAfasAddressIdAsync(afasAddressId, afasContactNumber, AddressType.Unknown)).Throws(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByAfasAddressIdAsync(afasAddressId, afasContactNumber, AddressType.Unknown);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    
    [Fact]
    public async Task GetByOwnerAsync_Success() {
        // Arrange
        var Owner = this._fixture.Create<string>();
        var addressType = this._fixture.Create<AddressType>();

        // Act
        await this._logicProvider.GetByOwnerAsync(Owner, addressType);

        // Assert
        this._dataProvider.Verify(x => x.GetByOwnerAsync(Owner, addressType), Times.Once);
    }

    [Fact]
    public async Task GetByOwnerAsync_Should_ThrowException_If_Owner_IsNull() {
        // Arrange
        string Owner = null;
        var addressType = this._fixture.Create<AddressType>();

        // Act
        var result = async () => await this._logicProvider.GetByOwnerAsync(Owner, addressType);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    
    [Fact]
    public async Task GetByOwnerAsync_Should_ThrowException_If_Owner_IsEmpty() {
        // Arrange
        var Owner = string.Empty;
        var addressType = this._fixture.Create<AddressType>();

        // Act
        var result = async () => await this._logicProvider.GetByOwnerAsync(Owner, addressType);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByOwnerAsync_Should_ThrowException_If_Error() {
        // Arrange
        var Owner = this._fixture.Create<string>();
        var addressType = this._fixture.Create<AddressType>();
        this._dataProvider.Setup(x => x.GetByOwnerAsync(Owner, addressType)).Throws(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByOwnerAsync(Owner, addressType);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    #endregion

    #region [ Public Methods - Custom List ]
    [Fact]
    public async Task GetByAfasContactNumberAsync_Success() {
        // Arrange
        var AfasContactNumber = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByAfasContactNumberAsync(AfasContactNumber);

        // Assert
        this._dataProvider.Verify(x => x.GetByAfasContactNumberAsync(AfasContactNumber), Times.Once);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ThrowException_If_AfasContactNumber_IsNull() {
        // Arrange
        string AfasContactNumber = null;

        // Act
        var result = async () => await this._logicProvider.GetByAfasContactNumberAsync(AfasContactNumber);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ThrowException_If_AfasContactNumber_IsEmpty() {
        // Arrange
        var AfasContactNumber = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByAfasContactNumberAsync(AfasContactNumber);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ThrowException_If_Error() {
        // Arrange
        var AfasContactNumber = this._fixture.Create<string>();
        this._dataProvider.Setup(x => x.GetByAfasContactNumberAsync(AfasContactNumber)).Throws(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByAfasContactNumberAsync(AfasContactNumber);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    
    [Fact]
    public async Task GetByOwnerContactAsync_Success() {
        // Arrange
        var ownerContactId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByOwnerContactAsync(ownerContactId);

        // Assert
        this._dataProvider.Verify(x => x.GetByOwnerContactAsync(ownerContactId), Times.Once);
    }

    [Fact]
    public async Task GetByOwnerContactAsync_Should_ThrowException_If_ownerContactId_IsNull() {
        // Arrange
        string ownerContactId = null;

        // Act
        var result = async () => await this._logicProvider.GetByOwnerContactAsync(ownerContactId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByOwnerContactAsync_Should_ThrowException_If_ownerContactId_IsEmpty() {
        // Arrange
        var ownerContactId = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByOwnerContactAsync(ownerContactId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByOwnerContactAsync_Should_ThrowException_If_Error() {
        // Arrange
        var ownerContactId = this._fixture.Create<string>();
        this._dataProvider.Setup(x => x.GetByOwnerContactAsync(ownerContactId)).Throws(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByOwnerContactAsync(ownerContactId);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    #endregion
}
