using System;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using RCode.Data.Providers;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

[Collection("DataProvider")]
public class PrintOrderDataProviderUnitTest : BaseEntityDataProviderUnitTests<PrintOrderDataProvider<ThiemeMeulenhoffPlatformDbContext>, IPrintOrderValidationProvider, PrintOrder>
{
    #region [ CTor ]
    public PrintOrderDataProviderUnitTest() : base(SeedProvider.Current.PrintOrders) {
    }
    #endregion

    #region [ Protected Methods - override ]
    protected override PrintOrderDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        return new PrintOrderDataProvider<ThiemeMeulenhoffPlatformDbContext>(
           this._logger.Object,
           this._dbContextFactory.Object,
           this._validationProvider.Object);
    }
    #endregion

    #region [ Methods - Single ]
    [Fact]
    public async Task GetByAfasPrintOrderNumberAsync_Success() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        var expected = this.SeedSource.FirstOrDefault(x => x.Id == entity.Id);

        // Act
        var actual = await this._dataProvider.GetByAfasPrintOrderNumberAsync(entity.Id);

        // Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.IsActive, actual.IsActive);
        Assert.Equal(expected.CreatedAt.ToShortDateString(), actual.CreatedAt.ToShortDateString());
    }

    [Fact]
    public virtual async Task GetByAfasPrintOrderNumberAsync_Should_ThrowException_If_Entity_IsNull() {
        // Arrange 
        var entity = default(Address);

        // Act
        var result = async () => await this._dataProvider.GetByAfasPrintOrderNumberAsync(entity.Id);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public virtual async Task GetByAfasPrintOrderNumberAsync_Should_ThrowException_If_Entity_IsEmpty() {
        // Arrange 
        var entityId = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetByAfasPrintOrderNumberAsync(entityId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }
    
    [Fact]
    public virtual async Task GetByAfasPrintOrderNumberAsync_Should_ThrowException_If_Error() {
        // Arrange 
        var entityId = Guid.NewGuid().ToString();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByAfasPrintOrderNumberAsync(entityId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }
    #endregion

    #region [ Public Methods - Custom - Lists ]
    [Fact]
    public async Task GetByProductIdAsync_Success() {
        // Arrange
        var entity = this.SeedSource.First();
        var expected = this.SeedSource.Where(x => x.ProductId == entity.ProductId);

        // Act
        var actual = await this._dataProvider.GetByProductIdAsync(entity.ProductId);

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

    [Fact]
    public async Task GetByEanAsync_Success() {
        // Arrange
        var entity = this.SeedSource.First();
        var expected = this.SeedSource.Where(x => x.Ean == entity.Ean);

        // Act
        var actual = await this._dataProvider.GetByEanAsync(entity.Ean);

        // Assert

        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetByEanAsync_Should_ThrowException_If_Ean_IsEmpty() {
        // Arrange
        var Ean = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetByEanAsync(Ean);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByStatusAsync_Success() {
        // Arrange
        var entity = this.SeedSource.First();
        var expected = this.SeedSource.Where(x => x.Status == entity.Status);

        // Act
        var actual = await this._dataProvider.GetByStatusAsync(entity.Status);

        // Assert

        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetByStatusAsync_Should_ThrowException_If_Status_IsEmpty() {
        // Arrange
        var Status = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetByStatusAsync(Status);

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
        var expected = this.SeedSource.Where(x => (x.Id + x.Ean + x.ProductId + x.BatchNumber + x.UnitsOrdered + x.ProductionCompanyName).ToLower().Contains(entity.Id))
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
