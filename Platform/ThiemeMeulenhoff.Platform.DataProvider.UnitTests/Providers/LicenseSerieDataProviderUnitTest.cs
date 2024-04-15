using System;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using RCode.Data.Providers;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

//[Collection("DataProvider")]
//[CollectionDefinition(nameof(LicenseSerieDataProviderUnitTest), DisableParallelization = true)]
public class LicenseSerieDataProviderUnitTest : BaseEntityDataProviderUnitTests<LicenseSerieDataProvider<ThiemeMeulenhoffPlatformDbContext>, ILicenseSerieValidationProvider, LicenseSerie>
{
    #region [ CTor ]
    public LicenseSerieDataProviderUnitTest() : base(SeedProvider.Current.LicenseSeries) {
    }
    #endregion

    #region [ Protected Methods - override ]
    protected override LicenseSerieDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        return new LicenseSerieDataProvider<ThiemeMeulenhoffPlatformDbContext>(
          this._logger.Object,
          this._dbContextFactory.Object,
          this._validationProvider.Object);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByOrderItemIdAsync_Success() {
        //Arrange
        var expected = this.SeedSource.FirstOrDefault();


        // Act
        var actual = await this._dataProvider.GetByOrderItemIdAsync(expected.Id);

        // Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.CreatedAt.ToShortDateString(), actual.CreatedAt.ToShortDateString());
        Assert.Equal(expected.UpdatedAt.ToShortDateString(), actual.UpdatedAt.ToShortDateString());
        Assert.Equal(expected.IsActive, actual.IsActive);
    }

    [Fact]
    public async Task GetByOrderItemIdAsync_Should_ThrowException_If_OrderItemId_IsEmpty() {
        // Arrange 
        var OrderItemId = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetByOrderItemIdAsync(OrderItemId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByOrderItemIdAsync_Should_ThrowException_If_OrderItemId_IsNull() {
        // Arrange 
        string OrderItemId = null;

        // Act
        var result = async () => await this._dataProvider.GetByOrderItemIdAsync(OrderItemId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByOrderItemIdAsync_Should_ThrowException_If_Exception() {
        // Arrange 
        var OrderItemId = this._fixture.Create<string>();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByOrderItemIdAsync(OrderItemId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByAfasOrderItemIdAsync_Success() {
        //Arrange
        var orderItem = SeedProvider.Current.OrderItems[new Random().Next(0, 49)];
        var expected = SeedProvider.Current.LicenseSeries.FirstOrDefault(x => x.Id == orderItem.Id);

        // Act
        var actual = await this._dataProvider.GetByAfasOrderItemIdAsync(orderItem.Id);

        // Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.IsActive, actual.IsActive);
        Assert.Equal(expected.CreatedAt.ToShortDateString(), actual.CreatedAt.ToShortDateString());
    }

    [Fact]
    public async Task GetByAfasOrderItemIdAsync_Should_ThrowException_If_AfasOrderItemId_IsEmpty() {
        // Arrange 
        var AfasOrderItemId = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetByAfasOrderItemIdAsync(AfasOrderItemId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByAfasOrderItemIdAsync_Should_ThrowException_If_OrderItem_IsNull() {
        //Arrange
        var orderItem = SeedProvider.Current.OrderItems.FirstOrDefault();
        var AfasOrderItemId = Guid.NewGuid().ToString();

        // Act
        var result = async () => await this._dataProvider.GetByAfasOrderItemIdAsync(AfasOrderItemId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByAfasOrderItemIdAsync_Should_ThrowException_If_AfasOrderItemId_IsNull() {
        // Arrange 
        string AfasOrderItemId = null;

        // Act
        var result = async () => await this._dataProvider.GetByAfasOrderItemIdAsync(AfasOrderItemId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByAfasOrderItemIdAsync_Should_ThrowException_If_Exception() {
        // Arrange 
        var AfasOrderItemId = this._fixture.Create<string>();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByAfasOrderItemIdAsync(AfasOrderItemId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }
    #endregion

    #region [ Override Methods -  ]
    [Fact]
    public async Task GetBySearchFilterAsync_Success() {
        //Arrange
        var entity = this.SeedSource.FirstOrDefault();
        var take = 5;
        var skip = 0;
        var expected = this.SeedSource.Where(x => (x.Id + x.Units + x.TargetGrades + x.TargetGroup).ToLower().Contains(entity.Id))
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

    #region [ Methods - Helper ]
    public override void Dispose() {
        this.CreateContext().Database.EnsureDeleted();
    }
    #endregion
}
