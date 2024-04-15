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

public class ProductBundleItemControllerUnitTest : BaseControllerUnitTest<ProductBundleItem, IProductBundleItemLogicProvider, ProductBundleItemController>
{
    #region [ CTor ]
    public ProductBundleItemControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override ProductBundleItemController OnGetController(ILogger<ProductBundleItemController> logger, IProductBundleItemLogicProvider logic) {
        return new ProductBundleItemController(logger, logic);
    }
    #endregion

    #region [ Public Methods - Custom - Lists ]
    // GetByOwnerProductIdAsync
    [Fact]
    public async Task GetByOwnerProductIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var OwnerProductId = this._fixture.Create<string>();
        var entity = this._fixture.Create<List<ProductBundleItem>>();
        this._logic.Setup(x => x.GetByOwnerProductIdAsync(OwnerProductId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByOwnerProductIdAsync(OwnerProductId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByOwnerProductIdAsync(OwnerProductId), Times.Once);
    }

    [Fact]
    public async Task GetByOwnerProductIdAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var OwnerProductId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOwnerProductIdAsync(OwnerProductId)).ReturnsAsync(default(List<ProductBundleItem>));
        // Act
        var actual = await this._controller.GetByOwnerProductIdAsync(OwnerProductId);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetByOwnerProductIdAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var OwnerProductId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOwnerProductIdAsync(OwnerProductId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByOwnerProductIdAsync(OwnerProductId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByOwnerProductIdAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var OwnerProductId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOwnerProductIdAsync(OwnerProductId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByOwnerProductIdAsync(OwnerProductId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByOwnerProductIdAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var OwnerProductId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOwnerProductIdAsync(OwnerProductId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByOwnerProductIdAsync(OwnerProductId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetByRelatedProductIdAsync
    [Fact]
    public async Task GetByRelatedProductIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var relatedProductId = this._fixture.Create<string>();
        var entity = this._fixture.Create<List<ProductBundleItem>>();
        this._logic.Setup(x => x.GetByRelatedProductIdAsync(relatedProductId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByRelatedProductIdAsync(relatedProductId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByRelatedProductIdAsync(relatedProductId), Times.Once);
    }

    [Fact]
    public async Task GetByRelatedProductIdAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var relatedProductId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByRelatedProductIdAsync(relatedProductId)).ReturnsAsync(default(List<ProductBundleItem>));
        // Act
        var actual = await this._controller.GetByRelatedProductIdAsync(relatedProductId);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetByRelatedProductIdAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var relatedProductId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByRelatedProductIdAsync(relatedProductId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByRelatedProductIdAsync(relatedProductId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByRelatedProductIdAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var relatedProductId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByRelatedProductIdAsync(relatedProductId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByRelatedProductIdAsync(relatedProductId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByRelatedProductIdAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var relatedProductId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByRelatedProductIdAsync(relatedProductId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByRelatedProductIdAsync(relatedProductId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetBatchByRelatedProductIdAsync
    [Fact]
    public async Task GetBatchByRelatedProductIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var relatedProductIds = this._fixture.Create<List<string>>();
        var entity = this._fixture.Create<List<ProductBundleItem>>();
        this._logic.Setup(x => x.GetBatchByRelatedProductIdAsync(relatedProductIds)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetBatchByRelatedProductIdAsync(relatedProductIds);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetBatchByRelatedProductIdAsync(relatedProductIds), Times.Once);
    }

    [Fact]
    public async Task GetBatchByRelatedProductIdAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var relatedProductIds = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetBatchByRelatedProductIdAsync(relatedProductIds)).ReturnsAsync(default(List<ProductBundleItem>));
        // Act
        var actual = await this._controller.GetBatchByRelatedProductIdAsync(relatedProductIds);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetBatchByRelatedProductIdAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var relatedProductIds = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetBatchByRelatedProductIdAsync(relatedProductIds)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetBatchByRelatedProductIdAsync(relatedProductIds);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetBatchByRelatedProductIdAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var relatedProductIds = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetBatchByRelatedProductIdAsync(relatedProductIds)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetBatchByRelatedProductIdAsync(relatedProductIds);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetBatchByRelatedProductIdAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var relatedProductIds = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetBatchByRelatedProductIdAsync(relatedProductIds)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetBatchByRelatedProductIdAsync(relatedProductIds) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetBatchByOwnerProductIdAsync
    [Fact]
    public async Task GetBatchByOwnerProductIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var ownerProductIds = this._fixture.Create<List<string>>();
        var entity = this._fixture.Create<List<ProductBundleItem>>();
        this._logic.Setup(x => x.GetBatchByOwnerProductIdAsync(ownerProductIds)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetBatchByOwnerProductIdAsync(ownerProductIds);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetBatchByOwnerProductIdAsync(ownerProductIds), Times.Once);
    }

    [Fact]
    public async Task GetBatchByOwnerProductIdAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var ownerProductIds = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetBatchByOwnerProductIdAsync(ownerProductIds)).ReturnsAsync(default(List<ProductBundleItem>));
        // Act
        var actual = await this._controller.GetBatchByOwnerProductIdAsync(ownerProductIds);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetBatchByOwnerProductIdAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var ownerProductIds = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetBatchByOwnerProductIdAsync(ownerProductIds)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetBatchByOwnerProductIdAsync(ownerProductIds);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetBatchByOwnerProductIdAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var ownerProductIds = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetBatchByOwnerProductIdAsync(ownerProductIds)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetBatchByOwnerProductIdAsync(ownerProductIds);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetBatchByOwnerProductIdAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var ownerProductIds = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetBatchByOwnerProductIdAsync(ownerProductIds)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetBatchByOwnerProductIdAsync(ownerProductIds) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion
}
