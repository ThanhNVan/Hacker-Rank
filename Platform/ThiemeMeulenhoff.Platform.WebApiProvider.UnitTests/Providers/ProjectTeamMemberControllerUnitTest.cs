using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ThiemeMeulenhoff.Platform.WebApi;

public class ProjectTeamMemberControllerUnitTest : BaseControllerUnitTest<ProjectTeamMember, IProjectTeamMemberLogicProvider, ProjectTeamMemberController>
{
    #region [ CTor ]
    public ProjectTeamMemberControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override ProjectTeamMemberController OnGetController(ILogger<ProjectTeamMemberController> logger, IProjectTeamMemberLogicProvider logic) {
        return new ProjectTeamMemberController(logger, logic);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    // GetByProjectIdAndContactIdAsync
    [Fact]
    public async Task GetByProjectIdAndContactIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var projectId = this._fixture.Create<string>();
        var contactId = this._fixture.Create<string>();
        var entity = this._fixture.Create<ProjectTeamMember>();
        this._logic.Setup(x => x.GetByProjectIdAndContactIdAsync(projectId, contactId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByProjectIdAndContactIdAsync(projectId, contactId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByProjectIdAndContactIdAsync(projectId, contactId), Times.Once);
    }

    [Fact]
    public async Task GetByProjectIdAndContactIdAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var projectId = this._fixture.Create<string>();
        var contactId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByProjectIdAndContactIdAsync(projectId, contactId)).ReturnsAsync(default(ProjectTeamMember));
        // Act
        var actual = await this._controller.GetByProjectIdAndContactIdAsync(projectId, contactId);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByProjectIdAndContactIdAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var projectId = this._fixture.Create<string>();
        var contactId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByProjectIdAndContactIdAsync(projectId, contactId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByProjectIdAndContactIdAsync(projectId, contactId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByProjectIdAndContactIdAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var projectId = this._fixture.Create<string>();
        var contactId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByProjectIdAndContactIdAsync(projectId, contactId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByProjectIdAndContactIdAsync(projectId, contactId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByProjectIdAndContactIdAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var projectId = this._fixture.Create<string>();
        var contactId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByProjectIdAndContactIdAsync(projectId, contactId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByProjectIdAndContactIdAsync(projectId, contactId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion

    #region [ Public Methods - Custom - List ]
    // GetByProjectIdAsync
    [Fact]
    public async Task GetByProjectIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var projectId = this._fixture.Create<string>();
        var entity = this._fixture.Create<List<ProjectTeamMember>>();
        this._logic.Setup(x => x.GetByProjectIdAsync(projectId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByProjectIdAsync(projectId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByProjectIdAsync(projectId), Times.Once);
    }

    [Fact]
    public async Task GetByProjectIdAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var projectId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByProjectIdAsync(projectId)).ReturnsAsync(default(List<ProjectTeamMember>));
        // Act
        var actual = await this._controller.GetByProjectIdAsync(projectId);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByProjectIdAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var projectId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByProjectIdAsync(projectId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByProjectIdAsync(projectId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByProjectIdAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var projectId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByProjectIdAsync(projectId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByProjectIdAsync(projectId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByProjectIdAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var projectId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByProjectIdAsync(projectId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByProjectIdAsync(projectId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    
    // GetByContactIdAsync
    [Fact]
    public async Task GetByContactIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var contactId = this._fixture.Create<string>();
        var entity = this._fixture.Create<List<ProjectTeamMember>>();
        this._logic.Setup(x => x.GetByContactIdAsync(contactId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByContactIdAsync(contactId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByContactIdAsync(contactId), Times.Once);
    }

    [Fact]
    public async Task GetByContactIdAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var contactId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByContactIdAsync(contactId)).ReturnsAsync(default(List<ProjectTeamMember>));
        // Act
        var actual = await this._controller.GetByContactIdAsync(contactId);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByContactIdAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var contactId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByContactIdAsync(contactId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByContactIdAsync(contactId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByContactIdAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var contactId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByContactIdAsync(contactId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByContactIdAsync(contactId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByContactIdAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var contactId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByContactIdAsync(contactId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByContactIdAsync(contactId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    
    
    // GetBatchByContactIdAsync
    [Fact]
    public async Task GetBatchByContactIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var contactId = this._fixture.Create<List<string>>();
        var entity = this._fixture.Create<List<ProjectTeamMember>>();
        this._logic.Setup(x => x.GetBatchByContactIdAsync(contactId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetBatchByContactIdAsync(contactId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetBatchByContactIdAsync(contactId), Times.Once);
    }

    [Fact]
    public async Task GetBatchByContactIdAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var contactId = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetBatchByContactIdAsync(contactId)).ReturnsAsync(default(List<ProjectTeamMember>));
        // Act
        var actual = await this._controller.GetBatchByContactIdAsync(contactId);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetBatchByContactIdAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var contactId = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetBatchByContactIdAsync(contactId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetBatchByContactIdAsync(contactId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetBatchByContactIdAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var contactId = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetBatchByContactIdAsync(contactId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetBatchByContactIdAsync(contactId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetBatchByContactIdAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var contactId = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetBatchByContactIdAsync(contactId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetBatchByContactIdAsync(contactId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion
}
