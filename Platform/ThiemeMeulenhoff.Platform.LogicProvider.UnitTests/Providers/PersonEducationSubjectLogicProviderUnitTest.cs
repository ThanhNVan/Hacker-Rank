using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class PersonEducationSubjectLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<PersonEducationSubject, IPersonEducationSubjectDataProvider, PersonEducationSubjectLogicProvider>
{
    #region [ CTor ]
    public PersonEducationSubjectLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override PersonEducationSubjectLogicProvider OnCreateLogicProvider(IPersonEducationSubjectDataProvider dataProvider, ILogger<PersonEducationSubjectLogicProvider> logger) {
        return new PersonEducationSubjectLogicProvider(logger, dataProvider);
    }
    #endregion

    #region [ Public Methods - Customer - Single ]
    [Fact]
    public async Task GetByPersonAndOrganisationAsync_Success() {
        // Arrange
        var PersonId = this._fixture.Create<string>();
        var OrganizationId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByPersonAndOrganisationAsync(PersonId, OrganizationId);

        // Assert
        this._dataProvider.Verify(x => x.GetByPersonAndOrganisationAsync(PersonId, OrganizationId), Times.Once);
    }

    [Fact]
    public async Task GetByPersonAndOrganisationAsync_Should_ThrowException_If_PersonId_IsNull() {
        // Arrange
        string PersonId = null;
        var OrganizationId = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.GetByPersonAndOrganisationAsync(PersonId, OrganizationId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByPersonAndOrganisationAsync_Should_ThrowException_If_PersonId_IsEmpty() {
        // Arrange
        var PersonId = string.Empty;
        var OrganizationId = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.GetByPersonAndOrganisationAsync(PersonId, OrganizationId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByPersonAndOrganisationAsync_Should_ThrowException_If_Error() {
        // Arrange
        var PersonId = Guid.NewGuid().ToString();
        var OrganizationId = this._fixture.Create<string>();
        this._dataProvider.Setup(x => x.GetByPersonAndOrganisationAsync(PersonId, OrganizationId)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByPersonAndOrganisationAsync(PersonId, OrganizationId);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    #endregion

    #region [ Public Methods - Lists ]
    [Fact]
    public async Task GetByPersonAsync_Success() {
        // Arrange
        var PersonId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByPersonAsync(PersonId);

        // Assert
        this._dataProvider.Verify(x => x.GetByPersonAsync(PersonId), Times.Once);
    }

    [Fact]
    public async Task GetByPersonAsync_Should_ThrowException_If_PersonId_IsNull() {
        // Arrange
        string PersonId = null;

        // Act
        var result = async () => await this._logicProvider.GetByPersonAsync(PersonId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByPersonAsync_Should_ThrowException_If_PersonId_IsEmpty() {
        // Arrange
        var PersonId = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByPersonAsync(PersonId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByPersonAsync_Should_ThrowException_If_Error() {
        // Arrange
        var PersonId = this._fixture.Create<string>();
        this._dataProvider.Setup(x => x.GetByPersonAsync(PersonId)).Throws(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByPersonAsync(PersonId);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }

    [Fact]
    public async Task GetByOrganizationAsync_Success() {
        // Arrange
        var OrganizationId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByOrganizationAsync(OrganizationId);

        // Assert
        this._dataProvider.Verify(x => x.GetByOrganizationAsync(OrganizationId), Times.Once);
    }

    [Fact]
    public async Task GetByOrganizationAsync_Should_ThrowException_If_OrganizationId_IsNull() {
        // Arrange
        string OrganizationId = null;

        // Act
        var result = async () => await this._logicProvider.GetByOrganizationAsync(OrganizationId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByOrganizationAsync_Should_ThrowException_If_OrganizationId_IsEmpty() {
        // Arrange
        var OrganizationId = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByOrganizationAsync(OrganizationId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByOrganizationAsync_Should_ThrowException_If_Error() {
        // Arrange
        var OrganizationId = this._fixture.Create<string>();
        this._dataProvider.Setup(x => x.GetByOrganizationAsync(OrganizationId)).Throws(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetByOrganizationAsync(OrganizationId);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    #endregion
}

