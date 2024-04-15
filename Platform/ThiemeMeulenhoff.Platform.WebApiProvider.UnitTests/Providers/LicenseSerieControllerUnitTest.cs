using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using System.Threading.Tasks;

namespace ThiemeMeulenhoff.Platform.WebApi;

public class LicenseSerieControllerUnitTest : BaseControllerUnitTest<LicenseSerie, ILicenseSerieLogicProvider, LicenseSerieController>
{
    #region [ CTor ]
    public LicenseSerieControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override LicenseSerieController OnGetController(ILogger<LicenseSerieController> logger, ILicenseSerieLogicProvider logic) {
        return new LicenseSerieController(logger, logic);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    // GetByOrderItemIdAsync
    [Fact]
    public async Task GetByOrderItemIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var orderItemId = this._fixture.Create<string>();
        var entity = this._fixture.Create<LicenseSerie>();
        this._logic.Setup(x => x.GetByOrderItemIdAsync(orderItemId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByOrderItemIdAsync(orderItemId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByOrderItemIdAsync(orderItemId), Times.Once);
    }

    [Fact]
    public async Task GetByOrderItemIdAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var orderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOrderItemIdAsync(orderItemId)).ReturnsAsync(default(LicenseSerie));
        // Act
        var actual = await this._controller.GetByOrderItemIdAsync(orderItemId);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByOrderItemIdAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var orderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOrderItemIdAsync(orderItemId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByOrderItemIdAsync(orderItemId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByOrderItemIdAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var orderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOrderItemIdAsync(orderItemId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByOrderItemIdAsync(orderItemId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByOrderItemIdAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var orderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOrderItemIdAsync(orderItemId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByOrderItemIdAsync(orderItemId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    
    // GetByAfasOrderItemIdAsync
    [Fact]
    public async Task GetByAfasOrderItemIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var AfasOrderItemId = this._fixture.Create<string>();
        var entity = this._fixture.Create<LicenseSerie>();
        this._logic.Setup(x => x.GetByAfasOrderItemIdAsync(AfasOrderItemId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByAfasOrderItemIdAsync(AfasOrderItemId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByAfasOrderItemIdAsync(AfasOrderItemId), Times.Once);
    }

    [Fact]
    public async Task GetByAfasOrderItemIdAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var AfasOrderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasOrderItemIdAsync(AfasOrderItemId)).ReturnsAsync(default(LicenseSerie));
        // Act
        var actual = await this._controller.GetByAfasOrderItemIdAsync(AfasOrderItemId);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByAfasOrderItemIdAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var AfasOrderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasOrderItemIdAsync(AfasOrderItemId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByAfasOrderItemIdAsync(AfasOrderItemId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByAfasOrderItemIdAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var AfasOrderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasOrderItemIdAsync(AfasOrderItemId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByAfasOrderItemIdAsync(AfasOrderItemId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByAfasOrderItemIdAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var AfasOrderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasOrderItemIdAsync(AfasOrderItemId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByAfasOrderItemIdAsync(AfasOrderItemId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion
}
