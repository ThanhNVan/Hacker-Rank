using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using RCode;
using RCode.Data.Providers;
using ThiemeMeulenhoff.Platform.Data;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

[Collection("DataProvider")]
public class EanCodeDataProviderUnitTest : BaseEntityDataProviderUnitTests<EanCodeDataProvider<ThiemeMeulenhoffPlatformDbContext>, IEanCodeValidationProvider, EanCode>
{
    #region [ CTor ]
    public EanCodeDataProviderUnitTest() : base(SeedProvider.Current.EanCodes) {
    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override EanCodeDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        return new EanCodeDataProvider<ThiemeMeulenhoffPlatformDbContext>(
           this._logger.Object,
           this._dbContextFactory.Object,
           this._validationProvider.Object);
    }
    #endregion

    #region [ Public Methods - Custom - Create ]
    [Fact]
    public async Task CreateAndAddAsync_Success() {
        // Arrange
        var expected = this.SeedSource[0];
        expected.BaseCode = "AABBCC1";
        expected.TitleCode = "1234567";
        expected.CheckCode = "1";

        // Act
        var actual = await this._dataProvider.CreateAndAddAsync(expected.BaseCode, expected.TitleCode, expected.CheckCode);

        // Assert
        Assert.Equal(expected.BaseCode, actual.BaseCode);
        Assert.Equal(expected.TitleCode, actual.TitleCode);
        Assert.Equal(expected.CheckCode, actual.CheckCode);
    }

    [Fact]
    public async Task CreateAndAddAsync_Should_ThrowException_If_BaseCode_IsEmpty() {
        // Arrange
        var BaseCode = string.Empty;
        var TitleCode = "1234567";
        var CheckCode = "1";

        // Act
        var result = async () => await this._dataProvider.CreateAndAddAsync(BaseCode, TitleCode, CheckCode);

        // Assert
        await Assert.ThrowsAsync<DataProviderAddException>(result);
    }

    [Fact]
    public async Task CreateAndAddAsync_Should_ThrowException_If_TitleCode_IsEmpty() {
        // Arrange
        var BaseCode = "AABBCC1";
        var TitleCode = string.Empty;
        var CheckCode = "1";

        // Act
        var result = async () => await this._dataProvider.CreateAndAddAsync(BaseCode, TitleCode, CheckCode);

        // Assert
        await Assert.ThrowsAsync<DataProviderAddException>(result);
    }

    [Fact]
    public async Task CreateAndAddAsync_Should_ThrowException_If_CheckCode_IsEmpty() {
        // Arrange
        var BaseCode = "AABBCC1";
        var TitleCode = "1234567";
        var CheckCode = string.Empty;

        // Act
        var result = async () => await this._dataProvider.CreateAndAddAsync(BaseCode, TitleCode, CheckCode);

        // Assert
        await Assert.ThrowsAsync<DataProviderAddException>(result);
    }

    [Fact]
    public async Task CreateAndAddTitleCodeAsync_Success() {
        // Arrange
        var BaseCode = "AABBCC1";

        // Act
        var result = await this._dataProvider.CreateAndAddTitleCodeAsync(BaseCode);

        // Assert
        Assert.Equal(BaseCode, result.BaseCode);
    }

    [Fact]
    public async Task CreateAndAddTitleCodeAsync_Should_ThrowException_If_BaseCode_IsEmpty() {
        // Arrange
        var BaseCode = string.Empty;

        // Act
        var result = async () => await this._dataProvider.CreateAndAddTitleCodeAsync(BaseCode);

        // Assert
        await Assert.ThrowsAsync<DataProviderAddException>(result);
    }

    [Fact]
    public async Task GenerateTitleCodeAsync_Success() {
        // Arrange
        var BaseCode = "AABBCC1";

        // Act
        var result = await this._dataProvider.GenerateTitleCodeAsync(BaseCode);

        // Assert
        Assert.Equal(BaseCode, result.BaseCode);
    }

