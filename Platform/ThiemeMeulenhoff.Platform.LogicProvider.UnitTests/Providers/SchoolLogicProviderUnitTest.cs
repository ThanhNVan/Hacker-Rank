using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class SchoolLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<School, ISchoolDataProvider, SchoolLogicProvider>
{
    #region [ CTor ]
    public SchoolLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override SchoolLogicProvider OnCreateLogicProvider(ISchoolDataProvider dataProvider, ILogger<SchoolLogicProvider> logger) {
        return new SchoolLogicProvider(logger, dataProvider);
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
    public async Task GetByAfasContactNumberAsync_Should_ThrowException_If_Error() {
        // Arrange
        var afasContactNumber = this._fixture.Create<string>();
        this._dataProvider.Setup(x => x.GetByAfasContactNumberAsync(afasContactNumber)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByAfasContactNumberAsync(afasContactNumber);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }

    [Fact]
    public async Task GetByBranchNumberAsync_Success() {
        // Arrange
        var BranchNumber = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByBranchNumberAsync(BranchNumber);

        // Assert
        this._dataProvider.Verify(x => x.GetByBranchNumberAsync(BranchNumber), Times.Once);
    }

    [Fact]
    public async Task GetByBranchNumberAsync_Should_ThrowException_If_ApplicationName_IsNull() {
        // Arrange
        string BranchNumber = null;

        // Act
        var result = async () => await this._logicProvider.GetByBranchNumberAsync(BranchNumber);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByBranchNumberAsync_Should_ThrowException_If_ApplicationName_IsEmpty() {
        // Arrange
        var BranchNumber = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByBranchNumberAsync(BranchNumber);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByBrinCodeAsync_Success() {
        // Arrange
        var BrinCode = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByBrinCodeAsync(BrinCode);

        // Assert
        this._dataProvider.Verify(x => x.GetByBrinCodeAsync(BrinCode), Times.Once);
    }

    [Fact]
    public async Task GetByBrinCodeAsync_Should_ThrowException_If_BrinCode_IsNull() {
        // Arrange
        string BrinCode = null;

        // Act
        var result = async () => await this._logicProvider.GetByBrinCodeAsync(BrinCode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByBrinCodeAsync_Should_ThrowException_If_BrinCode_IsEmpty() {
        // Arrange
        var BrinCode = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByBrinCodeAsync(BrinCode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetBySchoolBoardNumberAsync_Success() {
        // Arrange
        var SchoolBoardNumber = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetBySchoolBoardNumberAsync(SchoolBoardNumber);

        // Assert
        this._dataProvider.Verify(x => x.GetBySchoolBoardNumberAsync(SchoolBoardNumber), Times.Once);
    }

    [Fact]
    public async Task GetBySchoolBoardNumberAsync_Should_ThrowException_If_SchoolBoardNumber_IsNull() {
        // Arrange
        string SchoolBoardNumber = null;

        // Act
        var result = async () => await this._logicProvider.GetBySchoolBoardNumberAsync(SchoolBoardNumber);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetBySchoolBoardNumberAsync_Should_ThrowException_If_SchoolBoardNumber_IsEmpty() {
        // Arrange
        var SchoolBoardNumber = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetBySchoolBoardNumberAsync(SchoolBoardNumber);

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
        this._dataProvider.Setup(x => x.GetByAssuNumberAsync(AssuNumber)).Throws(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByAssuNumberAsync(AssuNumber);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    
    [Fact]
    public async Task GetByAssuNumberTempAsync_Success() {
        // Arrange
        var assuNumberTemp = this._fixture.Create<int>();

        // Act
        await this._logicProvider.GetByAssuNumberTempAsync(assuNumberTemp);

        // Assert
        this._dataProvider.Verify(x => x.GetByAssuNumberAsync(assuNumberTemp), Times.Once);
    }

    [Fact]
    public async Task GetByAssuNumberTempAsync_Should_ThrowException_If_Error() {
        // Arrange
        var assuNumberTemp = new Random().Next(0, 1000);
        this._dataProvider.Setup(x => x.GetByAssuNumberAsync(assuNumberTemp)).Throws(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByAssuNumberTempAsync(assuNumberTemp);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    #endregion
}
