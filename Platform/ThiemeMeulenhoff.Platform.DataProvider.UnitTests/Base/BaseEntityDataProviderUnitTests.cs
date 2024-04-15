using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using RCode;
using RCode.Data.Paging;
using RCode.Data.Providers;
using RCode.Validation;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

[Collection("DataProvider")]
[CollectionDefinition(nameof(BaseEntityDataProviderUnitTests<TDataProvider, TIValidationProvider, TEntity>), DisableParallelization = true)]
public abstract class BaseEntityDataProviderUnitTests<TDataProvider, TIValidationProvider, TEntity> : IDisposable
    where TDataProvider : ThiemeBaseEntityDataProvider<TEntity, ThiemeMeulenhoffPlatformDbContext>
    where TEntity : BaseEntity
    where TIValidationProvider : class, IEntityValidationProvider<TEntity>
{
    #region [ Fields ]
    protected readonly Mock<IDbContextFactory<ThiemeMeulenhoffPlatformDbContext>> _dbContextFactory;
    protected readonly Fixture _fixture;
    protected readonly Mock<ILogger<TDataProvider>> _logger;
    protected readonly Mock<TIValidationProvider> _validationProvider;
    protected readonly TDataProvider _dataProvider;
    #endregion

    #region [ CTor ]
    public BaseEntityDataProviderUnitTests(List<TEntity> seedSource) {
        this._dbContextFactory = new Mock<IDbContextFactory<ThiemeMeulenhoffPlatformDbContext>>();
        this._dbContextFactory.Setup(f => f.CreateDbContext()).Returns(() => this.CreateContext());
        this._dbContextFactory.Setup(f => f.CreateDbContextAsync(It.IsAny<CancellationToken>())).Returns(async () => await this.CreateContextAsync());
        this._fixture = new Fixture();
        this._logger = _fixture.Freeze<Mock<ILogger<TDataProvider>>>();
        this._validationProvider = _fixture.Freeze<Mock<TIValidationProvider>>();
        this._dataProvider = this.GetDataProvider();

        this.SeedSource = seedSource;

        this.EnsureCreate();
    }
    #endregion

    #region [ Properties - SeedSource ]
    protected List<TEntity> SeedSource { get; set; }

    #endregion

    #region [ Methods - SaveAsync ]
    [Fact]
    public virtual async Task SaveAsync_AddEntity_Success() {
        // Arrange
        var entity = this.SeedSource.LastOrDefault();
        entity.Id = IdFactory.CreateId();

        // Act
        await this._dataProvider.SaveAsync(entity);

        // Assert
        var listDbEntities = (await _dataProvider.GetAllAsync()).Count();
        var listSeedEntities = this.SeedSource.Count();

        Assert.True((listSeedEntities + 1) == listDbEntities);
    }

    [Fact]
    public virtual async Task SaveAsync_UpdateEntity_Success() {
        // Arrange 
        var entity = this.SeedSource.FirstOrDefault();
        entity.IsActive = false;

        // Act
        await this._dataProvider.SaveAsync(entity);

        // Assert
        var dbEntity = await this._dataProvider.GetAsync(entity.Id);
        Assert.False(dbEntity.IsActive);
    }

    [Fact]
    public virtual async Task SaveAsync_Should_ThrowException_If_Entity_IsNull() {
        // Arrange
        var entity = default(TEntity);

        // Act
        var result = async () => await this._dataProvider.SaveAsync(entity);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }
    #endregion

    #region [ Methods - SyncAsync ]
    [Fact]
    public virtual async Task SyncAsync_Add_Success() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        entity.Id = IdFactory.CreateId();

        // Act
        await this._dataProvider.SyncAsync(entity);

        // Assert
        var listDbEntities = (await _dataProvider.GetAllAsync()).Count();
        var listSeedEntities = this.SeedSource.Count();

        Assert.True((listSeedEntities + 1) == listDbEntities);
    }

    [Fact]
    public virtual async Task SyncAsync_Should_ThrowException_If_Entity_IsNull() {
        // Arrange
        var entity = default(TEntity);

        // Act
        var result = async () => await this._dataProvider.SyncAsync(entity);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    //[Fact]
    //public virtual async Task SyncAsync_Should_ThrowException_If_EntityId_IsNull()
    //{
    //    // Arrange
    //    var entity = this.SeedSource.FirstOrDefault();
    //    entity.Id = null;

    //    // Act
    //    var result = async () => await this._dataProvider.SyncAsync(entity);

    //    // Assert
    //    await Assert.ThrowsAsync<DataProviderUpdateException>(result);
    //}

    //[Fact]
    //public virtual async Task SyncAsync_Should_ThrowException_If_EntityId_IsEmpty()
    //{
    //    // Arrange
    //    var entity = this.SeedSource.FirstOrDefault();
    //    entity.Id = string.Empty;

    //    // Act
    //    var result = async () => await this._dataProvider.SyncAsync(entity);

    //    // Assert
    //    await Assert.ThrowsAsync<DataProviderUpdateException>(result);
    //}
    #endregion

    #region [ public virtual Methods - Add ]
    [Fact]
    public virtual async Task AddAsync_Success() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        entity.Id = IdFactory.CreateId();

        // Act
        await this._dataProvider.AddAsync(entity);
        var dbEntity = await _dataProvider.GetAsync(entity.Id);

        // Assert
        Assert.Equal(entity.Id, dbEntity.Id);
        Assert.Equal(entity.CreatedAt, dbEntity.CreatedAt);
        Assert.Equal(entity.EntityType, dbEntity.EntityType);
    }

    [Fact]
    public virtual async Task AddAsync_Should_ThrowDataProviderEntityAlreadyExistsException_If_Entity_IsDuplicated() {
        // Arrange
        var entity = this.SeedSource.LastOrDefault();

        // Act
        var result = async () => await this._dataProvider.AddAsync(entity);

        // Assert
        await Assert.ThrowsAsync<DataProviderAddException>(result);
    }

    [Fact]
    public virtual async Task AddAsync_Should_ThrowException_If_Entity_IsNull() {
        // Arrange
        var entity = default(TEntity);

        // Act
        var result = async () => await this._dataProvider.AddAsync(entity);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }
    #endregion

    #region [ Protected Abstract Methods ]
    protected abstract TDataProvider GetDataProvider();
    #endregion

    #region [ Methods - UpdateAsync ]
    [Fact]
    public virtual async Task UpdateAsync_Success() {
        // Arrange 
        var entity = this.SeedSource.FirstOrDefault();
        entity.IsActive = false;

        // Act
        await this._dataProvider.UpdateAsync(entity);

        // Assert
        var dbEntity = await this._dataProvider.GetAsync(entity.Id);
        Assert.Equal(entity.IsActive, dbEntity.IsActive);
    }

    [Fact]
    public virtual async Task UpdateAsync_Should_ThrowDataProviderUpdateException_If_Entity_NotFound() {
        // Arrange 
        var entity = this.SeedSource.FirstOrDefault();
        entity.Id = IdFactory.CreateId();

        // Act
        var result = async () => await this._dataProvider.UpdateAsync(entity);

        // Assert
        await Assert.ThrowsAsync<DataProviderUpdateException>(result);
    }

    [Fact]
    public virtual async Task UpdateAsync_Should_ThrowNull_If_Entity_Null() {
        // Arrange 
        var entity = default(TEntity);

        // Act
        var result = async () => await this._dataProvider.UpdateAsync(entity);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }
    #endregion

    #region [ Methods - ActivateAsync ]
    [Fact]
    public virtual async Task ActivateAsync_Success() {
        // Arrange 
        var entity = this.SeedSource.LastOrDefault();

        // Act
        var aa = await this._dataProvider.GetAllAsync();
        await this._dataProvider.ActivateAsync(entity.Id);


        // Assert
        var dbEntity = await this._dataProvider.GetAsync(entity.Id);
        Assert.True(dbEntity.IsActive);
    }

    [Fact]
    public virtual async Task ActivateAsync_Should_ThrowException_If_Entity_IsNull() {
        // Arrange 
        var entity = default(TEntity);

        // Act
        var result = async () => await this._dataProvider.ActivateAsync(entity.Id);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }
    #endregion

    #region [ Methods - DeactivateAsync ]
    [Fact]
    public virtual async Task DeactivateAsync_Success() {
        // Arrange 
        var entity = this.SeedSource.FirstOrDefault();

        // Act
        await this._dataProvider.DeactivateAsync(entity.Id);

        // Assert
        var dbEntity = await this._dataProvider.GetAsync(entity.Id);
        Assert.False(dbEntity.IsActive);
    }

    [Fact]
    public virtual async Task DeactivateAsync_Should_ThrowException_If_Entity_IsNull() {
        // Arrange 
        var entity = default(TEntity);

        // Act
        var result = async () => await this._dataProvider.DeactivateAsync(entity.Id);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }
    #endregion

    #region [ Methods - DeleteAsync ]
    [Fact]
    public virtual async Task DeleteAsync_Success() {
        // Arrange 
        var entity = this.SeedSource.FirstOrDefault();

        // Act
        await this._dataProvider.DeleteAsync(entity.Id);

        // Assert
        var dbEntity = await this._dataProvider.GetAsync(entity.Id);
        Assert.Null(dbEntity);
    }

    [Fact]
    public virtual async Task DeleteAsync_Should_ThrowException_If_Entity_IsNull() {
        // Arrange 
        var entity = default(TEntity);

        // Act
        var result = async () => await this._dataProvider.DeleteAsync(entity.Id);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }
    #endregion

    #region [ Methods - DeleteBatchAsync ]
    [Fact]
    public virtual async Task DeleteBatchAsync_Success() {
        // Arrange 
        var idList = new List<string>() {
            this.SeedSource[0].Id,
            this.SeedSource[1].Id,
            this.SeedSource[2].Id,
        };

        // Act
        await this._dataProvider.DeleteBatchAsync(idList);

        // Assert
        var dbEntities = await this._dataProvider.GetAllAsync();
        var expectedResult = this.SeedSource.Count() - idList.Count();
        var actualResult = dbEntities.Count();
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public virtual async Task DeleteBatchAsync_Should_ThrowException_If_Entity_IsNull() {
        // Arrange 
        var idList = default(List<string>);

        // Act
        var result = async () => await this._dataProvider.DeleteBatchAsync(idList);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }
    #endregion

    #region [ Methods - GetAsync ]
    [Fact]
    public virtual async Task GetAsync_Success() {
        // Arrange 
        var entity = this.SeedSource.FirstOrDefault();

        // Assert
        var dbEntity = await this._dataProvider.GetAsync(entity.Id);
        Assert.Equal(dbEntity.Id, entity.Id);
        Assert.Equal(dbEntity.CreatedAt, entity.CreatedAt);
        Assert.Equal(dbEntity.UpdatedAt, entity.UpdatedAt);
        Assert.Equal(dbEntity.IsActive, entity.IsActive);
    }

    [Fact]
    public virtual async Task GetAsync_Should_ThrowException_If_Entity_IsNull() {
        // Arrange 
        var entity = default(TEntity);

        // Act
        var result = async () => await this._dataProvider.GetAsync(entity.Id);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }
    #endregion

    #region [ Methods - GetAllAsync ]
    [Fact]
    public virtual async Task GetAllAsync_Success() {
        // Arrange 
        var entities = this.SeedSource;

        // Assert
        var dbEntity = await this._dataProvider.GetAllAsync();
        var expected = dbEntity.Count;
        var actual = entities.Count;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public virtual async Task GetAllAsync_Should_ThrowException_If_Option_IsNull() {
        // Arrange 
        var option = default(PagingOptions);

        // Act
        var result = async () => await this._dataProvider.GetAllAsync(option);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public virtual async Task GetAllAsync_PagingOptions_Success() {
        // Arrange
        var options = new PagingOptions() {
            CalculateTotals = true,
            LoadStrategy = PagingLoadStrategy.PerRequest,
            Page = 0,
            PageSize = 2
        };
        var expected = this.SeedSource.Skip((options.Page - 1) * options.PageSize).Take(options.PageSize);

        // Act
        var result = await this._dataProvider.GetAllAsync(options);

        // Assert
        Assert.True(expected.Count() == result.Items.Count);
    }
    #endregion

    #region [ Methods - GetActiveAsync ]
    [Fact]
    public virtual async Task GetActiveAsync_Success() {
        // Arrange 
        var entities = this.SeedSource.Where(x => x.IsActive == true).ToList();

        // Assert
        var dbEntity = await this._dataProvider.GetActiveAsync();
        var expected = dbEntity.Count;
        var actual = entities.Count;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public virtual async Task GetActiveAsync_Should_ThrowException_If_Option_IsNull() {
        // Arrange 
        var option = default(PagingOptions);

        // Act
        var result = async () => await this._dataProvider.GetActiveAsync(option);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public virtual async Task GetActiveAsync_PagingOptions_Success() {
        // Arrange
        var options = new PagingOptions() {
            CalculateTotals = true,
            LoadStrategy = PagingLoadStrategy.PerRequest,
            Page = 0,
            PageSize = 2
        };
        var expected = this.SeedSource.Where(x => x.IsActive == true).Skip((options.Page - 1) * options.PageSize).Take(options.PageSize);

        // Act
        var result = await this._dataProvider.GetActiveAsync(options);

        // Assert
        Assert.True(expected.Count() == result.Items.Count);
    }
    #endregion

    #region [ Methods - GetActiveAsync ]
    [Fact]
    public virtual async Task GetInActiveAsync_Success() {
        // Arrange 
        var entities = this.SeedSource.Where(x => x.IsActive == false).ToList();

        // Assert
        var dbEntity = await this._dataProvider.GetInActiveAsync();
        var expected = dbEntity.Count;
        var actual = entities.Count;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public virtual async Task GetInActiveAsync_Should_ThrowException_If_Option_IsNull() {
        // Arrange 
        var option = default(PagingOptions);

        // Act
        var result = async () => await this._dataProvider.GetInActiveAsync(option);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public virtual async Task GetInActiveAsync_PagingOptions_Success() {
        // Arrange
        var options = new PagingOptions() {
            CalculateTotals = true,
            LoadStrategy = PagingLoadStrategy.PerRequest,
            Page = 0,
            PageSize = 2
        };
        var expected = this.SeedSource.Where(x => x.IsActive == false).Skip((options.Page - 1) * options.PageSize).Take(options.PageSize);

        // Act
        var result = await this._dataProvider.GetInActiveAsync(options);

        // Assert
        Assert.True(expected.Count() == result.Items.Count);
    }
    #endregion

    #region [ Methods - GetBatchAsync ]
    [Fact]
    public virtual async Task GetBatchAsync_Success() {
        // Arrange 
        var idList = new List<string>() {
            this.SeedSource[0].Id,
            this.SeedSource[1].Id,
            this.SeedSource[2].Id,
        };

        // Act
        var dbEntities = await this._dataProvider.GetBatchAsync(idList);

        // Assert
        var expectedResult = idList.Count();
        var actualResult = dbEntities.Count();
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public virtual async Task GetBatchAsync_Should_ThrowException_If_Option_IsNull() {
        // Arrange 
        var idList = default(List<string>);

        // Act
        var result = async () => await this._dataProvider.GetBatchAsync(idList);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }
    #endregion

    #region [ Methods - GetChangesAsync ]
    [Fact]
    public virtual async Task GetChangesAsync_Success() {
        // Arrange 
        var date = DateTime.UtcNow.AddDays(-1);

        // Act
        var dbEntities = await this._dataProvider.GetChangesAsync(date);
        var actualResult = dbEntities.Count();
        var expectedResult = this.SeedSource.Where(x => x.UpdatedAt > date).Count();

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }
    #endregion

    #region [ Methods - AnyAsync ]
    [Fact]
    public virtual async Task AnyAsync_Success() {
        // Act
        var actualResult = await this._dataProvider.AnyAsync();

        // Assert
        Assert.True(actualResult);
    }
    #endregion

    #region [ Methods - CountAllAsync ]
    [Fact]
    public virtual async Task CountAllAsync_Success() {
        // Arrange
        var expected = this.SeedSource.Count;

        // Act
        var actualResult = await this._dataProvider.CountAllAsync();

        // Assert
        Assert.Equal(expected, actualResult);
    }
    #endregion

    #region [ Methods - CountActivelAsync ]
    [Fact]
    public virtual async Task CountActiveAsync_Success() {
        // Arrange
        var expected = this.SeedSource.Where(x => x.IsActive == true).Count();

        // Act
        var actualResult = await this._dataProvider.CountActivelAsync();

        // Assert
        Assert.Equal(expected, actualResult);
    }
    #endregion

    #region [ Methods - CountInActiveAsync ]
    [Fact]
    public virtual async Task CountInActiveAsync_Success() {
        // Arrange
        var expected = this.SeedSource.Where(x => x.IsActive == false).Count();

        // Act
        var actualResult = await this._dataProvider.CountInActiveAsync();

        // Assert
        Assert.Equal(expected, actualResult);
    }
    #endregion

    #region [ Methods - SaveFromInputConnector ]
    [Fact]
    public virtual async Task SaveFromInputConnector_Add_Success() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        entity.Id = IdFactory.CreateId();

        // Act
        await this._dataProvider.SaveFromInputConnector(entity);
        var dbEntity = await _dataProvider.GetAsync(entity.Id);

        // Assert
        Assert.Equal(entity.Id, dbEntity.Id);
        Assert.Equal(entity.CreatedAt, dbEntity.CreatedAt);
        Assert.Equal(entity.EntityType, dbEntity.EntityType);
    }
    
    [Fact]
    public virtual async Task SaveFromInputConnector_Update_Success() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        entity.IsActive = !entity.IsActive;

        // Act
        await this._dataProvider.SaveFromInputConnector(entity);
        var dbEntity = await _dataProvider.GetAsync(entity.Id);

        // Assert
        Assert.Equal(entity.Id, dbEntity.Id);
        Assert.Equal(entity.CreatedAt, dbEntity.CreatedAt);
        Assert.Equal(entity.EntityType, dbEntity.EntityType);
        Assert.Equal(entity.IsActive, dbEntity.IsActive);
    }
    
    [Fact]
    public virtual async Task SaveFromInputConnector_Should_ThrowException_If_Error() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        entity.IsActive = !entity.IsActive;
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.SaveFromInputConnector(entity);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }
    
    [Fact]
    public virtual async Task SaveFromInputConnector_Should_ThrowException_If_Entity_IsNull() {
        // Arrange
        var entity = default(TEntity);

        // Act
        var result = async () => await this._dataProvider.SaveFromInputConnector(entity);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    #endregion

    #region [ Methods - GetAllAsync ]
    [Fact]
    public virtual async Task GetAllAsync_TakeSkip_Success() { 
        // Arrange
        var take = 3;
        var skip = 0;
        var expected = this.SeedSource.Skip(skip).Take(take);

        // Act
        var actual = await this._dataProvider.GetAllAsync(take, skip);


        // Assert
        Assert.Equal(expected.Count(), actual.Count);
    }
    
    [Fact]
    public virtual async Task GetAllAsync_TakeSkip_Should_ThrowException_If_Error() { 
        // Arrange
        var take = 3;
        var skip = 0;
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetAllAsync(take, skip);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }
    #endregion

    #region [ Methods - GetBySearchFilterAsync ]
    [Fact]
    public virtual async Task GetBySearchFilterAsync_TakeSkip_Success() {
        // Arrange
        var take = 3;
        var skip = 0;
        var searchFilter = this._fixture.Create<string>();
        var expected = this.SeedSource.Where(x => x.Id.ToLower().Contains(searchFilter)).Skip(skip).Take(take);

        // Act
        var actual = await this._dataProvider.GetBySearchFilterAsync(searchFilter, take, skip);


        // Assert
        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public virtual async Task GetBySearchFilterAsync_TakeSkip_Should_ThrowException_If_Error() {
        // Arrange
        var take = 3;
        var skip = 0;
        var searchFilter = this._fixture.Create<string>();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetBySearchFilterAsync(searchFilter, take, skip);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }
    
    [Fact]
    public virtual async Task GetBySearchFilterAsync_TakeSkip_Should_ThrowException_If_SearchFilter_IsEmpty() {
        // Arrange
        var take = 3;
        var skip = 0;
        var searchFilter = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetBySearchFilterAsync(searchFilter, take, skip);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }
    
    [Fact]
    public virtual async Task GetBySearchFilterAsync_TakeSkip_Should_ThrowException_If_SearchFilter_IsNull() {
        // Arrange
        var take = 3;
        var skip = 0;
        string searchFilter = null;

        // Act
        var result = async () => await this._dataProvider.GetBySearchFilterAsync(searchFilter, take, skip);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }
    #endregion

    #region [ Methods - CreateContext ]
    public virtual ThiemeMeulenhoffPlatformDbContext CreateContext() {
        var option = new DbContextOptionsBuilder<ThiemeMeulenhoffPlatformDbContext>()
                            .UseInMemoryDatabase(databaseName: "db-Id")
                            .Options;
        return new ThiemeMeulenhoffPlatformDbContext(option);
    }

    public virtual Task<ThiemeMeulenhoffPlatformDbContext> CreateContextAsync() {
        var option = new DbContextOptionsBuilder<ThiemeMeulenhoffPlatformDbContext>()
                            .UseInMemoryDatabase(databaseName: "db-Id")
                            .Options;
        return Task.FromResult(new ThiemeMeulenhoffPlatformDbContext(option));
    }
    #endregion

    #region [ Methods - Helper ]
    public virtual void Dispose() {
        this.CreateContext().Database.EnsureDeleted();
    }

    public virtual void EnsureCreate() {
        this.CreateContext().Database.EnsureCreated();
        using (var context = this.CreateContext()) {
            var data = SeedProvider.Current;
            context.AddRange(data.EntityApplicationKeys);
            context.AddRange(data.Contacts);
            context.AddRange(data.Persons);
            context.AddRange(data.Organizations);
            context.AddRange(data.Schools);
            context.AddRange(data.Addresses);
            context.AddRange(data.Products);
            context.AddRange(data.ProductBundleItems);
            context.AddRange(data.PriceInfo);
            context.AddRange(data.LicenceInfo);
            context.AddRange(data.LicenseSeries);
            context.AddRange(data.LicenseSerieItems);
            context.AddRange(data.Subjects);
            context.AddRange(data.Orders);
            context.AddRange(data.OrderItems);
            context.AddRange(data.StockMutations);
            context.AddRange(data.Projects);
            context.AddRange(data.ProjectTeamMembers);
            context.AddRange(data.EanCodes);
            context.AddRange(data.PrintInfo);
            context.AddRange(data.PrintInfoTemplates);
            context.AddRange(data.PrintOrders);
            context.AddRange(data.Invoices);
            context.AddRange(data.InvoiceItems);
            context.AddRange(data.DeliveryNoteItems);
            context.AddRange(data.DeliveryNotes);
            context.AddRange(data.EducationFunctions);
            context.AddRange(data.EducationSectors);
            context.AddRange(data.EducationSubjects);
            context.AddRange(data.EducationTypes);
            context.AddRange(data.PersonEducationFunctions);
            context.AddRange(data.PersonEducationSubjects);
            context.AddRange(data.PersonOrganizations);
            context.SaveChanges();
        }
    }
    #endregion
}
