using AutoFixture;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.Extensions.Logging;
using Moq;
using RCode;
using RCode.Data.Providers;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

[Collection("LogicProvider")]
[CollectionDefinition(nameof(BaseEntityLogicProviderUnitTest<TEntity, TDataProvider, TLogicProvider>), DisableParallelization = true)]
public abstract class BaseEntityLogicProviderUnitTest<TEntity, TDataProvider, TLogicProvider> : IDisposable
    where TEntity : BaseEntity
    where TDataProvider : class, IThiemeEntityDataProvider<TEntity>
    where TLogicProvider : ThiemeBaseEntityLogicProvider<TEntity, TDataProvider>
{
    #region [ Fields ]
    protected readonly Fixture _fixture;
    protected readonly Mock<ILogger<TLogicProvider>> _logger;
    protected readonly Mock<TDataProvider> _dataProvider;
    protected readonly TLogicProvider _logicProvider;
    #endregion

    #region [ CTor ]
    public BaseEntityLogicProviderUnitTest()
    {
        this._fixture = new Fixture();

        this._dataProvider = this._fixture.Freeze<Mock<TDataProvider>>();
        this._logger = this._fixture.Freeze<Mock<ILogger<TLogicProvider>>>();
        this._logicProvider = this.CreateLogicProvider();
    }
    #endregion

   #region [ Methods - SaveAsync ]
    [Fact]
    public async Task SaveAsync_Success() {
        // Arrange
        var entity = this._fixture.Create<TEntity>();

        // Act
        await this._logicProvider.SaveAsync(entity);

        // Assert
        this._dataProvider.Verify(x => x.SaveAsync(entity), Times.Once);
    }

    [Fact]
    public async Task SaveAsync_EntityIsNull_Exception() {
        // Arrange
        var entity = default(TEntity);

        // Act
        var result = async () => await this._logicProvider.SaveAsync(entity);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    #endregion

    #region [ Methods - AddAsync ]
    [Fact]
    public async Task AddAsync_Success()
    {
        // Arrange
        var entity = this._fixture.Create<TEntity>();

        // Act
        await this._logicProvider.AddAsync(entity);

        // Assert
        this._dataProvider.Verify(x => x.AddAsync(entity), Times.Once);
    }

    [Fact]
    public async Task AddAsync_EntityIsNull_Exception()
    {
        // Arrange
        var entity = default(TEntity);

        // Act
        var result = async () => await this._logicProvider.AddAsync(entity);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    #endregion

    #region [ Methods - UpdateAsync ]
    [Fact]
    public async Task UpdateAsync_Success()
    {
        // Arrange
        var entity = this._fixture.Create<TEntity>();

        // Act
        await this._logicProvider.UpdateAsync(entity);

        // Assert
        this._dataProvider.Verify(x => x.UpdateAsync(entity), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_EntityIsNull_Exception()
    {
        // Arrange
        var entity = default(TEntity);

        // Act
        var result = async () => await this._logicProvider.UpdateAsync(entity);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    #endregion

    #region [ Methods - SyncAsync ]
    [Fact]
    public async Task SyncAsync_Success()
    {
        // Arrange
        var entity = this._fixture.Create<TEntity>();

        // Act
        await this._logicProvider.SyncAsync(entity);

        // Assert
        this._dataProvider.Verify(x => x.SyncAsync(entity), Times.Once);
    }

    [Fact]
    public async Task SyncAsync_EntityIsNull_Exception()
    {
        // Arrange
        var entity = default(TEntity);

        // Act
        var result = async () => await this._logicProvider.SyncAsync(entity);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    #endregion

    #region [ Methods - ActivateAsync ]
    [Fact]
    public async Task ActivateAsync_Success()
    {
        // Arrange
        var id = this._fixture.Create<string>();

        // Act
        await this._logicProvider.ActivateAsync(id);

        // Assert
        this._dataProvider.Verify(x => x.ActivateAsync(id), Times.Once);
    }

    [Fact]
    public async Task ActivateAsync_EntityIsNull_Exception()
    {
        // Arrange
        string id = null;

        // Act
        var result = async () => await this._logicProvider.ActivateAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    #endregion

    #region [ Methods - DeactivateAsync ]
    [Fact]
    public async Task DeactivateAsync_Success()
    {
        // Arrange
        var id = this._fixture.Create<string>();

        // Act
        await this._logicProvider.DeactivateAsync(id);

        // Assert
        this._dataProvider.Verify(x => x.DeactivateAsync(id), Times.Once);
    }

    [Fact]
    public async Task DeactivateAsync_EntityIsNull_Exception()
    {
        // Arrange
        string id = null;

        // Act
        var result = async () => await this._logicProvider.DeactivateAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    #endregion

    #region [ Methods - DeleteAsync ]
    [Fact]
    public async Task DeleteAsync_Success()
    {
        // Arrange
        var id = this._fixture.Create<string>();

        // Act
        await this._logicProvider.DeleteAsync(id);

        // Assert
        this._dataProvider.Verify(x => x.DeleteAsync(id), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_EntityIsNull_Exception()
    {
        // Arrange
        string id = null;

        // Act
        var result = async () => await this._logicProvider.DeleteAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    #endregion

    #region [ Methods - DeleteBatchAsync ]
    [Fact]
    public async Task DeleteBatchAsync_Success()
    {
        // Arrange
        var ids = this._fixture.Create<List<string>>();

        // Act
        await this._logicProvider.DeleteBatchAsync(ids);

        // Assert
        this._dataProvider.Verify(x => x.DeleteAsync(It.IsAny<string>()), Times.Exactly(ids.Count));
    }

    [Fact]
    public async Task DeleteBatchAsync_EntityIsNull_Exception()
    {
        // Arrange
        List<string> id = null;

        // Act
        var result = async () => await this._logicProvider.DeleteBatchAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    #endregion

    #region [ Methods - GetAsync ]
    [Fact]
    public async Task GetAsync_Success()
    {
        // Arrange
        var id = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetAsync(id);

        // Assert
        this._dataProvider.Verify(x => x.GetAsync(id), Times.Once);
    }

    [Fact]
    public async Task GetAsync_EntityIsNull_Exception()
    {
        // Arrange
        string id = null;

        // Act
        var result = async () => await this._logicProvider.GetAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    #endregion

    #region [ Methods - GetAsync ]
    [Fact]
    public async Task GetAllAsync_Success()
    {
        // Act
        await this._logicProvider.GetAllAsync();

        // Assert
        this._dataProvider.Verify(x => x.GetAllAsync(), Times.Once);
    }
    #endregion

    #region [ Methods - GetActiveAsync ]
    [Fact]
    public async Task GetActiveAsync_Success()
    {
        // Act
        await this._logicProvider.GetActiveAsync();

        // Assert
        this._dataProvider.Verify(x => x.GetActiveAsync(), Times.Once);
    }
    #endregion

    #region [ Methods - GetInActiveAsync ]
    [Fact]
    public async Task GetInActiveAsync_Success()
    {
        // Act
        await this._logicProvider.GetInActiveAsync();

        // Assert
        this._dataProvider.Verify(x => x.GetInActiveAsync(), Times.Once);
    }
    #endregion

    #region [ Methods - GetBatchAsync ]
    [Fact]
    public async Task GetBatchAsync_Success()
    {
        // Arrange
        List<string> ids = this._fixture.Create<List<string>>();

        // Act
        await this._logicProvider.GetBatchAsync(ids);

        // Assert
        this._dataProvider.Verify(x => x.GetBatchAsync(ids), Times.Once);
    }
    #endregion

    #region [ Methods - GetChangesAsync ]
    [Fact]
    public async Task GetChangesAsync_Success()
    {
        // Arrange
        var date = this._fixture.Create<DateTime>();

        // Act
        await this._logicProvider.GetChangesAsync(date);

        // Assert
        this._dataProvider.Verify(x => x.GetChangesAsync(date), Times.Once());
    }
    #endregion

    #region [ Methods - AnyAsync ]
    [Fact]
    public async Task AnyAsync_Success()
    {
        // Act
        await this._logicProvider.AnyAsync();

        // Assert
        this._dataProvider.Verify(x => x.AnyAsync(), Times.Once);
    }
    #endregion

    #region [ Methods - CountAllAsync ]
    [Fact]
    public async Task CountAllAsync_Success()
    {
        // Act
        await this._logicProvider.CountAllAsync();

        // Assert
        this._dataProvider.Verify(x => x.CountAllAsync(), Times.Once);
    }
    #endregion

    #region [ Methods - CountActivelAsync ]
    [Fact]
    public async Task CountActivelAsync_Success()
    {
        // Act
        await this._logicProvider.CountActivelAsync();

        // Assert
        this._dataProvider.Verify(x => x.CountActivelAsync(), Times.Once);
    }
    #endregion

    #region [ Methods - CountInActiveAsync ]
    [Fact]
    public async Task CountInActiveAsync_Success()
    {
        // Act
        await this._logicProvider.CountInActiveAsync();

        // Assert
        this._dataProvider.Verify(x => x.CountInActiveAsync(), Times.Once);
    }
    #endregion

    #region [ Methods - SaveFromInputConnector ]

    #endregion

    #region [ Methods - GetAllAsync Take Skip ]
    [Fact]
    public async Task GetAllAsync_TakeSkip_Success() {
        // Arrange
        var take = this._fixture.Create<int>();
        var skip = this._fixture.Create<int>();

        // Act
        await this._logicProvider.GetAllAsync(take, skip);

        // Assert
        this._dataProvider.Verify(x => x.GetAllAsync(take, skip), Times.Once);
    }
    
    [Fact]
    public async Task GetAllAsync_TakeSkip_Should_ThrowException_If_Error() {
        // Arrange
        var take = this._fixture.Create<int>();
        var skip = this._fixture.Create<int>();
        this._dataProvider.Setup(x => x.GetAllAsync(take, skip)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.GetAllAsync(take, skip);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    #endregion

    #region [ Methods - IsExistedNextEntitySearchFilterAsync ]
    [Fact]
    public async Task IsExistedNextEntitySearchFilterAsync_TakeSkip_Success() {
        // Arrange
        var skip = this._fixture.Create<int>();
        var searchString = this._fixture.Create<string>();
        var entites = this._fixture.Create<List<TEntity>>();
        this._dataProvider.Setup(x => x.GetBySearchFilterAsync(searchString, 1, skip)).ReturnsAsync(entites);

        // Act
        var actual = await this._logicProvider.IsExistedNextEntitySearchFilterAsync(searchString, skip);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public async Task IsExistedNextEntitySearchFilterAsync_TakeSkip_Should_ThrowException_If_Error() {
        // Arrange
        var skip = this._fixture.Create<int>();
        var searchString = this._fixture.Create<string>();
        this._dataProvider.Setup(x => x.GetBySearchFilterAsync(searchString, 1, skip)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.IsExistedNextEntitySearchFilterAsync(searchString, skip);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    
    [Fact]
    public async Task IsExistedNextEntitySearchFilterAsync_TakeSkip_Should_ThrowException_If_SearchString_IsEmpty() {
        // Arrange
        var skip = this._fixture.Create<int>();
        var searchString = string.Empty;

        // Act
        var result = async () => await this._logicProvider.IsExistedNextEntitySearchFilterAsync(searchString, skip);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    
    [Fact]
    public async Task IsExistedNextEntitySearchFilterAsync_TakeSkip_Should_ThrowException_If_SearchString_IsNull() {
        // Arrange
        var skip = this._fixture.Create<int>();
        string searchString = null;

        // Act
        var result = async () => await this._logicProvider.IsExistedNextEntitySearchFilterAsync(searchString, skip);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    #endregion

    #region [ Methods - IsExistedNextEntityAsync ]
    [Fact]
    public async Task IsExistedNextEntityAsync_TakeSkip_Success() {
        // Arrange
        var skip = this._fixture.Create<int>();
        var entites = this._fixture.Create<List<TEntity>>();
        this._dataProvider.Setup(x => x.GetAllAsync(1, skip)).ReturnsAsync(entites);

        // Act
        await this._logicProvider.IsExistedNextEntityAsync(skip);

        // Assert
        this._dataProvider.Verify(x => x.GetAllAsync(1, skip), Times.Once);
    }

    [Fact]
    public async Task IsExistedNextEntityAsync_TakeSkip_Should_ThrowException_If_Error() {
        // Arrange
        var skip = this._fixture.Create<int>();
        this._dataProvider.Setup(x => x.GetAllAsync(1, skip)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.IsExistedNextEntityAsync(skip);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    #endregion

    #region [ Methods - SaveFromInputConnector ]
    [Fact]
    public async Task SaveFromInputConnector_Success() {
        // Arrange
        var entity = this._fixture.Create<TEntity>();
        var excludedProperties = this._fixture.Create<string[]> ();

        // Act
        await this._logicProvider.SaveFromInputConnector(entity, excludedProperties);

        // Assert
        this._dataProvider.Verify(x => x.SaveFromInputConnector(entity, excludedProperties), Times.Once);
    }
    
    [Fact]
    public async Task SaveFromInputConnector_Should_ThrowException_If_Entity_IsNull() {
        // Arrange
        var entity = default(TEntity);
        var excludedProperties = this._fixture.Create<string[]> ();

        // Act
        var result = async () => await this._logicProvider.SaveFromInputConnector(entity, excludedProperties);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    
    [Fact]
    public async Task SaveFromInputConnector_Should_ThrowException_If_Error() {
        // Arrange
        var entity = this._fixture.Create<TEntity>();
        var excludedProperties = this._fixture.Create<string[]> ();
        this._dataProvider.Setup(x => x.SaveFromInputConnector(entity, excludedProperties)).ThrowsAsync(new Exception());

        // Act
        var result = async () => await this._logicProvider.SaveFromInputConnector(entity, excludedProperties);

        // Assert
        await Assert.ThrowsAsync<Exception>(result);
    }
    #endregion

    #region [ Protected Methods - Create ]
    protected TLogicProvider CreateLogicProvider()
    {
        return OnCreateLogicProvider(this._dataProvider.Object, this._logger.Object);
    }
    #endregion

    #region [ Protected Abstract Methods ]
    protected abstract TLogicProvider OnCreateLogicProvider(TDataProvider dataProvider, ILogger<TLogicProvider> logger);
    #endregion

    #region [ Methods - Dispose ]
    public void Dispose()
    {
        
    }
    #endregion
}
