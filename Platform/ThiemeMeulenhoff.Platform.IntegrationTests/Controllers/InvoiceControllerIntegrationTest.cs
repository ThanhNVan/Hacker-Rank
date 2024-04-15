using Newtonsoft.Json;
using RCode;
using System.Net;
using ThiemeMeulenhoff.Platform.WebApi;
using Xunit;

namespace ThiemeMeulenhoff.Platform.IntegrationTests;

public class InvoiceControllerIntegrationTest : BaseIntegrationTest<Invoice, InvoiceController, IInvoiceLogicProvider>
{
    #region [ CTor ]
    public InvoiceControllerIntegrationTest(CustomWebApplicationFactoryClass<Program> appFactory) : base(appFactory, SeedProvider.Current.Invoices) {

    }
    #endregion

    #region [ Public Methods - Custom - Lists ]
    [Fact]
    public async Task GetByOrderIdAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var entity = this.Entities.FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof(InvoiceController), nameof(this._controller.GetByOrderIdAsync), entity.OrderId);
        var expected = await this._logicProvider.GetByOrderIdAsync(entity.OrderId);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<List<Invoice>>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected.Count, actual.Count);
    }

    [Fact]
    public async Task GetByOrderIdAsync_Should_ReturnStatusCode404NotFound_If_NotFound() {
        // Arrange
        var id = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(InvoiceController), nameof(this._controller.GetByOrderIdAsync), id);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetByContactIdAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var entity = this.Entities.FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof(InvoiceController), nameof(this._controller.GetByContactIdAsync), entity.ContactId);
        var expected = await this._logicProvider.GetByContactIdAsync(entity.ContactId);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<List<Invoice>>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected.Count, actual.Count);
    }

    [Fact]
    public async Task GetByContactIdAsync_Should_ReturnStatusCode404NotFound_If_NotFound() {
        // Arrange
        var id = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(InvoiceController), nameof(this._controller.GetByContactIdAsync), id);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion
}
