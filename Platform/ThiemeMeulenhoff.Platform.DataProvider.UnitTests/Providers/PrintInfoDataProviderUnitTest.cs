using RCode.Data.Providers;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

[Collection("DataProvider")]
public class PrintInfoDataProviderUnitTest : BaseEntityDataProviderUnitTests<PrintInfoDataProvider<ThiemeMeulenhoffPlatformDbContext>, IPrintInfoValidationProvider, PrintInfo>
{
    #region [ CTor ]
    public PrintInfoDataProviderUnitTest() : base(SeedProvider.Current.PrintInfo) {
    }
    #endregion

    #region [ Protected Methods - override ]
    protected override PrintInfoDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        return new PrintInfoDataProvider<ThiemeMeulenhoffPlatformDbContext>(
           this._logger.Object,
           this._dbContextFactory.Object,
           this._validationProvider.Object);
    }
    #endregion

    #region [ Public Methods - Custom - Lists ]
    [Fact]
    public async Task GetByProductIdAsync_Success() {
        // Arrange
        var entity = this.SeedSource.First();
        var expected = this.SeedSource.Where(x => x.Id == entity.Id);

        // Act
        var actual = await this._dataProvider.GetByProductIdAsync(entity.Id);

        // Assert

        Assert.Equal(expected.Count(), actual.Count);
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
    #endregion

    #region [ Override Methods -  ]
    [Fact]
    public async Task GetBySearchFilterAsync_Success() {
        //Arrange
        var entity = this.SeedSource.FirstOrDefault();
        var take = 5;
        var skip = 0;
        var expected = this.SeedSource.Where(x => (x.Id + x.PrintTemplateId + x.Body).ToLower().Contains(entity.Id))
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
