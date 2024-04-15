using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using System.Threading.Tasks;

namespace ThiemeMeulenhoff.Platform.WebApi;

public class OrganizationControllerUnitTest : BaseControllerUnitTest<Organization, IOrganizationLogicProvider, OrganizationController>
{
    #region [ CTor ]
    public OrganizationControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override OrganizationController OnGetController(ILogger<OrganizationController> logger, IOrganizationLogicProvider logic) {
        return new OrganizationController(logger, logic);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    // GetByAfasContactNumberAsync
    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var contactNumber = this._fixture.Create<string>();
        var entity = this._fixture.Create<Organization>();
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
        this._logic.Setup(x => x.GetByAfasContactNumberAsync(contactNumber)).ReturnsAsync(default(Organization));
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
        var entity = this._fixture.Create<Organization>();
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
        this._logic.Setup(x => x.GetByAssuNumberAsync(assuNumber)).ReturnsAsync(default(Organization));
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

    // GetByCbPartijIdAsync
    [Fact]
    public async Task GetByCbPartijIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var cbPartijId = this._fixture.Create<string>();
        var entity = this._fixture.Create<Organization>();
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
        this._logic.Setup(x => x.GetByCbPartijIdAsync(cbPartijId)).ReturnsAsync(default(Organization));
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
        var entity = this._fixture.Create<Organization>();
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
        this._logic.Setup(x => x.GetByPropellerIdAsync(propellerId)).ReturnsAsync(default(Organization));
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
    
    // GetByOrganizationNameAsync
    [Fact]
    public async Task GetByOrganizationNameAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var organizationName = this._fixture.Create<string>();
        var entity = this._fixture.Create<Organization>();
        this._logic.Setup(x => x.GetByOrganizationNameAsync(organizationName)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByOrganizationNameAsync(organizationName);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByOrganizationNameAsync(organizationName), Times.Once);
    }

    [Fact]
    public async Task GetByOrganizationNameAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var organizationName = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOrganizationNameAsync(organizationName)).ReturnsAsync(default(Organization));
        // Act
        var actual = await this._controller.GetByOrganizationNameAsync(organizationName);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetByOrganizationNameAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var organizationName = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOrganizationNameAsync(organizationName)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByOrganizationNameAsync(organizationName);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByOrganizationNameAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var organizationName = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOrganizationNameAsync(organizationName)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByOrganizationNameAsync(organizationName);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByOrganizationNameAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var organizationName = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByOrganizationNameAsync(organizationName)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByOrganizationNameAsync(organizationName) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion
}
