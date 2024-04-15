using Newtonsoft.Json;
using RCode;
using System.Net;
using ThiemeMeulenhoff.Platform.WebApi;
using Xunit;

namespace ThiemeMeulenhoff.Platform.IntegrationTests;

public class SubjectControllerIntegrationTest : BaseIntegrationTest<Subject, SubjectController, ISubjectLogicProvider>
{
    #region [ CTor ]
    public SubjectControllerIntegrationTest(CustomWebApplicationFactoryClass<Program> appFactory) : base(appFactory, SeedProvider.Current.Subjects) {

    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetBySubjectCodeAsync_Should_ReturnStatusCode200k_If_Option_Is_Found() {

        //Arrange
        var entity = SeedProvider.Current.Subjects.FirstOrDefault();
        var expected = SeedProvider.Current.Subjects.FirstOrDefault(x => x.SubjectCode == entity.SubjectCode);
        var url = this.GetUrlEndpoint(typeof(SubjectController), nameof(this._controller.GetBySubjectCodeAsync), expected.SubjectCode);


        //Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<Subject>(await response.Content.ReadAsStringAsync());

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(actual.Id, expected.Id);
    }

    [Fact]
    public async Task GetBySubjectCodeAsync_Should_ReturnStatusCode404NotFound_If_Option_Is_NotFound() {
        //Arrange
        var subjectCode = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(SubjectController), nameof(this._controller.GetBySubjectCodeAsync), subjectCode);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion
}
