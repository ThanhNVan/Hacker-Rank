using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using RCode;
using RCode.Data.Paging;
using Xunit;

namespace ThiemeMeulenhoff.Platform.WebApi;

[Collection("ControllerProvider")]
[CollectionDefinition(nameof(BaseControllerUnitTest<TEntity, TLogicProvider, TController>), DisableParallelization = true)]
public abstract class BaseControllerUnitTest<TEntity, TLogicProvider, TController> : IDisposable
    where TEntity : BaseEntity
    where TLogicProvider : class, IThiemeEntityLogicProvider<TEntity>
    where TController : BaseThiemenMeulenhoffController<TEntity, TLogicProvider>

{
    #region [ Fields ]
    protected readonly Fixture _fixture;
    protected readonly Mock<ILogger<TController>> _logger;
    protected readonly Mock<TLogicProvider> _logic;
    protected readonly TController _controller;
    #endregion

    #region [ CTor ]
    public BaseControllerUnitTest() {
        this._fixture = new Fixture();
        this._logger = new Mock<ILogger<TController>>();
        this._logic = new Mock<TLogicProvider>();
        this._controller = this.GetController();
    }
    #endregion

    #region [ Public Methods - Add | Update | Delete ]
    // SaveAsync
    [Fact]
    public async Task SaveAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var entity = this._fixture.Create<TEntity>();

        // Act
        var actual = await this._controller.SaveAsync(entity);

        // Assert
        Assert.IsType<OkResult>(actual);
        this._logic.Verify(x => x.SaveAsync(entity), Times.Once);
    }
    
    [Fact]
    public async Task SaveAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var entity = this._fixture.Create<TEntity>();
        this._logic.Setup(x => x.SaveAsync(entity)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.SaveAsync(entity);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }
    
    [Fact]
    public async Task SaveAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var entity = this._fixture.Create<TEntity>();
        this._logic.Setup(x => x.SaveAsync(entity)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.SaveAsync(entity);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }
    
    [Fact]
    public async Task SaveAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var entity = this._fixture.Create<TEntity>();
        this._logic.Setup(x => x.SaveAsync(entity)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.SaveAsync(entity) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // SyncAsync
    [Fact]
    public async Task SyncAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var entity = this._fixture.Create<TEntity>();

        // Act
        var actual = await this._controller.SyncAsync(entity);

        // Assert
        Assert.IsType<OkResult>(actual);
        this._logic.Verify(x => x.SyncAsync(entity), Times.Once);
    }
    
    [Fact]
    public async Task SyncAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var entity = this._fixture.Create<TEntity>();
        this._logic.Setup(x => x.SyncAsync(entity)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.SyncAsync(entity);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }
    
    [Fact]
    public async Task SyncAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var entity = this._fixture.Create<TEntity>();
        this._logic.Setup(x => x.SyncAsync(entity)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.SyncAsync(entity);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }
    
    [Fact]
    public async Task SyncAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var entity = this._fixture.Create<TEntity>();
        this._logic.Setup(x => x.SyncAsync(entity)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.SyncAsync(entity) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // AddAsync
    [Fact]
    public async Task AddAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var entity = this._fixture.Create<TEntity>();

        // Act
        var actual = await this._controller.AddAsync(entity);

        // Assert
        Assert.IsType<OkResult>(actual);
        this._logic.Verify(x => x.AddAsync(entity), Times.Once);
    }
    
    [Fact]
    public async Task AddAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var entity = this._fixture.Create<TEntity>();
        this._logic.Setup(x => x.AddAsync(entity)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.AddAsync(entity);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }
    
    [Fact]
    public async Task AddAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var entity = this._fixture.Create<TEntity>();
        this._logic.Setup(x => x.AddAsync(entity)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.AddAsync(entity);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }
    
    [Fact]
    public async Task AddAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var entity = this._fixture.Create<TEntity>();
        this._logic.Setup(x => x.AddAsync(entity)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.AddAsync(entity) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // UpdateAsync
    [Fact]
    public async Task UpdateAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var entity = this._fixture.Create<TEntity>();

        // Act
        var actual = await this._controller.UpdateAsync(entity);

        // Assert
        Assert.IsType<OkResult>(actual);
        this._logic.Verify(x => x.UpdateAsync(entity), Times.Once);
    }
    
    [Fact]
    public async Task UpdateAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var entity = this._fixture.Create<TEntity>();
        this._logic.Setup(x => x.UpdateAsync(entity)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.UpdateAsync(entity);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }
    
    [Fact]
    public async Task UpdateAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var entity = this._fixture.Create<TEntity>();
        this._logic.Setup(x => x.UpdateAsync(entity)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.UpdateAsync(entity);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }
    
    [Fact]
    public async Task UpdateAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var entity = this._fixture.Create<TEntity>();
        this._logic.Setup(x => x.UpdateAsync(entity)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.UpdateAsync(entity) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // DeleteAsync
    [Fact]
    public async Task DeleteAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var id = this._fixture.Create<string>();
        var entity = this._fixture.Create<TEntity>();
        this._logic.Setup(x => x.GetAsync(id)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.DeleteAsync(id);

        // Assert
        Assert.IsType<OkResult>(actual);
        this._logic.Verify(x => x.DeleteAsync(id), Times.Once);
    }
    
    [Fact]
    public async Task DeleteAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var id = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetAsync(id)).ReturnsAsync(default(TEntity));
        // Act
        var actual = await this._controller.DeleteAsync(id);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }
    
    [Fact]
    public async Task DeleteAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var id = this._fixture.Create<string>();
        var entity = this._fixture.Create<TEntity>();
        this._logic.Setup(x => x.GetAsync(id)).ReturnsAsync(entity);
        this._logic.Setup(x => x.DeleteAsync(id)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.DeleteAsync(id);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }
    
    [Fact]
    public async Task DeleteAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var id = this._fixture.Create<string>();
        var entity = this._fixture.Create<TEntity>();
        this._logic.Setup(x => x.GetAsync(id)).ReturnsAsync(entity);
        this._logic.Setup(x => x.DeleteAsync(id)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.DeleteAsync(id);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }
    
    [Fact]
    public async Task DeleteAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var id = this._fixture.Create<string>();
        var entity = this._fixture.Create<TEntity>();
        this._logic.Setup(x => x.GetAsync(id)).ReturnsAsync(entity);
        this._logic.Setup(x => x.DeleteAsync(id)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.DeleteAsync(id) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion

    #region [ Public Methods - Activate ]
    // ActivateAsync
    [Fact]
    public async Task ActivateAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var id = this._fixture.Create<string>();
        var entity = this._fixture.Create<TEntity>();
        this._logic.Setup(x => x.GetAsync(id)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.ActivateAsync(id);

        // Assert
        Assert.IsType<OkResult>(actual);
        this._logic.Verify(x => x.ActivateAsync(id), Times.Once);
    }

    [Fact]
    public async Task ActivateAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var id = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetAsync(id)).ReturnsAsync(default(TEntity));
        // Act
        var actual = await this._controller.ActivateAsync(id);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task ActivateAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var id = this._fixture.Create<string>();
        var entity = this._fixture.Create<TEntity>();
        this._logic.Setup(x => x.GetAsync(id)).ReturnsAsync(entity);
        this._logic.Setup(x => x.ActivateAsync(id)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.ActivateAsync(id);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task ActivateAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var id = this._fixture.Create<string>();
        var entity = this._fixture.Create<TEntity>();
        this._logic.Setup(x => x.GetAsync(id)).ReturnsAsync(entity);
        this._logic.Setup(x => x.ActivateAsync(id)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.ActivateAsync(id);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task ActivateAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var id = this._fixture.Create<string>();
        var entity = this._fixture.Create<TEntity>();
        this._logic.Setup(x => x.GetAsync(id)).ReturnsAsync(entity);
        this._logic.Setup(x => x.ActivateAsync(id)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.ActivateAsync(id) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // DeactivateAsync
    [Fact]
    public async Task DeactivateAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var id = this._fixture.Create<string>();
        var entity = this._fixture.Create<TEntity>();
        this._logic.Setup(x => x.GetAsync(id)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.DeactivateAsync(id);

        // Assert
        Assert.IsType<OkResult>(actual);
        this._logic.Verify(x => x.DeactivateAsync(id), Times.Once);
    }

    [Fact]
    public async Task DeactivateAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var id = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetAsync(id)).ReturnsAsync(default(TEntity));
        // Act
        var actual = await this._controller.DeactivateAsync(id);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task DeactivateAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var id = this._fixture.Create<string>();
        var entity = this._fixture.Create<TEntity>();
        this._logic.Setup(x => x.GetAsync(id)).ReturnsAsync(entity);
        this._logic.Setup(x => x.DeactivateAsync(id)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.DeactivateAsync(id);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task DeactivateAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var id = this._fixture.Create<string>();
        var entity = this._fixture.Create<TEntity>();
        this._logic.Setup(x => x.GetAsync(id)).ReturnsAsync(entity);
        this._logic.Setup(x => x.DeactivateAsync(id)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.DeactivateAsync(id);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task DeactivateAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var id = this._fixture.Create<string>();
        var entity = this._fixture.Create<TEntity>();
        this._logic.Setup(x => x.GetAsync(id)).ReturnsAsync(entity);
        this._logic.Setup(x => x.DeactivateAsync(id)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.DeactivateAsync(id) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion

    #region [ Public Methods - Single ]
    // GetAsync
    [Fact]
    public async Task GetAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var id = this._fixture.Create<string>();
        var entity = this._fixture.Create<TEntity>();
        this._logic.Setup(x => x.GetAsync(id)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetAsync(id);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetAsync(id), Times.Once);
    }

    [Fact]
    public async Task GetAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var id = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetAsync(id)).ReturnsAsync(default(TEntity));
        // Act
        var actual = await this._controller.GetAsync(id);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var id = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetAsync(id)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetAsync(id);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var id = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetAsync(id)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetAsync(id);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var id = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetAsync(id)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetAsync(id) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion

    #region [ Public Methods - List ]
    // GetAllAsync
    [Fact]
    public async Task GetAllAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var entityList = this._fixture.Create<List<TEntity>>();
        this._logic.Setup(x => x.GetAllAsync()).ReturnsAsync(entityList);
        // Act
        var actual = await this._controller.GetAllAsync();

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetAllAsync(), Times.Once);
    }

    [Fact]
    public async Task GetAllAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var emptyList = default(List<TEntity>); 
        this._logic.Setup(x => x.GetAllAsync()).ReturnsAsync(emptyList);
        // Act
        var actual = await this._controller.GetAllAsync();

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetAllAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        this._logic.Setup(x => x.GetAllAsync()).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetAllAsync();

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetAllAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        this._logic.Setup(x => x.GetAllAsync()).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetAllAsync();

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetAllAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        this._logic.Setup(x => x.GetAllAsync()).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetAllAsync() as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetAllAsync_PagingOptions
    [Fact]
    public async Task GetAllAsync_PagingOptions_Should_ReturnOk_If_Success() {
        // Arrange
        var options = this._fixture.Create<PagingOptions>();
        var result = this._fixture.Create<PagingResult<TEntity>>();
        this._logic.Setup(x => x.GetAllAsync(options)).ReturnsAsync(result);
        // Act
        var actual = await this._controller.GetAllAsync(options);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetAllAsync(options), Times.Once);
    }

    [Fact]
    public async Task GetAllAsync_PagingOptions_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var options = this._fixture.Create<PagingOptions>();
        var result = default(PagingResult<TEntity>);
        this._logic.Setup(x => x.GetAllAsync(options)).ReturnsAsync(result);
        // Act
        var actual = await this._controller.GetAllAsync(options);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetAllAsync_PagingOptions_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var options = this._fixture.Create<PagingOptions>();
        this._logic.Setup(x => x.GetAllAsync(options)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetAllAsync(options);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetAllAsync_PagingOptions_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var options = this._fixture.Create<PagingOptions>();
        this._logic.Setup(x => x.GetAllAsync(options)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetAllAsync(options);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetAllAsync_PagingOptions_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var options = this._fixture.Create<PagingOptions>();
        this._logic.Setup(x => x.GetAllAsync(options)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetAllAsync(options) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetActiveAsync
    [Fact]
    public async Task GetActiveAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var entityList = this._fixture.Create<List<TEntity>>();
        this._logic.Setup(x => x.GetActiveAsync()).ReturnsAsync(entityList);
        // Act
        var actual = await this._controller.GetActiveAsync();

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetActiveAsync(), Times.Once);
    }

    [Fact]
    public async Task GetActiveAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var emptyList = default(List<TEntity>);
        this._logic.Setup(x => x.GetActiveAsync()).ReturnsAsync(emptyList);
        // Act
        var actual = await this._controller.GetActiveAsync();

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetActiveAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        this._logic.Setup(x => x.GetActiveAsync()).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetActiveAsync();

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetActiveAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        this._logic.Setup(x => x.GetActiveAsync()).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetActiveAsync();

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetActiveAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        this._logic.Setup(x => x.GetActiveAsync()).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetActiveAsync() as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetActiveAsync_PagingOptions
    [Fact]
    public async Task GetActiveAsync_PagingOptions_Should_ReturnOk_If_Success() {
        // Arrange
        var options = this._fixture.Create<PagingOptions>();
        var result = this._fixture.Create<PagingResult<TEntity>>();
        this._logic.Setup(x => x.GetActiveAsync(options)).ReturnsAsync(result);
        // Act
        var actual = await this._controller.GetActiveAsync(options);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetActiveAsync(options), Times.Once);
    }

    [Fact]
    public async Task GetActiveAsync_PagingOptions_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var options = this._fixture.Create<PagingOptions>();
        var result = default(PagingResult<TEntity>);
        this._logic.Setup(x => x.GetActiveAsync(options)).ReturnsAsync(result);
        // Act
        var actual = await this._controller.GetActiveAsync(options);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetActiveAsync_PagingOptions_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var options = this._fixture.Create<PagingOptions>();
        this._logic.Setup(x => x.GetActiveAsync(options)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetActiveAsync(options);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetActiveAsync_PagingOptions_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var options = this._fixture.Create<PagingOptions>();
        this._logic.Setup(x => x.GetActiveAsync(options)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetActiveAsync(options);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetActiveAsync_PagingOptions_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var options = this._fixture.Create<PagingOptions>();
        this._logic.Setup(x => x.GetActiveAsync(options)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetActiveAsync(options) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetInActiveAsync
    [Fact]
    public async Task GetInActiveAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var entityList = this._fixture.Create<List<TEntity>>();
        this._logic.Setup(x => x.GetInActiveAsync()).ReturnsAsync(entityList);
        // Act
        var actual = await this._controller.GetInActiveAsync();

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetInActiveAsync(), Times.Once);
    }

    [Fact]
    public async Task GetInActiveAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var emptyList = default(List<TEntity>);
        this._logic.Setup(x => x.GetInActiveAsync()).ReturnsAsync(emptyList);
        // Act
        var actual = await this._controller.GetInActiveAsync();

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetInActiveAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        this._logic.Setup(x => x.GetInActiveAsync()).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetInActiveAsync();

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetInActiveAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        this._logic.Setup(x => x.GetInActiveAsync()).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetInActiveAsync();

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetInActiveAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        this._logic.Setup(x => x.GetInActiveAsync()).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetInActiveAsync() as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetInActiveAsync_PagingOptions
    [Fact]
    public async Task GetInActiveAsync_PagingOptions_Should_ReturnOk_If_Success() {
        // Arrange
        var options = this._fixture.Create<PagingOptions>();
        var result = this._fixture.Create<PagingResult<TEntity>>();
        this._logic.Setup(x => x.GetInActiveAsync(options)).ReturnsAsync(result);
        // Act
        var actual = await this._controller.GetInActiveAsync(options);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetInActiveAsync(options), Times.Once);
    }

    [Fact]
    public async Task GetInActiveAsync_PagingOptions_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var options = this._fixture.Create<PagingOptions>();
        var result = default(PagingResult<TEntity>);
        this._logic.Setup(x => x.GetInActiveAsync(options)).ReturnsAsync(result);
        // Act
        var actual = await this._controller.GetInActiveAsync(options);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetInActiveAsync_PagingOptions_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var options = this._fixture.Create<PagingOptions>();
        this._logic.Setup(x => x.GetInActiveAsync(options)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetInActiveAsync(options);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetInActiveAsync_PagingOptions_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var options = this._fixture.Create<PagingOptions>();
        this._logic.Setup(x => x.GetInActiveAsync(options)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetInActiveAsync(options);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetInActiveAsync_PagingOptions_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var options = this._fixture.Create<PagingOptions>();
        this._logic.Setup(x => x.GetInActiveAsync(options)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetInActiveAsync(options) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }


    // GetBatchAsync
    [Fact]
    public async Task GetBatchAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var entityList = this._fixture.Create<List<TEntity>>();
        var entityIds = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetBatchAsync(entityIds)).ReturnsAsync(entityList);
        // Act
        var actual = await this._controller.GetBatchAsync(entityIds);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetBatchAsync(entityIds), Times.Once);
    }

    [Fact]
    public async Task GetBatchAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var emptyList = default(List<TEntity>);
        var entityIds = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetBatchAsync(entityIds)).ReturnsAsync(emptyList);
        // Act
        var actual = await this._controller.GetBatchAsync(entityIds);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetBatchAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var entityIds = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetBatchAsync(entityIds)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetBatchAsync(entityIds);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetBatchAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var entityIds = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetBatchAsync(entityIds)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetBatchAsync(entityIds);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetBatchAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var entityIds = this._fixture.Create<List<string>>();
        this._logic.Setup(x => x.GetBatchAsync(entityIds)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetBatchAsync(entityIds) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // AnyAsync
    [Fact]
    public async Task AnyAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var result = this._fixture.Create<bool>();
        this._logic.Setup(x => x.AnyAsync()).ReturnsAsync(result);
        // Act
        var actual = await this._controller.AnyAsync();

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.AnyAsync(), Times.Once);
    }

    [Fact]
    public async Task AnyAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        this._logic.Setup(x => x.AnyAsync()).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.AnyAsync();

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task AnyAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        this._logic.Setup(x => x.AnyAsync()).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.AnyAsync();

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task AnyAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        this._logic.Setup(x => x.AnyAsync()).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.AnyAsync() as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetChangesAsync
    [Fact]
    public async Task GetChangesAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var entityList = this._fixture.Create<List<TEntity>>();
        var date = this._fixture.Create<DateTime>();
        this._logic.Setup(x => x.GetChangesAsync(date)).ReturnsAsync(entityList);
        // Act
        var actual = await this._controller.GetChangesAsync(date);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetChangesAsync(date), Times.Once);
    }

    [Fact]
    public async Task GetChangesAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var emptyList = default(List<TEntity>);
        var date = this._fixture.Create<DateTime>();
        this._logic.Setup(x => x.GetChangesAsync(date)).ReturnsAsync(emptyList);
        // Act
        var actual = await this._controller.GetChangesAsync(date);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetChangesAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var date = this._fixture.Create<DateTime>();
        this._logic.Setup(x => x.GetChangesAsync(date)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetChangesAsync(date);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetChangesAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var date = this._fixture.Create<DateTime>();
        this._logic.Setup(x => x.GetChangesAsync(date)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetChangesAsync(date);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetChangesAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var date = this._fixture.Create<DateTime>();
        this._logic.Setup(x => x.GetChangesAsync(date)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetChangesAsync(date) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion

    #region [ public Methods - Count ]
    // CountAllAsync
    [Fact]
    public async Task CountAllAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var result = this._fixture.Create<int>();
        this._logic.Setup(x => x.CountAllAsync()).ReturnsAsync(result);
        // Act
        var actual = await this._controller.CountAllAsync();

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.CountAllAsync(), Times.Once);
    }

    [Fact]
    public async Task CountAllAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        this._logic.Setup(x => x.CountAllAsync()).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.CountAllAsync();

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task CountAllAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        this._logic.Setup(x => x.CountAllAsync()).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.CountAllAsync();

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task CountAllAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        this._logic.Setup(x => x.CountAllAsync()).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.CountAllAsync() as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    
    // CountActiveAsync
    [Fact]
    public async Task CountActiveAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var result = this._fixture.Create<int>();
        this._logic.Setup(x => x.CountActivelAsync()).ReturnsAsync(result);
        // Act
        var actual = await this._controller.CountActiveAsync();

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.CountActivelAsync(), Times.Once);
    }

    [Fact]
    public async Task CountActiveAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        this._logic.Setup(x => x.CountActivelAsync()).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.CountActiveAsync();

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task CountActiveAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        this._logic.Setup(x => x.CountActivelAsync()).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.CountActiveAsync();

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task CountActiveAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        this._logic.Setup(x => x.CountActivelAsync()).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.CountActiveAsync() as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // CountInActiveAsync
    [Fact]
    public async Task CountInActiveAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var result = this._fixture.Create<int>();
        this._logic.Setup(x => x.CountInActiveAsync()).ReturnsAsync(result);
        // Act
        var actual = await this._controller.CountInActiveAsync();

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.CountInActiveAsync(), Times.Once);
    }

    [Fact]
    public async Task CountInActiveAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        this._logic.Setup(x => x.CountInActiveAsync()).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.CountInActiveAsync();

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task CountInActiveAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        this._logic.Setup(x => x.CountInActiveAsync()).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.CountInActiveAsync();

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task CountInActiveAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        this._logic.Setup(x => x.CountInActiveAsync()).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.CountInActiveAsync() as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion

    #region [ Public Methods - Data ]
    [Fact]
    public async Task CreateTestDataAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var expected = new Random().Next(1, 50);

        // Act
        var result = await this._controller.CreateTestDataAsync(expected);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
    
    [Fact]
    public async Task CreateTestDataAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var expected = 0;

        // Act
        var result = await this._controller.CreateTestDataAsync(expected);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
    #endregion

    #region [ Protected Methods - Create ]
    protected TController GetController() {
        return OnGetController(this._logger.Object, this._logic.Object);
    }
    #endregion

    #region [ Protected Abstract Methods ]
    protected abstract TController OnGetController(ILogger<TController> logger, TLogicProvider logic);
    #endregion

    #region [ Methods - Dispose ]
    public void Dispose() {

    }
    #endregion
}
