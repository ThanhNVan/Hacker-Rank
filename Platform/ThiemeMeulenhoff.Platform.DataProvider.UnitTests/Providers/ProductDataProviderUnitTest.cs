using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RCode.Data.Providers;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

[Collection("DataProvider")]
public class ProductDataProviderUnitTest : BaseEntityDataProviderUnitTests<ProductDataProvider<ThiemeMeulenhoffPlatformDbContext>, IProductValidationProvider, Product>
{
    #region [ Fields ]
    private BusinessRuleSettings _businessRuleSettings;
    #endregion

    #region [ CTor ]
    public ProductDataProviderUnitTest() : base(SeedProvider.Current.Products) {

    }
    #endregion


    #region [ Protected Methods - Override ]
    protected override ProductDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        this._businessRuleSettings = new();
        this.SetBusinessRuleSettings();
        return new ProductDataProvider<ThiemeMeulenhoffPlatformDbContext>(
           this._logger.Object,
           this._dbContextFactory.Object,
           this._validationProvider.Object,
           this._businessRuleSettings);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByAfasProductIdAsync_Success() {
        // Arrange
        var entity = SeedSource.FirstOrDefault();
        var expected = SeedSource.FirstOrDefault(x => x.AfasProductId == entity.AfasProductId);

        //Act
        var actual = await this._dataProvider.GetByAfasProductIdAsync(entity.AfasProductId);

        //Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.CreatedAt.ToLongDateString(), actual.CreatedAt.ToLongDateString());
        Assert.Equal(expected.IsActive, actual.IsActive);
    }

