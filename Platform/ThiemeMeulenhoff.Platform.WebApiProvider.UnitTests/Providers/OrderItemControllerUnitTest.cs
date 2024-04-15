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

public class OrderItemControllerUnitTest : BaseControllerUnitTest<OrderItem, IOrderItemLogicProvider, OrderItemController>
{
    #region [ CTor ]
    public OrderItemControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override]
    protected override OrderItemController OnGetController(ILogger<OrderItemController> logger, IOrderItemLogicProvider logic) {
        return new OrderItemController(logger, logic);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    // GetByAfasOrderItemIdAsync
    [Fact]
    public async Task GetByAfasOrderItemIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var afasOrderItemId = this._fixture.Create<string>();
        var entity = this._fixture.Create<OrderItem>();
        this._logic.Setup(x => x.GetByAfasOrderItemIdAsync(afasOrderItemId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByAfasOrderItemIdAsync(afasOrderItemId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByAfasOrderItemIdAsync(afasOrderItemId), Times.Once);
    }

    [Fact]
    public async Task GetByAfasOrderItemIdAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var afasOrderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasOrderItemIdAsync(afasOrderItemId)).ReturnsAsync(default(OrderItem));
        // Act
        var actual = await this._controller.GetByAfasOrderItemIdAsync(afasOrderItemId);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByAfasOrderItemIdAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var afasOrderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasOrderItemIdAsync(afasOrderItemId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByAfasOrderItemIdAsync(afasOrderItemId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByAfasOrderItemIdAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var afasOrderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasOrderItemIdAsync(afasOrderItemId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByAfasOrderItemIdAsync(afasOrderItemId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByAfasOrderItemIdAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var afasOrderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasOrderItemIdAsync(afasOrderItemId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByAfasOrderItemIdAsync(afasOrderItemId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetByCbOwnerReferenceAsync
    [Fact]
    public async Task GetByCbOwnerReferenceAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var cbOwnerReference = this._fixture.Create<string>();
        var entity = this._fixture.Create<OrderItem>();
        this._logic.Setup(x => x.GetByCbOwnerReferenceAsync(cbOwnerReference)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByCbOwnerReferenceAsync(cbOwnerReference);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByCbOwnerReferenceAsync(cbOwnerReference), Times.Once);
    }

    [Fact]
    public async Task GetByCbOwnerReferenceAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var cbOwnerReference = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByCbOwnerReferenceAsync(cbOwnerReference)).ReturnsAsync(default(OrderItem));
        // Act
        var actual = await this._controller.GetByCbOwnerReferenceAsync(cbOwnerReference);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByCbOwnerReferenceAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var cbOwnerReference = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByCbOwnerReferenceAsync(cbOwnerReference)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByCbOwnerReferenceAsync(cbOwnerReference);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByCbOwnerReferenceAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var cbOwnerReference = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByCbOwnerReferenceAsync(cbOwnerReference)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByCbOwnerReferenceAsync(cbOwnerReference);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByCbOwnerReferenceAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var cbOwnerReference = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByCbOwnerReferenceAsync(cbOwnerReference)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByCbOwnerReferenceAsync(cbOwnerReference) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    #endregion

    #region [ Public Methods - Custom - List ]
    // GetByOrderIdAsync
    [Fact]
    public async Task GetByOrderIdAsync_orderId_Should_ReturnOk_If_Success() {
        // Arrange
        var orderId = this._fixture.Create<string>();
        var entity = this._fixture.Create<List<OrderItem>>();
        this._logic.Setup(x => x.GetByOrderIdAsync(orderId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByOrderIdAsync(orderId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByOrderIdAsync(orderId), Times.Once);
    }

    [Fact]
    public async Task GetByOrderIdAsync_orderId_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var orderId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOrderIdAsync(orderId)).ReturnsAsync(default(List<OrderItem>));
        // Act
        var actual = await this._controller.GetByOrderIdAsync(orderId);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByOrderIdAsync_orderId_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var orderId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOrderIdAsync(orderId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByOrderIdAsync(orderId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByOrderIdAsync_orderId_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var orderId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOrderIdAsync(orderId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByOrderIdAsync(orderId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByOrderIdAsync_orderId_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var orderId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOrderIdAsync(orderId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByOrderIdAsync(orderId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetByProductAsync
    [Fact]
    public async Task GetByProductAsync_productId_Should_ReturnOk_If_Success() {
        // Arrange
        var productId = this._fixture.Create<string>();
        var entity = this._fixture.Create<List<OrderItem>>();
        this._logic.Setup(x => x.GetByProductAsync(productId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByProductAsync(productId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByProductAsync(productId), Times.Once);
    }

    [Fact]
    public async Task GetByProductAsync_productId_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var productId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByProductAsync(productId)).ReturnsAsync(default(List<OrderItem>));
        // Act
        var actual = await this._controller.GetByProductAsync(productId);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByProductAsync_productId_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var productId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByProductAsync(productId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByProductAsync(productId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByProductAsync_productId_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var productId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByProductAsync(productId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByProductAsync(productId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByProductAsync_productId_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var productId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByProductAsync(productId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByProductAsync(productId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetBatchByOrderIdAsync
    [Fact]
    public async Task GetBatchByOrderIdAsync_orderIds_Should_ReturnOk_If_Success() {
        // Arrange
        var orderIds = this._fixture.Create<List<string>>();
        var entity = this._fixture.Create<List<OrderItem>>();
        this._logic.Setup(x => x.GetBatchByOrderIdAsync(orderIds)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetBatchByOrderIdAsync(orderIds);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetBatchByOrderIdAsync(orderIds), Times.Once);
    }

    [Fact]
    public async Task GetBatchByOrderIdAsync_orderIds_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var orderIds = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetBatchByOrderIdAsync(orderIds)).ReturnsAsync(default(List<OrderItem>));
        // Act
        var actual = await this._controller.GetBatchByOrderIdAsync(orderIds);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetBatchByOrderIdAsync_orderIds_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var orderIds = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetBatchByOrderIdAsync(orderIds)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetBatchByOrderIdAsync(orderIds);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetBatchByOrderIdAsync_orderIds_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var orderIds = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetBatchByOrderIdAsync(orderIds)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetBatchByOrderIdAsync(orderIds);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetBatchByOrderIdAsync_orderIds_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var orderIds = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetBatchByOrderIdAsync(orderIds)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetBatchByOrderIdAsync(orderIds) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetChangesProductGroupAsync
    [Fact]
    public async Task GetChangesProductGroupAsync_model_Should_ReturnOk_If_Success() {
        // Arrange
        var model = this._fixture.Create<ChangesRequest>();
        var entity = this._fixture.Create<List<OrderItem>>();
        this._logic.Setup(x => x.GetChangesAsync(model.DateTime, model.Data)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetChangesProductGroupAsync(model);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetChangesAsync(model.DateTime, model.Data), Times.Once);
    }

    [Fact]
    public async Task GetChangesProductGroupAsync_model_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var model = this._fixture.Create<ChangesRequest>();
        this._logic.Setup(x => x.GetChangesAsync(model.DateTime, model.Data)).ReturnsAsync(default(List<OrderItem>));
        // Act
        var actual = await this._controller.GetChangesProductGroupAsync(model);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetChangesProductGroupAsync_model_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var model = this._fixture.Create<ChangesRequest>();
        this._logic.Setup(x => x.GetChangesAsync(model.DateTime, model.Data)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetChangesProductGroupAsync(model);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetChangesProductGroupAsync_model_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var model = this._fixture.Create<ChangesRequest>();
        this._logic.Setup(x => x.GetChangesAsync(model.DateTime, model.Data)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetChangesProductGroupAsync(model);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetChangesProductGroupAsync_model_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var model = this._fixture.Create<ChangesRequest>();
        this._logic.Setup(x => x.GetChangesAsync(model.DateTime, model.Data)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetChangesProductGroupAsync(model) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetChangesBookProductsAsync
    [Fact]
    public async Task GetChangesBookProductsAsync_date_Should_ReturnOk_If_Success() {
        // Arrange
        var date = this._fixture.Create<DateTime>();
        var entity = this._fixture.Create<List<OrderItem>>();
        this._logic.Setup(x => x.GetChangesBookProductsAsync(date)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetChangesBookProductsAsync(date);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetChangesBookProductsAsync(date), Times.Once);
    }

    [Fact]
    public async Task GetChangesBookProductsAsync_date_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var date = this._fixture.Create<DateTime>();
        this._logic.Setup(x => x.GetChangesBookProductsAsync(date)).ReturnsAsync(default(List<OrderItem>));
        // Act
        var actual = await this._controller.GetChangesBookProductsAsync(date);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetChangesBookProductsAsync_date_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var date = this._fixture.Create<DateTime>();
        this._logic.Setup(x => x.GetChangesBookProductsAsync(date)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetChangesBookProductsAsync(date);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetChangesBookProductsAsync_date_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var date = this._fixture.Create<DateTime>();
        this._logic.Setup(x => x.GetChangesBookProductsAsync(date)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetChangesBookProductsAsync(date);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetChangesBookProductsAsync_date_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var date = this._fixture.Create<DateTime>();
        this._logic.Setup(x => x.GetChangesBookProductsAsync(date)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetChangesBookProductsAsync(date) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetChangesLicenseProductsAsync
    [Fact]
    public async Task GetChangesLicenseProductsAsync_date_Should_ReturnOk_If_Success() {
        // Arrange
        var date = this._fixture.Create<DateTime>();
        var entity = this._fixture.Create<List<OrderItem>>();
        this._logic.Setup(x => x.GetChangesLicenseProductsAsync(date)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetChangesLicenseProductsAsync(date);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetChangesLicenseProductsAsync(date), Times.Once);
    }

    [Fact]
    public async Task GetChangesLicenseProductsAsync_date_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var date = this._fixture.Create<DateTime>();
        this._logic.Setup(x => x.GetChangesLicenseProductsAsync(date)).ReturnsAsync(default(List<OrderItem>));
        // Act
        var actual = await this._controller.GetChangesLicenseProductsAsync(date);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetChangesLicenseProductsAsync_date_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var date = this._fixture.Create<DateTime>();
        this._logic.Setup(x => x.GetChangesLicenseProductsAsync(date)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetChangesLicenseProductsAsync(date);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetChangesLicenseProductsAsync_date_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var date = this._fixture.Create<DateTime>();
        this._logic.Setup(x => x.GetChangesLicenseProductsAsync(date)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetChangesLicenseProductsAsync(date);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetChangesLicenseProductsAsync_date_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var date = this._fixture.Create<DateTime>();
        this._logic.Setup(x => x.GetChangesLicenseProductsAsync(date)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetChangesLicenseProductsAsync(date) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion
}
