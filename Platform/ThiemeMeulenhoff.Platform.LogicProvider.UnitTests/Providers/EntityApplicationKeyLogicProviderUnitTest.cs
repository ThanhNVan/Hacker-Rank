using AutoFixture;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class EntityApplicationKeyLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<EntityApplicationKey, IEntityApplicationKeyDataProvider, EntityApplicationKeyLogicProvider>
{
    #region [ CTor ]
    public EntityApplicationKeyLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override EntityApplicationKeyLogicProvider OnCreateLogicProvider(IEntityApplicationKeyDataProvider dataProvider, ILogger<EntityApplicationKeyLogicProvider> logger) {
        return new EntityApplicationKeyLogicProvider(logger, dataProvider);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByApplicationKeyAsync_Success() {
        // Arrange
        var applicationName = this._fixture.Create<string>();
        var applicationKey = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByApplicationKeyAsync(applicationName, applicationKey);

        // Assert
        this._dataProvider.Verify(x => x.GetByApplicationKeyAsync(applicationName, applicationKey), Times.Once);
    }

    [Fact]
    public async Task GetByApplicationKeyAsync_Should_ThrowException_If_ApplicationName_IsNull() {
        // Arrange
        string applicationName = null;
        var applicationKey = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.GetByApplicationKeyAsync(applicationName, applicationKey);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByApplicationKeyAsync_Should_ThrowException_If_ApplicationName_IsEmpty() {
        // Arrange
        var applicationName = string.Empty;
        var applicationKey = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.GetByApplicationKeyAsync(applicationName, applicationKey);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    
    [Fact]
    public async Task GetByApplicationKeyAsync_Should_ThrowException_If_ApplicationKey_IsNull() {
        // Arrange
        var applicationName = this._fixture.Create<string>(); ;
        string applicationKey = null;

        // Act
        var result = async () => await this._logicProvider.GetByApplicationKeyAsync(applicationName, applicationKey);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByApplicationKeyAsync_Should_ThrowException_If_ApplicationKey_IsEmpty() {
        // Arrange
        var applicationKey = string.Empty;
        var applicationName = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.GetByApplicationKeyAsync(applicationName, applicationKey);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    
    [Fact]
    public async Task GetByEntityIdAsync_Success() {
        // Arrange
        var applicationName = this._fixture.Create<string>();
        var EntityId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByEntityIdAsync(applicationName, EntityId);

        // Assert
        this._dataProvider.Verify(x => x.GetByEntityIdAsync(applicationName, EntityId), Times.Once);
    }

    [Fact]
    public async Task GetByEntityIdAsync_Should_ThrowException_If_ApplicationName_IsNull() {
        // Arrange
        string applicationName = null;
        var EntityId = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.GetByEntityIdAsync(applicationName, EntityId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByEntityIdAsync_Should_ThrowException_If_ApplicationName_IsEmpty() {
        // Arrange
        var applicationName = string.Empty;
        var EntityId = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.GetByEntityIdAsync(applicationName, EntityId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    
    [Fact]
    public async Task GetByEntityIdAsync_Should_ThrowException_If_EntityId_IsNull() {
        // Arrange
        var applicationName = this._fixture.Create<string>(); ;
        string EntityId = null;

        // Act
        var result = async () => await this._logicProvider.GetByEntityIdAsync(applicationName, EntityId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByEntityIdAsync_Should_ThrowException_If_EntityId_IsEmpty() {
        // Arrange
        var EntityId = string.Empty;
        var applicationName = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.GetByEntityIdAsync(applicationName, EntityId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    #endregion

    #region [ Public Methods - Custom - List ]
    [Fact]
    public async Task GetByEntityIdAsync_EntityId_Success() {
        // Arrange
        var EntityId = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByEntityIdAsync(EntityId);

        // Assert
        this._dataProvider.Verify(x => x.GetByEntityIdAsync(EntityId), Times.Once);
    }

    [Fact]
    public async Task GetByEntityIdAsync_EntityId_Should_ThrowException_If_EntityId_IsNull() {
        // Arrange
        string EntityId = null;

        // Act
        var result = async () => await this._logicProvider.GetByEntityIdAsync(EntityId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByEntityIdAsync_EntityId_Should_ThrowException_If_EntityId_IsEmpty() {
        // Arrange
        var EntityId = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByEntityIdAsync(EntityId);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    #endregion
}