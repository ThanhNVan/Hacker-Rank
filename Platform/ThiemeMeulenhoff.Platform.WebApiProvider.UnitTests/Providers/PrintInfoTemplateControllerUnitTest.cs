using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using System.Threading.Tasks;

namespace ThiemeMeulenhoff.Platform.WebApi;

public class PrintInfoTemplateControllerUnitTest : BaseControllerUnitTest<PrintInfoTemplate, IPrintInfoTemplateLogicProvider, PrintInfoTemplateController>
{
    #region [ CTor ]
    public PrintInfoTemplateControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override PrintInfoTemplateController OnGetController(ILogger<PrintInfoTemplateController> logger, IPrintInfoTemplateLogicProvider logic) {
        return new PrintInfoTemplateController(logger, logic);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    // GetByNameAsync
    [Fact]
    public async Task GetByNameAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var orderItemId = this._fixture.Create<string>();
        var entity = this._fixture.Create<PrintInfoTemplate>();
        this._logic.Setup(x => x.GetByNameAsync(orderItemId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByNameAsync(orderItemId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByNameAsync(orderItemId), Times.Once);
    }

    [Fact]
    public async Task GetByNameAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var orderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByNameAsync(orderItemId)).ReturnsAsync(default(PrintInfoTemplate));
        // Act
        var actual = await this._controller.GetByNameAsync(orderItemId);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetByNameAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var orderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByNameAsync(orderItemId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByNameAsync(orderItemId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByNameAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var orderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByNameAsync(orderItemId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByNameAsync(orderItemId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByNameAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var orderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByNameAsync(orderItemId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByNameAsync(orderItemId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion
}
