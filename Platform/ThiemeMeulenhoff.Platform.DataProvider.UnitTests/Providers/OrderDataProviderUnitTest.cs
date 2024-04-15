using System;
using System.Linq;
using System.Threading.Tasks;
using RCode.Data.Providers;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

[Collection("DataProvider")]
public class OrderDataProviderUnitTest : BaseEntityDataProviderUnitTests<OrderDataProvider<ThiemeMeulenhoffPlatformDbContext>, IOrderValidationProvider, Order>
{
    #region [ Fields ]
    private BusinessRuleSettings _businessRuleSettings;
    #endregion

    #region [ CTor ]
    public OrderDataProviderUnitTest() : base(SeedProvider.Current.Orders) {
        this._businessRuleSettings = new();
    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override OrderDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        this._businessRuleSettings = new();
        this.SetBusinessRuleSettings();
        return new OrderDataProvider<ThiemeMeulenhoffPlatformDbContext>(
           this._logger.Object,
           this._dbContextFactory.Object,
           this._validationProvider.Object,
           this._businessRuleSettings);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByAfasOrderIdAsync_Success() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        var expected = SeedSource.FirstOrDefault(x => x.AfasOrderId == entity.AfasOrderId);

        //Act
        var actual = await this._dataProvider.GetByAfasOrderIdAsync(entity.AfasOrderId);

        //Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.CreatedAt.ToLongDateString(), actual.CreatedAt.ToLongDateString());
        Assert.Equal(expected.IsActive, actual.IsActive);
    }

