using Newtonsoft.Json;
using RCode;
using System.Net;
using ThiemeMeulenhoff.Platform.WebApi;
using Xunit;

namespace ThiemeMeulenhoff.Platform.IntegrationTests;

[Collection("IntegrationTest")]
[CollectionDefinition(nameof(DeliveryNoteItemControllerIntegrationTest), DisableParallelization = true)]
public class DeliveryNoteItemControllerIntegrationTest : BaseIntegrationTest<DeliveryNoteItem, DeliveryNoteItemController, IDeliveryNoteItemLogicProvider>
{
    #region [ CTor ]
    public DeliveryNoteItemControllerIntegrationTest(CustomWebApplicationFactoryClass<Program> appFactory) : base(appFactory, SeedProvider.Current.DeliveryNoteItems) {

    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public virtual async Task GetByOrderIdAndOrderItemIdAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var expected = this.Entities.FirstOrDefault();
        var url = this.GetUrlEndpoint(typeof(DeliveryNoteItemController), nameof(this._controller.GetByOrderIdAndOrderItemIdAsync), expected.OrderId, expected.OrderItemId);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<DeliveryNoteItem>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(actual.Id, expected.Id);
        Assert.Equal(expected.CreatedAt.ToShortDateString(), actual.CreatedAt.ToShortDateString());
        Assert.Equal(actual.IsActive, expected.IsActive);
    }

    [Fact]
    public virtual async Task GetByOrderIdAndOrderItemIdAsync_Should_ReturnStatusCode404NotFound_If_NotFound() {
        // Arrange
        var id = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(DeliveryNoteItemController), nameof(this._controller.GetByOrderIdAndOrderItemIdAsync), id, id);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion
}
