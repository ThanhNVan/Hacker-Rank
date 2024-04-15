using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using System.Threading.Tasks;

namespace ThiemeMeulenhoff.Platform.WebApi;

public class SchoolControllerUnitTest : BaseControllerUnitTest<School, ISchoolLogicProvider, SchoolController>
{
    #region [ CTor ]
    public SchoolControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override SchoolController OnGetController(ILogger<SchoolController> logger, ISchoolLogicProvider logic) {
        return new SchoolController(logger, logic);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    // GetByAfasContactNumberAsync
    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var afasContactNumber = this._fixture.Create<string>();
        var entity = this._fixture.Create<School>();
        this._logic.Setup(x => x.GetByAfasContactNumberAsync(afasContactNumber)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByAfasContactNumberAsync(afasContactNumber);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByAfasContactNumberAsync(afasContactNumber), Times.Once);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var afasContactNumber = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasContactNumberAsync(afasContactNumber)).ReturnsAsync(default(School));
        // Act
        var actual = await this._controller.GetByAfasContactNumberAsync(afasContactNumber);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var afasContactNumber = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasContactNumberAsync(afasContactNumber)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByAfasContactNumberAsync(afasContactNumber);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var afasContactNumber = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasContactNumberAsync(afasContactNumber)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByAfasContactNumberAsync(afasContactNumber);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var afasContactNumber = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasContactNumberAsync(afasContactNumber)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByAfasContactNumberAsync(afasContactNumber) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetBySchoolBoardNumberAsync
    [Fact]
    public async Task GetBySchoolBoardNumberAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var schoolBoardNumber = this._fixture.Create<string>();
        var entity = this._fixture.Create<School>();
        this._logic.Setup(x => x.GetBySchoolBoardNumberAsync(schoolBoardNumber)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetBySchoolBoardNumberAsync(schoolBoardNumber);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetBySchoolBoardNumberAsync(schoolBoardNumber), Times.Once);
    }

    [Fact]
    public async Task GetBySchoolBoardNumberAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var schoolBoardNumber = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetBySchoolBoardNumberAsync(schoolBoardNumber)).ReturnsAsync(default(School));
        // Act
        var actual = await this._controller.GetBySchoolBoardNumberAsync(schoolBoardNumber);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetBySchoolBoardNumberAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var schoolBoardNumber = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetBySchoolBoardNumberAsync(schoolBoardNumber)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetBySchoolBoardNumberAsync(schoolBoardNumber);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetBySchoolBoardNumberAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var schoolBoardNumber = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetBySchoolBoardNumberAsync(schoolBoardNumber)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetBySchoolBoardNumberAsync(schoolBoardNumber);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetBySchoolBoardNumberAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var schoolBoardNumber = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetBySchoolBoardNumberAsync(schoolBoardNumber)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetBySchoolBoardNumberAsync(schoolBoardNumber) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    
    // GetByBrinCodeAsync
    [Fact]
    public async Task GetByBrinCodeAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var brinCode = this._fixture.Create<string>();
        var entity = this._fixture.Create<School>();
        this._logic.Setup(x => x.GetByBrinCodeAsync(brinCode)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByBrinCodeAsync(brinCode);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByBrinCodeAsync(brinCode), Times.Once);
    }

    [Fact]
    public async Task GetByBrinCodeAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var brinCode = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByBrinCodeAsync(brinCode)).ReturnsAsync(default(School));
        // Act
        var actual = await this._controller.GetByBrinCodeAsync(brinCode);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByBrinCodeAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var brinCode = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByBrinCodeAsync(brinCode)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByBrinCodeAsync(brinCode);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByBrinCodeAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var brinCode = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByBrinCodeAsync(brinCode)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByBrinCodeAsync(brinCode);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByBrinCodeAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var brinCode = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByBrinCodeAsync(brinCode)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByBrinCodeAsync(brinCode) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    
    // GetByBranchNumberAsync
    [Fact]
    public async Task GetByBranchNumberAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var branchNumber = this._fixture.Create<string>();
        var entity = this._fixture.Create<School>();
        this._logic.Setup(x => x.GetByBranchNumberAsync(branchNumber)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByBranchNumberAsync(branchNumber);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByBranchNumberAsync(branchNumber), Times.Once);
    }

    [Fact]
    public async Task GetByBranchNumberAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var branchNumber = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByBranchNumberAsync(branchNumber)).ReturnsAsync(default(School));
        // Act
        var actual = await this._controller.GetByBranchNumberAsync(branchNumber);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByBranchNumberAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var branchNumber = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByBranchNumberAsync(branchNumber)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByBranchNumberAsync(branchNumber);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByBranchNumberAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var branchNumber = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByBranchNumberAsync(branchNumber)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByBranchNumberAsync(branchNumber);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByBranchNumberAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var branchNumber = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByBranchNumberAsync(branchNumber)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByBranchNumberAsync(branchNumber) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    
    // GetByAssuNumberAsync
    [Fact]
    public async Task GetByAssuNumberAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var assuNumber = this._fixture.Create<int>();
        var entity = this._fixture.Create<School>();
        this._logic.Setup(x => x.GetByAssuNumberAsync(assuNumber)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByAssuNumberAsync(assuNumber);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByAssuNumberAsync(assuNumber), Times.Once);
    }

    [Fact]
    public async Task GetByAssuNumberAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var assuNumber = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetByAssuNumberAsync(assuNumber)).ReturnsAsync(default(School));
        // Act
        var actual = await this._controller.GetByAssuNumberAsync(assuNumber);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByAssuNumberAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var assuNumber = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetByAssuNumberAsync(assuNumber)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByAssuNumberAsync(assuNumber);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByAssuNumberAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var assuNumber = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetByAssuNumberAsync(assuNumber)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByAssuNumberAsync(assuNumber);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByAssuNumberAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var assuNumber = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetByAssuNumberAsync(assuNumber)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByAssuNumberAsync(assuNumber) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    
    // GetByAssuNumberTempAsync
    [Fact]
    public async Task GetByAssuNumberTempAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var assuNumberTemp = this._fixture.Create<int>();
        var entity = this._fixture.Create<School>();
        this._logic.Setup(x => x.GetByAssuNumberTempAsync(assuNumberTemp)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByAssuNumberTempAsync(assuNumberTemp);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByAssuNumberTempAsync(assuNumberTemp), Times.Once);
    }

    [Fact]
    public async Task GetByAssuNumberTempAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var assuNumberTemp = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetByAssuNumberTempAsync(assuNumberTemp)).ReturnsAsync(default(School));
        // Act
        var actual = await this._controller.GetByAssuNumberTempAsync(assuNumberTemp);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByAssuNumberTempAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var assuNumberTemp = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetByAssuNumberTempAsync(assuNumberTemp)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByAssuNumberTempAsync(assuNumberTemp);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByAssuNumberTempAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var assuNumberTemp = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetByAssuNumberTempAsync(assuNumberTemp)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByAssuNumberTempAsync(assuNumberTemp);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByAssuNumberTempAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var assuNumberTemp = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetByAssuNumberTempAsync(assuNumberTemp)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByAssuNumberTempAsync(assuNumberTemp) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    #endregion
}
