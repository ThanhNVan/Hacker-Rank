using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class OrderLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<Order, IOrderDataProvider, OrderLogicProvider>
{
    #region [ CTor ]
    public OrderLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override OrderLogicProvider OnCreateLogicProvider(IOrderDataProvider dataProvider, ILogger<OrderLogicProvider> logger) {
        return new OrderLogicProvider(logger, dataProvider);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByAfasOrderIdAsync_Success() {
        // Arrange
        var AfasOrderId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByAfasOrderIdAsync(AfasOrderId);

        // Assert
        this._dataProvider.Verify(x => x.GetByAfasOrderIdAsync(AfasOrderId), Times.Once);
    }

    [Fact]
    public async Task GetByAfasOrderIdAsync_Should_ThrowException_If_AfasOrderId_IsNull() {
        // Arrange
        string AfasOrderId = null;

        // Act
        var result = async () => await this._logicProvider.GetByAfasOrderIdAsync(AfasOrderId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByAfasOrderIdAsync_Should_ThrowException_If_AfasOrderId_IsEmpty() {
        // Arrange
        var AfasOrderId = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByAfasOrderIdAsync(AfasOrderId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByAfasOrderIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var ContactId = this._fixture.Create<string>();
        this._dataProvider.Setup(x => x.GetByAfasOrderIdAsync(ContactId)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByAfasOrderIdAsync(ContactId);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    
    [Fact]
    public async Task GetByPropellerOrderReferenceIdAsync_Success() {
        // Arrange
        var propellerOrderReferenceId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByPropellerOrderReferenceIdAsync(propellerOrderReferenceId);

        // Assert
        this._dataProvider.Verify(x => x.GetByPropellerOrderReferenceIdAsync(propellerOrderReferenceId), Times.Once);
    }

    [Fact]
    public async Task GetByPropellerOrderReferenceIdAsync_Should_ThrowException_If_propellerOrderReferenceId_IsNull() {
        // Arrange
        string propellerOrderReferenceId = null;

        // Act
        var result = async () => await this._logicProvider.GetByPropellerOrderReferenceIdAsync(propellerOrderReferenceId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByPropellerOrderReferenceIdAsync_Should_ThrowException_If_propellerOrderReferenceId_IsEmpty() {
        // Arrange
        var propellerOrderReferenceId = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByPropellerOrderReferenceIdAsync(propellerOrderReferenceId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByPropellerOrderReferenceIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var ContactId = this._fixture.Create<string>();
        this._dataProvider.Setup(x => x.GetByPropellerOrderReferenceIdAsync(ContactId)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByPropellerOrderReferenceIdAsync(ContactId);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    #endregion

    #region [ Public Methods - Custom - List ]
    [Fact]
    public async Task GetByContactAsync_Success() {
        // Arrange
        var ContactId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByContactAsync(ContactId);

        // Assert
        this._dataProvider.Verify(x => x.GetByContactAsync(ContactId), Times.Once);
    }

    [Fact]
    public async Task GetByContactAsync_Should_ThrowException_If_Contact_IsNull() {
        // Arrange
        string ContactId = null;

        // Act
        var result = async () => await this._logicProvider.GetByContactAsync(ContactId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByContactAsync_Should_ThrowException_If_Contact_IsEmpty() {
        // Arrange
        var ContactId = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByContactAsync(ContactId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByContactAsync_Should_ThrowException_If_Error() {
        // Arrange
        var ContactId = this._fixture.Create<string>();
        this._dataProvider.Setup(x => x.GetByContactAsync(ContactId)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByContactAsync(ContactId);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    
    [Fact]
    public async Task GetByCbOrderTypeAsync_Success() {
        // Arrange
        var cbContact = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByCbOrderTypeAsync(cbContact);

        // Assert
        this._dataProvider.Verify(x => x.GetByCbOrderTypeAsync(cbContact), Times.Once);
    }

    [Fact]
    public async Task GetByCbOrderTypeAsync_Should_ThrowException_If_CbOrder_IsNull() {
        // Arrange
        string cbContact = null;

        // Act
        var result = async () => await this._logicProvider.GetByCbOrderTypeAsync(cbContact);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByCbOrderTypeAsync_Should_ThrowException_If_CbOrder_IsEmpty() {
        // Arrange
        var cbContact = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByCbOrderTypeAsync(cbContact);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByCbOrderTypeAsync_Should_ThrowException_If_Error() {
        // Arrange
        var cbContact = this._fixture.Create<string>();
        this._dataProvider.Setup(x => x.GetByCbOrderTypeAsync(cbContact)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByCbOrderTypeAsync(cbContact);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    
    [Fact]
    public async Task GetChangesForCentraalBoekhuisAsync_Success() {
        // Arrange
        var cbContact = this._fixture.Create<string>();
        var date = this._fixture.Create<DateTime>();

        // Act
        await this._logicProvider.GetChangesForCentraalBoekhuisAsync(date, cbContact);

        // Assert
        this._dataProvider.Verify(x => x.GetChangesForCentraalBoekhuisAsync(date, cbContact), Times.Once);
    }

    [Fact]
    public async Task GetChangesForCentraalBoekhuisAsync_Should_ThrowException_If_CbOrder_IsNull() {
        // Arrange
        string cbContact = null;
        var date = this._fixture.Create<DateTime>();

        // Act
        var result = async () => await this._logicProvider.GetChangesForCentraalBoekhuisAsync(date, cbContact);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetChangesForCentraalBoekhuisAsync_Should_ThrowException_If_CbOrder_IsEmpty() {
        // Arrange
        var cbContact = string.Empty;
        var date = this._fixture.Create<DateTime>();

        // Act
        var result = async () => await this._logicProvider.GetChangesForCentraalBoekhuisAsync(date, cbContact);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetChangesForCentraalBoekhuisAsync_Should_ThrowException_If_Error() {
        // Arrange
        var cbContact = this._fixture.Create<string>();
        var date = this._fixture.Create<DateTime>();
        this._dataProvider.Setup(x => x.GetChangesForCentraalBoekhuisAsync(date, cbContact)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetChangesForCentraalBoekhuisAsync(date, cbContact);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    #endregion
}
