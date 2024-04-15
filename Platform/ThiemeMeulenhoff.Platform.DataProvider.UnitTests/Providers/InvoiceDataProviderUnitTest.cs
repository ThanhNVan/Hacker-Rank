using System;
using System.Linq;
using System.Threading.Tasks;
using RCode.Data.Providers;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

[Collection("DataProvider")]
public class InvoiceDataProviderUnitTest : BaseEntityDataProviderUnitTests<InvoiceDataProvider<ThiemeMeulenhoffPlatformDbContext>, IInvoiceValidationProvider, Invoice>
{
    #region [ CTor ]
    public InvoiceDataProviderUnitTest() : base(SeedProvider.Current.Invoices) {
    }
    #endregion

    #region [ Protected Methods - override ]
    protected override InvoiceDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        return new InvoiceDataProvider<ThiemeMeulenhoffPlatformDbContext>(
           this._logger.Object,
           this._dbContextFactory.Object,
           this._validationProvider.Object);
    }
    #endregion

    #region [ Public Methods - Custom - Lists ]
    [Fact]
    public async Task GetByOrderIdAsync_Success() {
        // Arrange
        var entity = this.SeedSource.First();
        var expected = this.SeedSource.Where(x => x.OrderId == entity.OrderId);

        // Act
        var actual = await this._dataProvider.GetByOrderIdAsync(entity.OrderId);

        // Assert

        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetByOrderIdAsync_Should_ThrowException_If_OrderId_IsEmpty() {
        // Arrange
        var OrderId = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetByOrderIdAsync(OrderId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByContactIdAsync_Success() {
        // Arrange
        var entity = this.SeedSource.First();
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

        // Act
        var result = async () => await this._dataProvider.GetByContactIdAsync(ContactId);

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
        var expected = this.SeedSource.Where(x => (x.Id + x.OrderId + x.ContactId + x.Reference + x.State + x.DueDate + x.DateReceived).ToLower().Contains(entity.Id))
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
