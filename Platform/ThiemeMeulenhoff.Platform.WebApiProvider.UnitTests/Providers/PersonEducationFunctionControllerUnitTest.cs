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

public class PersonEducationFunctionControllerUnitTest : BaseControllerUnitTest<PersonEducationFunction, IPersonEducationFunctionLogicProvider, PersonEducationFunctionController>
{
    #region [ CTor ]
    public PersonEducationFunctionControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override PersonEducationFunctionController OnGetController(ILogger<PersonEducationFunctionController> logger, IPersonEducationFunctionLogicProvider logic) {
        return new PersonEducationFunctionController(logger, logic);
    }
    #endregion

    #region [ Public Methods - Custom _ Single ]
    // GetByPersonAndOrganisationAsync
    [Fact]
    public async Task GetByPersonAndOrganisationAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var personId = this._fixture.Create<string>();
        var organizationId = this._fixture.Create<string>();
        var entity = this._fixture.Create<PersonEducationFunction>();
        this._logic.Setup(x => x.GetByPersonAndOrganisationAsync(personId, organizationId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByPersonAndOrganisationAsync(personId, organizationId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByPersonAndOrganisationAsync(personId, organizationId), Times.Once);
    }

    [Fact]
    public async Task GetByPersonAndOrganisationAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var personId = this._fixture.Create<string>();
        var organizationId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByPersonAndOrganisationAsync(personId, organizationId)).ReturnsAsync(default(PersonEducationFunction));
        // Act
        var actual = await this._controller.GetByPersonAndOrganisationAsync(personId, organizationId);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetByPersonAndOrganisationAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var personId = this._fixture.Create<string>();
        var organizationId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByPersonAndOrganisationAsync(personId, organizationId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByPersonAndOrganisationAsync(personId, organizationId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByPersonAndOrganisationAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var personId = this._fixture.Create<string>();
        var organizationId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByPersonAndOrganisationAsync(personId, organizationId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByPersonAndOrganisationAsync(personId, organizationId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByPersonAndOrganisationAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var personId = this._fixture.Create<string>();
        var organizationId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByPersonAndOrganisationAsync(personId, organizationId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByPersonAndOrganisationAsync(personId, organizationId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion

    #region [ Public Methods - Custom - Lists ]
    // GetByPersonAsync
    [Fact]
    public async Task GetByPersonAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var personId = this._fixture.Create<string>();
        var entity = this._fixture.Create<List<PersonEducationFunction>>();
        this._logic.Setup(x => x.GetByPersonAsync(personId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByPersonAsync(personId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByPersonAsync(personId), Times.Once);
    }

    [Fact]
    public async Task GetByPersonAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var personId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByPersonAsync(personId)).ReturnsAsync(default(List<PersonEducationFunction>));
        // Act
        var actual = await this._controller.GetByPersonAsync(personId);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetByPersonAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var personId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByPersonAsync(personId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByPersonAsync(personId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByPersonAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var personId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByPersonAsync(personId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByPersonAsync(personId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByPersonAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var personId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByPersonAsync(personId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByPersonAsync(personId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetByOrganizationAsync
    [Fact]
    public async Task GetByOrganizationAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var organizationId = this._fixture.Create<string>();
        var entity = this._fixture.Create<List<PersonEducationFunction>>();
        this._logic.Setup(x => x.GetByOrganizationAsync(organizationId)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByOrganizationAsync(organizationId);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByOrganizationAsync(organizationId), Times.Once);
    }

    [Fact]
    public async Task GetByOrganizationAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var organizationId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOrganizationAsync(organizationId)).ReturnsAsync(default(List<PersonEducationFunction>));
        // Act
        var actual = await this._controller.GetByOrganizationAsync(organizationId);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetByOrganizationAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var organizationId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOrganizationAsync(organizationId)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByOrganizationAsync(organizationId);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByOrganizationAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var organizationId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOrganizationAsync(organizationId)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByOrganizationAsync(organizationId);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByOrganizationAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var organizationId = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOrganizationAsync(organizationId)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByOrganizationAsync(organizationId) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion
}
