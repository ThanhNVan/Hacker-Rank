using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;
using Moq;
using ThiemeMeulenhoff.Platform.WebApi;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ThiemeMeulenhoff.Platform.WebApi;

public class OrderControllerUnitTest : BaseControllerUnitTest<Order, IOrderLogicProvider, OrderController>
{
    #region [ CTor ]
    public OrderControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override]
    protected override OrderController OnGetController(ILogger<OrderController> logger, IOrderLogicProvider logic) {
        return new OrderController(logger, logic);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    // GetByAfasOrderIdAsync
    [Fact]
    public async Task GetByAfasOrderIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var afasOrderItemId = this._fixture.Create<string>();
        var entity = this._fixture.Create<Order>();
        this._logic.Setup(x => x.GetByAfasOrderIdAsync(afasOrderItemId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByAfasOrderIdAsync(afasOrderItemId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByAfasOrderIdAsync(afasOrderItemId), Times.Once);
    }

    [Fact]
    public async Task GetByAfasOrderIdAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var afasOrderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasOrderIdAsync(afasOrderItemId)).ReturnsAsync(default(Order));
        // Act
        var actual = await this._controller.GetByAfasOrderIdAsync(afasOrderItemId);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByAfasOrderIdAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var afasOrderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasOrderIdAsync(afasOrderItemId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByAfasOrderIdAsync(afasOrderItemId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByAfasOrderIdAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var afasOrderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasOrderIdAsync(afasOrderItemId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByAfasOrderIdAsync(afasOrderItemId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByAfasOrderIdAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var afasOrderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasOrderIdAsync(afasOrderItemId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByAfasOrderIdAsync(afasOrderItemId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    
    // GetByPropellerOrderReferenceIdAsync
    [Fact]
    public async Task GetByPropellerOrderReferenceIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var propellerOrderReferenceId = this._fixture.Create<string>();
        var entity = this._fixture.Create<Order>();
        this._logic.Setup(x => x.GetByPropellerOrderReferenceIdAsync(propellerOrderReferenceId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByPropellerOrderReferenceIdAsync(propellerOrderReferenceId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByPropellerOrderReferenceIdAsync(propellerOrderReferenceId), Times.Once);
    }

    [Fact]
    public async Task GetByPropellerOrderReferenceIdAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var propellerOrderReferenceId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByPropellerOrderReferenceIdAsync(propellerOrderReferenceId)).ReturnsAsync(default(Order));
        // Act
        var actual = await this._controller.GetByPropellerOrderReferenceIdAsync(propellerOrderReferenceId);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByPropellerOrderReferenceIdAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var propellerOrderReferenceId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByPropellerOrderReferenceIdAsync(propellerOrderReferenceId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByPropellerOrderReferenceIdAsync(propellerOrderReferenceId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByPropellerOrderReferenceIdAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var propellerOrderReferenceId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByPropellerOrderReferenceIdAsync(propellerOrderReferenceId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByPropellerOrderReferenceIdAsync(propellerOrderReferenceId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByPropellerOrderReferenceIdAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var propellerOrderReferenceId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByPropellerOrderReferenceIdAsync(propellerOrderReferenceId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByPropellerOrderReferenceIdAsync(propellerOrderReferenceId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    #endregion

    #region [ Public Methods - Custom - List ]
    // GetByContactAsync
    [Fact]
    public async Task GetByContactAsync_Should_ReturnOk_Success() {
        // Arrange
        var contact = this._fixture.Create<string>();
        var result = this._fixture.Create<List<Order>>();
        this._logic.Setup(x => x.GetByContactAsync(contact)).ReturnsAsync(result);

        // Act
        var actual = await this._controller.GetByContactAsync(contact);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
    }

    [Fact]
    public async Task GetByContactAsync_Should_ReturnNotFound_If_Empty() {
        // Arrange
        var contact = this._fixture.Create<string>();
        var result = default(List<Order>);
        this._logic.Setup(x => x.GetByContactAsync(contact)).ReturnsAsync(result);

        // Act
        var actual = await this._controller.GetByContactAsync(contact);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByContactAsync_Should_ReturnInternalServerError_If_Error() {
        // Arrange
        var contact = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByContactAsync(contact)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByContactAsync(contact) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    [Fact]
    public async Task GetByContactAsync_Should_ReturnBadRequest_If_NotValidParam() {
        // Arrange
        var contact = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByContactAsync(contact)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByContactAsync(contact);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByContactAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var contact = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByContactAsync(contact)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByContactAsync(contact);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    // GetByCbOrderTypeAsync
    [Fact]
    public async Task GetByCbOrderTypeAsync_Should_ReturnOk_Success() {
        // Arrange
        var cbOrderType = this._fixture.Create<string>();
        var result = this._fixture.Create<List<Order>>();
        this._logic.Setup(x => x.GetByCbOrderTypeAsync(cbOrderType)).ReturnsAsync(result);

        // Act
        var actual = await this._controller.GetByCbOrderTypeAsync(cbOrderType);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
    }

    [Fact]
    public async Task GetByCbOrderTypeAsync_Should_ReturnNotFound_If_Empty() {
        // Arrange
        var cbOrderType = this._fixture.Create<string>();
        var result = default(List<Order>);
        this._logic.Setup(x => x.GetByCbOrderTypeAsync(cbOrderType)).ReturnsAsync(result);

        // Act
        var actual = await this._controller.GetByCbOrderTypeAsync(cbOrderType);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByCbOrderTypeAsync_Should_ReturnInternalServerError_If_Error() {
        // Arrange
        var cbOrderType = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByCbOrderTypeAsync(cbOrderType)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByCbOrderTypeAsync(cbOrderType) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    [Fact]
    public async Task GetByCbOrderTypeAsync_Should_ReturnBadRequest_If_NotValidParam() {
        // Arrange
        var cbOrderType = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByCbOrderTypeAsync(cbOrderType)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByCbOrderTypeAsync(cbOrderType);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByCbOrderTypeAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var cbOrderType = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByCbOrderTypeAsync(cbOrderType)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByCbOrderTypeAsync(cbOrderType);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    // GetChangesForCentraalBoekhuisAsync
    [Fact]
    public async Task GetChangesForCentraalBoekhuisAsync_Should_ReturnOk_Success() {
        // Arrange
        var cbOrderType = this._fixture.Create<string>();
        var date = this._fixture.Create<DateTime>();
        var result = this._fixture.Create<List<Order>>();
        this._logic.Setup(x => x.GetChangesForCentraalBoekhuisAsync(date, cbOrderType)).ReturnsAsync(result);

        // Act
        var actual = await this._controller.GetChangesForCentraalBoekhuisAsync(date, cbOrderType);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
    }

    [Fact]
    public async Task GetChangesForCentraalBoekhuisAsync_Should_ReturnNotFound_If_Empty() {
        // Arrange
        var cbOrderType = this._fixture.Create<string>();
        var date = this._fixture.Create<DateTime>();
        var result = default(List<Order>);
        this._logic.Setup(x => x.GetChangesForCentraalBoekhuisAsync(date, cbOrderType)).ReturnsAsync(result);

        // Act
        var actual = await this._controller.GetChangesForCentraalBoekhuisAsync(date, cbOrderType);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetChangesForCentraalBoekhuisAsync_Should_ReturnInternalServerError_If_Error() {
        // Arrange
        var cbOrderType = this._fixture.Create<string>();
        var date = this._fixture.Create<DateTime>();
        this._logic.Setup(x => x.GetChangesForCentraalBoekhuisAsync(date, cbOrderType)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetChangesForCentraalBoekhuisAsync(date, cbOrderType) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    [Fact]
    public async Task GetChangesForCentraalBoekhuisAsync_Should_ReturnBadRequest_If_NotValidParam() {
        // Arrange
        var cbOrderType = this._fixture.Create<string>();
        var date = this._fixture.Create<DateTime>();
        this._logic.Setup(x => x.GetChangesForCentraalBoekhuisAsync(date, cbOrderType)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetChangesForCentraalBoekhuisAsync(date, cbOrderType);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetChangesForCentraalBoekhuisAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var cbOrderType = this._fixture.Create<string>();
        var date = this._fixture.Create<DateTime>();
        this._logic.Setup(x => x.GetChangesForCentraalBoekhuisAsync(date, cbOrderType)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetChangesForCentraalBoekhuisAsync(date, cbOrderType);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }
    #endregion
}
