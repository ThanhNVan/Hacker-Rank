using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class ProjectTeamMemberLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<ProjectTeamMember, IProjectTeamMemberDataProvider, ProjectTeamMemberLogicProvider>
{
    #region [ CTor ]
    public ProjectTeamMemberLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override ProjectTeamMemberLogicProvider OnCreateLogicProvider(IProjectTeamMemberDataProvider dataProvider, ILogger<ProjectTeamMemberLogicProvider> logger) {
        return new ProjectTeamMemberLogicProvider(logger, dataProvider);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByProjectIdAndContactIdAsync_Success() {
        // Arrange
        var ProjectId = this._fixture.Create<string>();
        var contactId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByProjectIdAndContactIdAsync(ProjectId, contactId);

        // Assert
        this._dataProvider.Verify(x => x.GetByProjectIdAndContactIdAsync(ProjectId, contactId), Times.Once);
    }

    [Fact]
    public async Task GetByProjectIdAndContactIdAsync_Should_ThrowException_If_ProjectId_IsNull() {
        // Arrange
        string ProjectId = null;
        var contactId = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.GetByProjectIdAndContactIdAsync(ProjectId, contactId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByProjectIdAndContactIdAsync_Should_ThrowException_If_ProjectId_IsEmpty() {
        // Arrange
        var ProjectId = string.Empty;
        var contactId = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.GetByProjectIdAndContactIdAsync(ProjectId, contactId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByProjectIdAndContactIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var ProjectId = Guid.NewGuid().ToString();
        var contactId = this._fixture.Create<string>();
        this._dataProvider.Setup(x => x.GetByProjectIdAndContactIdAsync(ProjectId, contactId)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByProjectIdAndContactIdAsync(ProjectId, contactId);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    #endregion

    #region [ Public Methods - Custom - Lists ]
    [Fact]
    public async Task GetByProjectIdAsync_Success() {
        // Arrange
        var ProjectId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByProjectIdAsync(ProjectId);

        // Assert
        this._dataProvider.Verify(x => x.GetByProjectIdAsync(ProjectId), Times.Once);
    }

    [Fact]
    public async Task GetByProjectIdAsync_Should_ThrowException_If_ProjectId_IsNull() {
        // Arrange
        string ProjectId = null;

        // Act
        var result = async () => await this._logicProvider.GetByProjectIdAsync(ProjectId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByProjectIdAsync_Should_ThrowException_If_ProjectId_IsEmpty() {
        // Arrange
        var ProjectId = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByProjectIdAsync(ProjectId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByProjectIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var ProjectId = Guid.NewGuid().ToString();
        this._dataProvider.Setup(x => x.GetByProjectIdAsync(ProjectId)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByProjectIdAsync(ProjectId);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }


    [Fact]
    public async Task GetByContactIdAsync_Success() {
        // Arrange
        var ContactId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByContactIdAsync(ContactId);

        // Assert
        this._dataProvider.Verify(x => x.GetByContactIdAsync(ContactId), Times.Once);
    }

    [Fact]
    public async Task GetByContactIdAsync_Should_ThrowException_If_ContactId_IsNull() {
        // Arrange
        string ContactId = null;

        // Act
        var result = async () => await this._logicProvider.GetByContactIdAsync(ContactId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByContactIdAsync_Should_ThrowException_If_ContactId_IsEmpty() {
        // Arrange
        var ContactId = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByContactIdAsync(ContactId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetBatchByContactIdAsync_Success() {
        // Arrange
        var contactIds = this._fixture.Create<List<string>>();

        // Act
        await this._logicProvider.GetBatchByContactIdAsync(contactIds);

        // Assert
        this._dataProvider.Verify(x => x.GetBatchByContactIdAsync(contactIds), Times.Once);
    }

    [Fact]
    public async Task GetBatchByContactIdAsync_Should_ThrowException_If_ProjectId_IsNull() {
        // Arrange
        List<string> contactIds = null;

        // Act
        var result = async () => await this._logicProvider.GetBatchByContactIdAsync(contactIds);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetBatchByContactIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var contactIds = this._fixture.Create<List<string>>();
        this._dataProvider.Setup(x => x.GetBatchByContactIdAsync(contactIds)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetBatchByContactIdAsync(contactIds);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    #endregion
}
