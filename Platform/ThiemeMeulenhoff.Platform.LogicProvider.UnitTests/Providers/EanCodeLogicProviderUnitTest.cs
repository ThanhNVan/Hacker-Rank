using System;
using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class EanCodeLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<EanCode, IEanCodeDataProvider, EanCodeLogicProvider>
{
    #region [ CTor ]
    public EanCodeLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override EanCodeLogicProvider OnCreateLogicProvider(IEanCodeDataProvider dataProvider, ILogger<EanCodeLogicProvider> logger) {
        return new EanCodeLogicProvider(logger, dataProvider);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task CreateAndAddAsync_Success() {
        // Arrange
        var random = new Random();
        var baseCode = SeedProvider.Current.EanCodes[random.Next(0, SeedProvider.Current.EanCodes.Count - 1)].BaseCode;
        var titleCode = this._fixture.Create<string>();
        var checkCode = this._fixture.Create<string>();

        // Act
        await this._logicProvider.CreateAndAddAsync(baseCode, titleCode, checkCode);

        // Assert
        this._dataProvider.Verify(x => x.CreateAndAddAsync(baseCode, titleCode, checkCode), Times.Once);
    }

    [Fact]
    public async Task CreateAndAddAsync_Should_ThrowException_If_BaseCode_IsNull() {
        // Arrange
        string baseCode = null;
        var titleCode = this._fixture.Create<string>();
        var checkCode = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.CreateAndAddAsync(baseCode, titleCode, checkCode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task CreateAndAddAsync_Should_ThrowException_If_BaseCode_IsEmpty() {
        // Arrange
        var baseCode = string.Empty;
        var titleCode = this._fixture.Create<string>();
        var checkCode = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.CreateAndAddAsync(baseCode, titleCode, checkCode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task CreateAndAddAsync_Should_ThrowException_If_BaseCode_IsNotValid() {
        // Arrange
        var baseCode = this._fixture.Create<string>();
        var titleCode = this._fixture.Create<string>();
        var checkCode = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.CreateAndAddAsync(baseCode, titleCode, checkCode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task CreateAndAddAsync_Should_ThrowException_If_TitleCode_IsNull() {
        // Arrange
        var random = new Random();
        var baseCode = SeedProvider.Current.EanCodes[random.Next(0, SeedProvider.Current.EanCodes.Count - 1)].BaseCode;
        string titleCode = null;
        var checkCode = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.CreateAndAddAsync(baseCode, titleCode, checkCode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task CreateAndAddAsync_Should_ThrowException_If_TitleCode_IsEmpty() {
        // Arrange
        var random = new Random();
        var baseCode = SeedProvider.Current.EanCodes[random.Next(0, SeedProvider.Current.EanCodes.Count - 1)].BaseCode;
        string titleCode = null;
        var checkCode = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.CreateAndAddAsync(baseCode, titleCode, checkCode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    
    [Fact]
    public async Task CreateAndAddAsync_Should_ThrowException_If_CheckCode_IsNull() {
        // Arrange
        var random = new Random();
        var baseCode = SeedProvider.Current.EanCodes[random.Next(0, SeedProvider.Current.EanCodes.Count - 1)].BaseCode;
        var titleCode = this._fixture.Create<string>();
        string checkCode = null;

        // Act
        var result = async () => await this._logicProvider.CreateAndAddAsync(baseCode, titleCode, checkCode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task CreateAndAddAsync_Should_ThrowException_If_CheckCode_IsEmpty() {
        // Arrange
        var random = new Random();
        var baseCode = SeedProvider.Current.EanCodes[random.Next(0, SeedProvider.Current.EanCodes.Count - 1)].BaseCode;
        var titleCode = this._fixture.Create<string>();
        var checkCode = string.Empty;

        // Act
        var result = async () => await this._logicProvider.CreateAndAddAsync(baseCode, titleCode, checkCode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GenerateTitleCodeAsync_Success() {
        // Arrange
        var random = new Random();
        var baseCode = SeedProvider.Current.EanCodes[random.Next(0, SeedProvider.Current.EanCodes.Count - 1)].BaseCode;

        // Act
        await this._logicProvider.GenerateTitleCodeAsync(baseCode);

        // Assert
        this._dataProvider.Verify(x => x.GenerateTitleCodeAsync(baseCode), Times.Once);
    }

    [Fact]
    public async Task GenerateTitleCodeAsync_Should_ThrowException_If_BaseCode_IsNull() {
        // Arrange
        string baseCode = null;

        // Act
        var result = async () => await this._logicProvider.GenerateTitleCodeAsync(baseCode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GenerateTitleCodeAsync_Should_ThrowException_If_BaseCode_IsEmpty() {
        // Arrange
        var baseCode = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GenerateTitleCodeAsync(baseCode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GenerateTitleCodeAsync_Should_ThrowException_If_BaseCode_IsNotValid() {
        // Arrange
        var baseCode = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.GenerateTitleCodeAsync(baseCode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByBaseCodeAsync_Sucess() {
        // Act
        await this._logicProvider.GetByBaseCodeAsync();

        // Assert
        this._dataProvider.Verify(x => x.GetByBaseCodeAsync(), Times.Once);
    }

    [Fact]
    public async Task GetByCodeAsync_Success() {
        // Arrange
        var fullcode = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByCodeAsync(fullcode);

        // Assert
        this._dataProvider.Verify(x => x.GetByCodeAsync(fullcode), Times.Once);
    }

    [Fact]
    public async Task GetByCodeAsync_Should_ThrowException_If_Fullcode_IsNull() {
        // Arrange
        string fullcode = null;

        // Act
        var result = async () => await this._logicProvider.GetByCodeAsync(fullcode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByCodeAsync_Should_ThrowException_If_Fullcode_IsEmpty() {
        // Arrange
        var fullcode = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByCodeAsync(fullcode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task CreateAndAddTitleCodeAsync_Success() {
        // Arrange
        var random = new Random();
        var baseCode = SeedProvider.Current.EanCodes[random.Next(0, SeedProvider.Current.EanCodes.Count - 1)].BaseCode;

        // Act
        await this._logicProvider.CreateAndAddTitleCodeAsync(baseCode);

        // Assert
        this._dataProvider.Verify(x => x.CreateAndAddTitleCodeAsync(baseCode), Times.Once);
    }

    [Fact]
    public async Task CreateAndAddTitleCodeAsync_Should_ThrowException_If_BaseCode_IsNull() {
        // Arrange
        string baseCode = null;

        // Act
        var result = async () => await this._logicProvider.CreateAndAddTitleCodeAsync(baseCode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task CreateAndAddTitleCodeAsync_Should_ThrowException_If_BaseCode_IsEmpty() {
        // Arrange
        var baseCode = string.Empty;

        // Act
        var result = async () => await this._logicProvider.CreateAndAddTitleCodeAsync(baseCode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task CreateAndAddTitleCodeAsync_Should_ThrowException_If_BaseCode_IsNotValid() {
        // Arrange
        var baseCode = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.CreateAndAddTitleCodeAsync(baseCode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    #endregion

    #region [ Public Methods - Custom - List ]
    [Fact]
    public async Task GetAllBaseCodeAsync_Success() {
        // Act
        await this._logicProvider.GetAllBaseCodeAsync();

        // Assert
        this._dataProvider.Verify(x => x.GetAllBaseCodeAsync(), Times.Once);
    }
    
    [Fact]
    public async Task GetByBaseCodeAsync_Success() {
        // Arrange
        var random = new Random();
        var baseCode = SeedProvider.Current.EanCodes[random.Next(0, SeedProvider.Current.EanCodes.Count - 1)].BaseCode;

        // Act
        await this._logicProvider.GetByBaseCodeAsync(baseCode);

        // Assert
        this._dataProvider.Verify(x => x.GetByBaseCodeAsync(baseCode), Times.Once);
    }

    [Fact]
    public async Task GetByBaseCodeAsync_Should_ThrowException_If_BaseCode_IsNull() {
        // Arrange
        string baseCode = null;

        // Act
        var result = async () => await this._logicProvider.GetByBaseCodeAsync(baseCode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByBaseCodeAsync_Should_ThrowException_If_BaseCode_IsEmpty() {
        // Arrange
        var baseCode = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByBaseCodeAsync(baseCode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByBaseCodeAsync_Should_ThrowException_If_BaseCode_IsNotValid() {
        // Arrange
        var baseCode = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.GetByBaseCodeAsync(baseCode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetUnregisteredCodesAsync_Success() {
        // Act
        await this._logicProvider.GetUnregisteredCodesAsync();

        // Assert
        this._dataProvider.Verify(x => x.GetUnregisteredCodesAsync(), Times.Once);
    }
    
    [Fact]
    public async Task GetUnregisteredCodesAsync_BaseCode_Success() {
        // Arrange
        var random = new Random();
        var baseCode = SeedProvider.Current.EanCodes[random.Next(0, SeedProvider.Current.EanCodes.Count - 1)].BaseCode;

        // Act
        await this._logicProvider.GetUnregisteredCodesAsync(baseCode);

        // Assert
        this._dataProvider.Verify(x => x.GetUnregisteredCodesAsync(baseCode), Times.Once);
    }

    [Fact]
    public async Task GetUnregisteredCodesAsync_Should_ThrowException_If_BaseCode_IsNull() {
        // Arrange
        string baseCode = null;

        // Act
        var result = async () => await this._logicProvider.GetUnregisteredCodesAsync(baseCode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetUnregisteredCodesAsync_Should_ThrowException_If_BaseCode_IsEmpty() {
        // Arrange
        var baseCode = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetUnregisteredCodesAsync(baseCode);

        // Assert
     
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetUnregisteredCodesAsync_Should_ThrowException_If_BaseCode_IsNotValid() {
        // Arrange
        var baseCode = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.GenerateTitleCodeAsync(baseCode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetAllTitleCodeAsync_Success() {
        // Act
        await this._logicProvider.GetAllTitleCodeAsync();

        // Assert
        this._dataProvider.Verify(x => x.GetAllTitleCodeAsync(), Times.Once);
    }
    
    [Fact]
    public async Task GetAllTitleCodeAsync_Take_Skip_Success() {
        // Arrange
        var take = this._fixture.Create<int>();    
        var skip = this._fixture.Create<int>();    

        // Act
        await this._logicProvider.GetAllTitleCodeAsync(take, skip);

        // Assert
        this._dataProvider.Verify(x => x.GetAllTitleCodeAsync(take, skip), Times.Once);
    }
    
    [Fact]
    public async Task GetAllTitleCodeAsync_Take_Skip_Should_ThrowException_If_NotValid() {
        // Arrange
        var take = 0;    
        var skip = this._fixture.Create<int>();

        // Act
        var result = async () => await this._logicProvider.GetAllTitleCodeAsync(take, skip);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    
    [Fact]
    public async Task GenerateTitleCodesAsync_Success() {
        // Arrange
        var random = new Random();
        var basecode = SeedProvider.Current.EanCodes[random.Next(0, SeedProvider.Current.EanCodes.Count - 1)].BaseCode;
        var numberOfRecords = this._fixture.Create<int>();   

        // Act
        await this._logicProvider.GenerateTitleCodesAsync(basecode, numberOfRecords);

        // Assert
        this._dataProvider.Verify(x => x.GenerateTitleCodesAsync(basecode, numberOfRecords), Times.Once);
    }
    
    [Fact]
    public async Task GenerateTitleCodesAsync_Should_ThrowException_If_NotValid() {
        // Arrange
        var random = new Random();
        var basecode = SeedProvider.Current.EanCodes[random.Next(0, SeedProvider.Current.EanCodes.Count - 1)].BaseCode;
        var numberOfRecords = 0;

        // Act
        var result = async () => await this._logicProvider.GenerateTitleCodesAsync(basecode, numberOfRecords);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GenerateTitleCodesAsync_Should_ThrowException_If_BaseCode_IsNull() {
        // Arrange
        string baseCode = null;
        var numberOfRecords = this._fixture.Create<int>();

        // Act
        var result = async () => await this._logicProvider.GenerateTitleCodesAsync(baseCode, numberOfRecords);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GenerateTitleCodesAsync_Should_ThrowException_If_BaseCode_IsEmpty() {
        // Arrange
        var baseCode = string.Empty;
        var numberOfRecords = this._fixture.Create<int>();

        // Act
        var result = async () => await this._logicProvider.GenerateTitleCodesAsync(baseCode, numberOfRecords);

        // Assert

        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GenerateTitleCodesAsync_Should_ThrowException_If_BaseCode_IsNotValid() {
        // Arrange
        var baseCode = this._fixture.Create<string>();
        var numberOfRecords = this._fixture.Create<int>();

        // Act
        var result = async () => await this._logicProvider.GenerateTitleCodesAsync(baseCode, numberOfRecords);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetBySearchFilterAsync_Success() {
        // Arrange
        var searchString = this._fixture.Create<string>(); 
        var take = this._fixture.Create<int>();   
        var skip = this._fixture.Create<int>();   

        // Act
        await this._logicProvider.GetBySearchFilterAsync(searchString, take, skip);

        // Assert
        this._dataProvider.Verify(x => x.GetBySearchFilterAsync(searchString, take, skip), Times.Once);
    }

    [Fact]
    public async Task GetBySearchFilterAsync_Should_ThrowException_If_SearchString_IsNull() {
        // Arrange
        string searchString = null; 
        var take = this._fixture.Create<int>();
        var skip = this._fixture.Create<int>();

        // Act
        var result = async () => await this._logicProvider.GetBySearchFilterAsync(searchString, take, skip);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetBySearchFilterAsync_Should_ThrowException_If_SearchString_IsEmpty() {
        // Arrange
        string searchString = string.Empty;
        var take = this._fixture.Create<int>();
        var skip = this._fixture.Create<int>();

        // Act
        var result = async () => await this._logicProvider.GetBySearchFilterAsync(searchString, take, skip);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    #endregion

    #region [ Public Methods - Custom - Add ]
    [Fact]
    public async Task AddNewBaseCodeAsync_Success() {
        // Arrange
        var random = new Random();
        var baseCode = SeedProvider.Current.EanCodes[random.Next(0, SeedProvider.Current.EanCodes.Count - 1)].BaseCode;

        // Act
        await this._logicProvider.AddNewBaseCodeAsync(baseCode);

        // Assert
        this._dataProvider.Verify(x => x.AddNewBaseCodeAsync(baseCode), Times.Once);
    }

    [Fact]
    public async Task AddNewBaseCodeAsync_Should_ThrowException_If_BaseCode_IsNull() {
        // Arrange
        string baseCode = null;

        // Act
        var result = async () => await this._logicProvider.AddNewBaseCodeAsync(baseCode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task AddNewBaseCodeAsync_Should_ThrowException_If_BaseCode_IsEmpty() {
        // Arrange
        string baseCode = string.Empty;

        // Act
        var result = async () => await this._logicProvider.AddNewBaseCodeAsync(baseCode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    
    [Fact]
    public async Task AddNewBaseCodeAsync_Should_ThrowException_If_BaseCode_IsNotValid() {
        // Arrange
        var baseCode = this._fixture.Create<string>();

        // Act
        var result = async () => await this._logicProvider.AddNewBaseCodeAsync(baseCode);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task AddRangeAsync_Success() {
        // Arrange
        var eanCodes = this._fixture.Create<List<EanCode>>();

        // Act
        await this._logicProvider.AddRangeAsync(eanCodes);

        // Assert
        this._dataProvider.Verify(x => x.AddRangeAsync(eanCodes), Times.Once);
    }

    [Fact]
    public async Task AddRangeAsync_Should_ThrowException_If_EanCodes_IsNull() {
        // Arrange
        var eanCodes = default(List<EanCode>);

        // Act
        var result = async () => await this._logicProvider.AddRangeAsync(eanCodes);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    #endregion

    #region [ Public Methods - Custom - Count ]
    [Fact]
    public async Task CountAllTitleCodeAsync_Success() {
        // Act
        await this._logicProvider.CountAllTitleCodeAsync();

        // Assert
        this._dataProvider.Verify(x => x.CountAllTitleCodeAsync(), Times.Once);
    }

    [Fact]
    public async Task CountBySearchFilterAsync_Success() {
        // Arrange
        var searchString = this._fixture.Create<string>();

        // Act
        await this._logicProvider.CountBySearchFilterAsync(searchString);

        // Assert
        this._dataProvider.Verify(x => x.CountBySearchFilterAsync(searchString), Times.Once);
    }

    [Fact]
    public async Task CountBySearchFilterAsync_Should_ThrowException_If_SearchString_IsNull() {
        // Arrange
        string searchString = null;

        // Act
        var result = async () => await this._logicProvider.CountBySearchFilterAsync(searchString);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task CountBySearchFilterAsync_Should_ThrowException_If_SearchString_IsEmpty() {
        // Arrange
        string searchString = string.Empty;

        // Act
        var result = async () => await this._logicProvider.CountBySearchFilterAsync(searchString);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    #endregion
}
