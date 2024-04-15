using RCode.Data.Providers;
using System.Linq;
using System.Threading.Tasks;
using System;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class PersonOrganizationDataProviderUnitTest : BaseEntityDataProviderUnitTests<PersonOrganizationDataProvider<ThiemeMeulenhoffPlatformDbContext>, IPersonOrganizationValidationProvider, PersonOrganization>
{
    #region [ CTor ]
    public PersonOrganizationDataProviderUnitTest() : base(SeedProvider.Current.PersonOrganizations) {
    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override PersonOrganizationDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        return new PersonOrganizationDataProvider<ThiemeMeulenhoffPlatformDbContext>(
           this._logger.Object,
           this._dbContextFactory.Object,
           this._validationProvider.Object);
    }
    #endregion

    #region [ Public Methods - Customer - Single ]
    [Fact]
    public async Task GetByPersonAndOrganisationAsync_Success() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        var expected = SeedSource.FirstOrDefault(x => x.PersonId == entity.PersonId && entity.OrganizationId == x.OrganizationId);

        //Act
        var actual = await this._dataProvider.GetByPersonAndOrganisationAsync(entity.PersonId, entity.OrganizationId);

        //Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.CreatedAt.ToLongDateString(), actual.CreatedAt.ToLongDateString());
        Assert.Equal(expected.IsActive, actual.IsActive);
    }

    [Fact]
    public async Task GetByPersonAndOrganisationAsync_Should_ThrowException_If_PersonId_IsEmpty() {
        // Arrange
        var PersonId = string.Empty;
        var OrganizationId = string.Empty;

        //Act
        var result = async () => await this._dataProvider.GetByPersonAndOrganisationAsync(PersonId, OrganizationId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByPersonAndOrganisationAsync_Should_ThrowException_If_PersonId_IsNull() {
        // Arrange
        var entity = default(PersonOrganization);

        //Act
        var result = async () => await this._dataProvider.GetByPersonAndOrganisationAsync(entity.PersonId, entity.OrganizationId);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByPersonAndOrganisationAsync_Should_ThrowException_If_Error() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetByPersonAndOrganisationAsync(entity.Id, entity.OrganizationId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }
    #endregion

    #region [ Public Methods - Lists ]
    [Fact]
    public async Task GetByPersonAsync_Success() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        var expected = SeedSource.Where(x => x.PersonId == entity.PersonId);

        //Act
        var actual = await this._dataProvider.GetByPersonAsync(entity.PersonId);

        //Assert
        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetByPersonAsync_Should_ThrowException_If_PersonId_IsEmpty() {
        // Arrange
        var PersonId = string.Empty;

        //Act
        var result = async () => await this._dataProvider.GetByPersonAsync(PersonId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByPersonAsync_Should_ThrowException_If_PersonId_IsNull() {
        // Arrange
        var entity = default(PersonOrganization);

        //Act
        var result = async () => await this._dataProvider.GetByPersonAsync(entity.PersonId);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByPersonAsync_Should_ThrowException_If_Error() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetByPersonAsync(entity.Id);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByOrganizationAsync_Success() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        var expected = SeedSource.Where(x => x.OrganizationId == entity.OrganizationId);

        //Act
        var actual = await this._dataProvider.GetByOrganizationAsync(entity.OrganizationId);

        //Assert
        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetByOrganizationAsync_Should_ThrowException_If_OrganizationId_IsEmpty() {
        // Arrange
        var OrganizationId = string.Empty;

        //Act
        var result = async () => await this._dataProvider.GetByOrganizationAsync(OrganizationId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByOrganizationAsync_Should_ThrowException_If_OrganizationId_IsNull() {
        // Arrange
        var entity = default(PersonOrganization);

        //Act
        var result = async () => await this._dataProvider.GetByOrganizationAsync(entity.OrganizationId);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByOrganizationAsync_Should_ThrowException_If_Error() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetByOrganizationAsync(entity.Id);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }
    #endregion
}
