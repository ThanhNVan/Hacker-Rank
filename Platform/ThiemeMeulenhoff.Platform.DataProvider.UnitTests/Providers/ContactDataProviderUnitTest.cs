using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RCode;
using RCode.Data.Providers;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class ContactDataProviderUnitTest : BaseEntityDataProviderUnitTests<ContactDataProvider<ThiemeMeulenhoffPlatformDbContext>, IContactValidationProvider, Contact>
{
    #region [ CTor ]
    public ContactDataProviderUnitTest() : base(SeedProvider.Current.Contacts) {
    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override ContactDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        return new ContactDataProvider<ThiemeMeulenhoffPlatformDbContext>(
           this._logger.Object,
           this._dbContextFactory.Object,
           this._validationProvider.Object);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByAfasContactNumberAsync_Success() {
        // Arrange
        var expected = this.SeedSource[0];

        // Act
        var actualResult = await this._dataProvider.GetByAfasContactNumberAsync(expected.AfasContactNumber);

        // Assert
        Assert.Equal(expected.Id, actualResult.Id);
        Assert.Equal(expected.AfasContactNumber, actualResult.AfasContactNumber);
        Assert.Equal(expected.CreatedAt.ToLongDateString(), actualResult.CreatedAt.ToLongDateString());
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ThrowException_If_Id_IsEmpty() {
        // Arrange 
        var entityNumber = default(string);

        // Act
        var result = async () => await this._dataProvider.GetByAfasContactNumberAsync(entityNumber);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ThrowException_If_Id_IsNull() {
        // Arrange 
        var entity = default(Contact);

        // Act
        var result = async () => await this._dataProvider.GetByAfasContactNumberAsync(entity.AfasContactNumber);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByAfasDebtorIdAsync_Success() {
        // Arrange
        var expected = this.SeedSource[0];

        // Act
        var actualResult = await this._dataProvider.GetByAfasDebtorIdAsync(expected.AfasDebtorId);

        // Assert
        Assert.Equal(expected.Id, actualResult.Id);
        Assert.Equal(expected.AfasContactNumber, actualResult.AfasContactNumber);
        Assert.Equal(expected.CreatedAt.ToLongDateString(), actualResult.CreatedAt.ToLongDateString());
    }

    [Fact]
    public async Task GetByAfasDebtorIdAsync_Should_ThrowException_If_AfasDebtorId_IsEmpty() {
        // Arrange 
        var entityId = default(string);

        // Act
        var result = async () => await this._dataProvider.GetByAfasDebtorIdAsync(entityId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByCbPartijIdAsync_Success() {
        // Arrange
        var expected = this.SeedSource[0];

        // Act
        var actualResult = await this._dataProvider.GetByCbPartijIdAsync(expected.CbPartijId);

        // Assert
        Assert.Equal(expected.Id, actualResult.Id);
        Assert.Equal(expected.AfasContactNumber, actualResult.AfasContactNumber);
        Assert.Equal(expected.CreatedAt.ToLongDateString(), actualResult.CreatedAt.ToLongDateString());
    }

    [Fact]
    public async Task GetByCbPartijIdAsync_Should_ThrowException_If_Id_IsEmpty() {
        // Arrange 
        var entityId = default(string);

        // Act
        var result = async () => await this._dataProvider.GetByCbPartijIdAsync(entityId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByCbPartijIdAsync_Should_ThrowException_If_Id_IsNull() {
        // Arrange 
        var entity = default(Contact);

        // Act
        var result = async () => await this._dataProvider.GetByCbPartijIdAsync(entity.CbPartijId);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByCbPartijIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var expected = this.SeedSource[0];
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByCbPartijIdAsync(expected.CbPartijId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }
    
    [Fact]
    public async Task GetByPropellerIdAsync_Success() {
        // Arrange
        var expected = this.SeedSource[0];

        // Act
        var actualResult = await this._dataProvider.GetByPropellerIdAsync(expected.PropellerId);

        // Assert
        Assert.Equal(expected.Id, actualResult.Id);
        Assert.Equal(expected.AfasContactNumber, actualResult.AfasContactNumber);
        Assert.Equal(expected.CreatedAt.ToLongDateString(), actualResult.CreatedAt.ToLongDateString());
    }

    [Fact]
    public async Task GetByPropellerIdAsync_Should_ThrowException_If_Id_IsEmpty() {
        // Arrange 
        var entityId = default(string);

        // Act
        var result = async () => await this._dataProvider.GetByPropellerIdAsync(entityId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByPropellerIdAsync_Should_ThrowException_If_Id_IsNull() {
        // Arrange 
        var entity = default(Contact);

        // Act
        var result = async () => await this._dataProvider.GetByPropellerIdAsync(entity.PropellerId);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByPropellerIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var expected = this.SeedSource[0];
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByPropellerIdAsync(expected.PropellerId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByAssuNumberAsync_Success() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        var expected = SeedSource.FirstOrDefault(x => x.AssuNumber == entity.AssuNumber);

        //Act
        var actual = await this._dataProvider.GetByAssuNumberAsync(entity.AssuNumber.GetValueOrDefault());

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
        var result = async () => await this._dataProvider.GetByAssuNumberAsync(entity.AssuNumber.GetValueOrDefault());

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
    #endregion

    #region [ Override Methods - ]
    [Fact]
    public async Task GetBySearchFilterAsync_Success() {
        // Arrange
        var entity = this.SeedSource[0];
        var take = 5;
        var skip = 0;
        var expected = this.SeedSource.Where(x => (x.Id + x.AfasDebtorId + x.CbPartijId + x.AfasContactNumber).ToLower().Contains(entity.Id))
                            .Skip(skip)
                            .Take(take);

        // Act
        var actualResult = await this._dataProvider.GetBySearchFilterAsync(entity.Id, take, skip);

        // Assert
        Assert.Equal(expected.Count(), actualResult.Count);
    }

    [Fact]
    public async Task GetBySearchFilterAsync_Should_ThrowException_If_SearchFilter_IsEmpty() {
        // Arrange 
        var entityId = default(string);
        var take = 5;
        var skip = 0;

        // Act
        var result = async () => await this._dataProvider.GetBySearchFilterAsync(entityId, take, skip);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetBySearchFilterAsync_Should_ThrowException_If_SearchFilter_IsNull() {
        // Arrange 
        var entity = default(Contact);
        var take = 5;
        var skip = 0;

        // Act
        var result = async () => await this._dataProvider.GetBySearchFilterAsync(entity.CbPartijId, take, skip);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }
    #endregion

    #region [ Override Methods -  ]
    [Fact]
    public override async Task CountAllAsync_Success() {
        // Arrange
        var expected = this.SeedSource.Count
                        + SeedProvider.Current.Organizations.Count()
                        + SeedProvider.Current.Schools.Count()
                        + SeedProvider.Current.Persons.Count();

        // Act
        var actualResult = await this._dataProvider.CountAllAsync();

        // Assert
        Assert.Equal(expected, actualResult);
    }

    [Fact]
    public override async Task CountActiveAsync_Success() {
        // Arrange
        var expected = this.SeedSource.Where(x => x.IsActive == true).Count() 
                        + SeedProvider.Current.Organizations.Where(x => x.IsActive == true).Count() 
                        + SeedProvider.Current.Schools.Where(x => x.IsActive == true).Count() 
                        + SeedProvider.Current.Persons.Where(x => x.IsActive == true).Count();

        // Act
        var actualResult = await this._dataProvider.CountActivelAsync();

        // Assert
        Assert.Equal(expected, actualResult);
    }

    [Fact]
    public override async Task CountInActiveAsync_Success() {
        // Arrange
        var expected = this.SeedSource.Where(x => x.IsActive == false).Count()
                        + SeedProvider.Current.Organizations.Where(x => x.IsActive == false).Count()
                        + SeedProvider.Current.Schools.Where(x => x.IsActive == false).Count()
                        + SeedProvider.Current.Persons.Where(x => x.IsActive == false).Count();


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
        var expectedResult = this.SeedSource.Count
                        + SeedProvider.Current.Organizations.Count()
                        + SeedProvider.Current.Schools.Count()
                        + SeedProvider.Current.Persons.Count()
                        - idList.Count();
        var actualResult = dbEntities.Count();
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public override async Task GetActiveAsync_Success() {
        // Arrange 
        var expected = this.SeedSource.Where(x => x.IsActive == true).Count()
                        + SeedProvider.Current.Organizations.Where(x => x.IsActive == true).Count()
                        + SeedProvider.Current.Schools.Where(x => x.IsActive == true).Count()
                        + SeedProvider.Current.Persons.Where(x => x.IsActive == true).Count();

        // Assert
        var dbEntity = await this._dataProvider.GetActiveAsync();
        var actual = dbEntity.Count;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public override async Task GetAllAsync_Success() {
        // Arrange 
        var expected = this.SeedSource.Count
                        + SeedProvider.Current.Organizations.Count()
                        + SeedProvider.Current.Schools.Count()
                        + SeedProvider.Current.Persons.Count();

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
        var actualResult = dbEntities.Count();
        var expectedResult = this.SeedSource.Where(x => x.UpdatedAt > date).Count()
                        + SeedProvider.Current.Organizations.Where(x => x.UpdatedAt > date).Count()
                        + SeedProvider.Current.Schools.Where(x => x.UpdatedAt > date).Count()
                        + SeedProvider.Current.Persons.Where(x => x.UpdatedAt > date).Count();

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public override async Task GetInActiveAsync_Success() {
        // Arrange 
        var expected = this.SeedSource.Where(x => x.IsActive == false).Count()
                        + SeedProvider.Current.Organizations.Where(x => x.IsActive == false).Count()
                        + SeedProvider.Current.Schools.Where(x => x.IsActive == false).Count()
                        + SeedProvider.Current.Persons.Where(x => x.IsActive == false).Count();

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
        var expected = this.SeedSource.Count
                        + SeedProvider.Current.Organizations.Count()
                        + SeedProvider.Current.Schools.Count()
                        + SeedProvider.Current.Persons.Count();

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
        var expected = this.SeedSource.Count
                        + SeedProvider.Current.Organizations.Count()
                        + SeedProvider.Current.Schools.Count()
                        + SeedProvider.Current.Persons.Count();

        Assert.True((expected + 1) == actual);
    }
    #endregion
}