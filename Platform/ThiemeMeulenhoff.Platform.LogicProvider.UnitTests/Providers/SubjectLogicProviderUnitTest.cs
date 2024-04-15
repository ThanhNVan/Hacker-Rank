using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class SubjectLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<Subject, ISubjectDataProvider, SubjectLogicProvider>
{
    #region [ CTor ]
    public SubjectLogicProviderUnitTest() {

    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetBySubjectCodeAsync_Success() {
        // Arrange
        var SubjectCode = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetBySubjectCodeAsync(SubjectCode);

        // Assert
        this._dataProvider.Verify(x => x.GetBySubjectCodeAsync(SubjectCode), Times.Once);
    }

    [Fact]
    public async Task GetBySubjectCodeAsync_Should_ThrowException_If_SubjectCode_IsNull() {
        // Arrange
        string SubjectCode = null;

        // Act
        var result = async () => await this._logicProvider.GetBySubjectCodeAsync(SubjectCode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetBySubjectCodeAsync_Should_ThrowException_If_SubjectCode_IsEmpty() {
        // Arrange
        var SubjectCode = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetBySubjectCodeAsync(SubjectCode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetBySubjectCodeAsync_Should_ThrowException_If_Error() {
        // Arrange
        var SubjectCode = Guid.NewGuid().ToString();
        this._dataProvider.Setup(x => x.GetBySubjectCodeAsync(SubjectCode)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetBySubjectCodeAsync(SubjectCode);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override SubjectLogicProvider OnCreateLogicProvider(ISubjectDataProvider dataProvider, ILogger<SubjectLogicProvider> logger) {
        return new SubjectLogicProvider(logger, dataProvider);
    }
    #endregion
}
