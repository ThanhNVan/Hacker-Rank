using RCode.Data.Providers;
using System.Linq;
using System.Threading.Tasks;
using System;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

[Collection("DataProvider")]
public class StockMutationDataProviderUnitTest : BaseEntityDataProviderUnitTests<StockMutationDataProvider<ThiemeMeulenhoffPlatformDbContext>, IStockMutationValidationProvider, StockMutation>
{
    #region [ CTor ]
    public StockMutationDataProviderUnitTest() : base(SeedProvider.Current.StockMutations) {
    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override StockMutationDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        return new StockMutationDataProvider<ThiemeMeulenhoffPlatformDbContext>(
           this._logger.Object,
           this._dbContextFactory.Object,
           this._validationProvider.Object);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetLastBySourceAsync_Success() {
        //Arrange
        var entity = SeedSource.FirstOrDefault();

        //Act
        var dbEntity = await this._dataProvider.GetLastBySourceAsync(entity.ProductId, entity.MutationSourceName);
        var expected = dbEntity.Id;
        var actual = entity.Id;

        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetLastBySourceAsync_Should_ThrowException_If_Entity_IsNull() {
        // Arrange 
        var entity = default(StockMutation);

        // Act
        var result = async () => await this._dataProvider.GetLastBySourceAsync(entity.ProductId, entity.MutationSourceName);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetLastBySourceAsync_Should_ThrowException_If_ProductId_IsEmpty() {
        // Arrange 
        var ProductId = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetLastBySourceAsync(ProductId, ProductId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetLastBySourceAsync_Should_ThrowException_If_Error() {
        // Arrange 
        var ProductId = Guid.NewGuid().ToString();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetLastBySourceAsync(ProductId, ProductId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }
    #endregion

    #region [ Public Methods - Custom - List ]
    [Fact]
    public async Task GetByProductIdAsync_Success() {
        //Arrange
        var entity = this.SeedSource.FirstOrDefault();
        var expected = SeedSource.Where(x =>
                x.ProductId == entity.ProductId
            );

        //Act
        var dbEntity = await this._dataProvider.GetByProductIdAsync(entity.ProductId);
        var actual = dbEntity.Count;

        //Assert
        Assert.Equal(expected.Count(), actual);
    }

    [Fact]
    public async Task GetByProductIdAsync_Should_ThrowException_If_Entity_IsNull() {
        // Arrange 
        var entity = default(StockMutation);

        // Act
        var result = async () => await this._dataProvider.GetByProductIdAsync(entity.ProductId);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByProductIdAsync_Should_ThrowException_If_ProductId_IsEmpty() {
        // Arrange 
        var ProductId = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetByProductIdAsync(ProductId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByProductIdAsync_Should_ThrowException_If_Error() {
        // Arrange 
        var ProductId = Guid.NewGuid().ToString();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByProductIdAsync(ProductId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }
    
    [Fact]
    public async Task GetByContactIdAsync_Success() {
        //Arrange
        var entity = this.SeedSource.FirstOrDefault();
        var expected = SeedSource.Where(x =>
                x.ContactId == entity.ContactId
            );

        //Act
        var dbEntity = await this._dataProvider.GetByContactIdAsync(entity.ContactId);
        var actual = dbEntity.Count;

        //Assert
        Assert.Equal(expected.Count(), actual);
    }

    [Fact]
    public async Task GetByContactIdAsync_Should_ThrowException_If_Entity_IsNull() {
        // Arrange 
        var entity = default(StockMutation);

        // Act
        var result = async () => await this._dataProvider.GetByContactIdAsync(entity.ContactId);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByContactIdAsync_Should_ThrowException_If_ContactId_IsEmpty() {
        // Arrange 
        var ContactId = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetByContactIdAsync(ContactId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByContactIdAsync_Should_ThrowException_If_Error() {
        // Arrange 
        var ContactId = Guid.NewGuid().ToString();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByContactIdAsync(ContactId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }
    
    [Fact]
    public async Task GetByAfasWarehouseIdAsync_Success() {
        //Arrange
        var entity = this.SeedSource.FirstOrDefault();
        var expected = SeedSource.Where(x =>
                x.AfasWarehouseId == entity.AfasWarehouseId
            );

        //Act
        var dbEntity = await this._dataProvider.GetByAfasWarehouseIdAsync(entity.AfasWarehouseId);
        var actual = dbEntity.Count;

        //Assert
        Assert.Equal(expected.Count(), actual);
    }

    [Fact]
    public async Task GetByAfasWarehouseIdAsync_Should_ThrowException_If_Entity_IsNull() {
        // Arrange 
        var entity = default(StockMutation);

        // Act
        var result = async () => await this._dataProvider.GetByAfasWarehouseIdAsync(entity.AfasWarehouseId);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByAfasWarehouseIdAsync_Should_ThrowException_If_AfasWarehouseId_IsEmpty() {
        // Arrange 
        var AfasWarehouseId = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetByAfasWarehouseIdAsync(AfasWarehouseId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByAfasWarehouseIdAsync_Should_ThrowException_If_Error() {
        // Arrange 
        var AfasWarehouseId = Guid.NewGuid().ToString();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByAfasWarehouseIdAsync(AfasWarehouseId);

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
        var expected = this.SeedSource.Where(x => (x.Id + x.ProductId + x.Units + x.ContactId + x.AfasWarehouseId + x.MutationSourceName).ToLower().Contains(entity.Id))
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
}
