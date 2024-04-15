using System.Net;
using Newtonsoft.Json;
using RCode;
using ThiemeMeulenhoff.Platform.WebApi;
using Xunit;

namespace ThiemeMeulenhoff.Platform.IntegrationTests;

public class SchoolControllerIntegrationTest : BaseIntegrationTest<School, SchoolController, ISchoolLogicProvider>
{
    #region [ CTor ]
    public SchoolControllerIntegrationTest(CustomWebApplicationFactoryClass<Program> appFactory) : base(appFactory, SeedProvider.Current.Schools) {

    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetBySchoolBoardNumberAsync_Should_ReturnStatusCode200k_If_Option_Is_Found() {

        //Arrange
        var entity = SeedProvider.Current.Schools.FirstOrDefault();
        var expected = SeedProvider.Current.Schools.FirstOrDefault(x => x.SchoolBoardNumber == entity.SchoolBoardNumber);
        var url = this.GetUrlEndpoint(typeof(SchoolController), nameof(this._controller.GetBySchoolBoardNumberAsync), expected.SchoolBoardNumber);


        //Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<School>(await response.Content.ReadAsStringAsync());

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(actual.SchoolBoardNumber, expected.SchoolBoardNumber);
    }

    [Fact]
    public async Task GetBySchoolBoardNumberAsync_Should_ReturnStatusCode404NotFound_If_Option_Is_NotFound() {
        //Arrange
        var school = SchoolFactory.Create();
        var url = this.GetUrlEndpoint(typeof(SchoolController), nameof(this._controller.GetBySchoolBoardNumberAsync), school.SchoolBoardNumber);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetByBrinCodeAsync_Should_ReturnStatusCode200k_If_Option_Is_Found() {

        //Arrange
        var entity = SeedProvider.Current.Schools.FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof(SchoolController), nameof(this._controller.GetByBrinCodeAsync), entity.BrinCode);


        //Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var result = JsonConvert.DeserializeObject<School>(await response.Content.ReadAsStringAsync());
        var dbEntites = await this._logicProvider.GetByBrinCodeAsync(entity.BrinCode);

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(result.SchoolBoardNumber, dbEntites.SchoolBoardNumber);
    }

    [Fact]
    public async Task GetByBrinCodeAsync_Should_ReturnStatusCode404NotFound_If_Option_Is_NotFound() {
        //Arrange
        var school = SchoolFactory.Create();
        var url = this.GetUrlEndpoint(typeof(SchoolController), nameof(this._controller.GetByBrinCodeAsync), school.BrinCode);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetByBranchNumberAsync_Should_ReturnStatusCode200k_If_Option_Is_Found() {

        //Arrange
        var entity = SeedProvider.Current.Schools.FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof(SchoolController), nameof(this._controller.GetByBranchNumberAsync), entity.BranchNumber);


        //Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var result = JsonConvert.DeserializeObject<School>(await response.Content.ReadAsStringAsync());
        var dbEntites = await this._logicProvider.GetByBranchNumberAsync(entity.BranchNumber);

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(result.BranchNumber, dbEntites.BranchNumber);
    }

    [Fact]
    public async Task GetByBranchNumberAsync_Should_ReturnStatusCode404NotFound_If_Option_Is_NotFound() {
        //Arrange
        var Id = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(SchoolController), nameof(this._controller.GetByBranchNumberAsync), Id);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion
}
