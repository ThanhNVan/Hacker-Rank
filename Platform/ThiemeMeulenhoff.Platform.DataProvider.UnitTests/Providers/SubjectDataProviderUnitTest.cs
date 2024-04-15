using System;
using System.Linq;
using System.Threading.Tasks;
using RCode.Data.Providers;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

[Collection("DataProvider")]
public class SubjectDataProviderUnitTest : BaseEntityDataProviderUnitTests<SubjectDataProvider<ThiemeMeulenhoffPlatformDbContext>, ISubjectValidationProvider, Subject>
{
    #region [ CTor ]
    public SubjectDataProviderUnitTest() : base(SeedProvider.Current.Subjects) {
    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override SubjectDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        return new SubjectDataProvider<ThiemeMeulenhoffPlatformDbContext>(
           this._logger.Object,
           this._dbContextFactory.Object,
           this._validationProvider.Object);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetBySubjectCodeAsync_Success() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        var expected = this.SeedSource.FirstOrDefault(x => x.SubjectCode == entity.SubjectCode);

        // Act
        var actual = await this._dataProvider.GetBySubjectCodeAsync(entity.SubjectCode);

        // Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.IsActive, actual.IsActive);
        Assert.Equal(expected.CreatedAt.ToShortDateString(), actual.CreatedAt.ToShortDateString());
    }

    [Fact]
    public async Task GetBySubjectCodeAsync_Should_ThrowException_If_SubjectCode_IsEmpty() {
        // Arrange
        var SubjectCode = string.Empty;

        //Act
        var result = async () => await this._dataProvider.GetBySubjectCodeAsync(SubjectCode);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetBySubjectCodeAsync_Should_ThrowException_If_SubjectCode_IsNull() {
        // Arrange
        var entity = default(Subject);

        //Act
        var result = async () => await this._dataProvider.GetBySubjectCodeAsync(entity.SubjectCode);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetBySubjectCodeAsync_Should_ThrowException_If_Error() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetBySubjectCodeAsync(entity.SubjectCode);

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
        var expected = this.SeedSource.Where(x => (x.Id + x.Name).ToLower().Contains(entity.Id))
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
