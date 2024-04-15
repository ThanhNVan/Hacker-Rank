using RCode.Data.Providers;
using System.Linq;
using System.Threading.Tasks;
using System;
using Xunit;
using System.Collections.Generic;

namespace ThiemeMeulenhoff.Platform;

[Collection("DataProvider")]
public class ProjectDataProviderUnitTest : BaseEntityDataProviderUnitTests<ProjectDataProvider<ThiemeMeulenhoffPlatformDbContext>, IProjectValidationProvider, Project>
{
    #region [ CTor ]
    public ProjectDataProviderUnitTest() : base(SeedProvider.Current.Projects) {
    }
    #endregion

    #region [ Protected Methods - override ]
    protected override ProjectDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        return new ProjectDataProvider<ThiemeMeulenhoffPlatformDbContext>(
           this._logger.Object,
           this._dbContextFactory.Object,
           this._validationProvider.Object);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByProjectNameAsync_Success() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        var expected = this.SeedSource.FirstOrDefault(x => x.ProjectName == entity.ProjectName);

        // Act
        var actual = await this._dataProvider.GetByProjectNameAsync(entity.ProjectName);

        // Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.IsActive, actual.IsActive);
        Assert.Equal(expected.CreatedAt.ToShortDateString(), actual.CreatedAt.ToShortDateString());
    }

    [Fact]
    public async Task GetByProjectNameAsync_Should_ThrowException_If_Entity_IsNull() {
        // Arrange 
        var entity = default(Project);

        // Act
        var result = async () => await this._dataProvider.GetByProjectNameAsync(entity.ProjectName);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByProjectNameAsync_Should_ThrowException_If_Entity_IsEmpty() {
        // Arrange 
        var entityId = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetByProjectNameAsync(entityId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByProjectNameAsync_Should_ThrowException_If_Error() {
        // Arrange 
        var entityId = Guid.NewGuid().ToString();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByProjectNameAsync(entityId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByProjectNumberAsync_Success() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        var expected = this.SeedSource.FirstOrDefault(x => x.ProjectNumber == entity.ProjectNumber);

        // Act
        var actual = await this._dataProvider.GetByProjectNumberAsync(entity.ProjectNumber);

        // Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.IsActive, actual.IsActive);
        Assert.Equal(expected.CreatedAt.ToShortDateString(), actual.CreatedAt.ToShortDateString());
    }

    [Fact]
    public async Task GetByProjectNumberAsync_Should_ThrowException_If_Entity_IsNull() {
        // Arrange 
        var entity = default(Project);

        // Act
        var result = async () => await this._dataProvider.GetByProjectNumberAsync(entity.ProjectNumber);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByProjectNumberAsync_Should_ThrowException_If_Error() {
        // Arrange 
        var ProjectNumber = new Random().Next(0, 999);
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByProjectNumberAsync(ProjectNumber);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }
    #endregion

    #region [ Public Methods - Custom - List ]
    [Fact]
    public async Task GetBySubjectIdAsync_Success() {
        // Arrange
        var entity = this.SeedSource.First();
        var expected = this.SeedSource.Where(x => x.SubjectId == entity.SubjectId);

        // Act
        var actual = await this._dataProvider.GetBySubjectIdIdAsync(entity.SubjectId);

        // Assert

        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetBySubjectIdAsync_Should_ThrowException_If_SubjectId_IsEmpty() {
        // Arrange
        var SubjectId = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetBySubjectIdIdAsync(SubjectId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetBySubjectIdAsync_Should_ThrowException_If_SubjectId_IsNull() {
        // Arrange
        string SubjectId = null;

        // Act
        var result = async () => await this._dataProvider.GetBySubjectIdIdAsync(SubjectId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }
    
    [Fact]
    public async Task GetBySubjectIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var SubjectId = Guid.NewGuid().ToString();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetBySubjectIdIdAsync(SubjectId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }


    [Fact]
    public async Task GetBatchBySubjectIdAsync_Success() {
        // Arrange
        var SubjectIds = new List<string> {
            SeedProvider.Current.Projects[0].SubjectId,
            SeedProvider.Current.Projects[1].SubjectId,
            SeedProvider.Current.Projects[2].SubjectId,
        };
        var expected = SeedSource.Where(x => SubjectIds.Contains(x.SubjectId));

        //Act
        var actual = await this._dataProvider.GetBatchBySubjectIdAsync(SubjectIds);

        //Assert
        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetBatchBySubjectIdAsync_Should_ThrowException_If_Exception() {
        // Arrange
        var SubjectIds = new List<string> {
            SeedProvider.Current.Projects[0].SubjectId,
            SeedProvider.Current.Projects[1].SubjectId,
            SeedProvider.Current.Projects[2].SubjectId,
        };
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetBatchBySubjectIdAsync(SubjectIds);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetBatchBySubjectIdAsync_Should_ThrowException_If_RelatedProduct_IsNull() {
        // Arrange
        var SubjectIds = default(List<string>);

        //Act
        var result = async () => await this._dataProvider.GetBatchBySubjectIdAsync(SubjectIds);

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
        var expected = this.SeedSource.Where(x => (x.Id + x.ProjectName + x.ProjectNumber + x.SubjectName + x.EducationSector + x.GroupName).ToLower().Contains(entity.Id))
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