    [Fact]
    public async Task GenerateTitleCodeAsync_Should_ThrowException_If_BaseCode_IsEmpty() {
        // Arrange
        var BaseCode = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GenerateTitleCodeAsync(BaseCode);

        // Assert
        await Assert.ThrowsAsync<DataProviderAddException>(result);
    }

    [Fact]
    public async Task GenerateTitleCodesAsync_Success() {
        // Arrange
        var BaseCode = "AABBCC1";
        var numberOfCodes = 2;

        // Act
        var result = await this._dataProvider.GenerateTitleCodesAsync(BaseCode, numberOfCodes);

        // Assert
        for (int i = 0; i < numberOfCodes; i++) {
            Assert.Equal(BaseCode, result[i].BaseCode);
        }
        Assert.Equal(result.Count, numberOfCodes);
    }

    [Fact]
    public async Task GenerateTitleCodesAsync_Should_ThrowException_If_BaseCode_IsEmpty() {
        // Arrange
        var BaseCode = string.Empty;
        var numberOfCodes = 2;

        // Act
        var result = async () => await this._dataProvider.GenerateTitleCodesAsync(BaseCode, numberOfCodes);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByBaseCodeAsync_Success() {
        // Arrange
        var expected = this.SeedSource.FirstOrDefault(x => x.CodeType == EanCodeType.Base);

        // Act
        var actual = await this._dataProvider.GetByBaseCodeAsync();

        // Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.BaseCode, actual.BaseCode);
        Assert.Equal(expected.FullCode, actual.FullCode);
        Assert.Equal(expected.CheckCode, actual.CheckCode);
        Assert.Equal(expected.CreatedAt.ToShortDateString(), actual.CreatedAt.ToShortDateString());
    }


    [Fact]
    public async Task GetByCodeAsync_Should_ThrowException_If_Exception() {
        // Arrange
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByBaseCodeAsync();

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByCodeAsync_Success() {
        // Arrange
        var expected = this.SeedSource.FirstOrDefault();

        // Act
        var actual = await this._dataProvider.GetByCodeAsync(expected.FullCode);

        // Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.BaseCode, actual.BaseCode);
        Assert.Equal(expected.FullCode, actual.FullCode);
        Assert.Equal(expected.CheckCode, actual.CheckCode);
        Assert.Equal(expected.CreatedAt.ToShortDateString(), actual.CreatedAt.ToShortDateString());
    }

    [Fact]
    public async Task GetByCodeAsync_Should_ThrowException_If_BaseCode_IsEmpty() {
        // Arrange
        var fullcode = string.Empty;

        // Act
        var actual = async () => await this._dataProvider.GetByCodeAsync(fullcode);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(actual);
    }

    [Fact]
    public async Task GetByCodeAsync_Should_ThrowException_If_BaseCode_IsNull() {
        // Arrange
        var entity = default(EanCode);

        // Act
        var actual = async () => await this._dataProvider.GetByCodeAsync(entity.FullCode);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(actual);
    }
    #endregion

    #region [ Public Methods - Custom - List ]
    [Fact]
    public async Task GetAllBaseCodeAsync_Success() {
        // Arrange
        var expected = this.SeedSource.Where(x => x.CodeType == EanCodeType.Base);

        // Act
        var actual = await this._dataProvider.GetAllBaseCodeAsync();

        // Assert

        Assert.Equal(expected.Count(), actual.Count);
    }


    [Fact]
    public async Task GetAllBaseCodeAsync_Should_ThrowException_If_Exception() {
        // Arrange
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetAllBaseCodeAsync();

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByBaseCodeAsync_List_Success() {
        // Arrange
        var baseCode = this.SeedSource.FirstOrDefault().BaseCode;
        var expected = this.SeedSource.Where(x => x.BaseCode == baseCode && x.CodeType != EanCodeType.Base);

        // Act
        var actual = await this._dataProvider.GetByBaseCodeAsync(baseCode);

        // Assert
        Assert.Equal(expected.Count(), actual.Count);
    }
    [Fact]
    public async Task GetByBaseCodeAsync_Should_ThrowException_If_BaseCode_IsEmpty() {
        // Arrange
        var baseCode = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetByBaseCodeAsync(baseCode);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetUnregisteredCodesAsync_Sucess() {
        // Arrange
        var expected = this.SeedSource.Where(x => !x.IsRegister);

        // Act
        var actual = await this._dataProvider.GetUnregisteredCodesAsync();

        // Assert
        Assert.Equal(expected.Count(), actual.Count);
    }


    [Fact]
    public async Task GetUnregisteredCodesAsync_Should_ThrowException_If_Exception() {
        // Arrange
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetUnregisteredCodesAsync();

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetUnregisteredCodesAsync_BaseCode_Success() {
        // Arrange
        var basecode = this.SeedSource.First().BaseCode;
        var expected = this.SeedSource.Where(x => !x.IsRegister && x.BaseCode == basecode);

        // Act
        var actual = await this._dataProvider.GetUnregisteredCodesAsync(basecode);

        // Assert
        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetUnregisteredCodesAsync_Should_ThrowException_If_BaseCode_IsEmpty() {
        // Arrange
        var basecode = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetUnregisteredCodesAsync(basecode);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetAllTitleCodeAsync_Success() {
        // Arrange
        var expected = this.SeedSource.Where(x => x.CodeType == EanCodeType.Title);

        // Act
        var actual = await this._dataProvider.GetAllTitleCodeAsync();

        // Assert
        Assert.Equal(expected.Count(), actual.Count);
    }


    [Fact]
    public async Task GetAllTitleCodeAsync_Should_ThrowException_If_Exception() {
        // Arrange
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetAllTitleCodeAsync();

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetAllTitleCodeAsync_Take_Skip_Success() {
        // Arrange
        var skip = 2;
        var take = 2;
        var expected = this.SeedSource.Where(x => x.CodeType == EanCodeType.Title)
                            .OrderBy(x => (x.BaseCode + x.TitleCode))
                            .Skip(skip)
                            .Take(take);

        // Act
        var actual = await this._dataProvider.GetAllTitleCodeAsync(take, skip);

        // Assert
        for (int i = 0; i < take; i++) {
            Assert.Equal(expected.ElementAt(i).Id, actual[i].Id);
        }
    }


    [Fact]
    public async Task GetAllTitleCodeAsync_TakeSkip_Should_ThrowException_If_Exception() {
        // Arrange
        var skip = 2;
        var take = 2;
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetAllTitleCodeAsync(take, skip);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetBySearchFilterAsync_Success() {
        // Arrange
        var searchFilter = "AABB";
        var skip = 2;
        var take = 2;
        var expected = this.SeedSource.Where(x => x.CodeType == EanCodeType.Title)
                            .OrderBy(x => (x.BaseCode + x.TitleCode))
                            .Where(x => x.FullCode.ToLower().Contains(searchFilter))
                            .Skip(skip)
                            .Take(take);

        // Act
        var actual = await this._dataProvider.GetBySearchFilterAsync(searchFilter, take, skip);

        // Assert
        for (int i = 0; i < expected.Count(); i++) {
            Assert.Equal(expected.ElementAt(i).Id, actual[i].Id);
        }
    }


    [Fact]
    public async Task GetBySearchFilterAsync_Should_ThrowException_If_Exception() {
        // Arrange
        var searchFilter = "AABB";
        var skip = 2;
        var take = 2;
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetBySearchFilterAsync(searchFilter,take, skip);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }
    #endregion

    #region [ Public Methods - Custom ]
    [Fact]
    public async Task GetMaxTitleCodeAsync_Success() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        var expected = this.SeedSource.Where(x => x.BaseCode == entity.BaseCode).Max(x => int.Parse(x.TitleCode)).ToString("00000");

        // Act
        var actual = await this._dataProvider.GetMaxTitleCodeAsync(entity.BaseCode);

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public async Task GetMaxTitleCodeAsync_Should_ThrowException_If_BaseCode_IsEmpty() {
        // Arrange
        var baseCode = string.Empty;

        // Act
        var actual = async () =>  await this._dataProvider.GetMaxTitleCodeAsync(baseCode);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(actual);
    }


    [Fact]
    public async Task GetMaxTitleCodeAsync_Should_ThrowException_If_Exception() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetMaxTitleCodeAsync(entity.BaseCode);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetNewTitleCodeAsync_Success() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        var expected = (this.SeedSource.Where(x => x.BaseCode == entity.BaseCode).Max(x => int.Parse(x.TitleCode)) + 1).ToString("00000");

        // Act
        var actual = await this._dataProvider.GetNewTitleCodeAsync(entity.BaseCode);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetNewTitleCodeAsync_Should_ThrowException_If_BaseCode_IsEmpty() {
        // Arrange
        var baseCode = string.Empty;

        // Act
        var actual = async () => await this._dataProvider.GetNewTitleCodeAsync(baseCode);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(actual);
    }

    [Fact]
    public async Task AddNewBaseCode_Success() {
        // Arrange
        var baseCode = "ABCABC0";

        // Act
        await this._dataProvider.AddNewBaseCodeAsync(baseCode);
        var dbResult = await this._dataProvider.GetAllBaseCodeAsync();

        // Assert
        var isExist = dbResult.Any(x => x.BaseCode == baseCode);
        Assert.True(isExist);
    }
    
    [Fact]
    public async Task AddNewBaseCode_Should_ThrowException_If_BaseCode_IsEmpty() {
        // Arrange
        var baseCode = string.Empty;

        // Act
        var actual = async () => await this._dataProvider.AddNewBaseCodeAsync(baseCode);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(actual);
    }

    [Fact]
    public async Task AddRangeAsync_Success() {
        // Arrange
        var item1 = this.SeedSource.First();
        item1.Id = IdFactory.CreateId();

        var item2 = this.SeedSource.Last();
        item2.Id = IdFactory.CreateId();

        var payload = new List<EanCode> {item1, item1};

        // Act
        await this._dataProvider.AddRangeAsync(payload);

        // Assert
        foreach (var item in payload) {
            var dbResult = await this._dataProvider.GetAsync(item.Id);
            Assert.Equal(item.IsActive, dbResult.IsActive);
            Assert.Equal(item.CreatedAt.ToShortDateString(), dbResult.CreatedAt.ToShortDateString());
            Assert.Equal(item.UpdatedAt.ToShortDateString(), dbResult.UpdatedAt.ToShortDateString());
            Assert.Equal(item.BaseCode, dbResult.BaseCode);
            Assert.Equal(item.CheckCode, dbResult.CheckCode);
        }
    }

    [Fact]
    public async Task AddRangeAsync_Should_ThrowException_If_EanCodes_IsNull() {
        // Arrange
        var payload = default(List<EanCode>);

        // Act
        var actual = async () => await this._dataProvider.AddRangeAsync(payload);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(actual);
    }
    #endregion

    #region [ Public Methods - Custom - Count ]
    [Fact]
    public async Task CountAllTitleCodeAsync_Success() {
        // Arrange
        var expected = this.SeedSource.Count( x => x.CodeType == EanCodeType.Title );

        // Act
        var actual = await this._dataProvider.CountAllTitleCodeAsync(); 

        // Assert
        Assert.True(expected.Equals(actual));  
    }


    [Fact]
    public async Task CountAllTitleCodeAsync_Should_ThrowException_If_Exception() {
        // Arrange
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.CountAllTitleCodeAsync();

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task CountBySearchFilterAsync_Success() {
        // Arrange
        var entity = this.SeedSource.First();
        var expected = this.SeedSource.Count(x => x.CodeType == EanCodeType.Title && x.FullCode.ToLower().Contains(entity.BaseCode));

        // Act
        var actual = await this._dataProvider.CountBySearchFilterAsync(entity.BaseCode);

        // Assert
        Assert.True(expected.Equals(actual));
    }

    [Fact]
    public async Task CountBySearchFilterAsync_Should_ThrowException_If_SearchFilter_IsEmpty() {
        // Arrange
        var searchFilter = string.Empty;

        // Act
        var actual = async () => await this._dataProvider.CountBySearchFilterAsync(searchFilter);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(actual);
    }
    #endregion
}