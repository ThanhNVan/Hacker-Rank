using Newtonsoft.Json;
using System.Net;
using ThiemeMeulenhoff.Platform.WebApi;
using Xunit;

namespace ThiemeMeulenhoff.Platform.IntegrationTests;

public class PersonControllerIntegrationTest : BaseIntegrationTest<Person, PersonController, IPersonLogicProvider>
{
    #region [ CTor ]
    public PersonControllerIntegrationTest(CustomWebApplicationFactoryClass<Program> appFactory) : base(appFactory, SeedProvider.Current.Persons) {

    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var afasContactNumber = this.Entities.FirstOrDefault().AfasContactNumber;
        var entity = await this._logicProvider.GetByAfasContactNumberAsync(afasContactNumber);
        var url = this.GetUrlEndpoint(typeof(PersonController), nameof(this._controller.GetByAfasContactNumberAsync), afasContactNumber);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<Person>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(actual.Id, entity.Id);
        Assert.Equal(entity.CreatedAt.ToShortDateString(), actual.CreatedAt.ToShortDateString());
        Assert.Equal(actual.IsActive, entity.IsActive);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ReturnStatusCode404NotFound_If_IsNotFound() {
        // Arrange
        var afasContactNumber = Guid.NewGuid().ToString();
        var url = this.GetUrlEndpoint(typeof(PersonController), nameof(this._controller.GetByAfasContactNumberAsync), afasContactNumber);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetByCbPartijIdAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var CbPartijId = this.Entities.FirstOrDefault().CbPartijId;
        var entity = await this._logicProvider.GetByCbPartijIdAsync(CbPartijId);
        var url = this.GetUrlEndpoint(typeof(PersonController), nameof(this._controller.GetByCbPartijIdAsync), CbPartijId);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<Person>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(actual.Id, entity.Id);
        Assert.Equal(entity.CreatedAt.ToShortDateString(), actual.CreatedAt.ToShortDateString());
        Assert.Equal(actual.IsActive, entity.IsActive);
    }

    [Fact]
    public async Task GetByCbPartijIdAsync_Should_ReturnStatusCode404NotFound_If_IsNotFound() {
        // Arrange
        var CbPartijId = this.Entities.FirstOrDefault().CbPartijId.Substring(0, new Random().Next(1, 16));
        var url = this.GetUrlEndpoint(typeof(PersonController), nameof(this._controller.GetByCbPartijIdAsync), CbPartijId);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion
}

