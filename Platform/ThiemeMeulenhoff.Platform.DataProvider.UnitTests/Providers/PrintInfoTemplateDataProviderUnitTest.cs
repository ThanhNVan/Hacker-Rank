using System;
using System.Linq;
using System.Threading.Tasks;
using RCode.Data.Providers;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

[Collection("DataProvider")]
public class PrintInfoTemplateDataProviderUnitTest : BaseEntityDataProviderUnitTests<PrintInfoTemplateDataProvider<ThiemeMeulenhoffPlatformDbContext>, IPrintInfoTemplateValidationProvider, PrintInfoTemplate>
{
    #region [ CTor ]
    public PrintInfoTemplateDataProviderUnitTest() : base(SeedProvider.Current.PrintInfoTemplates) {
    }
    #endregion

    #region [ Protected Methods - override ]
    protected override PrintInfoTemplateDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        return new PrintInfoTemplateDataProvider<ThiemeMeulenhoffPlatformDbContext>(
           this._logger.Object,
           this._dbContextFactory.Object,
           this._validationProvider.Object);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByNameAsync_Success() {
        // Arrange
        var entity = this.SeedSource.First();
        var expected = this.SeedSource.FirstOrDefault(x => x.Name == entity.Name);

        // Act
        var actual = await this._dataProvider.GetByNameAsync(entity.Name);

        // Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.CreatedAt.ToShortDateString(), actual.CreatedAt.ToShortDateString());
    }

    [Fact]
    public async Task GetByNameAsync_Should_ThrowException_If_Name_IsEmpty() {
        // Arrange
        var Name = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetByNameAsync(Name);

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
        var expected = this.SeedSource.Where(x => ( x.Name + x.Body).ToLower().Contains(entity.Id))
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
