using System.Net;
using Newtonsoft.Json;
using RCode;
using ThiemeMeulenhoff.Platform.WebApi;
using Xunit;

namespace ThiemeMeulenhoff.Platform.IntegrationTests;

[Collection("IntegrationTest")]
[CollectionDefinition(nameof(AddressControllerIntegrationTest), DisableParallelization = true)]
public class AddressControllerIntegrationTest : BaseIntegrationTest<Address, AddressController, IAddressLogicProvider>
{
    #region [ CTor ]
    public AddressControllerIntegrationTest(CustomWebApplicationFactoryClass<Program> appFactory) : base(appFactory, SeedProvider.Current.Addresses) {

    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public virtual async Task GetByAfasAddressIdAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var entity = this.Entities.FirstOrDefault();
        var addressType = (AddressType)Enum.Parse(typeof(AddressType), entity.AddressType);
        var url = this.GetUrlEndpoint(typeof(AddressController), nameof(this._controller.GetByAfasAddressIdAsync), entity.AfasAddressId, entity.AfasContactNumber, ((int)addressType).ToString());

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var dbEntity = await this._logicProvider.GetByAfasAddressIdAsync(entity.AfasAddressId, entity.AfasContactNumber, addressType);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(dbEntity.Id, entity.Id);
        Assert.Equal(entity.CreatedAt.ToShortDateString(), dbEntity.CreatedAt.ToShortDateString());
        Assert.Equal(dbEntity.IsActive, entity.IsActive);
    }

    [Fact]
    public virtual async Task GetByAfasAddressIdAsync_Should_ReturnStatusCode404NotFound_If_NotFound() {
        // Arrange
        var id = IdFactory.CreateId();
        var addressType = ((AddressType)(new Random()).Next(0, 4)).ToString();
        var url = this.GetUrlEndpoint(typeof(AddressController), nameof(this._controller.GetByAfasAddressIdAsync), id, id, addressType);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public virtual async Task GetByOwnerAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var entity = this.Entities.FirstOrDefault();
        var addressType = (AddressType)Enum.Parse(typeof(AddressType), entity.AddressType);
        var url = this.GetUrlEndpoint(typeof(AddressController), nameof(this._controller.GetByOwnerAsync), entity.OwnerContactId, ((int)addressType).ToString());

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var dbEntity = await this._logicProvider.GetByOwnerAsync(entity.OwnerContactId, addressType);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(dbEntity.Id, entity.Id);
        Assert.Equal(entity.CreatedAt.ToShortDateString(), dbEntity.CreatedAt.ToShortDateString());
        Assert.Equal(dbEntity.IsActive, entity.IsActive);
    }

    [Fact]
    public virtual async Task GetByOwnerAsync_Should_ReturnStatusCode404NotFound_If_NotFound() {
        // Arrange
        var id = IdFactory.CreateId();
        var addressType = ((AddressType)(new Random()).Next(0, 4)).ToString();
        var url = this.GetUrlEndpoint(typeof(AddressController), nameof(this._controller.GetByOwnerAsync), id, addressType);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion

    #region [ Public Methods - Custom - Lists ]
    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var entity = SeedProvider.Current.Addresses.FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof(AddressController), nameof(this._controller.GetByAfasContactNumberAsync), entity.AfasContactNumber);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<List<Address>>(await response.Content.ReadAsStringAsync());
        var expected = await this._logicProvider.GetByAfasContactNumberAsync(entity.AfasContactNumber);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected.Count, actual.Count);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ReturnStatusCode404NotFound_If_NotFound() {
        // Arrange
        var afasContactNumber = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(AddressController), nameof(this._controller.GetByAfasContactNumberAsync), afasContactNumber);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion
}
