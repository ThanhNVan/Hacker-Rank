using System;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using RCode.Data.Providers;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

[Collection("DataProvider")]
public class AddressDataProviderUnitTest : BaseEntityDataProviderUnitTests<AddressDataProvider<ThiemeMeulenhoffPlatformDbContext>, IAddressValidationProvider, Address>
{
    #region [ CTor ]
    public AddressDataProviderUnitTest() : base(SeedProvider.Current.Addresses) {
    }
    #endregion

    #region [ Protected Methods - override ]
    protected override AddressDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        return new AddressDataProvider<ThiemeMeulenhoffPlatformDbContext>(
           this._logger.Object,
           this._dbContextFactory.Object,
           this._validationProvider.Object);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByAfasAddressIdAsync_Success() {
        // Arrange
        var entity = this.SeedSource.FirstOrDefault();
        var expected = this.SeedSource.FirstOrDefault(x =>
                                        x.AfasAddressId == entity.AfasAddressId &&
                                        x.AfasContactNumber == entity.AfasContactNumber &&
                                        x.AddressType == entity.AddressType);
        var addressType = Enum.Parse<AddressType>(entity.AddressType);
        // Act
        var actual = await this._dataProvider.GetByAfasAddressIdAsync(entity.AfasAddressId, entity.AfasContactNumber, addressType);

        // Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.IsActive, actual.IsActive);
        Assert.Equal(expected.AfasAddressId, actual.AfasAddressId);
        Assert.Equal(expected.AfasContactNumber, actual.AfasContactNumber);
        Assert.Equal(expected.AddressType, actual.AddressType);
    }

    [Fact]
    public virtual async Task GetByAfasAddressIdAsync_Should_ThrowException_If_Entity_IsNull() {
        // Arrange 
        //var entity = default(Address);
        var addressType = (AddressType)(new Random().Next(0, 4));
        // Act
        var result = async () => await this._dataProvider.GetByAfasAddressIdAsync(null, null, addressType);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public virtual async Task GetByAfasAddressIdAsync_Should_ThrowException_If_Entity_IsEmpty() {
        // Arrange 
        var entityId = string.Empty;


        // Act
        var result = async () => await this._dataProvider.GetByAfasAddressIdAsync(entityId, string.Empty, AddressType.Unknown);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }

    [Fact]
    public async Task GetByOwnerAsync_Success() {
        // Arrange
        var entity = SeedProvider.Current.Addresses.FirstOrDefault();
        var addressType = (AddressType)Enum.Parse(typeof(AddressType), entity.AddressType);
        var expected = this.SeedSource.FirstOrDefault(x => x.OwnerContactId == entity.OwnerContactId && x.AddressType == entity.AddressType);

        // Act
        var actual = await this._dataProvider.GetByOwnerAsync(entity.OwnerContactId, addressType);

        // Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.IsActive, actual.IsActive);
        Assert.Equal(expected.Street, actual.Street);
    }

    [Fact]
    public async Task GetByOwnerAsync_Should_ThrowException_If_OwnerContactId_IsEmpty() {
        // Arrange 
        var entityId = string.Empty;
        var entity = SeedProvider.Current.Addresses.FirstOrDefault();
        var addressType = (AddressType)Enum.Parse(typeof(AddressType), entity.AddressType);

        // Act
        var result = async () => await this._dataProvider.GetByOwnerAsync(entityId, addressType);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }
    
    [Fact]
    public async Task GetByOwnerAsync_Should_ThrowException_If_OwnerContactId_IsNull() {
        // Arrange 
        string entityId = null;
        var entity = SeedProvider.Current.Addresses.FirstOrDefault();
        var addressType = (AddressType)Enum.Parse(typeof(AddressType), entity.AddressType);

        // Act
        var result = async () => await this._dataProvider.GetByOwnerAsync(entityId, addressType);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }
    
    [Fact]
    public async Task GetByOwnerAsync_Should_ThrowException_If_Error() {
        // Arrange 
        string entityId = Guid.NewGuid().ToString();
        var entity = SeedProvider.Current.Addresses.FirstOrDefault();
        var addressType = (AddressType)Enum.Parse(typeof(AddressType), entity.AddressType);
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());
        // Act
        var result = async () => await this._dataProvider.GetByOwnerAsync(entityId, addressType);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetSingleException>(result);
    }
    #endregion

    #region [ Public Methods - Lists ]
    [Fact]
    public async Task GetByAfasContactNumberAsync_Success() {
        //Arrange
        var entity = this.SeedSource.FirstOrDefault();
        var expected = this.SeedSource.Where(x => x.AfasContactNumber == entity.AfasContactNumber);

        // Act
        var actual = await this._dataProvider.GetByAfasContactNumberAsync(entity.AfasContactNumber);

        // Assert
        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ThrowException_If_Error() {
        // Arrange 
        var AfasContactNumber = this._fixture.Create<string>();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByAfasContactNumberAsync(AfasContactNumber);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByAfasContactNumberAsync_Should_ThrowException_If_AfasContactNumber_IsEmpty() {
        // Arrange 
        var AfasContactNumber = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetByAfasContactNumberAsync(AfasContactNumber);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }
    
    [Fact]
    public async Task GetByOwnerContactAsync_Success() {
        //Arrange
        var entity = this.SeedSource.FirstOrDefault();
        var expected = this.SeedSource.Where(x => x.OwnerContactId == entity.OwnerContactId);

        // Act
        var actual = await this._dataProvider.GetByOwnerContactAsync(entity.OwnerContactId);

        // Assert
        Assert.Equal(expected.Count(), actual.Count);
    }

    [Fact]
    public async Task GetByOwnerContactAsync_Should_ThrowException_If_Error() {
        // Arrange 
        var ownerContactId = this._fixture.Create<string>();
        this._dbContextFactory.Setup(x => x.CreateDbContext()).Throws(new Exception());

        // Act
        var result = async () => await this._dataProvider.GetByOwnerContactAsync(ownerContactId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }

    [Fact]
    public async Task GetByOwnerContactAsync_Should_ThrowException_If_Param_IsEmpty() {
        // Arrange 
        var ownerContactId = string.Empty;

        // Act
        var result = async () => await this._dataProvider.GetByOwnerContactAsync(ownerContactId);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }
    
    [Fact]
    public async Task GetBySearchFilterAsync_Success() {
        //Arrange
        var entity = this.SeedSource.FirstOrDefault();
        var take = 5;
        var skip = 0;
        var expected = this.SeedSource.Where(x => (x.Id + x.HouseNumberPrefix + x.HouseNumber + x.Street + x.City + x.PostalCode + x.AddressType).ToLower().Contains(entity.Id))
                            .Skip(skip)
                            .Take(take);

        // Act
        var actual = await this._dataProvider.GetBySearchFilterAsync(entity.Id, take, skip);

        // Assert
        Assert.Equal(expected.Count(), actual.Count);
    }
    
    [Fact]
    public async Task GetBySearchFilterAsync_Should_ThrowException_If_OwnerContactId_IsEmpty() {
        // Arrange 
        var OwnerContactId = string.Empty;
        var take = 5;
        var skip = 0;

        // Act
        var result = async () => await this._dataProvider.GetBySearchFilterAsync(OwnerContactId, take, skip);

        // Assert
        await Assert.ThrowsAsync<DataProviderGetListException>(result);
    }
    #endregion
}
