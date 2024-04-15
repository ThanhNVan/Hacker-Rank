using RCode.Data.Providers;
using System.Linq;
using System.Threading.Tasks;
using System;
using Xunit;
using System.Collections.Generic;

namespace ThiemeMeulenhoff.Platform;

[Collection("DataProvider")]
public class ProjectTeamMemberDataProviderUnitTest : BaseEntityDataProviderUnitTests<ProjectTeamMemberDataProvider<ThiemeMeulenhoffPlatformDbContext>, IProjectTeamMemberValidationProvider, ProjectTeamMember>
{
    #region [ CTor ]
    public ProjectTeamMemberDataProviderUnitTest() : base(SeedProvider.Current.ProjectTeamMembers) {
    }
    #endregion

    #region [ Protected Methods - override ]
    protected override ProjectTeamMemberDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        return new ProjectTeamMemberDataProvider<ThiemeMeulenhoffPlatformDbContext>(
           this._logger.Object,
           this._dbContextFactory.Object,
           this._validationProvider.Object);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByProjectIdAndContactIdAsync_Success() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        var expected = this.SeedSource.FirstOrDefault(x => x.ProjectId == entity.ProjectId 
                                               && x.ContactId == entity.ContactId);

        // Act
        var actual = await this._dataProvider.GetByProjectIdAndContactIdAsync(entity.ProjectId, entity.ContactId);

        // Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.IsActive, actual.IsActive);
        Assert.Equal(expected.CreatedAt.ToShortDateString(), actual.CreatedAt.ToShortDateString());
    }

    [Fact]
    public async Task GetByProjectIdAndContactIdAsync_Should_ThrowException_If_ProjectId_IsEmpty() {
        // Arrange
        var ProjectId = string.Empty;
        var contactId = string.Empty;

        //Act
        var result = async () => await this._dataProvider.GetByProjectIdAndContactIdAsync(ProjectId, contactId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByProjectIdAndContactIdAsync_Should_ThrowException_If_ProjectId_IsNull() {
        // Arrange
        var entity = default(ProjectTeamMember);

        //Act
        var result = async () => await this._dataProvider.GetByProjectIdAndContactIdAsync(entity.ProjectId, entity.ContactId);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByProjectIdAndContactIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetByProjectIdAndContactIdAsync(entity.ProjectId, entity.ContactId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }
    #endregion

    #region [ Public Methods - Custom - Lists ]
    [Fact]
    public async Task GetByProjectIdAsync_Success() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        var expected = this.SeedSource.Where(x => x.ProjectId == entity.ProjectId);

        // Act
        var actual = await this._dataProvider.GetByProjectIdAsync(entity.ProjectId);

        // Assert
        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetByProjectIdAsync_Should_ThrowException_If_ProjectId_IsEmpty() {
        // Arrange
        var ProjectId = string.Empty;

        //Act
        var result = async () => await this._dataProvider.GetByProjectIdAsync(ProjectId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByProjectIdAsync_Should_ThrowException_If_ProjectId_IsNull() {
        // Arrange
        var entity = default(ProjectTeamMember);

        //Act
        var result = async () => await this._dataProvider.GetByProjectIdAsync(entity.ProjectId);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }
    
    [Fact]
    public async Task GetByProjectIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetByProjectIdAsync(entity.ProjectId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByContactIdAsync_Success() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        var expected = this.SeedSource.Where(x => x.ContactId == entity.ContactId);

        // Act
        var actual = await this._dataProvider.GetByContactIdAsync(entity.ContactId);

        // Assert
        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetByContactIdAsync_Should_ThrowException_If_ContactId_IsEmpty() {
        // Arrange
        var ContactId = string.Empty;

        //Act
        var result = async () => await this._dataProvider.GetByContactIdAsync(ContactId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByContactIdAsync_Should_ThrowException_If_ContactId_IsNull() {
        // Arrange
        var entity = default(ProjectTeamMember);

        //Act
        var result = async () => await this._dataProvider.GetByContactIdAsync(entity.ContactId);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetBatchByContactIdAsync_Success() {
        // Arrange
        var ContactIds = new List<string> {
            SeedProvider.Current.ProjectTeamMembers[0].ContactId,
            SeedProvider.Current.ProjectTeamMembers[1].ContactId,
            SeedProvider.Current.ProjectTeamMembers[2].ContactId,
        };
        var expected = SeedSource.Where(x => ContactIds.Contains(x.ContactId));

        //Act
        var actual = await this._dataProvider.GetBatchByContactIdAsync(ContactIds);

        //Assert
        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetBatchByContactIdAsync_Should_ThrowException_If_Exception() {
        // Arrange
        var ContactIds = new List<string> {
            SeedProvider.Current.ProjectTeamMembers[0].ContactId,
            SeedProvider.Current.ProjectTeamMembers[1].ContactId,
            SeedProvider.Current.ProjectTeamMembers[2].ContactId,
        };
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetBatchByContactIdAsync(ContactIds);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetBatchByContactIdAsync_Should_ThrowException_If_RelatedProduct_IsNull() {
        // Arrange
        var ContactIds = default(List<string>);

        //Act
        var result = async () => await this._dataProvider.GetBatchByContactIdAsync(ContactIds);

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
        var expected = this.SeedSource.Where(x => (x.Id + x.ProjectId + x.ContactId + x.Role).ToLower().Contains(entity.Id))
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
