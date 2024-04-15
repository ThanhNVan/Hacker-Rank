using RCode.Data.Providers;
using System.Linq;
using System.Threading.Tasks;
using System;
using ThiemeMeulenhoff.Platform.Data;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

[Collection("DataProvider")]
public class PersonDataProviderUnitTest : BaseEntityDataProviderUnitTests<PersonDataProvider<ThiemeMeulenhoffPlatformDbContext>, IPersonValidationProvider, Person>
{
    #region [ CTor ]
    public PersonDataProviderUnitTest() : base(SeedProvider.Current.Persons)
    {
    }
    #endregion

    #region [ Protected Methods - override ]
    protected override PersonDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider()
    {
        return new PersonDataProvider<ThiemeMeulenhoffPlatformDbContext>(
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
        var entity = default(Person);

        //Act
        var result = async () => await this._dataProvider.GetByAfasContactNumberAsync(entity.AfasContactNumber);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByAssuNumberAsync_Success() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        var expected = SeedSource.FirstOrDefault(x => x.AssuNumber.Value == entity.AssuNumber.Value);

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
        var entity = default(Person);

        //Act
        var result = async () => await this._dataProvider.GetByAssuNumberAsync(entity.AssuNumber.Value);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByAssuNumberTempAsync_Success() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        var expected = SeedSource.FirstOrDefault(x => x.AssuNumberTemporary == entity.AssuNumberTemporary);

        //Act
        var actual = await this._dataProvider.GetByAssuNumberTempAsync(entity.AssuNumberTemporary);

        //Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.CreatedAt.ToLongDateString(), actual.CreatedAt.ToLongDateString());
        Assert.Equal(expected.IsActive, actual.IsActive);
    }

    [Fact]
    public async Task GetByAssuNumberTempAsync_Should_ThrowException_If_Exception() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetByAssuNumberTempAsync(entity.AssuNumberTemporary);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }

    [Fact]
    public async Task GetByAssuNumberTempAsync_Should_ThrowException_If_Param_IsNull() {
        // Arrange
        var entity = default(Person);

        //Act
        var result = async () => await this._dataProvider.GetByAssuNumberTempAsync(entity.AssuNumberTemporary);

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
        var entity = default(Person);

        //Act
        var result = async () => await this._dataProvider.GetByCbPartijIdAsync(entity.CbPartijId);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }
    
    [Fact]
    public async Task GetByPropellerIdAsync_Success() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        var expected = SeedSource.FirstOrDefault(x => x.PropellerId == entity.PropellerId);

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
        var entity = default(Person);

        //Act
        var result = async () => await this._dataProvider.GetByPropellerIdAsync(entity.PropellerId);

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
        var expected = this.SeedSource.Where(x => (x.LastNamePrefix + x.FirstName + x.LastName + x.PrivateEmail + x.PrivatePhone).ToLower().Contains(entity.Id))
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
