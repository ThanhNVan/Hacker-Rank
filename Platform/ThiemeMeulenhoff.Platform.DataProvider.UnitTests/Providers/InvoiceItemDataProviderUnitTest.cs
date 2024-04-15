using System;
using System.Linq;
using System.Threading.Tasks;
using RCode.Data.Providers;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class InvoiceItemDataProviderUnitTest : BaseEntityDataProviderUnitTests<InvoiceItemDataProvider<ThiemeMeulenhoffPlatformDbContext>, IInvoiceItemValidationProvider, InvoiceItem>
{
    #region [ CTor ]
    public InvoiceItemDataProviderUnitTest() : base(SeedProvider.Current.InvoiceItems) {
    }
    #endregion

    #region [ Protected Methods - override ]
    protected override InvoiceItemDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        return new InvoiceItemDataProvider<ThiemeMeulenhoffPlatformDbContext>(
           this._logger.Object,
           this._dbContextFactory.Object,
           this._validationProvider.Object);
    }
    #endregion

    #region [ Public Methods - Custom - Lists ]
    [Fact]
    public async Task GetByInvoiceIdAsync_Success() {
        // Arrange
        var entity = this.SeedSource.First();
        var expected = this.SeedSource.Where(x => x.InvoiceId == entity.InvoiceId);

        // Act
        var actual = await this._dataProvider.GetByInvoiceIdAsync(entity.InvoiceId);

        // Assert

        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetByInvoiceIdAsync_Should_ThrowException_If_InvoiceId_IsEmpty() {
        // Arrange
        var InvoiceId = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetByInvoiceIdAsync(InvoiceId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

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
    public async Task GetByOrderItemIdAsync_Success() {
        // Arrange
        var entity = this.SeedSource.First();
        var expected = this.SeedSource.Where(x => x.OrderItemId == entity.OrderItemId);

        // Act
        var actual = await this._dataProvider.GetByOrderItemIdAsync(entity.OrderItemId);

        // Assert

        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetByOrderItemIdAsync_Should_ThrowException_If_OrderItemId_IsEmpty() {
        // Arrange
        var OrderItemId = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetByOrderItemIdAsync(OrderItemId);

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
        var expected = this.SeedSource.Where(x => (x.Id + x.InvoiceId + x.ProductId + x.OrderItemId + x.NetAmount + x.Currency + x.TaxPercentage).ToLower().Contains(entity.Id))
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
    public async Task GetBySearchFilterAsync_Should_ThrowException_If_Exception() {
        // Arrange 
        var searchFilter = string.Empty;
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
