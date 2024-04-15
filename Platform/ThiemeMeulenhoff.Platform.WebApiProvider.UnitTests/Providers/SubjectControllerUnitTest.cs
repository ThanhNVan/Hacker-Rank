using System;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform.WebApi;

public class SubjectControllerUnitTest : BaseControllerUnitTest<Subject, ISubjectLogicProvider, SubjectController>
{
    #region [ CTor ]
    public SubjectControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override SubjectController OnGetController(ILogger<SubjectController> logger, ISubjectLogicProvider logic) {
        return new SubjectController(logger, logic);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    // GetBySubjectCodeAsync
    [Fact]
    public async Task GetBySubjectCodeAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var subjectCode = this._fixture.Create<string>();
        var entity = this._fixture.Create<Subject>();
        this._logic.Setup(x => x.GetBySubjectCodeAsync(subjectCode)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetBySubjectCodeAsync(subjectCode);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetBySubjectCodeAsync(subjectCode), Times.Once);
    }

    [Fact]
    public async Task GetBySubjectCodeAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var subjectCode = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetBySubjectCodeAsync(subjectCode)).ReturnsAsync(default(Subject));
        // Act
        var actual = await this._controller.GetBySubjectCodeAsync(subjectCode);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetBySubjectCodeAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var subjectCode = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetBySubjectCodeAsync(subjectCode)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetBySubjectCodeAsync(subjectCode);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetBySubjectCodeAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var subjectCode = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetBySubjectCodeAsync(subjectCode)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetBySubjectCodeAsync(subjectCode);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetBySubjectCodeAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var subjectCode = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetBySubjectCodeAsync(subjectCode)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetBySubjectCodeAsync(subjectCode) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }


    #endregion
}
