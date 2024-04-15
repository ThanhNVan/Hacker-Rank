using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RCode;
using RCode.Data;
using RCode.Data.Paging;
using ThiemeMeulenhoff.Platform.WebApi;
using Xunit;

namespace ThiemeMeulenhoff.Platform.IntegrationTests;

[Collection("IntegrationTest")]
[CollectionDefinition(nameof(BaseIntegrationTest<TEntity, TController, TLogicProvider>), DisableParallelization = true)]
public abstract class BaseIntegrationTest<TEntity, TController, TLogicProvider> : IClassFixture<CustomWebApplicationFactoryClass<Program>>, IAsyncLifetime
    where TEntity : BaseEntity
    where TLogicProvider : IThiemeEntityLogicProvider<TEntity>
    where TController : BaseThiemenMeulenhoffController<TEntity, TLogicProvider>

{
    #region [ Fields ]
    protected const string _apiVersion = "1.0";
    protected readonly WebApplicationFactory<Program> _appFactory;
    protected readonly LogicContext _logicContext;
    protected readonly IDbContextFactory<ThiemeMeulenhoffPlatformDbContext> _dbContextFactory;
    protected readonly IDatabaseProvider _databaseProvider;
    protected readonly TLogicProvider _logicProvider;
    protected readonly TController _controller;
    #endregion

    #region [ CTor ]
    public BaseIntegrationTest(CustomWebApplicationFactoryClass<Program> appFactory, List<TEntity> entities)
    {
        this._appFactory = appFactory;
        this._logicContext = _appFactory.Services.GetRequiredService<LogicContext>();
        this._dbContextFactory = this._appFactory.Services.GetRequiredService<IDbContextFactory<ThiemeMeulenhoffPlatformDbContext>>();
        this._databaseProvider = this._appFactory.Services.GetRequiredService<IDatabaseProvider>();
        this._logicProvider = this._appFactory.Services.GetRequiredService<TLogicProvider>();
        this.Entities = entities;
    }
    #endregion

    #region [ Properties ] 
    protected List<TEntity> Entities { get; set; }
    #endregion

    #region [ Test Methods - SaveAsync ]
    [Fact]
    public virtual async Task SaveAsync_Should_ReturnStatusCode200Ok_If_AddSuccess()
    {
        // Arrange
        var entity = Entities.FirstOrDefault();
        var id = IdFactory.CreateId();
        entity.Id = id;
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.SaveAsync));


        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsJsonAsync(url, entity);
        var dbEntity = await this._logicProvider.GetAsync(id);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(id, dbEntity.Id);
        Assert.Equal(entity.IsActive, dbEntity.IsActive);
        Assert.Equal(entity.CreatedAt.ToShortDateString(), dbEntity.CreatedAt.ToShortDateString());
    }

    [Fact]
    public virtual async Task SaveAsync_Should_ReturnStatusCode400BadRequest_If_Param_Entity_IsNull()
    {
        // Arrange
        var entity = default(TEntity);
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.SaveAsync));

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsJsonAsync(url, entity);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public virtual async Task SaveAsync_Should_ReturnStatusCode200Ok_If_UpdateSuccess()
    {
        // Arrange
        var entity = this.Entities.LastOrDefault();
        entity.IsActive = false;
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.SaveAsync));
        var payload = this.GetJsonPayload(entity);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsync(url, payload);
        var dbEntity = await this._logicProvider.GetAsync(entity.Id);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(entity.Id, dbEntity.Id);
        Assert.Equal(entity.IsActive, dbEntity.IsActive);
    }
    #endregion

    #region [ Methods - SyncAsync ]
    [Fact]
    public virtual async Task SyncAsync_Should_ReturnStatusCode200Ok_If_Success()
    {
        // Arrange
        var entity = this.Entities.FirstOrDefault();
        entity.Id = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.SyncAsync));
        var payload = this.GetJsonPayload(entity);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsync(url, payload);
        var dbEntity = await this._logicProvider.GetAsync(entity.Id);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(entity.Id, dbEntity.Id);
        Assert.Equal(entity.IsActive, dbEntity.IsActive);
    }

    [Fact]
    public virtual async Task SyncAsync_Should_ReturnStatusCode400BadRequest_If_Param_Entity_IsNull()
    {
        // Arrange
        var entity = default(TEntity);
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.SyncAsync));
        var payload = this.GetJsonPayload(entity);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsync(url, payload);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    #endregion

    #region [ Methods - AddAsync ]
    [Fact]
    public virtual async Task AddAsync_Should_ReturnStatusCode200Ok_If_Success()
    {
        // Arrange
        var entity = this.Entities.FirstOrDefault();
        var id = IdFactory.CreateId();
        entity.Id = id;
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.AddAsync));
        var payload = this.GetJsonPayload(entity);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsync(url, payload);
        var dbEntity = await this._logicProvider.GetAsync(id);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(entity.Id, dbEntity.Id);
        Assert.Equal(entity.IsActive, dbEntity.IsActive);
    }

    [Fact]
    public virtual async Task AddAsync_Should_ReturnStatusCode400BadRequest_If_Param_Entity_IsNull()
    {
        // Arrange
        var entity = default(TEntity);
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.AddAsync));
        var payload = this.GetJsonPayload(entity);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsync(url, payload);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    #endregion

    #region [ Methods - UpdateAsync ]
    [Fact]
    public virtual async Task UpdateAsync_Should_ReturnStatusCode200Ok_If_Success()
    {
        // Arrange
        var entity = this.Entities.FirstOrDefault();
        entity.CreatedAt = DateTime.UtcNow.AddHours(5);
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.UpdateAsync));
        var payload = this.GetJsonPayload(entity);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PutAsync(url, payload);
        var dbEntity = await this._logicProvider.GetAsync(entity.Id);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(entity.CreatedAt.ToShortDateString(), dbEntity.CreatedAt.ToShortDateString());
        Assert.Equal(entity.IsActive, dbEntity.IsActive);
    }

    [Fact]
    public virtual async Task UpdateAsync_Should_ReturnStatusCode500InternalServerError_If_Exception()
    {
        // Arrange
        var entity = this.Entities.FirstOrDefault();
        entity.Id = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.UpdateAsync));
        var payload = this.GetJsonPayload(entity);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PutAsync(url, payload);
        var dbEntity = await this._logicProvider.GetAsync(entity.Id);

        // Assert
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);

    }

    [Fact]
    public virtual async Task UpdateAsync_Should_ReturnStatusCode400BadRequest_If_Param_Entity_IsNull()
    {
        // Arrange
        var entity = default(TEntity);
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.UpdateAsync));
        var payload = this.GetJsonPayload(entity);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PutAsync(url, payload);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    #endregion

    #region [ Methods - DeleteAsync ]
    [Fact]
    public virtual async Task DeleteAsync_Should_ReturnStatusCode200Ok_If_Success()
    {
        // Arrange
        var entity = this.Entities.FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.DeleteAsync), entity.Id);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().DeleteAsync(url);
        var dbEntity = await this._logicProvider.GetAsync(entity.Id);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Null(dbEntity);
    }

    [Fact]
    public virtual async Task DeleteAsync_Should_ReturnStatusCode404NotFound_If_NotFound()
    {
        // Arrange
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.DeleteAsync), IdFactory.CreateId());

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().DeleteAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion

    #region [ Methods - ActivateAsync ]
    [Fact]
    public virtual async Task ActivateAsync_Should_ReturnStatusCode200Ok_If_Success()
    {
        // Arrange
        var entity = this.Entities.LastOrDefault(x => x.IsActive == false);
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.ActivateAsync), entity.Id);
        var payload = this.GetJsonPayload(entity.Id);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PutAsync(url, payload);
        var dbEntity = await this._logicProvider.GetAsync(entity.Id);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.True(dbEntity.IsActive);
    }

    [Fact]
    public virtual async Task ActivateAsync_Should_ReturnStatusCode404NotFound_If_NotFound()
    {
        // Arrange
        var id = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.ActivateAsync), id);
        var payload = this.GetJsonPayload(id);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PutAsync(url, payload);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion

    #region [ Methods - DeactivateAsync ]
    [Fact]
    public virtual async Task DeactivateAsync_Should_ReturnStatusCode200Ok_If_Success()
    {
        // Arrange
        var entity = this.Entities.FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.DeactivateAsync), entity.Id);
        var payload = this.GetJsonPayload(entity.Id);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PutAsync(url, payload);
        var dbEntity = await this._logicProvider.GetAsync(entity.Id);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.False(dbEntity.IsActive);
    }

    [Fact]
    public virtual async Task DeactivateAsync_Should_ReturnStatusCode404NotFound_If_NotFound()
    {
        // Arrange
        var id = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.DeactivateAsync), id);
        var payload = this.GetJsonPayload(id);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PutAsync(url, payload);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion

    #region [ Methods - GetAsync ]
    [Fact]
    public virtual async Task GetAsync_Should_ReturnStatusCode200Ok_If_Success()
    {
        // Arrange
        var entity = this.Entities.FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.GetAsync), entity.Id);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<TEntity>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(actual.Id, entity.Id);
        Assert.Equal(entity.CreatedAt.ToShortDateString(), actual.CreatedAt.ToShortDateString());
        Assert.Equal(actual.IsActive, entity.IsActive);
    }

    [Fact]
    public virtual async Task GetAsync_Should_ReturnStatusCode404NotFound_If_NotFound()
    {
        // Arrange
        var id = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.GetAsync), id);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion

    #region [ Methods - GetAllAsync ]
    [Fact]
    public virtual async Task GetAllAsync_Should_ReturnStatusCode200Ok_If_Success()
    {
        // Arrange
        var entities = this.Entities;
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.GetAllAsync));

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var result = JsonConvert.DeserializeObject<List<TEntity>>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(entities.Count, result.Count);
    }

    [Fact]
    public virtual async Task GetAllAsync_PagingOptions_Should_ReturnStatusCode200Ok_If_Success()
    {
        // Arrange
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.GetAllAsync));
        var options = new PagingOptions()
        {
            CalculateTotals = true,
            LoadStrategy = PagingLoadStrategy.PerRequest,
            Page = 1,
            PageSize = 3
        };

        var payload = this.GetJsonPayload<PagingOptions>(options);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsync(url, payload);
        var result = JsonConvert.DeserializeObject<PagingResult<TEntity>>(await response.Content.ReadAsStringAsync());
        var dbResult = await this._logicProvider.GetAllAsync(options);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(dbResult.Items.Count, result.Items.Count);
        Assert.Equal(dbResult.TotalPages, result.TotalPages);
        Assert.Equal(dbResult.TotalItems, result.TotalItems);
    }

    [Fact]
    public virtual async Task GetAllAsync_PagingOptions_Should_ReturnStatusCode400BadRequest_If_Options_IsNull()
    {
        // Arrange
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.GetAllAsync));
        var options = default(PagingOptions);

        var payload = this.GetJsonPayload(options);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsync(url, payload);


        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    #endregion

    #region [ Methods - GetActiveAsync ]
    [Fact]
    public virtual async Task GetActiveAsync_Should_ReturnStatusCode200Ok_If_Success()
    {
        // Arrange
        var entities = this.Entities.Where(x => x.IsActive == true);
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.GetActiveAsync));

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var result = JsonConvert.DeserializeObject<List<TEntity>>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(entities.Count(), result.Count);
    }

    [Fact]
    public virtual async Task GetActiveAsync_PagingOptions_Should_ReturnStatusCode200Ok_If_Success()
    {
        // Arrange
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.GetActiveAsync));
        var options = new PagingOptions()
        {
            CalculateTotals = true,
            LoadStrategy = PagingLoadStrategy.PerRequest,
            Page = 1,
            PageSize = 3
        };

        var payload = this.GetJsonPayload<PagingOptions>(options);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsync(url, payload);
        var result = JsonConvert.DeserializeObject<PagingResult<TEntity>>(await response.Content.ReadAsStringAsync());
        var dbResult = await this._logicProvider.GetActiveAsync(options);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(dbResult.Items.Count, result.Items.Count);
        Assert.Equal(dbResult.TotalPages, result.TotalPages);
        Assert.Equal(dbResult.TotalItems, result.TotalItems);
    }

    [Fact]
    public virtual async Task GetActiveAsync_PagingOptions_Should_ReturnStatusCode400BadRequest_If_Options_IsNull()
    {
        // Arrange
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.GetActiveAsync));
        var options = default(PagingOptions);

        var payload = this.GetJsonPayload(options);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsync(url, payload);


        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    #endregion

    #region [ Methods - GetInActiveAsync ]
    [Fact]
    public virtual async Task GetInActiveAsync_Should_ReturnStatusCode200Ok_If_Success()
    {
        // Arrange
        var entities = this.Entities.Where(x => x.IsActive == false);
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.GetInActiveAsync));

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var result = JsonConvert.DeserializeObject<List<TEntity>>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(entities.Count(), result.Count);
    }

    [Fact]
    public virtual async Task GetInActiveAsync_PagingOptions_Should_ReturnStatusCode200Ok_If_Success()
    {
        // Arrange
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.GetInActiveAsync));
        var options = new PagingOptions()
        {
            CalculateTotals = true,
            LoadStrategy = PagingLoadStrategy.PerRequest,
            Page = 1,
            PageSize = 3
        };

        var payload = this.GetJsonPayload<PagingOptions>(options);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsync(url, payload);
        var result = JsonConvert.DeserializeObject<PagingResult<TEntity>>(await response.Content.ReadAsStringAsync());
        var dbResult = await this._logicProvider.GetInActiveAsync(options);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(dbResult.Items.Count, result.Items.Count);
        Assert.Equal(dbResult.TotalPages, result.TotalPages);
        Assert.Equal(dbResult.TotalItems, result.TotalItems);
    }

    [Fact]
    public virtual async Task GetInActiveAsync_PagingOptions_Should_ReturnStatusCode400BadRequest_If_Options_IsNull()
    {
        // Arrange
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.GetInActiveAsync));
        var options = default(PagingOptions);

        var payload = this.GetJsonPayload(options);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsync(url, payload);


        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    #endregion

    #region [ Methods - GetBatchAsync ]
    [Fact]
    public virtual async Task GetBatchAsync_Should_ReturnStatusCode200Ok_If_Success()
    {
        // Arrange
        var idList = new List<string>() {
            this.Entities[0].Id,
            this.Entities[1].Id,
            this.Entities[2].Id,
        };
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.GetBatchAsync));
        var payload = this.GetJsonPayload(idList);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsync(url, payload);
        var result = JsonConvert.DeserializeObject<List<TEntity>>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(idList.Count(), result.Count);
    }
    #endregion

    #region [ Methods - GetChangesAsync ]
    [Fact]
    public virtual async Task GetChangesAsync_Should_ReturnStatusCode200Ok_If_Success()
    {
        // Arrange
        var date = DateTime.UtcNow.AddDays(-1);
        var entities = this.Entities.Where(x => x.UpdatedAt >= date).ToList();
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.GetChangesAsync));
        var payload = this.GetJsonPayload(date);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsync(url, payload);
        var result = JsonConvert.DeserializeObject<List<TEntity>>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(entities.Count(), result.Count);
    }
    #endregion

    #region [ Methods - Count ]
    [Fact]
    public virtual async Task CountAllAsync_Should_ReturnStatusCode200Ok_If_Success()
    {
        // Arrange
        var data = this.Entities;
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.CountAllAsync));

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var result = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(data.Count, result);
    }

    [Fact]
    public virtual async Task CountActiveAsync_Should_ReturnStatusCode200Ok_If_Success()
    {
        // Arrange
        var data = this.Entities.Where(x => x.IsActive == true).ToList();
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.CountActiveAsync));

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var result = default(int);
        if (response.IsSuccessStatusCode)
        {
            result = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
        }

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(data.Count, result);
    }

    [Fact]
    public virtual async Task CountInActiveAsync_Should_ReturnStatusCode200Ok_If_Success()
    {
        // Arrange
        var data = this.Entities.Where(x => x.IsActive == false).ToList();
        var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.CountInActiveAsync));

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var result = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(data.Count, result);
    }
    #endregion

    #region [ Methods - Initialize ]
    public virtual async Task InitializeAsync()
    {
        await this.SeedData();
    }
    #endregion

    #region [ Methods - Seed & Clear ]
    protected async Task SeedData()
    {
        await this._databaseProvider.EnsureDatabaseAsync();
        await this._databaseProvider.SeedDatabaseAsync();
    }

    protected async Task ClearDataAsync()
    {
        await this._databaseProvider.ClearDatabaseAsync();
    }
    #endregion

    #region [ Protected Methods ]
    protected StringContent GetJsonPayload<TPayload>(TPayload payload)
    {
        return new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
    }

    protected HttpClient GetThiemeMeulenhoff_HttpClient()
    {
        var httpClient = this._appFactory.CreateClient();
        return httpClient;
    }

    protected string GetUrlEndpoint(Type apiControllerType, string methodName, params object[] pathParam)
    {
        var provider = _appFactory.Services.GetService<IActionDescriptorCollectionProvider>();
        var ctrlActions = provider.ActionDescriptors.Items
            .Where(x => (x as ControllerActionDescriptor)
            .ControllerTypeInfo.AsType() == apiControllerType)
            .Select(x => (ControllerActionDescriptor)x)
            .ToList();

        var getRouteTemplate = ctrlActions.FirstOrDefault(x => x.MethodInfo.Name == methodName).AttributeRouteInfo.Template;

        if (pathParam != null && pathParam.Count() > 0)
        {
            string pattern = @"\{(\w+)\??\}";
            var matches = Regex.Matches(getRouteTemplate, pattern);
            var patterns = new Dictionary<string, string>();
            int i = 0;
            foreach (string param in pathParam)
            {
                patterns.Add(matches[i].Groups[1].Value, param);
                i++;
            }
            getRouteTemplate = Regex.Replace(getRouteTemplate, pattern, m => patterns[m.Groups[1].Value]);
        }
        else
        {
            string pattern = @"\{(\w+)\}";
            getRouteTemplate = Regex.Replace(getRouteTemplate, pattern, "");

        }

        return getRouteTemplate;
    }
    #endregion

    #region [ Methods - Dispose ]
    public virtual async Task DisposeAsync()
    {
       await this.ClearDataAsync();
    }
    #endregion
}
