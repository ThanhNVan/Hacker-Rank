using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using RCode.Data.Providers;
using ThiemeMeulenhoff.Platform.Data;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

[Collection("DataProvider")]
public class SchoolDataProviderUnitTest : BaseEntityDataProviderUnitTests<SchoolDataProvider<ThiemeMeulenhoffPlatformDbContext>, ISchoolValidationProvider, School>
{
    public SchoolDataProviderUnitTest() : base(SeedProvider.Current.Schools)
    {
    }

    #region [ Protected Methods - Override ]
    protected override SchoolDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider()
    {
        return new SchoolDataProvider<ThiemeMeulenhoffPlatformDbContext>(
           this._logger.Object,
           this._dbContextFactory.Object,
           this._validationProvider.Object);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByAfasContactNumberAsync_Success() {
        //Arrange
        var entity = SeedSource.FirstOrDefault();

        //Act
        var dbEntity = await this._dataProvider.GetByAfasContactNumberAsync(entity.AfasContactNumber);
        var expected = dbEntity.Id;
        var actual = entity.Id;

        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ThrowException_If_Entity_IsNull() {
        // Arrange 
        var entity = default(School);

        // Act
        var result = async () => await this._dataProvider.GetByAfasContactNumberAsync(entity.AfasContactNumber);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ThrowException_If_AfasContactNumber_IsEmpty() {
        // Arrange 
        var AfasContactNumber = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetByAfasContactNumberAsync(AfasContactNumber);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ThrowException_If_Error() {
        // Arrange 
        var AfasContactNumber = Guid.NewGuid().ToString();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByAfasContactNumberAsync(AfasContactNumber);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByBranchNumberAsync_Success()
    {
        //Arrange
        var entity = SeedSource.FirstOrDefault();

        //Act
        var dbEntity = await this._dataProvider.GetByBranchNumberAsync(entity.BranchNumber);
        var expected = dbEntity.Id;
        var actual = entity.Id;

        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetByBranchNumberAsync_Should_ThrowException_If_Entity_IsNull()
    {
        // Arrange 
        var entity = default(School);

        // Act
        var result = async () => await this._dataProvider.GetByBranchNumberAsync(entity.BranchNumber);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }
    
    [Fact]
    public async Task GetByBranchNumberAsync_Should_ThrowException_If_BranchNumber_IsEmpty()
    {
        // Arrange 
        var BranchNumber = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetByBranchNumberAsync(BranchNumber);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }
    
    [Fact]
    public async Task GetByBranchNumberAsync_Should_ThrowException_If_Error()
    {
        // Arrange 
        var BranchNumber = Guid.NewGuid().ToString();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByBranchNumberAsync(BranchNumber);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByBrinCodeAsync_Success()
    {
        //Arrange
        var entity = SeedSource.FirstOrDefault();

        //Act
        var dbEntity = await this._dataProvider.GetByBrinCodeAsync(entity.BrinCode);
        var expected = dbEntity.Id;
        var actual = entity.Id;

        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetByBrinCodeAsync_Should_ThrowException_If_Entity_IsNull()
    {
        // Arrange 
        var entity = default(School);

        // Act
        var result = async () => await this._dataProvider.GetByBrinCodeAsync(entity.BrinCode);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByBrinCodeAsync_Should_ThrowException_If_BrinCode_IsEmpty() {
        // Arrange 
        var BrinCode = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetByBrinCodeAsync(BrinCode);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByBrinCodeAsync_Should_ThrowException_If_Error() {
        // Arrange 
        var BrinCode = Guid.NewGuid().ToString();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByBrinCodeAsync(BrinCode);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetBySchoolBoardNumberAsync_Success()
    {
        //Arrange
        var entity = SeedSource.FirstOrDefault();

        //Act
        var dbEntity = await this._dataProvider.GetBySchoolBoardNumberAsync(entity.SchoolBoardNumber);
        var expected = dbEntity.Id;
        var actual = entity.Id;

        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetBySchoolBoardNumberAsync_Should_ThrowException_If_Entity_IsNull()
    {
        // Arrange 
        var entity = default(School);

        // Act
        var result = async () => await this._dataProvider.GetBySchoolBoardNumberAsync(entity.SchoolBoardNumber);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetBySchoolBoardNumberAsync_Should_ThrowException_If_SchoolBoardNumber_IsEmpty() {
        // Arrange 
        var SchoolBoardNumber = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetBySchoolBoardNumberAsync(SchoolBoardNumber);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetBySchoolBoardNumberAsync_Should_ThrowException_If_Error() {
        // Arrange 
        var SchoolBoardNumber = Guid.NewGuid().ToString();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetBySchoolBoardNumberAsync(SchoolBoardNumber);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByAssuNumberAsync_Success() {
        //Arrange
        var entity = SeedSource.FirstOrDefault();

        //Act
        var dbEntity = await this._dataProvider.GetByAssuNumberAsync(entity.AssuNumber.Value);
        var expected = dbEntity.Id;
        var actual = entity.Id;

        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetByAssuNumberAsync_Should_ThrowException_If_Entity_IsNull() {
        // Arrange 
        var entity = default(School);

        // Act
        var result = async () => await this._dataProvider.GetByAssuNumberAsync(entity.AssuNumber.Value);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByAssuNumberAsync_Should_ThrowException_If_Error() {
        // Arrange 
        var input = this._fixture.Create<int>();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception()); 

        // Act
        var result = async () => await this._dataProvider.GetByAssuNumberAsync(input);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }

    [Fact]
    public async Task GetByAssuNumberTempAsync_Success() {
        //Arrange
        var entity = SeedSource.FirstOrDefault();

        //Act
        var dbEntity = await this._dataProvider.GetByAssuNumberTempAsync(entity.AssuNumberTemporary);
        var expected = dbEntity.Id;
        var actual = entity.Id;

        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetByAssuNumberTempAsync_Should_ThrowException_If_Entity_IsNull() {
        // Arrange 
        var entity = default(School);

        // Act
        var result = async () => await this._dataProvider.GetByAssuNumberTempAsync(entity.AssuNumberTemporary);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task TaskGetByAssuNumberTempAsync_Should_ThrowException_If_Error() {
        // Arrange 
        var input = this._fixture.Create<int>();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByAssuNumberTempAsync(input);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    #endregion

    #region [ Override Methods -  ]
    [Fact]
    public async Task GetBySearchFilterAsync_Success() {
        //Arrange
        var entity = this.SeedSource.FirstOrDefault();
        var take = 5;
        var skip = 0;
        var expected = this.SeedSource.Where(x => (x.OrganizationName + x.Email + x.Phone + x.AssuOnderwijsType + x.EducationType).ToLower().Contains(entity.Id))
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
