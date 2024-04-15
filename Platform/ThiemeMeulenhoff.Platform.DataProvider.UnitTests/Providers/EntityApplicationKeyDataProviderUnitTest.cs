using System;
using System.Linq;
using System.Threading.Tasks;
using RCode.Data.Providers;
using ThiemeMeulenhoff.Platform.Data;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

[Collection("DataProvider")]
public class EntityApplicationKeyDataProviderUnitTest : BaseEntityDataProviderUnitTests<EntityApplicationKeyDataProvider<ThiemeMeulenhoffPlatformDbContext>, IEntityApplicationKeyValidationProvider, EntityApplicationKey>
{
    #region [ CTor ]
    public EntityApplicationKeyDataProviderUnitTest() : base(SeedProvider.Current.EntityApplicationKeys) {
    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override EntityApplicationKeyDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        return new EntityApplicationKeyDataProvider<ThiemeMeulenhoffPlatformDbContext>(
          this._logger.Object,
          this._dbContextFactory.Object,
          this._validationProvider.Object);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByApplicationKeyAsync_Success() {
        //Arrange
        var entity = SeedSource.FirstOrDefault();

        //Act
        var dbEntity = await this._dataProvider.GetByApplicationKeyAsync(entity.ApplicationName, entity.ApplicationKey);
        var expect = entity.Id;
        var actual = dbEntity.Id;

        //Assert
        Assert.Equal(expect, actual);
    }

    [Fact]
    public async Task GetByApplicationKeyAsync_Should_ThrowException_If_ApplicationName_IsEmpty() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        var applicationName = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetByApplicationKeyAsync(applicationName, entity.ApplicationKey);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByApplicationKeyAsync_Should_ThrowException_If_ApplicationKey_IsEmpty() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        var applicationKey = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetByApplicationKeyAsync(entity.ApplicationName, applicationKey);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByEntityIdAsync_TwoParam_Success() {
        // Arrange
        var expected = SeedSource.FirstOrDefault();

        // Act
        var actual = await this._dataProvider.GetByEntityIdAsync(expected.ApplicationName, expected.EntityId);

        // Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.IsActive, actual.IsActive);
        Assert.Equal(expected.CreatedAt.ToLongDateString(), actual.CreatedAt.ToLongDateString());
    }
    
    [Fact]
    public async Task GetByEntityIdAsync_TwoParam_Should_ThrowException_If_ApplicationName_IsEmpty() {
        // Arrange
        var expected = SeedSource.FirstOrDefault();

        // Act
        var result = async () => await this._dataProvider.GetByEntityIdAsync(string.Empty, expected.ApplicationKey);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }
    
    [Fact]
    public async Task GetByEntityIdAsync_TwoParam_Should_ThrowException_If_EntityId_IsEmpty() {
        // Arrange
        var expected = SeedSource.FirstOrDefault();

        // Act
        var result = async () => await this._dataProvider.GetByEntityIdAsync(expected.ApplicationName, string.Empty);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }
    
    [Fact]
    public async Task GetByEntityIdAsync_TwoParam_Should_ThrowException_If_Error() {
        // Arrange
        var expected = SeedSource.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByEntityIdAsync(expected.ApplicationName, expected.ApplicationKey);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }
    #endregion

    #region [ Public Methods - Custom - List ]
    [Fact]
    public async Task GetByEntityIdAsync_Success() {
        //Arrange
        var entity = this.SeedSource.First();
        var expected = this.SeedSource.Where(x => x.EntityId == entity.EntityId);

        //Act
        var actual = await this._dataProvider.GetByEntityIdAsync(entity.EntityId);

        //Assert
        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetByEntityIdAsync_Should_ThrowException_If_EntityId_IsEmpty() {
        // Arrange
        var entityId = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetByEntityIdAsync(entityId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByEntityIdAsync_Should_ThrowException_If_EntityId_IsNull() {
        // Arrange
        var entity = default(EntityApplicationKey);

        // Act
        var result = async () => await this._dataProvider.GetByEntityIdAsync(entity.EntityId);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }
    #endregion

    #region [ Override Methods -  ]
    [Fact]
    public async Task GetBySearchFilterAsync_Success() {
        //Arrange
        var entity = this.SeedSource.FirstOrDefault();
        var take = 5;
        var skip = 0;
        var expected = this.SeedSource.Where(x => (x.Id + x.EntityId + x.EntityType + x.EntityPropertyName + x.ApplicationName + x.ApplicationKey + x.ColumnName).ToLower().Contains(entity.Id))
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
    public async Task GetBySearchFilterAsync_Should_ThrowException_If_Exception() {
        // Arrange 
        var searchFilter = string.Empty;
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