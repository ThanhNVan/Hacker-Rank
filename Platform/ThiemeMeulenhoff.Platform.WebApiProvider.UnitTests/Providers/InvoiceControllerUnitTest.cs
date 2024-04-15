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

public class InvoiceControllerUnitTest : BaseControllerUnitTest<Invoice, IInvoiceLogicProvider, InvoiceController>
{
    #region [ CTor ]
    public InvoiceControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override InvoiceController OnGetController(ILogger<InvoiceController> logger, IInvoiceLogicProvider logic) {
        return new InvoiceController(logger, logic);
    }
    #endregion

    #region [ Public Methods - Custom - Lists ]
    // GetByOrderIdAsync
    [Fact]
    public async Task GetByOrderIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var orderId = this._fixture.Create<string>();
        var entity = this._fixture.Create<List<Invoice>>();
        this._logic.Setup(x => x.GetByOrderIdAsync(orderId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByOrderIdAsync(orderId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByOrderIdAsync(orderId), Times.Once);
    }

    [Fact]
    public async Task GetByOrderIdAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var orderId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOrderIdAsync(orderId)).ReturnsAsync(default(List<Invoice>));
        // Act
        var actual = await this._controller.GetByOrderIdAsync(orderId);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetByOrderIdAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var orderId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOrderIdAsync(orderId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByOrderIdAsync(orderId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByOrderIdAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var orderId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOrderIdAsync(orderId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByOrderIdAsync(orderId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByOrderIdAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var orderId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOrderIdAsync(orderId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByOrderIdAsync(orderId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetByContactIdAsync
    [Fact]
    public async Task GetByContactIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var contactId = this._fixture.Create<string>();
        var entity = this._fixture.Create<List<Invoice>>();
        this._logic.Setup(x => x.GetByContactIdAsync(contactId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByContactIdAsync(contactId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByContactIdAsync(contactId), Times.Once);
    }

    [Fact]
    public async Task GetByContactIdAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var contactId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByContactIdAsync(contactId)).ReturnsAsync(default(List<Invoice>));
        // Act
        var actual = await this._controller.GetByContactIdAsync(contactId);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetByContactIdAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var contactId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByContactIdAsync(contactId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByContactIdAsync(contactId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByContactIdAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var contactId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByContactIdAsync(contactId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByContactIdAsync(contactId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByContactIdAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var contactId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByContactIdAsync(contactId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByContactIdAsync(contactId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion
}
