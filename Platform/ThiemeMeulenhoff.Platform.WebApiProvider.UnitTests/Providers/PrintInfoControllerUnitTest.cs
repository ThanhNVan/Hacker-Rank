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

public class PrintInfoControllerUnitTest : BaseControllerUnitTest<PrintInfo, IPrintInfoLogicProvider, PrintInfoController>
{
    #region [ CTor ]
    public PrintInfoControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override PrintInfoController OnGetController(ILogger<PrintInfoController> logger, IPrintInfoLogicProvider logic) {
        return new PrintInfoController(logger, logic);
    }
    #endregion

    #region [ Public Methods - Custom - List ]
    // GetByProductIdAsync
    [Fact]
    public async Task GetByProductIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var productId = this._fixture.Create<string>();
        var entity = this._fixture.Create<List<PrintInfo>>();
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
        this._logic.Setup(x => x.GetByProductIdAsync(productId)).ReturnsAsync(default(List<PrintInfo>));
        // Act
        var actual = await this._controller.GetByProductIdAsync(productId);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
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
