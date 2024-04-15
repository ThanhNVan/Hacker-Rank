using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace ThiemeMeulenhoff.Platform.WebApi;

public class EanCodeControllerUnitTest : BaseControllerUnitTest<EanCode, IEanCodeLogicProvider, EanCodeController>
{
    #region [ CTor ]
    public EanCodeControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override EanCodeController OnGetController(ILogger<EanCodeController> logger, IEanCodeLogicProvider logic) {
        return new EanCodeController(logger, logic);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    // CreateAndAddAsync
    [Fact]
    public async Task CreateAndAddAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var BaseCode = this._fixture.Create<string>();
        var TitleCode = this._fixture.Create<string>();
        var CheckCode = this._fixture.Create<string>();
        var entity = this._fixture.Create<EanCode>();
        var payload = new EanCodeCreateAndUpdateRequest() {
            BaseCode = BaseCode,
            TitleCode = TitleCode,
            CheckCode = CheckCode,
        };

        this._logic.Setup(x => x.CreateAndAddAsync(BaseCode, TitleCode, CheckCode)).ReturnsAsync(entity);

        // Act
        var actual = await this._controller.CreateAndAddAsync(payload);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.CreateAndAddAsync(BaseCode, TitleCode, CheckCode), Times.Once);
    }

    [Fact]
    public async Task CreateAndAddAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var BaseCode = this._fixture.Create<string>();
        var TitleCode = this._fixture.Create<string>();
        var CheckCode = this._fixture.Create<string>();
        var entity = this._fixture.Create<EanCode>();
        var payload = new EanCodeCreateAndUpdateRequest() {
            BaseCode = BaseCode,
            TitleCode = TitleCode,
            CheckCode = CheckCode,
        };

        this._logic.Setup(x => x.CreateAndAddAsync(BaseCode, TitleCode, CheckCode)).ReturnsAsync(default(EanCode));
        // Act
        var actual = await this._controller.CreateAndAddAsync(payload);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task CreateAndAddAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var BaseCode = this._fixture.Create<string>();
        var TitleCode = this._fixture.Create<string>();
        var CheckCode = this._fixture.Create<string>();
        var entity = this._fixture.Create<EanCode>();
        var payload = new EanCodeCreateAndUpdateRequest() {
            BaseCode = BaseCode,
            TitleCode = TitleCode,
            CheckCode = CheckCode,
        };

        this._logic.Setup(x => x.CreateAndAddAsync(BaseCode, TitleCode, CheckCode)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.CreateAndAddAsync(payload);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task CreateAndAddAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var BaseCode = this._fixture.Create<string>();
        var TitleCode = this._fixture.Create<string>();
        var CheckCode = this._fixture.Create<string>();
        var entity = this._fixture.Create<EanCode>();
        var payload = new EanCodeCreateAndUpdateRequest() {
            BaseCode = BaseCode,
            TitleCode = TitleCode,
            CheckCode = CheckCode,
        };

        this._logic.Setup(x => x.CreateAndAddAsync(BaseCode, TitleCode, CheckCode)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.CreateAndAddAsync(payload);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task CreateAndAddAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var BaseCode = this._fixture.Create<string>();
        var TitleCode = this._fixture.Create<string>();
        var CheckCode = this._fixture.Create<string>();
        var entity = this._fixture.Create<EanCode>();
        var payload = new EanCodeCreateAndUpdateRequest() {
            BaseCode = BaseCode,
            TitleCode = TitleCode,
            CheckCode = CheckCode,
        };

        this._logic.Setup(x => x.CreateAndAddAsync(BaseCode, TitleCode, CheckCode)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.CreateAndAddAsync(payload) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GenerateTitleCodeAsync
    [Fact]
    public async Task GenerateTitleCodeAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var fullcode = this._fixture.Create<string>();
        var entity = this._fixture.Create<EanCode>();
        this._logic.Setup(x => x.GenerateTitleCodeAsync(fullcode)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GenerateTitleCodeAsync(fullcode);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GenerateTitleCodeAsync(fullcode), Times.Once);
    }

    [Fact]
    public async Task GenerateTitleCodeAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var fullcode = this._fixture.Create<string>();
        this._logic.Setup(x => x.GenerateTitleCodeAsync(fullcode)).ReturnsAsync(default(EanCode));
        // Act
        var actual = await this._controller.GenerateTitleCodeAsync(fullcode);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GenerateTitleCodeAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var fullcode = this._fixture.Create<string>();
        this._logic.Setup(x => x.GenerateTitleCodeAsync(fullcode)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GenerateTitleCodeAsync(fullcode);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GenerateTitleCodeAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var fullcode = this._fixture.Create<string>();
        this._logic.Setup(x => x.GenerateTitleCodeAsync(fullcode)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GenerateTitleCodeAsync(fullcode);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GenerateTitleCodeAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var fullcode = this._fixture.Create<string>();
        this._logic.Setup(x => x.GenerateTitleCodeAsync(fullcode)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GenerateTitleCodeAsync(fullcode) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetByBaseCodeAsync
    [Fact]
    public async Task GetByBaseCodeAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var entity = this._fixture.Create<EanCode>();
        this._logic.Setup(x => x.GetByBaseCodeAsync()).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByBaseCodeAsync();

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByBaseCodeAsync(), Times.Once);
    }

    [Fact]
    public async Task GetByBaseCodeAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        this._logic.Setup(x => x.GetByBaseCodeAsync()).ReturnsAsync(default(EanCode));
        // Act
        var actual = await this._controller.GetByBaseCodeAsync();

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByBaseCodeAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        this._logic.Setup(x => x.GetByBaseCodeAsync()).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByBaseCodeAsync();

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByBaseCodeAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        this._logic.Setup(x => x.GetByBaseCodeAsync()).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByBaseCodeAsync();

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByBaseCodeAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        this._logic.Setup(x => x.GetByBaseCodeAsync()).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByBaseCodeAsync() as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetByCodeAsync
    [Fact]
    public async Task GetByCodeAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var fullcode = this._fixture.Create<string>();
        var entity = this._fixture.Create<EanCode>();
        this._logic.Setup(x => x.GetByCodeAsync(fullcode)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByCodeAsync(fullcode);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByCodeAsync(fullcode), Times.Once);
    }

    [Fact]
    public async Task GetByCodeAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var fullcode = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByCodeAsync(fullcode)).ReturnsAsync(default(EanCode));
        // Act
        var actual = await this._controller.GetByCodeAsync(fullcode);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByCodeAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var fullcode = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByCodeAsync(fullcode)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByCodeAsync(fullcode);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByCodeAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var fullcode = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByCodeAsync(fullcode)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByCodeAsync(fullcode);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByCodeAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var fullcode = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByCodeAsync(fullcode)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByCodeAsync(fullcode) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // CreateAndAddTitleCodeAsync
    [Fact]
    public async Task CreateAndAddTitleCodeAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var baseCode = this._fixture.Create<string>();
        var entity = this._fixture.Create<EanCode>();
        this._logic.Setup(x => x.CreateAndAddTitleCodeAsync(baseCode)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.CreateAndAddTitleCodeAsync(baseCode);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.CreateAndAddTitleCodeAsync(baseCode), Times.Once);
    }

    [Fact]
    public async Task CreateAndAddTitleCodeAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var baseCode = this._fixture.Create<string>();
        this._logic.Setup(x => x.CreateAndAddTitleCodeAsync(baseCode)).ReturnsAsync(default(EanCode));
        // Act
        var actual = await this._controller.CreateAndAddTitleCodeAsync(baseCode);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task CreateAndAddTitleCodeAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var baseCode = this._fixture.Create<string>();
        this._logic.Setup(x => x.CreateAndAddTitleCodeAsync(baseCode)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.CreateAndAddTitleCodeAsync(baseCode);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task CreateAndAddTitleCodeAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var baseCode = this._fixture.Create<string>();
        this._logic.Setup(x => x.CreateAndAddTitleCodeAsync(baseCode)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.CreateAndAddTitleCodeAsync(baseCode);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task CreateAndAddTitleCodeAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var baseCode = this._fixture.Create<string>();
        this._logic.Setup(x => x.CreateAndAddTitleCodeAsync(baseCode)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.CreateAndAddTitleCodeAsync(baseCode) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion

    #region [ Public Methods - Custom - List ]
    // GetAllBaseCodeAsync
    [Fact]
    public async Task GetAllBaseCodeAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var entity = this._fixture.Create<List<EanCode>>();
        this._logic.Setup(x => x.GetAllBaseCodeAsync()).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetAllBaseCodeAsync();

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetAllBaseCodeAsync(), Times.Once);
    }

    [Fact]
    public async Task GetAllBaseCodeAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        this._logic.Setup(x => x.GetAllBaseCodeAsync()).ReturnsAsync(default(List<EanCode>));
        // Act
        var actual = await this._controller.GetAllBaseCodeAsync();

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetAllBaseCodeAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        this._logic.Setup(x => x.GetAllBaseCodeAsync()).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetAllBaseCodeAsync();

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetAllBaseCodeAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        this._logic.Setup(x => x.GetAllBaseCodeAsync()).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetAllBaseCodeAsync();

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetAllBaseCodeAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        this._logic.Setup(x => x.GetAllBaseCodeAsync()).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetAllBaseCodeAsync() as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetByBaseCodeAsync
    [Fact]
    public async Task GetByBaseCodeAsync_List_Should_ReturnOk_If_Success() {
        // Arrange
        var baseCode = this._fixture.Create<string>();
        var entity = this._fixture.Create<List<EanCode>>();
        this._logic.Setup(x => x.GetByBaseCodeAsync(baseCode)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByBaseCodeAsync(baseCode);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByBaseCodeAsync(baseCode), Times.Once);
    }

    [Fact]
    public async Task GetByBaseCodeAsync_List_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var baseCode = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByBaseCodeAsync(baseCode)).ReturnsAsync(default(List<EanCode>));
        // Act
        var actual = await this._controller.GetByBaseCodeAsync(baseCode);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetByBaseCodeAsync_List_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var baseCode = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByBaseCodeAsync(baseCode)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByBaseCodeAsync(baseCode);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByBaseCodeAsync_List_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var baseCode = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByBaseCodeAsync(baseCode)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByBaseCodeAsync(baseCode);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByBaseCodeAsync_List_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var baseCode = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByBaseCodeAsync(baseCode)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByBaseCodeAsync(baseCode) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetUnregisteredCodesAsync
    [Fact]
    public async Task GetUnregisteredCodesAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var entity = this._fixture.Create<List<EanCode>>();
        this._logic.Setup(x => x.GetUnregisteredCodesAsync()).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetUnregisteredCodesAsync();

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetUnregisteredCodesAsync(), Times.Once);
    }

    [Fact]
    public async Task GetUnregisteredCodesAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        this._logic.Setup(x => x.GetUnregisteredCodesAsync()).ReturnsAsync(default(List<EanCode>));
        // Act
        var actual = await this._controller.GetUnregisteredCodesAsync();

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetUnregisteredCodesAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        this._logic.Setup(x => x.GetUnregisteredCodesAsync()).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetUnregisteredCodesAsync();

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetUnregisteredCodesAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        this._logic.Setup(x => x.GetUnregisteredCodesAsync()).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetUnregisteredCodesAsync();

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetUnregisteredCodesAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        this._logic.Setup(x => x.GetUnregisteredCodesAsync()).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetUnregisteredCodesAsync() as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetUnregisteredCodesAsync
    [Fact]
    public async Task GetUnregisteredCodesAsync_BaseCode_Should_ReturnOk_If_Success() {
        // Arrange
        var baseCode = this._fixture.Create<string>();
        var entity = this._fixture.Create<List<EanCode>>();
        this._logic.Setup(x => x.GetUnregisteredCodesAsync(baseCode)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetUnregisteredCodesAsync(baseCode);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetUnregisteredCodesAsync(baseCode), Times.Once);
    }

    [Fact]
    public async Task GetUnregisteredCodesAsync_BaseCode_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var baseCode = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetUnregisteredCodesAsync(baseCode)).ReturnsAsync(default(List<EanCode>));
        // Act
        var actual = await this._controller.GetUnregisteredCodesAsync(baseCode);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetUnregisteredCodesAsync_BaseCode_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var baseCode = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetUnregisteredCodesAsync(baseCode)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetUnregisteredCodesAsync(baseCode);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetUnregisteredCodesAsync_BaseCode_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var baseCode = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetUnregisteredCodesAsync(baseCode)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetUnregisteredCodesAsync(baseCode);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetUnregisteredCodesAsync_BaseCode_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var baseCode = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetUnregisteredCodesAsync(baseCode)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetUnregisteredCodesAsync(baseCode) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetAllTitleCodeAsync
    [Fact]
    public async Task GetAllTitleCodeAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var entityList = this._fixture.Create<List<EanCode>>();
        this._logic.Setup(x => x.GetAllTitleCodeAsync()).ReturnsAsync(entityList);
        // Act
        var actual = await this._controller.GetAllTitleCodeAsync();

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetAllTitleCodeAsync(), Times.Once);
    }

    [Fact]
    public async Task GetAllTitleCodeAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        this._logic.Setup(x => x.GetAllTitleCodeAsync()).ReturnsAsync(default(List<EanCode>));
        // Act
        var actual = await this._controller.GetAllTitleCodeAsync();

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetAllTitleCodeAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        this._logic.Setup(x => x.GetAllTitleCodeAsync()).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetAllTitleCodeAsync();

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetAllTitleCodeAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        this._logic.Setup(x => x.GetAllTitleCodeAsync()).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetAllTitleCodeAsync();

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetAllTitleCodeAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        this._logic.Setup(x => x.GetAllTitleCodeAsync()).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetAllTitleCodeAsync() as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetAllTitleCodeAsync
    [Fact]
    public async Task GetAllTitleCodeAsync_List_Should_ReturnOk_If_Success() {
        // Arrange
        var take = this._fixture.Create<int>();
        var skip = this._fixture.Create<int>();
        var entity = this._fixture.Create<List<EanCode>>();
        this._logic.Setup(x => x.GetAllTitleCodeAsync(take, skip)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetAllTitleCodeAsync(take, skip);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetAllTitleCodeAsync(take, skip), Times.Once);
    }

    [Fact]
    public async Task GetAllTitleCodeAsync_List_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var take = this._fixture.Create<int>();
        var skip = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetAllTitleCodeAsync(take, skip)).ReturnsAsync(default(List<EanCode>));
        // Act
        var actual = await this._controller.GetAllTitleCodeAsync(take, skip);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetAllTitleCodeAsync_List_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var take = this._fixture.Create<int>();
        var skip = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetAllTitleCodeAsync(take, skip)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetAllTitleCodeAsync(take, skip);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetAllTitleCodeAsync_List_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var take = this._fixture.Create<int>();
        var skip = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetAllTitleCodeAsync(take, skip)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetAllTitleCodeAsync(take, skip);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetAllTitleCodeAsync_List_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var take = this._fixture.Create<int>();
        var skip = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetAllTitleCodeAsync(take, skip)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetAllTitleCodeAsync(take, skip) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GenerateTitleCodesAsync
    [Fact]
    public async Task GenerateTitleCodesAsync_List_Should_ReturnOk_If_Success() {
        // Arrange
        var baseCode = this._fixture.Create<string>();
        var value = this._fixture.Create<int>();
        var entity = this._fixture.Create<List<EanCode>>();
        this._logic.Setup(x => x.GenerateTitleCodesAsync(baseCode, value)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GenerateTitleCodesAsync(baseCode, value);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GenerateTitleCodesAsync(baseCode, value), Times.Once);
    }

    [Fact]
    public async Task GenerateTitleCodesAsync_List_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var baseCode = this._fixture.Create<string>();
        var value = this._fixture.Create<int>();
        this._logic.Setup(x => x.GenerateTitleCodesAsync(baseCode, value)).ReturnsAsync(default(List<EanCode>));
        // Act
        var actual = await this._controller.GenerateTitleCodesAsync(baseCode, value);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GenerateTitleCodesAsync_List_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var baseCode = this._fixture.Create<string>();
        var value = this._fixture.Create<int>();
        this._logic.Setup(x => x.GenerateTitleCodesAsync(baseCode, value)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GenerateTitleCodesAsync(baseCode, value);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GenerateTitleCodesAsync_List_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var baseCode = this._fixture.Create<string>();
        var value = this._fixture.Create<int>();
        this._logic.Setup(x => x.GenerateTitleCodesAsync(baseCode, value)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GenerateTitleCodesAsync(baseCode, value);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GenerateTitleCodesAsync_List_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var baseCode = this._fixture.Create<string>();
        var value = this._fixture.Create<int>();
        this._logic.Setup(x => x.GenerateTitleCodesAsync(baseCode, value)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GenerateTitleCodesAsync(baseCode, value) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetBySearchFilterAsync
    [Fact]
    public async Task GetBySearchFilterAsync_List_Should_ReturnOk_If_Success() {
        // Arrange
        var searchString = this._fixture.Create<string>();
        var take = this._fixture.Create<int>();
        var skip = this._fixture.Create<int>();
        var entity = this._fixture.Create<List<EanCode>>();
        this._logic.Setup(x => x.GetBySearchFilterAsync(searchString, take, skip)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetBySearchFilterAsync(searchString, take, skip);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetBySearchFilterAsync(searchString, take, skip), Times.Once);
    }

    [Fact]
    public async Task GetBySearchFilterAsync_List_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var searchString = this._fixture.Create<string>();
        var take = this._fixture.Create<int>();
        var skip = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetBySearchFilterAsync(searchString, take, skip)).ReturnsAsync(default(List<EanCode>));
        // Act
        var actual = await this._controller.GetBySearchFilterAsync(searchString, take, skip);

        // Assert
        Assert.IsType<NotFoundResult>(actual);
    }

    [Fact]
    public async Task GetBySearchFilterAsync_List_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var searchString = this._fixture.Create<string>();
        var take = this._fixture.Create<int>();
        var skip = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetBySearchFilterAsync(searchString, take, skip)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetBySearchFilterAsync(searchString, take, skip);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetBySearchFilterAsync_List_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var searchString = this._fixture.Create<string>();
        var take = this._fixture.Create<int>();
        var skip = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetBySearchFilterAsync(searchString, take, skip)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetBySearchFilterAsync(searchString, take, skip);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetBySearchFilterAsync_List_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var searchString = this._fixture.Create<string>();
        var take = this._fixture.Create<int>();
        var skip = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetBySearchFilterAsync(searchString, take, skip)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetBySearchFilterAsync(searchString, take, skip) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion

    #region [ Public Methods - Custom - Add ]
    // AddNewBaseCodeAsync
    [Fact]
    public async Task AddNewBaseCodeAsync_BaseCode_Should_Return200Ok_If_Success() {
        // Arrange
        var entity = SeedProvider.Current.EanCodes.FirstOrDefault(x => x.CodeType == EanCodeType.Base);
        var baseCode = entity.BaseCode;
        var entityList = SeedProvider.Current.EanCodes;
        this._logic.Setup(x => x.GetAllBaseCodeAsync()).ReturnsAsync(entityList);
        // Act
        var actual = await this._controller.AddNewBaseCodeAsync(baseCode) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status200OK, actual.StatusCode);
        this._logic.Verify(x => x.AddNewBaseCodeAsync(baseCode), Times.Once);
    }
    
    [Fact]
    public async Task AddNewBaseCodeAsync_BaseCode_Should_ReturnInternalServerError_If_AddError() {
        // Arrange
        var baseCode = this._fixture.Create<string>();
        var entity = this._fixture.Create<List<EanCode>>();
        this._logic.Setup(x => x.GetAllBaseCodeAsync()).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.AddNewBaseCodeAsync(baseCode) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
        this._logic.Verify(x => x.AddNewBaseCodeAsync(baseCode), Times.Once);
    }

    [Fact]
    public async Task AddNewBaseCodeAsync_BaseCode_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var baseCode = this._fixture.Create<string>();
        this._logic.Setup(x => x.AddNewBaseCodeAsync(baseCode)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.AddNewBaseCodeAsync(baseCode);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task AddNewBaseCodeAsync_BaseCode_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var baseCode = this._fixture.Create<string>();
        this._logic.Setup(x => x.AddNewBaseCodeAsync(baseCode)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.AddNewBaseCodeAsync(baseCode);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task AddNewBaseCodeAsync_BaseCode_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var baseCode = this._fixture.Create<string>();
        this._logic.Setup(x => x.AddNewBaseCodeAsync(baseCode)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.AddNewBaseCodeAsync(baseCode) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // AddRangeAsync
    [Fact]
    public async Task AddRangeAsync_BaseCode_Should_Return200Ok_If_Success() {
        // Arrange
        var eanCodesList = SeedProvider.Current.EanCodes;
        var eanCode = this._fixture.Create<EanCode>();
        this._logic.Setup(x => x.GetAsync(eanCodesList.LastOrDefault().Id)).ReturnsAsync(eanCode);
        // Act
        var actual = await this._controller.AddRangeAsync(eanCodesList) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status200OK, actual.StatusCode);
        this._logic.Verify(x => x.AddRangeAsync(eanCodesList), Times.Once);
    }

    [Fact]
    public async Task AddRangeAsync_BaseCode_Should_ReturnInternalServerError_If_AddError() {
        // Arrange
        var eanCodes = this._fixture.Create<List<EanCode>>();
        this._logic.Setup(x => x.GetAllBaseCodeAsync()).ReturnsAsync(eanCodes);
        // Act
        var actual = await this._controller.AddRangeAsync(eanCodes) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
        this._logic.Verify(x => x.AddRangeAsync(eanCodes), Times.Once);
    }

    [Fact]
    public async Task AddRangeAsync_BaseCode_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var eanCodes = this._fixture.Create<List<EanCode>>();
        this._logic.Setup(x => x.AddRangeAsync(eanCodes)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.AddRangeAsync(eanCodes);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task AddRangeAsync_BaseCode_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var eanCodes = this._fixture.Create<List<EanCode>>();
        this._logic.Setup(x => x.AddRangeAsync(eanCodes)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.AddRangeAsync(eanCodes);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task AddRangeAsync_BaseCode_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var eanCodes = this._fixture.Create<List<EanCode>>();
        this._logic.Setup(x => x.AddRangeAsync(eanCodes)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.AddRangeAsync(eanCodes) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion

    #region [ Public Methods - Custom - Count ]
    // CountAllTitleCodeAsync
    [Fact]
    public async Task CountAllTitleCodeAsync_BaseCode_Should_Return200Ok_If_Success() {
        // Arrange
        var result = this._fixture.Create<int>();
        this._logic.Setup(x => x.CountAllTitleCodeAsync()).ReturnsAsync(result);
        // Act
        var actual = await this._controller.CountAllTitleCodeAsync();

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.CountAllTitleCodeAsync(), Times.Once);
    }

    [Fact]
    public async Task CountAllTitleCodeAsync_BaseCode_Should_ReturnInternalServerError_If_AddError() {
        // Arrange
        var result = -1 ;
        this._logic.Setup(x => x.CountAllTitleCodeAsync()).ReturnsAsync(result);
        // Act
        var actual = await this._controller.CountAllTitleCodeAsync() as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
        this._logic.Verify(x => x.CountAllTitleCodeAsync(), Times.Once);
    }

    [Fact]
    public async Task CountAllTitleCodeAsync_BaseCode_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        this._logic.Setup(x => x.CountAllTitleCodeAsync()).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.CountAllTitleCodeAsync();

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task CountAllTitleCodeAsync_BaseCode_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        this._logic.Setup(x => x.CountAllTitleCodeAsync()).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.CountAllTitleCodeAsync();

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task CountAllTitleCodeAsync_BaseCode_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        this._logic.Setup(x => x.CountAllTitleCodeAsync()).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.CountAllTitleCodeAsync() as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    
    // CountBySearchFilterAsync
    [Fact]
    public async Task CountBySearchFilterAsync_BaseCode_Should_Return200Ok_If_Success() {
        // Arrange
        var result = this._fixture.Create<int>();
        var searchString = this._fixture.Create<string>();
        this._logic.Setup(x => x.CountBySearchFilterAsync(searchString)).ReturnsAsync(result);
        // Act
        var actual = await this._controller.CountBySearchFilterAsync(searchString);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.CountBySearchFilterAsync(searchString), Times.Once);
    }

    [Fact]
    public async Task CountBySearchFilterAsync_BaseCode_Should_ReturnInternalServerError_If_AddError() {
        // Arrange
        var result = -1;
        var searchString = this._fixture.Create<string>();
        this._logic.Setup(x => x.CountBySearchFilterAsync(searchString)).ReturnsAsync(result);
        // Act
        var actual = await this._controller.CountBySearchFilterAsync(searchString) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
        this._logic.Verify(x => x.CountBySearchFilterAsync(searchString), Times.Once);
    }

    [Fact]
    public async Task CountBySearchFilterAsync_BaseCode_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var searchString = this._fixture.Create<string>();
        this._logic.Setup(x => x.CountBySearchFilterAsync(searchString)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.CountBySearchFilterAsync(searchString);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task CountBySearchFilterAsync_BaseCode_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var searchString = this._fixture.Create<string>();
        this._logic.Setup(x => x.CountBySearchFilterAsync(searchString)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.CountBySearchFilterAsync(searchString);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task CountBySearchFilterAsync_BaseCode_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var searchString = this._fixture.Create<string>();
        this._logic.Setup(x => x.CountBySearchFilterAsync(searchString)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.CountBySearchFilterAsync(searchString) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion
}
