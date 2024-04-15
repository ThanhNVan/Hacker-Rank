using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using System.Threading.Tasks;

namespace ThiemeMeulenhoff.Platform.WebApi;

public class PriceInfoControllerUnitTest : BaseControllerUnitTest<PriceInfo, IPriceInfoLogicProvider, PriceInfoController>
{
    #region [ CTor ]
    public PriceInfoControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override PriceInfoController OnGetController(ILogger<PriceInfoController> logger, IPriceInfoLogicProvider logic) {
        return new PriceInfoController(logger, logic);
    }
    #endregion

    #region [ Public Methods - Cutom - Single ]
    // GetByProductIdAsync
    [Fact]
    public async Task GetByProductIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var productId = this._fixture.Create<string>();
        var entity = this._fixture.Create<PriceInfo>();
        this._logic.Setup(x => x.GetByProductIdAsync(productId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByProductIdAsync(productId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByProductIdAsync(productId), Times.Once);
    }

    [Fact]
    public async Task GetByProductIdAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var productId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByProductIdAsync(productId)).ReturnsAsync(default(PriceInfo));
        // Act
        var actual = await this._controller.GetByProductIdAsync(productId);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByProductIdAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var productId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByProductIdAsync(productId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByProductIdAsync(productId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByProductIdAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var productId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByProductIdAsync(productId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByProductIdAsync(productId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByProductIdAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var productId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByProductIdAsync(productId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByProductIdAsync(productId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion
}
