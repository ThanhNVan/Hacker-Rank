using RCode.Data.Providers;
using System.Linq;
using System.Threading.Tasks;
using System;
using ThiemeMeulenhoff.Platform.Data;
using Xunit;
using System.Collections.Generic;

namespace ThiemeMeulenhoff.Platform;

[Collection("DataProvider")]
public class ProductBundleItemDataProviderUnitTest : BaseEntityDataProviderUnitTests<ProductBundleItemDataProvider<ThiemeMeulenhoffPlatformDbContext>, IProductBundleItemValidationProvider, ProductBundleItem>
{
    #region [ CTor ]
    public ProductBundleItemDataProviderUnitTest() : base(SeedProvider.Current.ProductBundleItems) {
    }
    #endregion

    #region [ Protected Methods - override ]
    protected override ProductBundleItemDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        return new ProductBundleItemDataProvider<ThiemeMeulenhoffPlatformDbContext>(
           this._logger.Object,
           this._dbContextFactory.Object,
           this._validationProvider.Object);
    }
    #endregion

    #region [ Public Methods - Custom - Lists ]
    [Fact]
    public async Task GetByOwnerProductIdAsync_Success() {
        // Arrange
        var entity = SeedProvider.Current.ProductBundleItems.FirstOrDefault();
        var expected = SeedSource.Where(x => x.OwnerProductId == entity.OwnerProductId);

        //Act
        var actual = await this._dataProvider.GetByOwnerProductIdAsync(entity.OwnerProductId);

        //Assert
        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetByOwnerProductIdAsync_Should_ThrowException_If_Exception() {
        // Arrange
        var entity = SeedProvider.Current.Persons.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetByOwnerProductIdAsync(entity.Id);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByOwnerProductIdAsync_Should_ThrowException_If_OwnerProductId_IsEmpty() {
        // Arrange
        var OwnerProductId = string.Empty;

        //Act
        var result = async () => await this._dataProvider.GetByOwnerProductIdAsync(OwnerProductId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByOwnerProductIdAsync_Should_ThrowException_If_OwnerProductId_IsNull() {
        // Arrange
        var entity = default(ProductBundleItem);

        //Act
        var result = async () => await this._dataProvider.GetByOwnerProductIdAsync(entity.OwnerProductId);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByRelatedProductIdAsync_Success() {
        // Arrange
        var entity = SeedProvider.Current.ProductBundleItems.FirstOrDefault();
        var expected = SeedSource.Where(x => x.RelatedProductId == entity.RelatedProductId);

        //Act
        var actual = await this._dataProvider.GetByRelatedProductIdAsync(entity.RelatedProductId);

        //Assert
        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetByRelatedProductIdAsync_Should_ThrowException_If_Exception() {
        // Arrange
        var entity = SeedProvider.Current.Persons.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetByRelatedProductIdAsync(entity.Id);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByRelatedProductIdAsync_Should_ThrowException_If_RelatedProductId_IsEmpty() {
        // Arrange
        var RelatedProductId = string.Empty;

        //Act
        var result = async () => await this._dataProvider.GetByRelatedProductIdAsync(RelatedProductId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByRelatedProductIdAsync_Should_ThrowException_If_RelatedProductId_IsNull() {
        // Arrange
        var entity = default(ProductBundleItem);

        //Act
        var result = async () => await this._dataProvider.GetByRelatedProductIdAsync(entity.RelatedProductId);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }
    
    [Fact]
    public async Task GetBatchByRelatedProductIdAsync_Success() {
        // Arrange
        var relatedProductIds = new List<string> {
            SeedProvider.Current.ProductBundleItems[0].RelatedProductId,
            SeedProvider.Current.ProductBundleItems[1].RelatedProductId,
            SeedProvider.Current.ProductBundleItems[2].RelatedProductId,
        };
        var expected = SeedSource.Where(x => relatedProductIds.Contains(x.RelatedProductId));

        //Act
        var actual = await this._dataProvider.GetBatchByRelatedProductIdAsync(relatedProductIds);

        //Assert
        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetBatchByRelatedProductIdAsync_Should_ThrowException_If_Exception() {
        // Arrange
        var relatedProductIds = new List<string> {
            SeedProvider.Current.ProductBundleItems[0].RelatedProductId,
            SeedProvider.Current.ProductBundleItems[1].RelatedProductId,
            SeedProvider.Current.ProductBundleItems[2].RelatedProductId,
        };
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetBatchByRelatedProductIdAsync(relatedProductIds);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetBatchByRelatedProductIdAsync_Should_ThrowException_If_RelatedProduct_IsNull() {
        // Arrange
        var relatedProductIds = default(List<string>);

        //Act
        var result = async () => await this._dataProvider.GetBatchByRelatedProductIdAsync(relatedProductIds);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }
    
    [Fact]
    public async Task GetBatchByOwnerProductIdAsync_Success() {
        // Arrange
        var relatedProductIds = new List<string> {
            SeedProvider.Current.ProductBundleItems[0].OwnerProductId,
            SeedProvider.Current.ProductBundleItems[1].OwnerProductId,
            SeedProvider.Current.ProductBundleItems[2].OwnerProductId,
        };
        var expected = SeedSource.Where(x => relatedProductIds.Contains(x.OwnerProductId));

        //Act
        var actual = await this._dataProvider.GetBatchByOwnerProductIdAsync(relatedProductIds);

        //Assert
        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetBatchByOwnerProductIdAsync_Should_ThrowException_If_Exception() {
        // Arrange
        var relatedProductIds = new List<string> {
            SeedProvider.Current.ProductBundleItems[0].OwnerProductId,
            SeedProvider.Current.ProductBundleItems[1].OwnerProductId,
            SeedProvider.Current.ProductBundleItems[2].OwnerProductId,
        };
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        //Act
        var result = async () => await this._dataProvider.GetBatchByOwnerProductIdAsync(relatedProductIds);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetBatchByOwnerProductIdAsync_Should_ThrowException_If_RelatedProduct_IsNull() {
        // Arrange
        var relatedProductIds = default(List<string>);

        //Act
        var result = async () => await this._dataProvider.GetBatchByOwnerProductIdAsync(relatedProductIds);

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
        var expected = this.SeedSource.Where(x => (x.Id + x.OwnerProductId + x.RelatedProductId).ToLower().Contains(entity.Id))
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
