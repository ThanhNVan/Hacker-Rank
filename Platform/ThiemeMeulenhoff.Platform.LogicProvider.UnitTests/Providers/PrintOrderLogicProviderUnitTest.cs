using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class PrintOrderLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<PrintOrder, IPrintOrderDataProvider, PrintOrderLogicProvider>
{
    #region [ CTor ]
    public PrintOrderLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override PrintOrderLogicProvider OnCreateLogicProvider(IPrintOrderDataProvider dataProvider, ILogger<PrintOrderLogicProvider> logger) {
        return new PrintOrderLogicProvider(logger, dataProvider);
    }
    #endregion

    #region [ Public Methods - Custom - Lists ]
    [Fact]
    public async Task GetByAfasPrintOrderNumberAsync_Success() {
        // Arrange
        var AfasPrintOrderNumber = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByAfasPrintOrderNumberAsync(AfasPrintOrderNumber);

        // Assert
        this._dataProvider.Verify(x => x.GetByAfasPrintOrderNumberAsync(AfasPrintOrderNumber), Times.Once);
    }

    [Fact]
    public async Task GetByAfasPrintOrderNumberAsync_Should_ThrowException_If_AfasPrintOrderNumber_IsNull() {
        // Arrange
        string AfasPrintOrderNumber = null;

        // Act
        var result = async () => await this._logicProvider.GetByAfasPrintOrderNumberAsync(AfasPrintOrderNumber);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByAfasPrintOrderNumberAsync_Should_ThrowException_If_AfasPrintOrderNumber_IsEmpty() {
        // Arrange
        var AfasPrintOrderNumber = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByAfasPrintOrderNumberAsync(AfasPrintOrderNumber);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByAfasPrintOrderNumberAsync_Should_ThrowException_If_Error() {
        // Arrange
        var AfasPrintOrderNumber = Guid.NewGuid().ToString();
        this._dataProvider.Setup(x => x.GetByAfasPrintOrderNumberAsync(AfasPrintOrderNumber)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByAfasPrintOrderNumberAsync(AfasPrintOrderNumber);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }

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

    [Fact]
    public async Task GetByEanAsync_Success() {
        // Arrange
        var Ean = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByEanAsync(Ean);

        // Assert
        this._dataProvider.Verify(x => x.GetByEanAsync(Ean), Times.Once);
    }

    [Fact]
    public async Task GetByEanAsync_Should_ThrowException_If_Ean_IsNull() {
        // Arrange
        string id = null;

        // Act
        var result = async () => await this._logicProvider.GetByEanAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByEanAsync_Should_ThrowException_If_Ean_IsEmpty() {
        // Arrange
        var id = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByEanAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByStatusAsync_Success() {
        // Arrange
        var Status = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByStatusAsync(Status);

        // Assert
        this._dataProvider.Verify(x => x.GetByStatusAsync(Status), Times.Once);
    }

    [Fact]
    public async Task GetByStatusAsync_Should_ThrowException_If_Status_IsNull() {
        // Arrange
        string id = null;

        // Act
        var result = async () => await this._logicProvider.GetByStatusAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByStatusAsync_Should_ThrowException_If_Status_IsEmpty() {
        // Arrange
        var id = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByStatusAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    #endregion
}
