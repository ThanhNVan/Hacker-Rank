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

public class PrintOrderControllerUnitTest : BaseControllerUnitTest<PrintOrder, IPrintOrderLogicProvider, PrintOrderController>
{
    #region [ CTor ]
    public PrintOrderControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override PrintOrderController OnGetController(ILogger<PrintOrderController> logger, IPrintOrderLogicProvider logic) {
        return new PrintOrderController(logger, logic);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    // GetByAfasPrintOrderNumberAsync
    [Fact]
    public async Task GetByAfasPrintOrderNumberAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var afasPrintOrderNumber = this._fixture.Create<string>();
        var entity = this._fixture.Create<PrintOrder>();
        this._logic.Setup(x => x.GetByAfasPrintOrderNumberAsync(afasPrintOrderNumber)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByAfasPrintOrderNumberAsync(afasPrintOrderNumber);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByAfasPrintOrderNumberAsync(afasPrintOrderNumber), Times.Once);
    }

    [Fact]
    public async Task GetByAfasPrintOrderNumberAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var afasPrintOrderNumber = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasPrintOrderNumberAsync(afasPrintOrderNumber)).ReturnsAsync(default(PrintOrder));
        // Act
        var actual = await this._controller.GetByAfasPrintOrderNumberAsync(afasPrintOrderNumber);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByAfasPrintOrderNumberAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var afasPrintOrderNumber = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasPrintOrderNumberAsync(afasPrintOrderNumber)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByAfasPrintOrderNumberAsync(afasPrintOrderNumber);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByAfasPrintOrderNumberAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var afasPrintOrderNumber = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasPrintOrderNumberAsync(afasPrintOrderNumber)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByAfasPrintOrderNumberAsync(afasPrintOrderNumber);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByAfasPrintOrderNumberAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var afasPrintOrderNumber = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasPrintOrderNumberAsync(afasPrintOrderNumber)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByAfasPrintOrderNumberAsync(afasPrintOrderNumber) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion

    #region [ Public Methods - Custom - Lists ]
    // GetByProductIdAsync
    [Fact]
    public async Task GetByProductIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var productId = this._fixture.Create<string>();
        var entity = this._fixture.Create<List<PrintOrder>>();
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
        this._logic.Setup(x => x.GetByProductIdAsync(productId)).ReturnsAsync(default(List<PrintOrder>));
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

    // GetByEanAsync
    [Fact]
    public async Task GetByEanAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var ean = this._fixture.Create<string>();
        var entity = this._fixture.Create<List<PrintOrder>>();
        this._logic.Setup(x => x.GetByEanAsync(ean)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByEanAsync(ean);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByEanAsync(ean), Times.Once);
    }

    [Fact]
    public async Task GetByEanAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var ean = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByEanAsync(ean)).ReturnsAsync(default(List<PrintOrder>));
        // Act
        var actual = await this._controller.GetByEanAsync(ean);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetByEanAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var ean = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByEanAsync(ean)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByEanAsync(ean);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByEanAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var ean = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByEanAsync(ean)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByEanAsync(ean);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByEanAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var ean = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByEanAsync(ean)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByEanAsync(ean) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    
    // GetByStatusAsync
    [Fact]
    public async Task GetByStatusAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var status = this._fixture.Create<string>();
        var entity = this._fixture.Create<List<PrintOrder>>();
        this._logic.Setup(x => x.GetByStatusAsync(status)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByStatusAsync(status);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByStatusAsync(status), Times.Once);
    }

    [Fact]
    public async Task GetByStatusAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var status = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByStatusAsync(status)).ReturnsAsync(default(List<PrintOrder>));
        // Act
        var actual = await this._controller.GetByStatusAsync(status);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetByStatusAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var status = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByStatusAsync(status)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByStatusAsync(status);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByStatusAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var status = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByStatusAsync(status)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByStatusAsync(status);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByStatusAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var status = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByStatusAsync(status)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByStatusAsync(status) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    #endregion
}
