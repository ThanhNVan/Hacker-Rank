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

public class LicenseSerieItemControllerUnitTest : BaseControllerUnitTest<LicenseSerieItem, ILicenseSerieItemLogicProvider, LicenseSerieItemController>
{
    #region [ CTor ]
    public LicenseSerieItemControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override LicenseSerieItemController OnGetController(ILogger<LicenseSerieItemController> logger, ILicenseSerieItemLogicProvider logic) {
        return new LicenseSerieItemController(logger, logic);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    // GetByLicenseKey
    [Fact]
    public async Task GetByLicenseKeyAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var orderItemId = this._fixture.Create<string>();
        var entity = this._fixture.Create<LicenseSerieItem>();
        this._logic.Setup(x => x.GetByLicenseKey(orderItemId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByLicenseKeyAsync(orderItemId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByLicenseKey(orderItemId), Times.Once);
    }

    [Fact]
    public async Task GetByLicenseKeyAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var orderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByLicenseKey(orderItemId)).ReturnsAsync(default(LicenseSerieItem));
        // Act
        var actual = await this._controller.GetByLicenseKeyAsync(orderItemId);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByLicenseKeyAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var orderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByLicenseKey(orderItemId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByLicenseKeyAsync(orderItemId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByLicenseKeyAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var orderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByLicenseKey(orderItemId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByLicenseKeyAsync(orderItemId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByLicenseKeyAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var orderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByLicenseKey(orderItemId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByLicenseKeyAsync(orderItemId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion

    #region [ Public Methods - Custom - List ]
    // GetByLicenseSerieId
    [Fact]
    public async Task GetByLicenseSerieId_Should_ReturnOk_If_Success() {
        // Arrange
        var licenseSerieId = this._fixture.Create<string>();
        var entity = this._fixture.Create<List<LicenseSerieItem>>();
        this._logic.Setup(x => x.GetByLicenseSerieId(licenseSerieId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByLicenseSerieIdAsync(licenseSerieId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByLicenseSerieId(licenseSerieId), Times.Once);
    }

    [Fact]
    public async Task GetByLicenseSerieId_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var licenseSerieId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByLicenseSerieId(licenseSerieId)).ReturnsAsync(default(List<LicenseSerieItem>));
        // Act
        var actual = await this._controller.GetByLicenseSerieIdAsync(licenseSerieId);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByLicenseSerieId_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var licenseSerieId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByLicenseSerieId(licenseSerieId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByLicenseSerieIdAsync(licenseSerieId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByLicenseSerieId_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var licenseSerieId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByLicenseSerieId(licenseSerieId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByLicenseSerieIdAsync(licenseSerieId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByLicenseSerieId_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var licenseSerieId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByLicenseSerieId(licenseSerieId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByLicenseSerieIdAsync(licenseSerieId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion
}
