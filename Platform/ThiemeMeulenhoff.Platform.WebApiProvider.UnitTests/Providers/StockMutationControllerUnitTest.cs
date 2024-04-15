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

public class StockMutationControllerUnitTest : BaseControllerUnitTest<StockMutation, IStockMutationLogicProvider, StockMutationController>
{
    #region [ CTor ]
    public StockMutationControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override StockMutationController OnGetController(ILogger<StockMutationController> logger, IStockMutationLogicProvider logic) {
        return new StockMutationController(logger, logic);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    // GetLastBySourceAsync
    [Fact]
    public async Task GetLastBySourceAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var productId = this._fixture.Create<string>();
        var source = this._fixture.Create<string>();
        var entity = this._fixture.Create<StockMutation>();
        this._logic.Setup(x => x.GetLastBySourceAsync(productId, source)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetLastBySourceAsync(productId, source);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetLastBySourceAsync(productId, source), Times.Once);
    }

    [Fact]
    public async Task GetLastBySourceAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var productId = this._fixture.Create<string>();
        var source = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetLastBySourceAsync(productId, source)).ReturnsAsync(default(StockMutation));
        // Act
        var actual = await this._controller.GetLastBySourceAsync(productId, source);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetLastBySourceAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var productId = this._fixture.Create<string>();
        var source = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetLastBySourceAsync(productId, source)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetLastBySourceAsync(productId, source);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetLastBySourceAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var productId = this._fixture.Create<string>();
        var source = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetLastBySourceAsync(productId, source)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetLastBySourceAsync(productId, source);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetLastBySourceAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var productId = this._fixture.Create<string>();
        var source = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetLastBySourceAsync(productId, source)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetLastBySourceAsync(productId, source) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion

    #region [ Public Methods - Custom - List ]
    // GetByProductIdAsync
    [Fact]
    public async Task GetByProductIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var productId = this._fixture.Create<string>();
        var entity = this._fixture.Create<List<StockMutation>>();
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
        this._logic.Setup(x => x.GetByProductIdAsync(productId)).ReturnsAsync(default(List<StockMutation>));
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
    
    // GetByContactIdAsync
    [Fact]
    public async Task GetByContactIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var contactId = this._fixture.Create<string>();
        var entity = this._fixture.Create<List<StockMutation>>();
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
        this._logic.Setup(x => x.GetByContactIdAsync(contactId)).ReturnsAsync(default(List<StockMutation>));
        // Act
        var actual = await this._controller.GetByContactIdAsync(contactId);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
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
    
    // GetByAfasWarehouseIdAsync
    [Fact]
    public async Task GetByAfasWarehouseIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var afasWarehouseId = this._fixture.Create<string>();
        var entity = this._fixture.Create<List<StockMutation>>();
        this._logic.Setup(x => x.GetByAfasWarehouseIdAsync(afasWarehouseId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByAfasWarehouseIdAsync(afasWarehouseId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByAfasWarehouseIdAsync(afasWarehouseId), Times.Once);
    }

    [Fact]
    public async Task GetByAfasWarehouseIdAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var afasWarehouseId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasWarehouseIdAsync(afasWarehouseId)).ReturnsAsync(default(List<StockMutation>));
        // Act
        var actual = await this._controller.GetByAfasWarehouseIdAsync(afasWarehouseId);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByAfasWarehouseIdAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var afasWarehouseId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasWarehouseIdAsync(afasWarehouseId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByAfasWarehouseIdAsync(afasWarehouseId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByAfasWarehouseIdAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var afasWarehouseId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasWarehouseIdAsync(afasWarehouseId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByAfasWarehouseIdAsync(afasWarehouseId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByAfasWarehouseIdAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var afasWarehouseId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasWarehouseIdAsync(afasWarehouseId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByAfasWarehouseIdAsync(afasWarehouseId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    #endregion
}
