using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RCode;
using RCode.Data.Providers;
using ThiemeMeulenhoff.Platform.Data;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

[Collection("DataProvider")]
public class OrganizationDataProviderUnitTest : BaseEntityDataProviderUnitTests<OrganizationDataProvider<ThiemeMeulenhoffPlatformDbContext>, IOrganizationValidationProvider, Organization>
{
    #region [ CTor ]
    public OrganizationDataProviderUnitTest() : base(SeedProvider.Current.Organizations) {
    }
    #endregion

    #region [ Protected Methods - override ]
    protected override OrganizationDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        return new OrganizationDataProvider<ThiemeMeulenhoffPlatformDbContext>(
           this._logger.Object,
           this._dbContextFactory.Object,
           this._validationProvider.Object);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByAfasContactNumberAsync_Success() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        var expected = SeedSource.FirstOrDefault(x => x.AfasContactNumber == entity.AfasContactNumber);

        //Act
        var actual = await this._dataProvider.GetByAfasContactNumberAsync(entity.AfasContactNumber);

        //Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.CreatedAt.ToLongDateString(), actual.CreatedAt.ToLongDateString());
        Assert.Equal(expected.IsActive, actual.IsActive);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ThrowException_If_Exception() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetByAfasContactNumberAsync(entity.AfasContactNumber);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ThrowException_If_AfasContactNumber_IsEmpty() {
        // Arrange
        var afasContactNumber = string.Empty;

        //Act
        var result = async () => await this._dataProvider.GetByAfasContactNumberAsync(afasContactNumber);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ThrowException_If_AfasContactNumber_IsNull() {
        // Arrange
        var entity = default(Order);

        //Act
        var result = async () => await this._dataProvider.GetByAfasContactNumberAsync(entity.AfasContactNumber);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByAfasDebtorIdAsync_Success() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        var expected = SeedSource.FirstOrDefault(x => x.AfasDebtorId == entity.AfasDebtorId);

        //Act
        var actual = await this._dataProvider.GetByAfasDebtorIdAsync(entity.AfasDebtorId);

        //Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.CreatedAt.ToLongDateString(), actual.CreatedAt.ToLongDateString());
        Assert.Equal(expected.IsActive, actual.IsActive);
    }

    [Fact]
    public async Task GetByAfasDebtorIdAsync_Should_ThrowException_If_Exception() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetByAfasDebtorIdAsync(entity.AfasDebtorId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByAfasDebtorIdAsync_Should_ThrowException_If_AfasDebtorId_IsEmpty() {
        // Arrange
        var AfasDebtorId = string.Empty;

        //Act
        var result = async () => await this._dataProvider.GetByAfasDebtorIdAsync(AfasDebtorId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByAfasDebtorIdAsync_Should_ThrowException_If_AfasDebtorId_IsNull() {
        // Arrange
        var entity = default(Organization);

        //Act
        var result = async () => await this._dataProvider.GetByAfasDebtorIdAsync(entity.AfasDebtorId);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByAssuNumberAsync_Success() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        var expected = SeedSource.FirstOrDefault(x => x.AssuNumber == entity.AssuNumber);

        //Act
        var actual = await this._dataProvider.GetByAssuNumberAsync(entity.AssuNumber.Value);

        //Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.CreatedAt.ToLongDateString(), actual.CreatedAt.ToLongDateString());
        Assert.Equal(expected.IsActive, actual.IsActive);
    }

    [Fact]
    public async Task GetByAssuNumberAsync_Should_ThrowException_If_Exception() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetByAssuNumberAsync(entity.AssuNumber.Value);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }

    [Fact]
    public async Task GetByAssuNumberAsync_Should_ThrowException_If_AssuNumber_IsNull() {
        // Arrange
        var entity = default(Organization);

        //Act
        var result = async () => await this._dataProvider.GetByAssuNumberAsync(entity.AssuNumber.Value);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }
    
    [Fact]
    public async Task GetByCbPartijIdAsync_Success() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        var expected = SeedSource.FirstOrDefault(x => x.CbPartijId == entity.CbPartijId);

        //Act
        var actual = await this._dataProvider.GetByCbPartijIdAsync(entity.CbPartijId);

        //Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.CreatedAt.ToLongDateString(), actual.CreatedAt.ToLongDateString());
        Assert.Equal(expected.IsActive, actual.IsActive);
    }

    [Fact]
    public async Task GetByCbPartijIdAsync_Should_ThrowException_If_Exception() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetByCbPartijIdAsync(entity.CbPartijId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByCbPartijIdAsync_Should_ThrowException_If_CbPartijId_IsEmpty() {
        // Arrange
        var CbPartijId = string.Empty;

        //Act
        var result = async () => await this._dataProvider.GetByCbPartijIdAsync(CbPartijId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByCbPartijIdAsync_Should_ThrowException_If_CbPartijId_IsNull() {
        // Arrange
        var entity = default(Organization);

        //Act
        var result = async () => await this._dataProvider.GetByCbPartijIdAsync(entity.CbPartijId);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }
    
    [Fact]
    public async Task GetByPropellerIdAsync_Success() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        var expected = (from a in SeedProvider.Current.Organizations
                       where a.PropellerId == entity.PropellerId
                       select a).FirstOrDefault();

        //Act
        var actual = await this._dataProvider.GetByPropellerIdAsync(entity.PropellerId);

        //Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.CreatedAt.ToLongDateString(), actual.CreatedAt.ToLongDateString());
        Assert.Equal(expected.IsActive, actual.IsActive);
    }

    [Fact]
    public async Task GetByPropellerIdAsync_Should_ThrowException_If_Exception() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetByPropellerIdAsync(entity.PropellerId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByPropellerIdAsync_Should_ThrowException_If_PropellerId_IsEmpty() {
        // Arrange
        var PropellerId = string.Empty;

        //Act
        var result = async () => await this._dataProvider.GetByPropellerIdAsync(PropellerId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByPropellerIdAsync_Should_ThrowException_If_PropellerId_IsNull() {
        // Arrange
        var entity = default(Organization);

        //Act
        var result = async () => await this._dataProvider.GetByPropellerIdAsync(entity.PropellerId);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }
    
    [Fact]
    public async Task GetByOrganizationNameAsync_Success() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        var expected = SeedSource.FirstOrDefault(x => x.OrganizationName == entity.OrganizationName);

        //Act
        var actual = await this._dataProvider.GetByOrganizationNameAsync(entity.OrganizationName);

        //Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.CreatedAt.ToLongDateString(), actual.CreatedAt.ToLongDateString());
        Assert.Equal(expected.IsActive, actual.IsActive);
    }

    [Fact]
    public async Task GetByOrganizationNameAsync_Should_ThrowException_If_Exception() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetByOrganizationNameAsync(entity.OrganizationName);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByOrganizationNameAsync_Should_ThrowException_If_OrganizationName_IsEmpty() {
        // Arrange
        var OrganizationName = string.Empty;

        //Act
        var result = async () => await this._dataProvider.GetByOrganizationNameAsync(OrganizationName);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByOrganizationNameAsync_Should_ThrowException_If_OrganizationName_IsNull() {
        // Arrange
        var entity = default(Organization);

        //Act
        var result = async () => await this._dataProvider.GetByOrganizationNameAsync(entity.OrganizationName);

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
        var expected = this.SeedSource.Where(x => (x.OrganizationName + x.Email + x.Phone + x.WebsiteUrl).ToLower().Contains(entity.Id))
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

    [Fact]
    public override async Task CountActiveAsync_Success() {
        // Arrange
        var expected = this.SeedSource.Where(x => x.IsActive == true).Count()
                        + SeedProvider.Current.Schools.Where(x => x.IsActive == true).Count();

        // Act
        var actual = await this._dataProvider.CountActivelAsync();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public override async Task CountAllAsync_Success() {
        // Arrange
        var expected = this.SeedSource.Count
                        + +SeedProvider.Current.Schools.Count();

        // Act
        var actualResult = await this._dataProvider.CountAllAsync();

        // Assert
        Assert.Equal(expected, actualResult);
    }

    [Fact]
    public override async Task CountInActiveAsync_Success() {
        // Arrange
        var expected = this.SeedSource.Where(x => x.IsActive == false).Count()
                         + SeedProvider.Current.Schools.Where(x => x.IsActive == false).Count();

        // Act
        var actualResult = await this._dataProvider.CountInActiveAsync();

        // Assert
        Assert.Equal(expected, actualResult);
    }

    [Fact]
    public override async Task DeleteBatchAsync_Success() {
        // Arrange 
        var idList = new List<string>() {
            this.SeedSource[0].Id,
            this.SeedSource[1].Id,
            this.SeedSource[2].Id,
        };

        // Act
        await this._dataProvider.DeleteBatchAsync(idList);

        // Assert
        var dbEntities = await this._dataProvider.GetAllAsync();
        var expectedResult = this.SeedSource.Count()
                             + SeedProvider.Current.Schools.Count() 
                             - idList.Count();
        var actualResult = dbEntities.Count();
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public override async Task GetActiveAsync_Success() {
        // Arrange 
        var expected = this.SeedSource.Where(x => x.IsActive == true).Count()
                         + SeedProvider.Current.Schools.Where(x => x.IsActive == true).Count();

        // Assert
        var dbEntity = await this._dataProvider.GetActiveAsync();
        var actual = dbEntity.Count;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public override async Task GetAllAsync_Success() {
        // Arrange 
        var expected = this.SeedSource.Count
                         + SeedProvider.Current.Schools.Count();

        // Assert
        var dbEntity = await this._dataProvider.GetAllAsync();
        var actual = dbEntity.Count;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public override async Task GetChangesAsync_Success() {
        // Arrange 
        var date = DateTime.UtcNow.AddDays(-1);

        // Act
        var dbEntities = await this._dataProvider.GetChangesAsync(date);
        var actual = dbEntities.Count();
        var expected = this.SeedSource.Where(x => x.UpdatedAt > date).Count()
                         + SeedProvider.Current.Schools.Where(x => x.UpdatedAt > date).Count();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public override async Task GetInActiveAsync_Success() {
        // Arrange 
        var expected = this.SeedSource.Where(x => x.IsActive == false).Count()
                          + SeedProvider.Current.Schools.Where(x => x.IsActive == false).Count();

        // Assert
        var dbEntity = await this._dataProvider.GetInActiveAsync();
        var actual = dbEntity.Count;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public override async Task SaveAsync_AddEntity_Success() {
        // Arrange
        var entity = this.SeedSource.LastOrDefault();
        entity.Id = IdFactory.CreateId();

        // Act
        await this._dataProvider.SaveAsync(entity);

        // Assert
        var actual = (await _dataProvider.GetAllAsync()).Count();
        var expected = this.SeedSource.Count()
                         + SeedProvider.Current.Schools.Count();

        Assert.True((expected + 1) == actual);
    }

    [Fact]
    public override async Task SyncAsync_Add_Success() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        entity.Id = IdFactory.CreateId();

        // Act
        await this._dataProvider.SyncAsync(entity);

        // Assert
        var actual = (await _dataProvider.GetAllAsync()).Count();
        var expected = this.SeedSource.Count()
                         + SeedProvider.Current.Schools.Count();

        Assert.True((expected + 1) == actual);
    }
    #endregion
}