    [Fact]
    public async Task GetByAfasOrderIdAsync_Should_ThrowException_If_AfasOrderId_IsEmpty() {
        // Arrange
        var AfasOrderId = string.Empty;

        //Act
        var result = async () => await this._dataProvider.GetByAfasOrderIdAsync(AfasOrderId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByAfasOrderIdAsync_Should_ThrowException_If_AfasOrderId_IsNull() {
        // Arrange
        var entity = default(Order);

        //Act
        var result = async () => await this._dataProvider.GetByAfasOrderIdAsync(entity.AfasOrderId);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByAfasOrderIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetByAfasOrderIdAsync(entity.AfasOrderId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByPropellerOrderReferenceIdAsync_Success() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        var expected = SeedSource.FirstOrDefault(x => x.PropellerOrderReferenceId == entity.PropellerOrderReferenceId);

        //Act
        var actual = await this._dataProvider.GetByPropellerOrderReferenceIdAsync(entity.PropellerOrderReferenceId);

        //Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.CreatedAt.ToLongDateString(), actual.CreatedAt.ToLongDateString());
        Assert.Equal(expected.IsActive, actual.IsActive);
    }

    [Fact]
    public async Task GetByPropellerOrderReferenceIdAsync_Should_ThrowException_If_PropellerOrderReferenceId_IsEmpty() {
        // Arrange
        var PropellerOrderReferenceId = string.Empty;

        //Act
        var result = async () => await this._dataProvider.GetByPropellerOrderReferenceIdAsync(PropellerOrderReferenceId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByPropellerOrderReferenceIdAsync_Should_ThrowException_If_PropellerOrderReferenceId_IsNull() {
        // Arrange
        var entity = default(Order);

        //Act
        var result = async () => await this._dataProvider.GetByPropellerOrderReferenceIdAsync(entity.PropellerOrderReferenceId);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByPropellerOrderReferenceIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetByPropellerOrderReferenceIdAsync(entity.PropellerOrderReferenceId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }
    #endregion

    #region [ Public Methods - Custom - List ]
    [Fact]
    public async Task GetByContactAsync_Success() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        var expected = SeedSource.Where(x => x.ContactId == entity.ContactId);

        //Act
        var actual = await this._dataProvider.GetByContactAsync(entity.AfasOrderId);

        //Assert
        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetByContactAsync_Should_ThrowException_If_AfasOrderId_IsEmpty() {
        // Arrange
        var AfasOrderId = string.Empty;

        //Act
        var result = async () => await this._dataProvider.GetByContactAsync(AfasOrderId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByContactAsync_Should_ThrowException_If_AfasOrderId_IsNull() {
        // Arrange
        var entity = default(Order);

        //Act
        var result = async () => await this._dataProvider.GetByContactAsync(entity.AfasOrderId);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByContactAsync_Should_ThrowException_If_Error() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetByContactAsync(entity.AfasOrderId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByCbOrderTypeAsync_Success() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        var expected = SeedSource.Where(x => x.CbOrderType == entity.CbOrderType);

        //Act
        var actual = await this._dataProvider.GetByCbOrderTypeAsync(entity.CbOrderType);

        //Assert
        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetByCbOrderTypeAsync_Should_ThrowException_If_AfasOrderId_IsEmpty() {
        // Arrange
        var AfasOrderId = string.Empty;

        //Act
        var result = async () => await this._dataProvider.GetByCbOrderTypeAsync(AfasOrderId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByCbOrderTypeAsync_Should_ThrowException_If_AfasOrderId_IsNull() {
        // Arrange
        var entity = default(Order);

        //Act
        var result = async () => await this._dataProvider.GetByCbOrderTypeAsync(entity.CbOrderType);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByCbOrderTypeAsync_Should_ThrowException_If_Error() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetByCbOrderTypeAsync(entity.CbOrderType);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetChangesForCentraalBoekhuisAsync_Success() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        var date = entity.UpdatedAt.AddDays(-1);
        var expected = (from a in SeedProvider.Current.Orders
                       join b in SeedProvider.Current.OrderItems on a.Id equals b.OrderId
                       join c in SeedProvider.Current.Products on b.ProductId equals c.Id
                       where a.UpdatedAt >= date
                           && a.CbOrderType == entity.CbOrderType
                           && this._businessRuleSettings.BookProductGroupList().Contains(c.ProductGroup)
                       select a.Id).Distinct().ToList();

        //Act
        var actual = await this._dataProvider.GetChangesForCentraalBoekhuisAsync(date, entity.CbOrderType);

        //Assert
        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetChangesForCentraalBoekhuisAsync_Should_ThrowException_If_AfasOrderId_IsEmpty() {
        // Arrange
        var CbOrderType = string.Empty;
        var date = DateTime.UtcNow.AddDays(-1);

        //Act
        var result = async () => await this._dataProvider.GetChangesForCentraalBoekhuisAsync(date, CbOrderType);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetChangesForCentraalBoekhuisAsync_Should_ThrowException_If_AfasOrderId_IsNull() {
        // Arrange
        var entity = default(Order);
        var date = DateTime.UtcNow.AddDays(-1);

        //Act
        var result = async () => await this._dataProvider.GetChangesForCentraalBoekhuisAsync(date, entity.CbOrderType);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetChangesForCentraalBoekhuisAsync_Should_ThrowException_If_Error() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        var date = DateTime.UtcNow.AddDays(-1);
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetChangesForCentraalBoekhuisAsync(date, entity.CbOrderType);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }
    #endregion

    #region [ Override Methods -  ]
    [Fact]
    public async Task GetBySearchFilterAsync_Success() {
        //Arrange
        var entity = this.SeedSource.FirstOrDefault();
        var take = 5;
        var skip = 0;
        var expected = this.SeedSource.Where(x => (x.Id + x.DeliveryAddressId + x.AfasOrderId + x.AfasContactNumber + x.OrderDate + x.State).ToLower().Contains(entity.Id))
                            .Skip(skip)
                            .Take(take);

        // Act
        var actual = await this._dataProvider.GetBySearchFilterAsync(entity.Id, take, skip);

        // Assert
        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetBySearchFilterAsync_Should_ThrowException_If_Search_IsEmpty() {
        // Arrange 
        var searchFilter = string.Empty;
        var take = 5;
        var skip = 0;

        // Act
        var result = async () => await this._dataProvider.GetBySearchFilterAsync(searchFilter, take, skip);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetBySearchFilterAsync_Should_ThrowException_If_Search_IsNull() {
        // Arrange 
        string searchFilter = null;
        var take = 5;
        var skip = 0;

        // Act
        var result = async () => await this._dataProvider.GetBySearchFilterAsync(searchFilter, take, skip);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetBySearchFilterAsync_Should_ThrowException_If_Exception() {
        // Arrange 
        var searchFilter = "string.Empty";
        var take = 5;
        var skip = 0;
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());


        // Act
        var result = async () => await this._dataProvider.GetBySearchFilterAsync(searchFilter, take, skip);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }
    #endregion

    #region [ Private Methods -  ]
    private void SetBusinessRuleSettings() {

        for (int i = 0; i < 10; i++) {
            this._businessRuleSettings.BookProductGroups += SeedProvider.Current.Products[i].ProductGroup + ",";
            this._businessRuleSettings.LicenseProductGroups += SeedProvider.Current.Products[i].ProductGroup + ",";
        }
    }
    #endregion
}
