using RCode.Data.Providers;
using System.Linq;
using System.Threading.Tasks;
using System;
using ThiemeMeulenhoff.Platform.Data;
using Xunit;
using AutoFixture;

namespace ThiemeMeulenhoff.Platform;

[Collection("DataProvider")]
public class LicenceInfoDataProviderUnitTest : BaseEntityDataProviderUnitTests<LicenceInfoDataProvider<ThiemeMeulenhoffPlatformDbContext>, ILicenceInfoValidationProvider, LicenceInfo>
{
    #region [ CTor ]
    public LicenceInfoDataProviderUnitTest() : base(SeedProvider.Current.LicenceInfo) {
    }
    #endregion

    #region [ Protected Methods - override ]
    protected override LicenceInfoDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        return new LicenceInfoDataProvider<ThiemeMeulenhoffPlatformDbContext>(
          this._logger.Object,
          this._dbContextFactory.Object,
          this._validationProvider.Object);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByProductIdAsync_Success() {
        //Arrange
        var expected = this.SeedSource.FirstOrDefault();


        // Act
        var actual = await this._dataProvider.GetByProductIdAsync(expected.Id);

        // Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.CreatedAt.ToShortDateString(), actual.CreatedAt.ToShortDateString());
        Assert.Equal(expected.UpdatedAt.ToShortDateString(), actual.UpdatedAt.ToShortDateString());
        Assert.Equal(expected.IsActive, actual.IsActive);
    }

    [Fact]
    public async Task GetByProductIdAsync_Should_ThrowException_If_ProductId_IsEmpty() {
        // Arrange 
        var productId = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetByProductIdAsync(productId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }
    
    [Fact]
    public async Task GetByProductIdAsync_Should_ThrowException_If_ProductId_IsNull() {
        // Arrange 
        string productId = null;

        // Act
        var result = async () => await this._dataProvider.GetByProductIdAsync(productId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }
    
    [Fact]
    public async Task GetByProductIdAsync_Should_ThrowException_If_Exception() {
        // Arrange 
        var productId = this._fixture.Create<string>();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByProductIdAsync(productId);

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
        var expected = this.SeedSource.Where(x => (x.Id + x.AccesUrl + x.Cpi + x.Duration + x.DurationType + x.SvsCode).ToLower().Contains(entity.Id))
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