    [Fact]
    public async Task GetByAfasProductIdAsync_Should_ThrowException_If_AfasProductId_IsEmpty() {
        // Arrange
        var AfasProductId = string.Empty;

        //Act
        var result = async () => await this._dataProvider.GetByAfasProductIdAsync(AfasProductId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByAfasProductIdAsync_Should_ThrowException_If_AfasProductId_IsNull() {
        // Arrange
        var entity = default(Product);

        //Act
        var result = async () => await this._dataProvider.GetByAfasProductIdAsync(entity.AfasProductId);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByNurAsync_Success() {
        // Arrange 
        var entity = SeedSource.FirstOrDefault();

        //Act
        var dbEntity = await this._dataProvider.GetByNurAsync(entity.Nur);
        var expected = dbEntity.Id;
        var actual = entity.Id;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetByNurAsync_Should_ThrowException_If_Entity_IsNull() {
        // Arrange 
        var entity = default(Product);

        // Act
        var result = async () => await this._dataProvider.GetByNurAsync(entity.Nur);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByNurAsync_Should_ThrowException_If_Error() {
        // Arrange 
        var entity = SeedSource.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByNurAsync(entity.Nur);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }
    
    [Fact]
    public async Task GetByEanAsync_Success() {
        // Arrange 
        var entity = SeedSource.FirstOrDefault();

        //Act
        var dbEntity = await this._dataProvider.GetByEanAsync(entity.Ean);
        var expected = dbEntity.Id;
        var actual = entity.Id;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetByEanAsync_Should_ThrowException_If_Entity_IsNull() {
        // Arrange 
        var entity = default(Product);

        // Act
        var result = async () => await this._dataProvider.GetByEanAsync(entity.Ean);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByEanAsync_Should_ThrowException_If_Error() {
        // Arrange 
        var entity = SeedSource.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByEanAsync(entity.Ean);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByUuidAsync_Success() {
        //Arrange
        var entity = SeedSource.FirstOrDefault();

        //Act
        var dbEntity = await this._dataProvider.GetByUuidAsync(entity.Ean);
        var expected = dbEntity.Id;
        var actual = entity.Id;

        // Assert
        Assert.Equal(expected, actual);

    }

    [Fact]
    public async Task GetByUuidAsync_Should_ThrowException_If_Entity_IsNull() {
        // Arrange 
        var entity = default(Product);

        // Act
        var result = async () => await this._dataProvider.GetByUuidAsync(entity.Ean);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(result);
    }

    [Fact]
    public async Task GetByUuidAsync_Should_ThrowException_If_Error() {
        // Arrange 
        var entity = SeedSource.FirstOrDefault();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByUuidAsync(entity.Ean);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }
    #endregion

    #region [ Public Methods - Custom - Lists ]
    [Fact]
    public async Task GetByProductGroupAsync_Success() {
        // Arrange
        var entity = this.SeedSource.First();
        var expected = this.SeedSource.Where(x => x.ProductGroup == entity.ProductGroup);

        // Act
        var actual = await this._dataProvider.GetByProductGroupAsync(entity.ProductGroup);

        // Assert

        Assert.Equal(expected.Count(), actual.Count);
    }
    [Fact]
    public async Task GetByProductGroupAsync_Should_ThrowException_If_ProductGroup_IsEmpty() {
        // Arrange
        var ProductGroup = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetByProductGroupAsync(ProductGroup);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByProductGroupAsync_Should_ThrowException_If_ProductGroup_IsNull() {
        // Arrange
        string ProductGroup = null;

        // Act
        var result = async () => await this._dataProvider.GetByProductGroupAsync(ProductGroup);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByProductGroupAsync_Should_ThrowException_If_Error() {
        // Arrange
        var ProductGroup = Guid.NewGuid().ToString();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByProductGroupAsync(ProductGroup);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetBookProductsAsync_Success() {
        // Arrange
        var expected = this.SeedSource.Where(x => this._businessRuleSettings.BookProductGroupList().Contains(x.ProductGroup));

        // Act
        var actual = await this._dataProvider.GetBookProductsAsync();

        // Assert

        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetBookProductsAsync_Should_ThrowException_If_Error() {
        // Arrange
        var ProductGroup = Guid.NewGuid().ToString();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetBookProductsAsync();

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }
    
    [Fact]
    public async Task GetLicenseProductsAsync_Success() {
        // Arrange
        var expected = this.SeedSource.Where(x => this._businessRuleSettings.BookProductGroupList().Contains(x.ProductGroup));

        // Act
        var actual = await this._dataProvider.GetLicenseProductsAsync();

        // Assert

        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetLicenseProductsAsync_Should_ThrowException_If_Error() {
        // Arrange
        var ProductGroup = Guid.NewGuid().ToString();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetLicenseProductsAsync();

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }
    
    [Fact]
    public async Task GetBundleProductsAsync_Success() {
        // Arrange
        var expected = this.SeedSource.Where(x => !string.IsNullOrEmpty(x.BundleType));

        // Act
        var actual = await this._dataProvider.GetBundleProductsAsync();

        // Assert

        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetBundleProductsAsync_Should_ThrowException_If_Error() {
        // Arrange
        var ProductGroup = Guid.NewGuid().ToString();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetBundleProductsAsync();

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetProductsInBundleAsync_Success() {
        // Arrange
        var entity = this.SeedSource.First();
        var expected = from a in SeedProvider.Current.Products
                       join b in SeedProvider.Current.ProductBundleItems on a.Id equals b.OwnerProductId
                       where a.Id == entity.Id
                       select a;

        // Act
        var actual = await this._dataProvider.GetProductsInBundleAsync(entity.Id);

        // Assert

        Assert.Equal(expected.Count(), actual.Count);
    }
    [Fact]
    public async Task GetProductsInBundleAsync_Should_ThrowException_If_ProductGroup_IsEmpty() {
        // Arrange
        var ProductGroup = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetProductsInBundleAsync(ProductGroup);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetProductsInBundleAsync_Should_ThrowException_If_ProductGroup_IsNull() {
        // Arrange
        string ProductGroup = null;

        // Act
        var result = async () => await this._dataProvider.GetProductsInBundleAsync(ProductGroup);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetProductsInBundleAsync_Should_ThrowException_If_Error() {
        // Arrange
        var ProductGroup = Guid.NewGuid().ToString();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetProductsInBundleAsync(ProductGroup);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByEansAsync_Success() {
        // Arrange
        var eans = new List<string> () {
            this.SeedSource[0].Ean,
            this.SeedSource[1].Ean,
            this.SeedSource[2].Ean,
        };
        var expected = from a in SeedProvider.Current.Products
                       join b in SeedProvider.Current.ProductBundleItems on a.Id equals b.OwnerProductId
                       where eans.Contains(a.Ean)
                       select a;

        // Act
        var actual = await this._dataProvider.GetByEansAsync(eans);

        // Assert

        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetByEansAsync_Should_ThrowException_If_Eans_IsNull() {
        // Arrange
        List<string> eans = null;

        // Act
        var result = async () => await this._dataProvider.GetByEansAsync(eans);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByEansAsync_Should_ThrowException_If_Error() {
        // Arrange
        var eans = new List<string>() {
            this.SeedSource[0].Ean,
            this.SeedSource[1].Ean,
            this.SeedSource[2].Ean,
        };
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByEansAsync(eans);

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
        var expected = this.SeedSource.Where(x => (x.Id + x.Ean + x.TargetAudience + x.ProductStatus + x.EducationSector + x.ProductGroup + x.Title).ToLower().Contains(entity.Id))
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
