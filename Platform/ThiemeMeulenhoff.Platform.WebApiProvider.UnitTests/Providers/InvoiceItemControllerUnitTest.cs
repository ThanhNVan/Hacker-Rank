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

public class InvoiceItemControllerUnitTest : BaseControllerUnitTest<InvoiceItem, IInvoiceItemLogicProvider, InvoiceItemController>
{
    #region [ CTor ]
    public InvoiceItemControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override InvoiceItemController OnGetController(ILogger<InvoiceItemController> logger, IInvoiceItemLogicProvider logic) {
        return new InvoiceItemController(logger, logic);
    }
    #endregion

    #region [ Public Methods - Custom - Lists ]
    // GetByInvoiceIdAsync
    [Fact]
    public async Task GetByInvoiceIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var invoiceId = this._fixture.Create<string>();
        var entity = this._fixture.Create<List<InvoiceItem>>();
        this._logic.Setup(x => x.GetByInvoiceIdAsync(invoiceId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByInvoiceIdAsync(invoiceId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByInvoiceIdAsync(invoiceId), Times.Once);
    }

    [Fact]
    public async Task GetByInvoiceIdAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var invoiceId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByInvoiceIdAsync(invoiceId)).ReturnsAsync(default(List<InvoiceItem>));
        // Act
        var actual = await this._controller.GetByInvoiceIdAsync(invoiceId);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetByInvoiceIdAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var invoiceId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByInvoiceIdAsync(invoiceId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByInvoiceIdAsync(invoiceId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByInvoiceIdAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var invoiceId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByInvoiceIdAsync(invoiceId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByInvoiceIdAsync(invoiceId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByInvoiceIdAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var invoiceId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByInvoiceIdAsync(invoiceId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByInvoiceIdAsync(invoiceId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetByProductIdAsync
    [Fact]
    public async Task GetByProductIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var productId = this._fixture.Create<string>();
        var entityList = this._fixture.Create<List<InvoiceItem>>();
        this._logic.Setup(x => x.GetByProductIdAsync(productId)).ReturnsAsync(entityList);
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
        this._logic.Setup(x => x.GetByProductIdAsync(productId)).ReturnsAsync(default(List<InvoiceItem>));
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

    // GetByOrderItemIdAsync
    [Fact]
    public async Task GetByOrderItemIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var orderItemId = this._fixture.Create<string>();
        var entity = this._fixture.Create<List<InvoiceItem>>();
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
        this._logic.Setup(x => x.GetByOrderItemIdAsync(orderItemId)).ReturnsAsync(default(List<InvoiceItem>));
        // Act
        var actual = await this._controller.GetByOrderItemIdAsync(orderItemId);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
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
    #endregion
}
