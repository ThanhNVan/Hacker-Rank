using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform.WebApi;

public class ProductControllerUnitTest : BaseControllerUnitTest<Product, IProductLogicProvider, ProductController>
{
    #region [ CTor ]
    public ProductControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override ProductController OnGetController(ILogger<ProductController> logger, IProductLogicProvider logic) {
        return new ProductController(logger, logic);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    // GetByIsbnAsync
    [Fact]
    public async Task GetByIsbnAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var isbn = this._fixture.Create<string>();
        var entity = this._fixture.Create<Product>();
        this._logic.Setup(x => x.GetByEanAsync(isbn)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByIsbnAsync(isbn);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByEanAsync(isbn), Times.Once);
    }

    [Fact]
    public async Task GetByIsbnAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var isbn = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByEanAsync(isbn)).ReturnsAsync(default(Product));
        // Act
        var actual = await this._controller.GetByIsbnAsync(isbn);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByIsbnAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var isbn = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByEanAsync(isbn)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByIsbnAsync(isbn);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByIsbnAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var isbn = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByEanAsync(isbn)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByIsbnAsync(isbn);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByIsbnAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var isbn = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByEanAsync(isbn)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByIsbnAsync(isbn) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetByUuidAsync
    [Fact]
    public async Task GetByUuidAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var uuid = this._fixture.Create<string>();
        var entity = this._fixture.Create<Product>();
        this._logic.Setup(x => x.GetByUuidAsync(uuid)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByUuidAsync(uuid);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByUuidAsync(uuid), Times.Once);
    }

    [Fact]
    public async Task GetByUuidAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var uuid = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByUuidAsync(uuid)).ReturnsAsync(default(Product));
        // Act
        var actual = await this._controller.GetByUuidAsync(uuid);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByUuidAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var uuid = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByUuidAsync(uuid)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByUuidAsync(uuid);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByUuidAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var uuid = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByUuidAsync(uuid)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByUuidAsync(uuid);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByUuidAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var uuid = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByUuidAsync(uuid)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByUuidAsync(uuid) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetByNurAsync
    [Fact]
    public async Task GetByNurAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var nur = this._fixture.Create<int>();
        var entity = this._fixture.Create<Product>();
        this._logic.Setup(x => x.GetByNurAsync(nur)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByNurAsync(nur);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByNurAsync(nur), Times.Once);
    }

    [Fact]
    public async Task GetByNurAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var nur = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetByNurAsync(nur)).ReturnsAsync(default(Product));
        // Act
        var actual = await this._controller.GetByNurAsync(nur);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByNurAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var nur = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetByNurAsync(nur)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByNurAsync(nur);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByNurAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var nur = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetByNurAsync(nur)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByNurAsync(nur);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByNurAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var nur = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetByNurAsync(nur)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByNurAsync(nur) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetByAfasProductIdAsync
    [Fact]
    public async Task GetByAfasProductIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var afasProductId = this._fixture.Create<string>();
        var entity = this._fixture.Create<Product>();
        this._logic.Setup(x => x.GetByAfasProductIdAsync(afasProductId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByAfasProductIdAsync(afasProductId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByAfasProductIdAsync(afasProductId), Times.Once);
    }

    [Fact]
    public async Task GetByAfasProductIdAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var afasProductId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasProductIdAsync(afasProductId)).ReturnsAsync(default(Product));
        // Act
        var actual = await this._controller.GetByAfasProductIdAsync(afasProductId);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByAfasProductIdAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var afasProductId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasProductIdAsync(afasProductId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByAfasProductIdAsync(afasProductId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByAfasProductIdAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var afasProductId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasProductIdAsync(afasProductId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByAfasProductIdAsync(afasProductId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByAfasProductIdAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var afasProductId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasProductIdAsync(afasProductId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByAfasProductIdAsync(afasProductId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion

    #region [ Public Methods - Custom - List ]
    // GetProductsFromProjectIdsAsync
    
    // GetBookProductsAsync
    [Fact]
    public async Task GetBookProductsAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var entity = this._fixture.Create<List<Product>>();
        this._logic.Setup(x => x.GetBookProductsAsync()).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetBookProductsAsync();

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetBookProductsAsync(), Times.Once);
    }

    [Fact]
    public async Task GetBookProductsAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        this._logic.Setup(x => x.GetBookProductsAsync()).ReturnsAsync(default(List<Product>));
        // Act
        var actual = await this._controller.GetBookProductsAsync();

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetBookProductsAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        this._logic.Setup(x => x.GetBookProductsAsync()).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetBookProductsAsync();

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetBookProductsAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        this._logic.Setup(x => x.GetBookProductsAsync()).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetBookProductsAsync();

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetBookProductsAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        this._logic.Setup(x => x.GetBookProductsAsync()).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetBookProductsAsync() as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetLicenseProductsAsync
    [Fact]
    public async Task GetLicenseProductsAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var entity = this._fixture.Create<List<Product>>();
        this._logic.Setup(x => x.GetLicenseProductsAsync()).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetLicenseProductsAsync();

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetLicenseProductsAsync(), Times.Once);
    }

    [Fact]
    public async Task GetLicenseProductsAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var status = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetLicenseProductsAsync()).ReturnsAsync(default(List<Product>));
        // Act
        var actual = await this._controller.GetLicenseProductsAsync();

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetLicenseProductsAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        this._logic.Setup(x => x.GetLicenseProductsAsync()).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetLicenseProductsAsync();

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetLicenseProductsAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        this._logic.Setup(x => x.GetLicenseProductsAsync()).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetLicenseProductsAsync();

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetLicenseProductsAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        this._logic.Setup(x => x.GetLicenseProductsAsync()).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetLicenseProductsAsync() as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetBundleProductsAsync
    [Fact]
    public async Task GetBundleProductsAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var entity = this._fixture.Create<List<Product>>();
        this._logic.Setup(x => x.GetBundleProductsAsync()).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetBundleProductsAsync();

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetBundleProductsAsync(), Times.Once);
    }

    [Fact]
    public async Task GetBundleProductsAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var status = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetBundleProductsAsync()).ReturnsAsync(default(List<Product>));
        // Act
        var actual = await this._controller.GetBundleProductsAsync();

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetBundleProductsAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        this._logic.Setup(x => x.GetBundleProductsAsync()).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetBundleProductsAsync();

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetBundleProductsAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        this._logic.Setup(x => x.GetBundleProductsAsync()).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetBundleProductsAsync();

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetBundleProductsAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        this._logic.Setup(x => x.GetBundleProductsAsync()).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetBundleProductsAsync() as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetProductsInBundleAsync
    [Fact]
    public async Task GetProductsInBundleAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var productId = this._fixture.Create<string>();
        var entity = this._fixture.Create<List<Product>>();
        this._logic.Setup(x => x.GetProductsInBundleAsync(productId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetProductsInBundleAsync(productId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetProductsInBundleAsync(productId), Times.Once);
    }

    [Fact]
    public async Task GetProductsInBundleAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var productId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetProductsInBundleAsync(productId)).ReturnsAsync(default(List<Product>));
        // Act
        var actual = await this._controller.GetProductsInBundleAsync(productId);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetProductsInBundleAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var productId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetProductsInBundleAsync(productId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetProductsInBundleAsync(productId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetProductsInBundleAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var productId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetProductsInBundleAsync(productId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetProductsInBundleAsync(productId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetProductsInBundleAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var productId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetProductsInBundleAsync(productId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetProductsInBundleAsync(productId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    
    
    // GetByEansAsync
    [Fact]
    public async Task GetByEansAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var eans = this._fixture.Create<List<string>>();
        var entity = this._fixture.Create<List<Product>>();
        this._logic.Setup(x => x.GetByEansAsync(eans)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByEansAsync(eans);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByEansAsync(eans), Times.Once);
    }

    [Fact]
    public async Task GetByEansAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var eans = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetByEansAsync(eans)).ReturnsAsync(default(List<Product>));
        // Act
        var actual = await this._controller.GetByEansAsync(eans);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetByEansAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var eans = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetByEansAsync(eans)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByEansAsync(eans);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByEansAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var eans = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetByEansAsync(eans)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByEansAsync(eans);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByEansAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var eans = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetByEansAsync(eans)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByEansAsync(eans) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    #endregion
}
