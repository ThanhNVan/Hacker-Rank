using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform.WebApi;

public class ProjectControllerUnitTest : BaseControllerUnitTest<Project, IProjectLogicProvider, ProjectController>
{
    #region [ CTor ]
    public ProjectControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override ProjectController OnGetController(ILogger<ProjectController> logger, IProjectLogicProvider logic) {
        return new ProjectController(logger, logic);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    // GetByProjectNameAsync
    [Fact]
    public async Task GetByProjectNameAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var projectName = this._fixture.Create<string>();
        var entity = this._fixture.Create<Project>();
        this._logic.Setup(x => x.GetByProjectNameAsync(projectName)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByProjectNameAsync(projectName);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByProjectNameAsync(projectName), Times.Once);
    }

    [Fact]
    public async Task GetByProjectNameAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var projectName = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByProjectNameAsync(projectName)).ReturnsAsync(default(Project));
        // Act
        var actual = await this._controller.GetByProjectNameAsync(projectName);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByProjectNameAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var projectName = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByProjectNameAsync(projectName)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByProjectNameAsync(projectName);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByProjectNameAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var projectName = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByProjectNameAsync(projectName)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByProjectNameAsync(projectName);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByProjectNameAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var projectName = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByProjectNameAsync(projectName)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByProjectNameAsync(projectName) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetByProjectNumberAsync
    [Fact]
    public async Task GetByProjectNumberAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var projectNumber = this._fixture.Create<int>();
        var entity = this._fixture.Create<Project>();
        this._logic.Setup(x => x.GetByProjectNumberAsync(projectNumber)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByProjectNumberAsync(projectNumber);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByProjectNumberAsync(projectNumber), Times.Once);
    }

    [Fact]
    public async Task GetByProjectNumberAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var projectNumber = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetByProjectNumberAsync(projectNumber)).ReturnsAsync(default(Project));
        // Act
        var actual = await this._controller.GetByProjectNumberAsync(projectNumber);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByProjectNumberAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var projectNumber = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetByProjectNumberAsync(projectNumber)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByProjectNumberAsync(projectNumber);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByProjectNumberAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var projectNumber = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetByProjectNumberAsync(projectNumber)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByProjectNumberAsync(projectNumber);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByProjectNumberAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var projectNumber = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetByProjectNumberAsync(projectNumber)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByProjectNumberAsync(projectNumber) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion

    #region [ Public Methods - Custom - List ]
    // GetBySubjectIdIdAsync
    [Fact]
    public async Task GetBySubjectIdIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var subjectId = this._fixture.Create<string>();
        var entity = this._fixture.Create<List<Project>>();
        this._logic.Setup(x => x.GetBySubjectIdIdAsync(subjectId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetBySubjectIdIdAsync(subjectId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetBySubjectIdIdAsync(subjectId), Times.Once);
    }

    [Fact]
    public async Task GetBySubjectIdIdAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var subjectId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetBySubjectIdIdAsync(subjectId)).ReturnsAsync(default(List<Project>));
        // Act
        var actual = await this._controller.GetBySubjectIdIdAsync(subjectId);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetBySubjectIdIdAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var subjectId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetBySubjectIdIdAsync(subjectId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetBySubjectIdIdAsync(subjectId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetBySubjectIdIdAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var subjectId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetBySubjectIdIdAsync(subjectId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetBySubjectIdIdAsync(subjectId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetBySubjectIdIdAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var subjectId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetBySubjectIdIdAsync(subjectId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetBySubjectIdIdAsync(subjectId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetBatchBySubjectIdAsync
    [Fact]
    public async Task GetBatchBySubjectIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var productId = this._fixture.Create<List<string>>();
        var entity = this._fixture.Create<List<Project>>();
        this._logic.Setup(x => x.GetBatchBySubjectIdAsync(productId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetBatchBySubjectIdAsync(productId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetBatchBySubjectIdAsync(productId), Times.Once);
    }

    [Fact]
    public async Task GetBatchBySubjectIdAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var productId = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetBatchBySubjectIdAsync(productId)).ReturnsAsync(default(List<Project>));
        // Act
        var actual = await this._controller.GetBatchBySubjectIdAsync(productId);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetBatchBySubjectIdAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var productId = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetBatchBySubjectIdAsync(productId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetBatchBySubjectIdAsync(productId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetBatchBySubjectIdAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var productId = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetBatchBySubjectIdAsync(productId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetBatchBySubjectIdAsync(productId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetBatchBySubjectIdAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var productId = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetBatchBySubjectIdAsync(productId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetBatchBySubjectIdAsync(productId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion
}
