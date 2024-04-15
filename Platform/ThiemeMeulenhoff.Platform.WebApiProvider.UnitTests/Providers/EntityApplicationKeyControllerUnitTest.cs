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

public class EntityApplicationKeyControllerUnitTest : BaseControllerUnitTest<EntityApplicationKey, IEntityApplicationKeyLogicProvider, EntityApplicationKeyController>
{
    #region [ CTor ]
    public EntityApplicationKeyControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override EntityApplicationKeyController OnGetController(ILogger<EntityApplicationKeyController> logger, IEntityApplicationKeyLogicProvider logic) {
        return new EntityApplicationKeyController(logger, logic);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    // GetByApplicationKeyAsync
    [Fact]
    public async Task GetByApplicationKeyAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var applicationName = this._fixture.Create<string>();
        var applicationKey = this._fixture.Create<string>();
        var entity = this._fixture.Create<EntityApplicationKey>();
        this._logic.Setup(x => x.GetByApplicationKeyAsync(applicationName, applicationKey)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByApplicationKeyAsync(applicationName, applicationKey);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByApplicationKeyAsync(applicationName, applicationKey), Times.Once);
    }

    [Fact]
    public async Task GetByApplicationKeyAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var applicationName = this._fixture.Create<string>();
        var applicationKey = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByApplicationKeyAsync(applicationName, applicationKey)).ReturnsAsync(default(EntityApplicationKey));
        // Act
        var actual = await this._controller.GetByApplicationKeyAsync(applicationName, applicationKey);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByApplicationKeyAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var applicationName = this._fixture.Create<string>();
        var applicationKey = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByApplicationKeyAsync(applicationName, applicationKey)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByApplicationKeyAsync(applicationName, applicationKey);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByApplicationKeyAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var applicationName = this._fixture.Create<string>();
        var applicationKey = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByApplicationKeyAsync(applicationName, applicationKey)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByApplicationKeyAsync(applicationName, applicationKey);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByApplicationKeyAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var applicationName = this._fixture.Create<string>();
        var applicationKey = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByApplicationKeyAsync(applicationName, applicationKey)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByApplicationKeyAsync(applicationName, applicationKey) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    
    // GetByEntityIdAsync
    [Fact]
    public async Task GetByEntityIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var applicationName = this._fixture.Create<string>();
        var entityId = this._fixture.Create<string>();
        var entity = this._fixture.Create<EntityApplicationKey>();
        this._logic.Setup(x => x.GetByEntityIdAsync(applicationName, entityId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByEntityIdAsync(applicationName, entityId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByEntityIdAsync(applicationName, entityId), Times.Once);
    }

    [Fact]
    public async Task GetByEntityIdAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var applicationName = this._fixture.Create<string>();
        var entityId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByEntityIdAsync(applicationName, entityId)).ReturnsAsync(default(EntityApplicationKey));
        // Act
        var actual = await this._controller.GetByEntityIdAsync(applicationName, entityId);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByEntityIdAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var applicationName = this._fixture.Create<string>();
        var entityId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByEntityIdAsync(applicationName, entityId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByEntityIdAsync(applicationName, entityId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByEntityIdAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var applicationName = this._fixture.Create<string>();
        var entityId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByEntityIdAsync(applicationName, entityId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByEntityIdAsync(applicationName, entityId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByEntityIdAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var applicationName = this._fixture.Create<string>();
        var entityId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByEntityIdAsync(applicationName, entityId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByEntityIdAsync(applicationName, entityId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion

    #region [ Public Methods - Custom - List ]
    // GetByEntityIdAsync
    [Fact]
    public async Task GetByEntityIdAsync_entityId_Should_ReturnOk_If_Success() {
        // Arrange
        var entityId = this._fixture.Create<string>();
        var entity = this._fixture.Create<List<EntityApplicationKey>>();
        this._logic.Setup(x => x.GetByEntityIdAsync(entityId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByEntityIdAsync(entityId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByEntityIdAsync(entityId), Times.Once);
    }

    [Fact]
    public async Task GetByEntityIdAsync_entityId_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var entityId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByEntityIdAsync(entityId)).ReturnsAsync(default(List<EntityApplicationKey>));
        // Act
        var actual = await this._controller.GetByEntityIdAsync(entityId);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByEntityIdAsync_entityId_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var entityId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByEntityIdAsync(entityId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByEntityIdAsync(entityId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByEntityIdAsync_entityId_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var entityId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByEntityIdAsync(entityId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByEntityIdAsync(entityId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByEntityIdAsync_entityId_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var entityId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByEntityIdAsync(entityId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByEntityIdAsync(entityId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion
}
