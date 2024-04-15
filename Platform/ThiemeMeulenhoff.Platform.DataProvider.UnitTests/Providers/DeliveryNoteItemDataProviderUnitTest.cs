using RCode.Data.Providers;
using System.Threading.Tasks;
using System;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

[Collection("DataProvider")]
public class DeliveryNoteItemDataProviderUnitTest : BaseEntityDataProviderUnitTests<DeliveryNoteItemDataProvider<ThiemeMeulenhoffPlatformDbContext>, IDeliveryNoteItemValidationProvider, DeliveryNoteItem>
{
    #region [ CTor ]
    public DeliveryNoteItemDataProviderUnitTest() : base(SeedProvider.Current.DeliveryNoteItems) {
    }
    #endregion

    #region [ Protected Methods - override ]
    protected override DeliveryNoteItemDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        return new DeliveryNoteItemDataProvider<ThiemeMeulenhoffPlatformDbContext>(
           this._logger.Object,
           this._dbContextFactory.Object,
           this._validationProvider.Object);
    }
    #endregion

    #region [ Public Methods - Custom Single ]
    [Fact]
    public async Task GetByOrderIdAndOrderItemIdAsync_Success() {
        // Arrange
        var expected = this.SeedSource[0];

        // Act
        var actualResult = await this._dataProvider.GetByOrderIdAndOrderItemIdAsync(expected.OrderId, expected.OrderItemId);

        // Assert
        Assert.Equal(expected.Id, actualResult.Id);
        Assert.Equal(expected.CreatedAt.ToShortDateString(), actualResult.CreatedAt.ToShortDateString());
    }

    [Fact]
    public async Task GetByOrderIdAndOrderItemIdAsync_Should_ThrowException_If_OrderId_IsEmpty() {
        // Arrange 
        var orderId = default(string);
        var expected = this.SeedSource[0];

        // Act
        var result = async () => await this._dataProvider.GetByOrderIdAndOrderItemIdAsync(orderId, expected.OrderItemId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByOrderIdAndOrderItemIdAsync_Should_ThrowException_If_Id_IsNull() {
        // Arrange 
        var entity = default(DeliveryNoteItem);
        var expected = this.SeedSource[0];

        // Act
        var result = async () => await this._dataProvider.GetByOrderIdAndOrderItemIdAsync(expected.OrderId, entity.OrderItemId);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }
    
    [Fact]
    public async Task GetByOrderIdAndOrderItemIdAsync_Should_ThrowException_If_Error() {
        // Arrange 
        var expected = this.SeedSource[0];
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByOrderIdAndOrderItemIdAsync(expected.OrderId, expected.OrderItemId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }
    #endregion
}
