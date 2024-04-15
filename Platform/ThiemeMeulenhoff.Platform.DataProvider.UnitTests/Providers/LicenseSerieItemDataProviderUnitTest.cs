using RCode.Data.Providers;
using System.Linq;
using System.Threading.Tasks;
using System;
using ThiemeMeulenhoff.Platform.Data;
using Xunit;
using AutoFixture;

namespace ThiemeMeulenhoff.Platform;

[Collection("DataProvider")]
public class LicenseSerieItemDataProviderUnitTest : BaseEntityDataProviderUnitTests<LicenseSerieItemDataProvider<ThiemeMeulenhoffPlatformDbContext>, ILicenseSerieItemValidationProvider, LicenseSerieItem>
{
    #region [ CTor ]
    public LicenseSerieItemDataProviderUnitTest() : base(SeedProvider.Current.LicenseSerieItems) {
    }
    #endregion

    #region [ Protected Methods - override ]
    protected override LicenseSerieItemDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        return new LicenseSerieItemDataProvider<ThiemeMeulenhoffPlatformDbContext>(
          this._logger.Object,
          this._dbContextFactory.Object,
          this._validationProvider.Object);
    }
    #endregion

    #region [ Public Methods - Cutom - Single ]
    [Fact]
    public async Task GetByLicenseKey_Success() {
        //Arrange
        var expected = this.SeedSource.FirstOrDefault();


        // Act
        var actual = await this._dataProvider.GetByLicenseKey(expected.LicenseKey);

        // Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.CreatedAt.ToShortDateString(), actual.CreatedAt.ToShortDateString());
        Assert.Equal(expected.UpdatedAt.ToShortDateString(), actual.UpdatedAt.ToShortDateString());
        Assert.Equal(expected.IsActive, actual.IsActive);
    }

    [Fact]
    public async Task GetByLicenseKey_Should_ThrowException_If_LicenseKey_IsEmpty() {
        // Arrange 
        var LicenseKey = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetByLicenseKey(LicenseKey);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByLicenseKey_Should_ThrowException_If_LicenseKey_IsNull() {
        // Arrange 
        string LicenseKey = null;

        // Act
        var result = async () => await this._dataProvider.GetByLicenseKey(LicenseKey);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByLicenseKey_Should_ThrowException_If_Exception() {
        // Arrange 
        var LicenseKey = this._fixture.Create<string>();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByLicenseKey(LicenseKey);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }
    #endregion

    #region [ Public Methods - Custom - List ]
    [Fact]
    public async Task GetByLicenseSerieId_Success() {
        //Arrange
        var entity = this.SeedSource.FirstOrDefault();
        var expected = this.SeedSource.Where(x => x.LicenseSerieId == entity.LicenseSerieId);


        // Act
        var actual = await this._dataProvider.GetByLicenseSerieId(entity.LicenseSerieId);

        // Assert
        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetByLicenseSerieId_Should_ThrowException_If_LicenseSerieId_IsEmpty() {
        // Arrange 
        var LicenseSerieId = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetByLicenseSerieId(LicenseSerieId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByLicenseSerieId_Should_ThrowException_If_LicenseSerieId_IsNull() {
        // Arrange 
        string LicenseSerieId = null;

        // Act
        var result = async () => await this._dataProvider.GetByLicenseSerieId(LicenseSerieId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByLicenseSerieId_Should_ThrowException_If_Exception() {
        // Arrange 
        var LicenseSerieId = this._fixture.Create<string>();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByLicenseSerieId(LicenseSerieId);

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
        var expected = this.SeedSource.Where(x => (x.Id + x.LicenseSerieId + x.LicenseKey + x.ToegangReferenceId).ToLower().Contains(entity.Id))
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
