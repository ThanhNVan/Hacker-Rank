using Newtonsoft.Json;
using RCode;
using System.Net;
using ThiemeMeulenhoff.Platform.WebApi;
using Xunit;

namespace ThiemeMeulenhoff.Platform.IntegrationTests;

public class ProjectTeamMemberControllerIntegrationTest : BaseIntegrationTest<ProjectTeamMember, ProjectTeamMemberController, IProjectTeamMemberLogicProvider>
{
    #region [ CTor ]
    public ProjectTeamMemberControllerIntegrationTest(CustomWebApplicationFactoryClass<Program> appFactory) : base(appFactory, SeedProvider.Current.ProjectTeamMembers) {

    }
    #endregion

    #region [ Public Methods - Custom - List ]
    [Fact]
    public async Task GetByProjectIdAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var ProjectId = this.Entities.FirstOrDefault().ProjectId;
        var entity = await this._logicProvider.GetByProjectIdAsync(ProjectId);
        var url = this.GetUrlEndpoint(typeof(ProjectTeamMemberController), nameof(this._controller.GetByProjectIdAsync), ProjectId);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<List<ProjectTeamMember>>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(actual.Count, entity.Count);
    }

    [Fact]
    public async Task GetByProjectIdAsync_Should_ReturnStatusCode404NotFound_If_IsNotFound() {
        // Arrange
        var ProjectId = this.Entities.FirstOrDefault().ProjectId.Substring(0, new Random().Next(1, 16));
        var url = this.GetUrlEndpoint(typeof(ProjectTeamMemberController), nameof(this._controller.GetByProjectIdAsync), ProjectId);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    
    [Fact]
    public async Task GetByContactIdAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var ContactId = this.Entities.FirstOrDefault().ContactId;
        var entity = await this._logicProvider.GetByContactIdAsync(ContactId);
        var url = this.GetUrlEndpoint(typeof(ProjectTeamMemberController), nameof(this._controller.GetByContactIdAsync), ContactId);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<List<ProjectTeamMember>>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(actual.Count, entity.Count);
    }

    [Fact]
    public async Task GetByContactIdAsync_Should_ReturnStatusCode404NotFound_If_IsNotFound() {
        // Arrange
        var ContactId = this.Entities.FirstOrDefault().ContactId.Substring(0, new Random().Next(1, 16));
        var url = this.GetUrlEndpoint(typeof(ProjectTeamMemberController), nameof(this._controller.GetByContactIdAsync), ContactId);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetBatchByContactIdAsync_Should_ReturnStatusCode200Ok_If_Item_Is_Found() {
        // Arrange
        var entityIds = new List<string>() {
            SeedProvider.Current.ProjectTeamMembers[0].ContactId,
            SeedProvider.Current.ProjectTeamMembers[1].ContactId,
            SeedProvider.Current.ProjectTeamMembers[2].ContactId,
        };
        var expected = SeedProvider.Current.ProjectTeamMembers.Where(x => entityIds.Contains(x.ContactId));
        var url = this.GetUrlEndpoint(typeof(ProjectTeamMemberController), nameof(this._controller.GetBatchByContactIdAsync));

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsJsonAsync(url, entityIds);
        var actual = JsonConvert.DeserializeObject<List<Project>>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(actual.Count, expected.Count());
    }

    [Fact]
    public async Task GetBatchByContactIdAsync_Should_ReturnStatusCode404NotFound_If_Option_Is_NotFound() {
        //Arange
        var entityIds = new List<string>() {
            IdFactory.CreateId(),
            IdFactory.CreateId(),
            IdFactory.CreateId(),
            IdFactory.CreateId(),
        };
        var url = this.GetUrlEndpoint(typeof(ProjectTeamMemberController), nameof(this._controller.GetBatchByContactIdAsync));

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsJsonAsync(url, entityIds);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion
}
