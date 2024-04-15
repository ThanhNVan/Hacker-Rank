using Newtonsoft.Json;
using RCode;
using System.Net;
using ThiemeMeulenhoff.Platform.WebApi;
using Xunit;

namespace ThiemeMeulenhoff.Platform.IntegrationTests;

public class PrintInfoControllerIntegrationTest : BaseIntegrationTest<PrintInfo, PrintInfoController, IPrintInfoLogicProvider>
{
    #region [ CTor ]
    public PrintInfoControllerIntegrationTest(CustomWebApplicationFactoryClass<Program> appFactory) : base(appFactory, SeedProvider.Current.PrintInfo) {

    }
    #endregion

    #region [ Public Methods - Custom - List ]
    [Fact]
    public async Task GetByProductIdAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var entity = this.Entities.FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof( PrintInfoController), nameof(this._controller.GetByProductIdAsync), entity.Id);
        var expected = await this._logicProvider.GetByProductIdAsync(entity.Id);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<List<PrintInfo>>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected.Count, actual.Count);
    }

    [Fact]
    public async Task GetByProductIdAsync_Should_ReturnStatusCode404NotFound_If_NotFound() {
        // Arrange
        var id = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof( PrintInfoController), nameof(this._controller.GetByProductIdAsync), id);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion
}
