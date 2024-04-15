using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using System.Threading.Tasks;

namespace ThiemeMeulenhoff.Platform.WebApi;

public class DeliveryNoteItemControllerUnitTest : BaseControllerUnitTest<DeliveryNoteItem, IDeliveryNoteItemLogicProvider, DeliveryNoteItemController>
{
    #region [ CTor ]
    public DeliveryNoteItemControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override DeliveryNoteItemController OnGetController(ILogger<DeliveryNoteItemController> logger, IDeliveryNoteItemLogicProvider logic) {
        return new DeliveryNoteItemController(logger, logic);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    // GetByOrderIdAndOrderItemIdAsync
    [Fact]
    public async Task GetByOrderIdAndOrderItemIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var orderId = this._fixture.Create<string>();
        var orderItemId = this._fixture.Create<string>();
        var entity = this._fixture.Create<DeliveryNoteItem>();
        this._logic.Setup(x => x.GetByOrderIdAndOrderItemIdAsync(orderId, orderItemId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByOrderIdAndOrderItemIdAsync(orderId, orderItemId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByOrderIdAndOrderItemIdAsync(orderId, orderItemId), Times.Once);
    }

    [Fact]
    public async Task GetByOrderIdAndOrderItemIdAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var orderId = this._fixture.Create<string>();
        var orderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOrderIdAndOrderItemIdAsync(orderId, orderItemId)).ReturnsAsync(default(DeliveryNoteItem));
        // Act
        var actual = await this._controller.GetByOrderIdAndOrderItemIdAsync(orderId, orderItemId);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetByOrderIdAndOrderItemIdAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var orderId = this._fixture.Create<string>();
        var orderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOrderIdAndOrderItemIdAsync(orderId, orderItemId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByOrderIdAndOrderItemIdAsync(orderId, orderItemId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByOrderIdAndOrderItemIdAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var orderId = this._fixture.Create<string>();
        var orderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOrderIdAndOrderItemIdAsync(orderId, orderItemId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByOrderIdAndOrderItemIdAsync(orderId, orderItemId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByOrderIdAndOrderItemIdAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var orderId = this._fixture.Create<string>();
        var orderItemId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOrderIdAndOrderItemIdAsync(orderId, orderItemId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByOrderIdAndOrderItemIdAsync(orderId, orderItemId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion
}
