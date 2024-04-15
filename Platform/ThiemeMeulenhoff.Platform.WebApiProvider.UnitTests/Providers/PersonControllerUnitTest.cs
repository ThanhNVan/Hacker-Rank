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

public class PersonControllerUnitTest : BaseControllerUnitTest<Person, IPersonLogicProvider, PersonController>
{
    #region [ CTor ]
    public PersonControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override PersonController OnGetController(ILogger<PersonController> logger, IPersonLogicProvider logic) {
        return new PersonController(logger, logic);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    // GetByAfasContactNumberAsync
    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var contactNumber = this._fixture.Create<string>();
        var entity = this._fixture.Create<Person>();
        this._logic.Setup(x => x.GetByAfasContactNumberAsync(contactNumber)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByAfasContactNumberAsync(contactNumber);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByAfasContactNumberAsync(contactNumber), Times.Once);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var contactNumber = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasContactNumberAsync(contactNumber)).ReturnsAsync(default(Person));
        // Act
        var actual = await this._controller.GetByAfasContactNumberAsync(contactNumber);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var contactNumber = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasContactNumberAsync(contactNumber)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByAfasContactNumberAsync(contactNumber);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var contactNumber = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasContactNumberAsync(contactNumber)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByAfasContactNumberAsync(contactNumber);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var contactNumber = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasContactNumberAsync(contactNumber)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByAfasContactNumberAsync(contactNumber) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetByAssuNumberAsync
    [Fact]
    public async Task GetByAssuNumberAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var assuNumber = this._fixture.Create<int>();
        var entity = this._fixture.Create<Person>();
        this._logic.Setup(x => x.GetByAssuNumberAsync(assuNumber)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByAssuNumberAsync(assuNumber);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByAssuNumberAsync(assuNumber), Times.Once);
    }

    [Fact]
    public async Task GetByAssuNumberAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var assuNumber = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetByAssuNumberAsync(assuNumber)).ReturnsAsync(default(Person));
        // Act
        var actual = await this._controller.GetByAssuNumberAsync(assuNumber);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetByAssuNumberAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var assuNumber = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetByAssuNumberAsync(assuNumber)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByAssuNumberAsync(assuNumber);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByAssuNumberAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var assuNumber = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetByAssuNumberAsync(assuNumber)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByAssuNumberAsync(assuNumber);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByAssuNumberAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var assuNumber = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetByAssuNumberAsync(assuNumber)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByAssuNumberAsync(assuNumber) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    
    // GetByAssuNumberTempAsync
    [Fact]
    public async Task GetByAssuNumberTempAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var assuNumberTemp = this._fixture.Create<int>();
        var entity = this._fixture.Create<Person>();
        this._logic.Setup(x => x.GetByAssuNumberTempAsync(assuNumberTemp)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByAssuNumberTempAsync(assuNumberTemp);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByAssuNumberTempAsync(assuNumberTemp), Times.Once);
    }

    [Fact]
    public async Task GetByAssuNumberTempAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var assuNumberTemp = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetByAssuNumberTempAsync(assuNumberTemp)).ReturnsAsync(default(Person));
        // Act
        var actual = await this._controller.GetByAssuNumberTempAsync(assuNumberTemp);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetByAssuNumberTempAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var assuNumberTemp = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetByAssuNumberTempAsync(assuNumberTemp)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByAssuNumberTempAsync(assuNumberTemp);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByAssuNumberTempAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var assuNumberTemp = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetByAssuNumberTempAsync(assuNumberTemp)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByAssuNumberTempAsync(assuNumberTemp);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByAssuNumberTempAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var assuNumberTemp = this._fixture.Create<int>();
        this._logic.Setup(x => x.GetByAssuNumberTempAsync(assuNumberTemp)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByAssuNumberTempAsync(assuNumberTemp) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetByCbPartijIdAsync
    [Fact]
    public async Task GetByCbPartijIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var cbPartijId = this._fixture.Create<string>();
        var entity = this._fixture.Create<Person>();
        this._logic.Setup(x => x.GetByCbPartijIdAsync(cbPartijId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByCbPartijIdAsync(cbPartijId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByCbPartijIdAsync(cbPartijId), Times.Once);
    }

    [Fact]
    public async Task GetByCbPartijIdAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var cbPartijId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByCbPartijIdAsync(cbPartijId)).ReturnsAsync(default(Person));
        // Act
        var actual = await this._controller.GetByCbPartijIdAsync(cbPartijId);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetByCbPartijIdAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var cbPartijId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByCbPartijIdAsync(cbPartijId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByCbPartijIdAsync(cbPartijId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByCbPartijIdAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var cbPartijId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByCbPartijIdAsync(cbPartijId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByCbPartijIdAsync(cbPartijId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByCbPartijIdAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var cbPartijId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByCbPartijIdAsync(cbPartijId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByCbPartijIdAsync(cbPartijId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetByPropellerIdAsync
    [Fact]
    public async Task GetByPropellerIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var propellerId = this._fixture.Create<string>();
        var entity = this._fixture.Create<Person>();
        this._logic.Setup(x => x.GetByPropellerIdAsync(propellerId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByPropellerIdAsync(propellerId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByPropellerIdAsync(propellerId), Times.Once);
    }

    [Fact]
    public async Task GetByPropellerIdAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var propellerId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByPropellerIdAsync(propellerId)).ReturnsAsync(default(Person));
        // Act
        var actual = await this._controller.GetByPropellerIdAsync(propellerId);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetByPropellerIdAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var propellerId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByPropellerIdAsync(propellerId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByPropellerIdAsync(propellerId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByPropellerIdAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var propellerId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByPropellerIdAsync(propellerId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByPropellerIdAsync(propellerId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByPropellerIdAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var propellerId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByPropellerIdAsync(propellerId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByPropellerIdAsync(propellerId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion

}
