using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using RCode;
using Xunit;

namespace ThiemeMeulenhoff.Platform.WebApi;

public class AddressControllerUnitTest : BaseControllerUnitTest<Address, IAddressLogicProvider, AddressController>
{
    #region [ CTor ]
    public AddressControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override]
    protected override AddressController OnGetController(ILogger<AddressController> logger, IAddressLogicProvider logic) {
        return new AddressController(logger, logic);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    // GetByAfasAddressIdAsync
    [Fact]
    public async Task GetByAfasAddressIdAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var entity = SeedProvider.Current.Addresses.FirstOrDefault();
        var expected = SeedProvider.Current.Addresses.FirstOrDefault(x =>
                                        x.AfasAddressId == entity.AfasAddressId &&
                                        x.AfasContactNumber == entity.AfasContactNumber &&
                                        x.AddressType == entity.AddressType);
        var addressType = Enum.Parse<AddressType>(entity.AddressType);
        this._logic.Setup(x => x.GetByAfasAddressIdAsync(entity.AfasAddressId, entity.AfasContactNumber, addressType)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByAfasAddressIdAsync(entity.AfasAddressId, entity.AfasContactNumber, addressType);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByAfasAddressIdAsync(entity.AfasAddressId, entity.AfasContactNumber, addressType), Times.Once);
    }

    [Fact]
    public async Task GetByAfasAddressIdAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var entity = SeedProvider.Current.Addresses.FirstOrDefault();
        var expected = SeedProvider.Current.Addresses.FirstOrDefault(x =>
                                        x.AfasAddressId == entity.AfasAddressId &&
                                        x.AfasContactNumber == entity.AfasContactNumber &&
                                        x.AddressType == entity.AddressType);
        var addressType = Enum.Parse<AddressType>(entity.AddressType);
        var id = IdFactory.CreateId();
        this._logic.Setup(x => x.GetByAfasAddressIdAsync(id, id, addressType)).ReturnsAsync(default(Address));
        // Act
        var actual = await this._controller.GetByAfasAddressIdAsync(id, id, addressType);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetByAfasAddressIdAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var entity = SeedProvider.Current.Addresses.FirstOrDefault();
        var expected = SeedProvider.Current.Addresses.FirstOrDefault(x =>
                                        x.AfasAddressId == entity.AfasAddressId &&
                                        x.AfasContactNumber == entity.AfasContactNumber &&
                                        x.AddressType == entity.AddressType);
        var addressType = Enum.Parse<AddressType>(entity.AddressType);
        var id = IdFactory.CreateId();
        this._logic.Setup(x => x.GetByAfasAddressIdAsync(id, id, addressType)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByAfasAddressIdAsync(id, id, addressType);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByAfasAddressIdAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var entity = SeedProvider.Current.Addresses.FirstOrDefault();
        var expected = SeedProvider.Current.Addresses.FirstOrDefault(x =>
                                        x.AfasAddressId == entity.AfasAddressId &&
                                        x.AfasContactNumber == entity.AfasContactNumber &&
                                        x.AddressType == entity.AddressType);
        var addressType = Enum.Parse<AddressType>(entity.AddressType);
        var id = IdFactory.CreateId();
        this._logic.Setup(x => x.GetByAfasAddressIdAsync(id, id, addressType)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByAfasAddressIdAsync(id, id, addressType);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByAfasAddressIdAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var entity = SeedProvider.Current.Addresses.FirstOrDefault();
        var expected = SeedProvider.Current.Addresses.FirstOrDefault(x =>
                                        x.AfasAddressId == entity.AfasAddressId &&
                                        x.AfasContactNumber == entity.AfasContactNumber &&
                                        x.AddressType == entity.AddressType);
        var addressType = Enum.Parse<AddressType>(entity.AddressType);
        var id = IdFactory.CreateId();
        this._logic.Setup(x => x.GetByAfasAddressIdAsync(id, id, addressType)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByAfasAddressIdAsync(id, id, addressType) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    // GetByOwnerAsync
    [Fact]
    public async Task GetByOwnerAsync_Should_ReturnOk_If_Success() {
        // Arrange
        var entity = SeedProvider.Current.Addresses.FirstOrDefault();
        var expected = SeedProvider.Current.Addresses.FirstOrDefault(x =>
                                        x.OwnerContactId == entity.OwnerContactId &&
                                        x.AddressType == entity.AddressType);
        var addressType = Enum.Parse<AddressType>(entity.AddressType);
        this._logic.Setup(x => x.GetByOwnerAsync(entity.OwnerContactId, addressType)).ReturnsAsync(entity);
        // Act
        var actual = await this._controller.GetByOwnerAsync(entity.OwnerContactId, addressType);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        this._logic.Verify(x => x.GetByOwnerAsync(entity.OwnerContactId, addressType), Times.Once);
    }

    [Fact]
    public async Task GetByOwnerAsync_Should_ReturnNotFound_If_NotFound() {
        // Arrange
        var entity = SeedProvider.Current.Addresses.FirstOrDefault();
        var expected = SeedProvider.Current.Addresses.FirstOrDefault(x =>
                                        x.OwnerContactId == entity.OwnerContactId &&
                                        x.AddressType == entity.AddressType);
        var addressType = Enum.Parse<AddressType>(entity.AddressType);
        var id = IdFactory.CreateId();
        this._logic.Setup(x => x.GetByOwnerAsync(id, addressType)).ReturnsAsync(default(Address));
        // Act
        var actual = await this._controller.GetByOwnerAsync(id, addressType);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetByOwnerAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var entity = SeedProvider.Current.Addresses.FirstOrDefault();
        var expected = SeedProvider.Current.Addresses.FirstOrDefault(x =>
                                        x.OwnerContactId == entity.OwnerContactId &&
                                        x.AddressType == entity.AddressType);
        var addressType = Enum.Parse<AddressType>(entity.AddressType);
        var id = IdFactory.CreateId();
        this._logic.Setup(x => x.GetByOwnerAsync(id, addressType)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByOwnerAsync(id, addressType);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }

    [Fact]
    public async Task GetByOwnerAsync_Should_ReturnBadRequest_If_ArgumentNullException() {
        // Arrange
        var entity = SeedProvider.Current.Addresses.FirstOrDefault();
        var expected = SeedProvider.Current.Addresses.FirstOrDefault(x =>
                                        x.OwnerContactId == entity.OwnerContactId &&
                                        x.AddressType == entity.AddressType);
        var addressType = Enum.Parse<AddressType>(entity.AddressType);
        var id = IdFactory.CreateId();
        this._logic.Setup(x => x.GetByOwnerAsync(id, addressType)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByOwnerAsync(id, addressType);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByOwnerAsync_Should_ReturnInternalServerError_If_Exception() {
        // Arrange
        var entity = SeedProvider.Current.Addresses.FirstOrDefault();
        var expected = SeedProvider.Current.Addresses.FirstOrDefault(x =>
                                        x.OwnerContactId == entity.OwnerContactId &&
                                        x.AddressType == entity.AddressType);
        var addressType = Enum.Parse<AddressType>(entity.AddressType);
        var id = IdFactory.CreateId();
        this._logic.Setup(x => x.GetByOwnerAsync(id, addressType)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByOwnerAsync(id, addressType) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }
    #endregion

    #region [ Public Methods - Custom - Lists ]
    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ReturnOk_Success() {
        // Arrange
        var afasContactNumber = this._fixture.Create<string>();
        var result = this._fixture.Create<List<Address>>();
        this._logic.Setup(x => x.GetByAfasContactNumberAsync(afasContactNumber)).ReturnsAsync(result);

        // Act
        var actual = await this._controller.GetByAfasContactNumberAsync(afasContactNumber);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ReturnNotFound_If_Empty() {
        // Arrange
        var afasContactNumber = this._fixture.Create<string>();
        var result = default(List<Address>);
        this._logic.Setup(x => x.GetByAfasContactNumberAsync(afasContactNumber)).ReturnsAsync(result);

        // Act
        var actual = await this._controller.GetByAfasContactNumberAsync(afasContactNumber);

        // Assert
        Assert.IsType<NotFoundObjectResult>(actual);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ReturnInternalServerError_If_Error() {
        // Arrange
        var afasContactNumber = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasContactNumberAsync(afasContactNumber)).ThrowsAsync(new Exception());

        // Act
        var actual = await this._controller.GetByAfasContactNumberAsync(afasContactNumber) as StatusCodeResult;

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, actual.StatusCode);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ReturnBadRequest_If_NotValidParam() {
        // Arrange
        var afasContactNumber = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasContactNumberAsync(afasContactNumber)).ThrowsAsync(new ArgumentNullException());

        // Act
        var actual = await this._controller.GetByAfasContactNumberAsync(afasContactNumber);

        // Assert
        Assert.IsType<BadRequestResult>(actual);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ReturnUnauthorized_If_Unauthorized() {
        // Arrange
        var afasContactNumber = this._fixture.Create<string>();
        this._logic.Setup(x => x.GetByAfasContactNumberAsync(afasContactNumber)).ThrowsAsync(new UnauthorizedAccessException());

        // Act
        var actual = await this._controller.GetByAfasContactNumberAsync(afasContactNumber);

        // Assert
        Assert.IsType<UnauthorizedResult>(actual);
    }
    #endregion
}
