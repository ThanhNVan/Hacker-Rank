using Newtonsoft.Json;
using RCode;
using System.Net;
using ThiemeMeulenhoff.Platform.WebApi;
using Xunit;

namespace ThiemeMeulenhoff.Platform.IntegrationTests;

public class PrintInfoTemplateControllerIntegrationTest : BaseIntegrationTest<PrintInfoTemplate, PrintInfoTemplateController, IPrintInfoTemplateLogicProvider>
{
    #region [ CTor ]
    public PrintInfoTemplateControllerIntegrationTest(CustomWebApplicationFactoryClass<Program> appFactory) : base(appFactory, SeedProvider.Current.PrintInfoTemplates) {

    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByNameAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var entity = this.Entities.FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof(PrintInfoTemplateController), nameof(this._controller.GetByNameAsync), entity.Name);
        var expected = await this._logicProvider.GetByNameAsync(entity.Name);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<PrintInfoTemplate>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(actual.Id, expected.Id);
        Assert.Equal(actual.CreatedAt.ToShortDateString(), expected.CreatedAt.ToShortDateString());
        Assert.Equal(actual.IsActive, expected.IsActive);
    }

    [Fact]
    public async Task GetByNameAsync_Should_ReturnStatusCode404NotFound_If_NotFound() {
        // Arrange
        var id = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(PrintInfoTemplateController), nameof(this._controller.GetByNameAsync), id);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion
}
