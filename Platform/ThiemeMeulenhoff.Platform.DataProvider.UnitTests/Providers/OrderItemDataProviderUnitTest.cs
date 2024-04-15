using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using RCode.Data.Providers;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

[Collection("DataProvider")]
public class OrderItemDataProviderUnitTest : BaseEntityDataProviderUnitTests<OrderItemDataProvider<ThiemeMeulenhoffPlatformDbContext>, IOrderItemValidationProvider, OrderItem>
{
    #region [ Fields ]
    private BusinessRuleSettings _businessRuleSettings;
    #endregion

    #region [ CTor ]
    public OrderItemDataProviderUnitTest() : base(SeedProvider.Current.OrderItems) {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override OrderItemDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        this._businessRuleSettings = new();
        this.SetBusinessRuleSettings();

        return new OrderItemDataProvider<ThiemeMeulenhoffPlatformDbContext>(
           this._logger.Object,
           this._dbContextFactory.Object,
           this._validationProvider.Object,
           this._businessRuleSettings);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByAfasOrderItemIdAsync_Success() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        var expected = SeedSource.FirstOrDefault(x => x.AfasOrderItemId == entity.AfasOrderItemId);

        //Act
        var actual = await this._dataProvider.GetByAfasOrderItemIdAsync(entity.AfasOrderItemId);

        //Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.CreatedAt.ToLongDateString(), actual.CreatedAt.ToLongDateString());
        Assert.Equal(expected.IsActive, actual.IsActive);
    }

