using Newtonsoft.Json;
using RCode;
using System.Net;
using ThiemeMeulenhoff.Platform.WebApi;
using Xunit;

namespace ThiemeMeulenhoff.Platform.IntegrationTests;

public class ProjectControllerIntegrationTest : BaseIntegrationTest<Project, ProjectController, IProjectLogicProvider>
{
    #region [ CTor ]
    public ProjectControllerIntegrationTest(CustomWebApplicationFactoryClass<Program> appFactory) : base(appFactory, SeedProvider.Current.Projects) {

    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByProjectNameAsync_Should_ReturnStatusCode200Ok_If_Item_Is_Found() {
        // Arrange
        var expected = SeedProvider.Current.Projects.FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof(ProjectController), nameof(this._controller.GetByProjectNameAsync), expected.ProjectName);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<Project>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(actual.Id, expected.Id);
        Assert.Equal(expected.CreatedAt.ToShortDateString(), actual.CreatedAt.ToShortDateString());
        Assert.Equal(actual.IsActive, expected.IsActive);
    }

    [Fact]
    public async Task GetByProjectNameAsync_Should_ReturnStatusCode404NotFound_If_Option_Is_NotFound() {
        //Arange
        var rnd = new Random();
        var afasProjectId = rnd.Next();
        var url = this.GetUrlEndpoint(typeof(ProjectController), nameof(this._controller.GetByProjectNameAsync), afasProjectId.ToString());

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    
    [Fact]
    public async Task GetByProjectNumberAsync_Should_ReturnStatusCode200Ok_If_Item_Is_Found() {
        // Arrange
        var expected = SeedProvider.Current.Projects.FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof(ProjectController), nameof(this._controller.GetByProjectNumberAsync), expected.ProjectNumber.ToString());

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<Project>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(actual.Id, expected.Id);
        Assert.Equal(expected.CreatedAt.ToShortDateString(), actual.CreatedAt.ToShortDateString());
        Assert.Equal(actual.IsActive, expected.IsActive);
    }

    [Fact]
    public async Task GetByProjectNumberAsync_Should_ReturnStatusCode404NotFound_If_Option_Is_NotFound() {
        //Arange
        var rnd = new Random();
        var afasProjectId = rnd.Next();
        var url = this.GetUrlEndpoint(typeof(ProjectController), nameof(this._controller.GetByProjectNumberAsync), afasProjectId.ToString());

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion

    #region [ Public Methods - Custom - List ]
    [Fact]
    public async Task GetBySubjectIdIdAsync_Should_ReturnStatusCode200Ok_If_Item_Is_Found() {
        // Arrange
        var entity = SeedProvider.Current.Projects.FirstOrDefault();
        var expected = SeedProvider.Current.Projects.Where(x => x.SubjectId == entity.Id);
        var url = this.GetUrlEndpoint(typeof(ProjectController), nameof(this._controller.GetBySubjectIdIdAsync), entity.SubjectId.ToString());

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<List<Project>>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(actual.Count, expected.Count());
    }

    [Fact]
    public async Task GetBySubjectIdIdAsync_Should_ReturnStatusCode404NotFound_If_Option_Is_NotFound() {
        //Arange
        var rnd = new Random();
        var afasProjectId = rnd.Next();
        var url = this.GetUrlEndpoint(typeof(ProjectController), nameof(this._controller.GetBySubjectIdIdAsync), afasProjectId.ToString());

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    
    [Fact]
    public async Task GetBatchBySubjectIdAsync_Should_ReturnStatusCode200Ok_If_Item_Is_Found() {
        // Arrange
        var entityIds = new List<string>() {
            SeedProvider.Current.Projects[0].Id,
            SeedProvider.Current.Projects[1].Id,
            SeedProvider.Current.Projects[2].Id,
        };
        var expected = SeedProvider.Current.Projects.Where(x => entityIds.Contains(x.SubjectId));
        var url = this.GetUrlEndpoint(typeof(ProjectController), nameof(this._controller.GetBatchBySubjectIdAsync));

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsJsonAsync(url,entityIds);
        var actual = JsonConvert.DeserializeObject<List<Project>>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(actual.Count, expected.Count());
    }

    [Fact]
    public async Task GetBatchBySubjectIdAsync_Should_ReturnStatusCode404NotFound_If_Option_Is_NotFound() {
        //Arange
        var entityIds = new List<string>() {
            IdFactory.CreateId(),
            IdFactory.CreateId(),
            IdFactory.CreateId(),
            IdFactory.CreateId(),
        };
        var url = this.GetUrlEndpoint(typeof(ProjectController), nameof(this._controller.GetBatchBySubjectIdAsync));

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsJsonAsync(url, entityIds);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion
}
