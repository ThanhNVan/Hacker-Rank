using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class ProjectLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<Project, IProjectDataProvider, ProjectLogicProvider>
{
    #region [ CTor ]
    public ProjectLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Abstract Methods ]
    protected override ProjectLogicProvider OnCreateLogicProvider(IProjectDataProvider dataProvider, ILogger<ProjectLogicProvider> logger) {
        return new ProjectLogicProvider(logger, dataProvider);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByProjectNameAsync_Success() {
        // Arrange
        var ProjectName = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByProjectNameAsync(ProjectName);

        // Assert
        this._dataProvider.Verify(x => x.GetByProjectNameAsync(ProjectName), Times.Once);
    }

    [Fact]
    public async Task GetByProjectNameAsync_Should_ThrowException_If_ProjectName_IsNull() {
        // Arrange
        string ProjectName = null;

        // Act
        var result = async () => await this._logicProvider.GetByProjectNameAsync(ProjectName);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByProjectNameAsync_Should_ThrowException_If_ProjectName_IsEmpty() {
        // Arrange
        var ProjectName = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByProjectNameAsync(ProjectName);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByProjectNameAsync_Should_ThrowException_If_Error() {
        // Arrange
        var ProjectName = Guid.NewGuid().ToString();
        this._dataProvider.Setup(x => x.GetByProjectNameAsync(ProjectName)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByProjectNameAsync(ProjectName);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }

    [Fact]
    public async Task GetByProjectNumberAsync_Success() {
        // Arrange
        var ProjectNumber = this._fixture.Create<int>();

        // Act
        await this._logicProvider.GetByProjectNumberAsync(ProjectNumber);

        // Assert
        this._dataProvider.Verify(x => x.GetByProjectNumberAsync(ProjectNumber), Times.Once);
    }

    [Fact]
    public async Task GetByProjectNumberAsync_Should_ThrowException_If_Error() {
        // Arrange
        var ProjectNumber = this._fixture.Create<int>();
        this._dataProvider.Setup(x => x.GetByProjectNumberAsync(ProjectNumber)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByProjectNumberAsync(ProjectNumber);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    #endregion

    #region [ Public Methods - Custom - Lists ]
    [Fact]
    public async Task GetBySubjectIdIdAsync_Success() {
        // Arrange
        var SubjectIdId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetBySubjectIdIdAsync(SubjectIdId);

        // Assert
        this._dataProvider.Verify(x => x.GetBySubjectIdIdAsync(SubjectIdId), Times.Once);
    }

    [Fact]
    public async Task GetBySubjectIdIdAsync_Should_ThrowException_If_SubjectIdId_IsNull() {
        // Arrange
        string SubjectIdId = null;

        // Act
        var result = async () => await this._logicProvider.GetBySubjectIdIdAsync(SubjectIdId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetBySubjectIdIdAsync_Should_ThrowException_If_SubjectIdId_IsEmpty() {
        // Arrange
        var SubjectIdId = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetBySubjectIdIdAsync(SubjectIdId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetBySubjectIdIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var SubjectIdId = Guid.NewGuid().ToString();
        this._dataProvider.Setup(x => x.GetBySubjectIdIdAsync(SubjectIdId)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetBySubjectIdIdAsync(SubjectIdId);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }

    [Fact]
    public async Task GetBatchBySubjectIdAsync_Success() {
        // Arrange
        var SubjectId = this._fixture.Create<List<string>>();

        // Act
        await this._logicProvider.GetBatchBySubjectIdAsync(SubjectId);

        // Assert
        this._dataProvider.Verify(x => x.GetBatchBySubjectIdAsync(SubjectId), Times.Once);
    }

    [Fact]
    public async Task GetBatchBySubjectIdAsync_Should_ThrowException_If_SubjectId_IsNull() {
        // Arrange
        List<string> SubjectId = null;

        // Act
        var result = async () => await this._logicProvider.GetBatchBySubjectIdAsync(SubjectId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetBatchBySubjectIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var SubjectId = this._fixture.Create<List<string>>();
        this._dataProvider.Setup(x => x.GetBatchBySubjectIdAsync(SubjectId)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetBatchBySubjectIdAsync(SubjectId);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    #endregion
}
