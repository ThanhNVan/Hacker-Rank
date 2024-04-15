using System.Net;
using Newtonsoft.Json;
using RCode;
using ThiemeMeulenhoff.Platform.WebApi;
using Xunit;

namespace ThiemeMeulenhoff.Platform.IntegrationTests;

public class EntityApplicationKeyControllerIntegrationTest : BaseIntegrationTest<EntityApplicationKey, EntityApplicationKeyController, IEntityApplicationKeyLogicProvider>
{
    #region [ CTor ]
    public EntityApplicationKeyControllerIntegrationTest(CustomWebApplicationFactoryClass<Program> appFactory) : base(appFactory, SeedProvider.Current.EntityApplicationKeys) {

    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByApplicationKeyAsync_Should_ReturnStatusCode200Ok_If_IsSuccess() {
        // Arrange
        var entity = this.Entities.FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof(EntityApplicationKeyController), nameof(this._controller.GetByApplicationKeyAsync), entity.ApplicationName, entity.ApplicationKey);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<EntityApplicationKey>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(actual.Id, entity.Id);
        Assert.Equal(actual.IsActive, entity.IsActive);
    }
    
    [Fact]
    public async Task GetByApplicationKeyAsync_Should_ReturnStatusCode404NotFound_If_IsNotFound() {
        // Arrange
        var entity = this.Entities.FirstOrDefault();
        var applicationName = entity.ApplicationName.Substring(0, entity.ApplicationName.Count() - 1);
        var applicationKey = entity.ApplicationKey.Substring(0, entity.ApplicationKey.Count() - 1);
        var url = this.GetUrlEndpoint(typeof(EntityApplicationKeyController), nameof(this._controller.GetByApplicationKeyAsync), applicationName, applicationKey);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetByEntityIdAsync_Should_ReturnStatusCode200Ok_If_IsSuccess() {
        // Arrange
        var entity = this.Entities.FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof(EntityApplicationKeyController), nameof(this._controller.GetByEntityIdAsync), entity.ApplicationName, entity.EntityId);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<EntityApplicationKey>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(actual.Id, entity.Id);
        Assert.Equal(actual.IsActive, entity.IsActive);
    }

    [Fact]
    public async Task GetByEntityIdAsync_Should_ReturnStatusCode404NotFound_If_IsNotFound() {
        // Arrange
        var entity = this.Entities.FirstOrDefault();
        var applicationName = "AA";
        var entityId = "BB";
        var url = this.GetUrlEndpoint(typeof(EntityApplicationKeyController), nameof(this._controller.GetByEntityIdAsync), applicationName, entityId);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion

    #region [ Public Methods - Custom - List ]
    [Fact]
    public async Task GetByEntityIdAsync_Entity_Should_ReturnStatusCode200Ok_If_IsSuccess() {
        // Arrange
        var entity = this.Entities.FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof(EntityApplicationKeyController), nameof(this._controller.GetByEntityIdAsync), entity.EntityId, entity.EntityId)
                    .Replace($"applicationName={entity.Id}&&", "");
        var expected = await this._logicProvider.GetByEntityIdAsync(entity.EntityId);
        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<List<EntityApplicationKey>>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected.Count, actual.Count);
    }
    
    [Fact]
    public async Task GetByEntityIdAsync_Entity_Should_ReturnStatusCode404NotFound_If_IsNotFound() {
        // Arrange
        var entityId = this.Entities.FirstOrDefault().Id.Substring(0, 16);
        var url = this.GetUrlEndpoint(typeof(EntityApplicationKeyController), nameof(this._controller.GetByEntityIdAsync), entityId, entityId)
                    .Replace($"applicationName={entityId}&&", "");
        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion
}
