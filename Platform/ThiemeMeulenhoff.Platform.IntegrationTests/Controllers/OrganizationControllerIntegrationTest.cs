using System.Net;
using Newtonsoft.Json;
using ThiemeMeulenhoff.Platform.WebApi;
using Xunit;

namespace ThiemeMeulenhoff.Platform.IntegrationTests;

public class OrganizationControllerIntegrationTest : BaseIntegrationTest<Organization, OrganizationController, IOrganizationLogicProvider>
{
    #region [ CTor ]
    public OrganizationControllerIntegrationTest(CustomWebApplicationFactoryClass<Program> appFactory) : base(appFactory, SeedProvider.Current.Organizations) {

    }
    #endregion

    #region [ Public Methods -  Override ]
    [Fact]
    public override async Task GetAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var entityId = this.Entities[0].Id;
        var url = this.GetUrlEndpoint(typeof(OrganizationController), nameof(this._controller.GetAsync), entityId);
        var expected = await this._logicProvider.GetAsync(entityId);
        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<Organization>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(actual.Id, expected.Id);
        Assert.Equal(actual.CreatedAt.ToShortDateString(), expected.CreatedAt.ToShortDateString());
        Assert.Equal(actual.IsActive, expected.IsActive);
    }

    [Fact]
    public override async Task GetAllAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var organizations = SeedProvider.Current.Organizations;
        var schools = SeedProvider.Current.Schools;
        var organization_url = this.GetUrlEndpoint(typeof(OrganizationController), nameof(this._controller.GetAllAsync));
        var school_url = this.GetUrlEndpoint(typeof(SchoolController), nameof(this._controller.GetAllAsync));

        // Act
        var organization_response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(organization_url);
        var school_response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(school_url);
        var organization_result = JsonConvert.DeserializeObject<List<Organization>>(await organization_response.Content.ReadAsStringAsync());
        var school_result = JsonConvert.DeserializeObject<List<School>>(await school_response.Content.ReadAsStringAsync());
        var result = organization_result.Count - school_result.Count;

        // Assert
        Assert.Equal(HttpStatusCode.OK, organization_response.StatusCode);
        Assert.Equal(organizations.Count, result);
    }

    [Fact]
    public override async Task GetActiveAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var organizations = SeedProvider.Current.Organizations.Where(x => x.IsActive == true);
        var schools = SeedProvider.Current.Schools.Where(x => x.IsActive == true);
        var organization_url = this.GetUrlEndpoint(typeof(OrganizationController), nameof(this._controller.GetActiveAsync));
        var school_url = this.GetUrlEndpoint(typeof(SchoolController), nameof(this._controller.GetActiveAsync));

        //Act
        var organization_response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(organization_url);
        var school_response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(school_url);
        var organization_result = JsonConvert.DeserializeObject<List<Organization>>(await organization_response.Content.ReadAsStringAsync());
        var school_result = JsonConvert.DeserializeObject<List<School>>(await school_response.Content.ReadAsStringAsync());
        var result = organization_result.Count - school_result.Count;

        //Assert
        Assert.Equal(HttpStatusCode.OK, organization_response.StatusCode);
        Assert.Equal(organizations.Count(), result);

    }

    [Fact]
    public override async Task GetChangesAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var date = DateTime.UtcNow.AddDays(-1);
        var organizations = SeedProvider.Current.Organizations.Where(x => x.UpdatedAt >= date).ToList();
        var schools = SeedProvider.Current.Schools.Where(x => x.UpdatedAt >= date).ToList();
        var organization_url = this.GetUrlEndpoint(typeof(OrganizationController), nameof(this._controller.GetChangesAsync));
        var school_url = this.GetUrlEndpoint(typeof(SchoolController), nameof(this._controller.GetChangesAsync));
        var payload = this.GetJsonPayload(date);

        // Act
        var organization_response = await this.GetThiemeMeulenhoff_HttpClient().PostAsync(organization_url, payload);
        var school_response = await this.GetThiemeMeulenhoff_HttpClient().PostAsync(school_url, payload);
        var organization_result = JsonConvert.DeserializeObject<List<Organization>>(await organization_response.Content.ReadAsStringAsync());
        var school_result = JsonConvert.DeserializeObject<List<School>>(await school_response.Content.ReadAsStringAsync());
        var result = organization_result.Count - school_result.Count;

        // Assert
        Assert.Equal(HttpStatusCode.OK, organization_response.StatusCode);
        Assert.Equal(organizations.Count(), result);
    }

    #region [ Methods - CountActiveAsync ]

    [Fact]
    public override async Task CountActiveAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var organizations = SeedProvider.Current.Organizations.Where(x => x.IsActive == true).ToList();
        var schools = SeedProvider.Current.Schools.Where(x => x.IsActive == true).ToList();
        var organization_url = this.GetUrlEndpoint(typeof(OrganizationController), nameof(this._controller.CountActiveAsync));
        var school_url = this.GetUrlEndpoint(typeof(SchoolController), nameof(this._controller.CountActiveAsync));

        // Act
        var organization_response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(organization_url);
        var school_response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(school_url);
        var organization_result = default(int);
        var school_result = default(int);
        if (organization_response.IsSuccessStatusCode && school_response.IsSuccessStatusCode) {
            organization_result = JsonConvert.DeserializeObject<int>(await organization_response.Content.ReadAsStringAsync());
            school_result = JsonConvert.DeserializeObject<int>(await school_response.Content.ReadAsStringAsync());

        }
        var result = organization_result - school_result;

        // Assert
        Assert.Equal(HttpStatusCode.OK, organization_response.StatusCode);
        Assert.Equal(organizations.Count, result);
    }
    #endregion


    #region [ Methods - CountAllAsync ]
    [Fact]
    public override async Task CountAllAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var organizations = SeedProvider.Current.Organizations;
        var schools = SeedProvider.Current.Schools;
        var organization_url = this.GetUrlEndpoint(typeof(OrganizationController), nameof(this._controller.CountAllAsync));
        var school_url = this.GetUrlEndpoint(typeof(SchoolController), nameof(this._controller.CountAllAsync));
        //var url = this.GetUrlEndpoint(typeof(TController), nameof(this._controller.CountAllAsync));

        // Act
        var organization_response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(organization_url);
        var school_response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(school_url);
        var organization_result = default(int);
        var school_result = default(int);
        if (organization_response.IsSuccessStatusCode && school_response.IsSuccessStatusCode) {
            organization_result = JsonConvert.DeserializeObject<int>(await organization_response.Content.ReadAsStringAsync());
            school_result = JsonConvert.DeserializeObject<int>(await school_response.Content.ReadAsStringAsync());

        }
        var result = organization_result - school_result;

        // Assert
        Assert.Equal(HttpStatusCode.OK, organization_response.StatusCode);
        Assert.Equal(organizations.Count, result);

    }
    #endregion

    #region [ Methods - GetActiveAsync ]
    [Fact]
    public override async Task GetInActiveAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var organizations = SeedProvider.Current.Organizations.Where(x => x.IsActive == false);
        var schools = SeedProvider.Current.Schools.Where(x => x.IsActive == false);
        var organization_url = this.GetUrlEndpoint(typeof(OrganizationController), nameof(this._controller.GetInActiveAsync));
        var school_url = this.GetUrlEndpoint(typeof(SchoolController), nameof(this._controller.GetInActiveAsync));

        // Act
        var organization_response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(organization_url);
        var school_response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(school_url);
        var organization_result = JsonConvert.DeserializeObject<List<Organization>>(await organization_response.Content.ReadAsStringAsync());
        var school_result = JsonConvert.DeserializeObject<List<School>>(await school_response.Content.ReadAsStringAsync());
        var result = organization_result.Count - school_result.Count;

        // Assert
        Assert.Equal(HttpStatusCode.OK, organization_response.StatusCode);
        Assert.Equal(organizations.Count(), result);
    }
    #endregion


    [Fact]
    public override async Task SaveAsync_Should_ReturnStatusCode200Ok_If_UpdateSuccess() {
        // Arrange
        var entity = SeedProvider.Current.Organizations.LastOrDefault();
        entity.IsActive = false;
        entity.CreatedAt = DateTime.UtcNow.AddDays(2);
        var url = this.GetUrlEndpoint(typeof(OrganizationController), nameof(this._controller.SaveAsync));
        var payload = this.GetJsonPayload(entity);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsync(url, payload);
        var dbEntity = await this._logicProvider.GetAsync(entity.Id);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(entity.Id, dbEntity.Id);
        Assert.Equal(entity.IsActive, dbEntity.IsActive);
        Assert.Equal(entity.CreatedAt.ToShortDateString(), dbEntity.CreatedAt.ToShortDateString());
    }

    [Fact]
    public override async Task CountInActiveAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var organizations = SeedProvider.Current.Organizations.Where(x => x.IsActive == false).ToList();
        var schools = SeedProvider.Current.Schools.Where(x => x.IsActive == false).ToList();
        var organization_url = this.GetUrlEndpoint(typeof(OrganizationController), nameof(this._controller.CountInActiveAsync));
        var school_url = this.GetUrlEndpoint(typeof(SchoolController), nameof(this._controller.CountInActiveAsync));

        // Act
        var organization_response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(organization_url);
        var school_response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(school_url);
        var organization_result = default(int);
        var school_result = default(int);
        if (organization_response.IsSuccessStatusCode && school_response.IsSuccessStatusCode) {
            school_result = JsonConvert.DeserializeObject<int>(await school_response.Content.ReadAsStringAsync());
            organization_result = JsonConvert.DeserializeObject<int>(await organization_response.Content.ReadAsStringAsync());
        }
        var result = organization_result - school_result;

        // Assert
        Assert.Equal(HttpStatusCode.OK, organization_response.StatusCode);
        Assert.Equal(organizations.Count, result);
    }

    [Fact]
    public override async Task DeactivateAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var entity = SeedProvider.Current.Organizations.Where(x => x.IsActive == true).FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof(OrganizationController), nameof(this._controller.DeactivateAsync), entity.Id);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PutAsJsonAsync(url, entity);
        var dbEntity = await this._logicProvider.GetAsync(entity.Id);


        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(entity.Id, dbEntity.Id);
        Assert.False(dbEntity.IsActive);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var afasContactNumber = this.Entities.FirstOrDefault().AfasContactNumber;
        var entity = await this._logicProvider.GetByAfasContactNumberAsync(afasContactNumber);
        var url = this.GetUrlEndpoint(typeof(OrganizationController), nameof(this._controller.GetByAfasContactNumberAsync), afasContactNumber);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<Organization>(await response.Content.ReadAsStringAsync());

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
        var url = this.GetUrlEndpoint(typeof(OrganizationController), nameof(this._controller.GetByAfasContactNumberAsync), afasContactNumber);

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
        var url = this.GetUrlEndpoint(typeof(OrganizationController), nameof(this._controller.GetByCbPartijIdAsync), CbPartijId);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<Organization>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(actual.Id, entity.Id);
        Assert.Equal(entity.CreatedAt.ToShortDateString(), actual.CreatedAt.ToShortDateString());
        Assert.Equal(actual.IsActive, entity.IsActive);
    }

    [Fact]
    public async Task GetByCbPartijIdAsync_Should_ReturnStatusCode404NotFound_If_IsNotFound() {
        // Arrange
        var CbPartijId = this.Entities.FirstOrDefault().CbPartijId.Substring(0, new Random().Next(1,16));
        var url = this.GetUrlEndpoint(typeof(OrganizationController), nameof(this._controller.GetByCbPartijIdAsync), CbPartijId);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion
}