    [Fact]
    public async Task GetByAfasOrderItemIdAsync_Should_ThrowException_If_AfasOrderItemId_IsEmpty() {
        // Arrange
        var AfasOrderItemId = string.Empty;

        //Act
        var result = async () => await this._dataProvider.GetByAfasOrderItemIdAsync(AfasOrderItemId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByAfasOrderItemIdAsync_Should_ThrowException_If_AfasOrderItemId_IsNull() {
        // Arrange
        var entity = default(OrderItem);

        //Act
        var result = async () => await this._dataProvider.GetByAfasOrderItemIdAsync(entity.AfasOrderItemId);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByAfasOrderItemIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetByAfasOrderItemIdAsync(entity.AfasOrderItemId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByCbOwnerReferenceAsync_Success() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        var expected = SeedSource.FirstOrDefault(x => x.Id.StartsWith(entity.Id));

        //Act
        var actual = await this._dataProvider.GetByCbOwnerReferenceAsync(entity.Id);

        //Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.CreatedAt.ToLongDateString(), actual.CreatedAt.ToLongDateString());
        Assert.Equal(expected.IsActive, actual.IsActive);
    }

    [Fact]
    public async Task GetByCbOwnerReferenceAsync_Should_ThrowException_If_AfasOrderItemId_IsEmpty() {
        // Arrange
        var CbOwnerReference = string.Empty;

        //Act
        var result = async () => await this._dataProvider.GetByCbOwnerReferenceAsync(CbOwnerReference);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByCbOwnerReferenceAsync_Should_ThrowException_If_AfasOrderItemId_IsNull() {
        // Arrange
        var entity = default(OrderItem);

        //Act
        var result = async () => await this._dataProvider.GetByCbOwnerReferenceAsync(entity.Id);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByCbOwnerReferenceAsync_Should_ThrowException_If_Error() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetByCbOwnerReferenceAsync(entity.Id);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }
    #endregion

    #region [ Public Methods - Custom - Lists ]
    [Fact]
    public async Task GetByOrderIdAsync_Success() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        var expected = SeedSource.Where(x => x.OrderId == entity.OrderId);

        //Act
        var actual = await this._dataProvider.GetByOrderIdAsync(entity.OrderId);

        //Assert
        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetByOrderIdAsync_Should_ThrowException_If_OrderId_IsEmpty() {
        // Arrange
        var OrderId = string.Empty;

        //Act
        var result = async () => await this._dataProvider.GetByOrderIdAsync(OrderId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByOrderIdAsync_Should_ThrowException_If_OrderId_IsNull() {
        // Arrange
        var entity = default(OrderItem);

        //Act
        var result = async () => await this._dataProvider.GetByOrderIdAsync(entity.OrderId);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByOrderIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetByOrderIdAsync(entity.Id);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByProductAsync_Success() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        var expected = SeedSource.Where(x => x.ProductId == entity.ProductId);

        //Act
        var actual = await this._dataProvider.GetByProductAsync(entity.ProductId);

        //Assert
        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetByProductAsync_Should_ThrowException_If_ProductId_IsEmpty() {
        // Arrange
        var ProductId = string.Empty;

        //Act
        var result = async () => await this._dataProvider.GetByProductAsync(ProductId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByProductAsync_Should_ThrowException_If_ProductId_IsNull() {
        // Arrange
        var entity = default(OrderItem);

        //Act
        var result = async () => await this._dataProvider.GetByProductAsync(entity.ProductId);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByProductAsync_Should_ThrowException_If_Error() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetByProductAsync(entity.Id);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetBatchByOrderIdAsync_Success() {
        // Arrange
        var entityIds = new List<string>() {

            this.SeedSource[1].Id, 
            this.SeedSource[2].Id,
            this.SeedSource[3].Id
        };
        var expected = SeedSource.Where(x => entityIds.Contains(x.Id));

        //Act
        var actual = await this._dataProvider.GetBatchByOrderIdAsync(entityIds);

        //Assert
        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetBatchByOrderIdAsync_Should_ThrowException_If_ProductId_IsNull() {
        // Arrange
        var entityIds = default(List<string>);

        //Act
        var result = async () => await this._dataProvider.GetBatchByOrderIdAsync(entityIds);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetBatchByOrderIdAsync_Should_ThrowException_If_Error() {
        // Arrange
        var entityIds = new List<string>() {
            this.SeedSource[0].Id, this.SeedSource[1].Id, this.SeedSource[2].Id
        };
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetBatchByOrderIdAsync(entityIds);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }
    
    [Fact]
    public async Task GetChangesAsync_ProductGroups_Success() {
        // Arrange
        var productGroups = new List<string>() {
            SeedProvider.Current.Products[0].ProductGroup,
            SeedProvider.Current.Products[1].ProductGroup,
            SeedProvider.Current.Products[2].ProductGroup,
        };

        var date = DateTime.UtcNow.AddDays(-1);

        var expected = (from a in SeedProvider.Current.OrderItems
                       join b in SeedProvider.Current.Products on a.ProductId equals b.Id
                       where a.UpdatedAt >= date && productGroups.Contains(b.ProductGroup)
                       select a).ToList();

        //Act
        var actual = await this._dataProvider.GetChangesAsync(date, productGroups);

        //Assert
        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetChangesAsync_Should_ThrowException_If_ProductGroups_IsNull() {
        // Arrange
        var productGroups = default(List<string>);
        var date = DateTime.UtcNow.AddDays(-1);

        //Act
        var result = async () => await this._dataProvider.GetChangesAsync(date, productGroups);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetChangesAsync_Should_ThrowException_If_Error() {
        // Arrange
        var productGroups = new List<string>() {
            this.SeedSource[0].Id, this.SeedSource[1].Id, this.SeedSource[2].Id
        };
        var date = DateTime.UtcNow.AddDays(-1);
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetChangesAsync(date, productGroups);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetChangesBookProductsAsync_ProductGroups_Success() {
        // Arrange
        var productGroups = new List<string>() {
            SeedProvider.Current.Products[0].ProductGroup,
            SeedProvider.Current.Products[1].ProductGroup,
            SeedProvider.Current.Products[2].ProductGroup,
            SeedProvider.Current.Products[3].ProductGroup,
            SeedProvider.Current.Products[4].ProductGroup,
            SeedProvider.Current.Products[5].ProductGroup,
            SeedProvider.Current.Products[6].ProductGroup,
            SeedProvider.Current.Products[7].ProductGroup,
            SeedProvider.Current.Products[8].ProductGroup,
            SeedProvider.Current.Products[9].ProductGroup,
        };

        var date = DateTime.UtcNow.AddDays(-1);

        var expected = (from a in SeedProvider.Current.OrderItems
                        join b in SeedProvider.Current.Products on a.ProductId equals b.Id
                        where a.UpdatedAt >= date && productGroups.Contains(b.ProductGroup)
                        select a).ToList();

        //Act
        var actual = await this._dataProvider.GetChangesBookProductsAsync(date);

        //Assert
        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetChangesBookProductsAsync_Should_ThrowException_If_Error() {
        // Arrange
        var productGroups = new List<string>() {
            this.SeedSource[0].Id, this.SeedSource[1].Id, this.SeedSource[2].Id
        };
        var date = DateTime.UtcNow.AddDays(-1);
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetChangesBookProductsAsync(date);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }
    
    [Fact]
    public async Task GetChangesLicenseProductsAsync_ProductGroups_Success() {
        // Arrange
        var productGroups = new List<string>() {
            SeedProvider.Current.Products[0].ProductGroup,
            SeedProvider.Current.Products[1].ProductGroup,
            SeedProvider.Current.Products[2].ProductGroup,
            SeedProvider.Current.Products[3].ProductGroup,
            SeedProvider.Current.Products[4].ProductGroup,
            SeedProvider.Current.Products[5].ProductGroup,
            SeedProvider.Current.Products[6].ProductGroup,
            SeedProvider.Current.Products[7].ProductGroup,
            SeedProvider.Current.Products[8].ProductGroup,
            SeedProvider.Current.Products[9].ProductGroup,
        };

        var date = DateTime.UtcNow.AddDays(-1);

        var expected = (from a in SeedProvider.Current.OrderItems
                        join b in SeedProvider.Current.Products on a.ProductId equals b.Id
                        where a.UpdatedAt >= date && productGroups.Contains(b.ProductGroup)
                        select a).ToList();

        //Act
        var actual = await this._dataProvider.GetChangesLicenseProductsAsync(date);

        //Assert
        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetChangesLicenseProductsAsync_Should_ThrowException_If_Error() {
        // Arrange
        var licenseGroup = new List<string>() {
            this.SeedSource[0].Id, this.SeedSource[1].Id, this.SeedSource[2].Id
        };
        var date = DateTime.UtcNow.AddDays(-1);
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetChangesLicenseProductsAsync(date);

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
        var expected = this.SeedSource.Where(x => (x.Id + x.OrderId + x.ProductId + x.Units + x.Sample + x.Status).ToLower().Contains(entity.Id))
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

    #region [ Private Methods -  ]
    private void SetBusinessRuleSettings() {
        
        for (int i = 0; i < 10; i++) {
            this._businessRuleSettings.BookProductGroups += SeedProvider.Current.Products[i].ProductGroup + ",";
            this._businessRuleSettings.LicenseProductGroups += SeedProvider.Current.Products[i].ProductGroup + ",";
        }
    }
    #endregion
}