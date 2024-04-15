using System.Net;
using Newtonsoft.Json;
using RCode;
using ThiemeMeulenhoff.Platform.WebApi;
using Xunit;

namespace ThiemeMeulenhoff.Platform.IntegrationTests;

public class EanCodeControllerIntegrationTest : BaseIntegrationTest<EanCode, EanCodeController, IEanCodeLogicProvider>
{
    #region [ CTor ]
    public EanCodeControllerIntegrationTest(CustomWebApplicationFactoryClass<Program> appFactory) : base(appFactory, SeedProvider.Current.EanCodes) {

    }
    #endregion

    #region  [ Public Methods - Custom - Single ]
    [Fact]
    public async Task CreateAndAddAsync_Should_ReturnStatusCode200Ok_If_Item_Is_Found() {
        // Arrange
        var random = new Random();
        var entity = SeedProvider.Current.EanCodes.FirstOrDefault();

        var customEntity = new EanCodeCreateAndUpdateRequest();
        customEntity.TitleCode = entity.TitleCode;
        customEntity.BaseCode = entity.BaseCode;
        customEntity.CheckCode = random.Next(0, 9).ToString();
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.CreateAndAddAsync));
        var payload = this.GetJsonPayload(customEntity);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsync(url, payload);
        var dbEntity = await this._logicProvider.GetAsync(entity.Id);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task CreateAndAddAsync_Should_ReturnStatusCode401BadRequest_If_TitleCode_IsEmpty() {
        // Arrange
        var random = new Random();
        var entity = SeedProvider.Current.EanCodes.FirstOrDefault();

        var customEntity = new EanCodeCreateAndUpdateRequest();
        customEntity.TitleCode = string.Empty;
        customEntity.BaseCode = entity.BaseCode;
        customEntity.CheckCode = random.Next(0, 9).ToString();
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.CreateAndAddAsync));
        var payload = this.GetJsonPayload(customEntity);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsync(url, payload);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CreateAndAddAsync_Should_ReturnStatusCode401BadRequest_If_BaseCode_IsEmpty() {
        // Arrange
        var random = new Random();
        var entity = SeedProvider.Current.EanCodes.FirstOrDefault();

        var customEntity = new EanCodeCreateAndUpdateRequest();
        customEntity.TitleCode = entity.TitleCode;
        customEntity.BaseCode = string.Empty;
        customEntity.CheckCode = random.Next(0, 9).ToString();
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.CreateAndAddAsync));
        var payload = this.GetJsonPayload(customEntity);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsync(url, payload);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CreateAndAddAsync_Should_ReturnStatusCode401BadRequest_If_BaseCode_IsNotValid() {
        // Arrange
        var random = new Random();
        var entity = SeedProvider.Current.EanCodes.FirstOrDefault();

        var customEntity = new EanCodeCreateAndUpdateRequest();
        customEntity.TitleCode = entity.TitleCode;
        customEntity.BaseCode = IdFactory.CreateId();
        customEntity.CheckCode = random.Next(0, 9).ToString();
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.CreateAndAddAsync));
        var payload = this.GetJsonPayload(customEntity);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsync(url, payload);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CreateAndAddAsync_Should_ReturnStatusCode401BadRequest_If_CheckCode_IsEmpty() {
        // Arrange
        var entity = SeedProvider.Current.EanCodes.FirstOrDefault();

        var customEntity = new EanCodeCreateAndUpdateRequest();
        customEntity.TitleCode = entity.TitleCode;
        customEntity.BaseCode = entity.BaseCode;
        customEntity.CheckCode = string.Empty;
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.CreateAndAddAsync));
        var payload = this.GetJsonPayload(customEntity);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsync(url, payload);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CreateAndAddAsync_Should_ReturnStatusCode401BadRequest_If_PayLoad_IsNull() {
        // Arrange
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.CreateAndAddAsync));
        var payload = default(EanCodeCreateAndUpdateRequest);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsJsonAsync(url, payload);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task GenerateTitleCodeAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var basecode = "ABCABC3";
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.GenerateTitleCodeAsync));

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsJsonAsync(url, basecode);
        var result = JsonConvert.DeserializeObject<EanCode>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(result.BaseCode, basecode);
    }

    [Fact]
    public async Task GenerateTitleCodeAsync_Should_ReturnStatusCode401BadRequest_If_BaseCode_IsEmpty() {
        // Arrange
        var basecode = string.Empty;
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.GenerateTitleCodeAsync));

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsJsonAsync(url, basecode);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task GenerateTitleCodeAsync_Should_ReturnStatusCode401BadRequest_If_BaseCode_IsNotValid() {
        // Arrange
        var basecode = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.GenerateTitleCodeAsync));

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsJsonAsync(url, basecode);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task GetByCodeAsync_Should_ReturnStatusCode200Ok_If_Item_Is_Found() {
        // Arrange
        var entity = SeedProvider.Current.EanCodes.FirstOrDefault();

        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.GetByCodeAsync), entity.FullCode);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var result = JsonConvert.DeserializeObject<EanCode>(await response.Content.ReadAsStringAsync());
        var dbEntity = await this._logicProvider.GetAsync(entity.Id);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(result.FullCode, dbEntity.FullCode);
    }

    [Fact]
    public async Task GetByCodeAsync_Should_ReturnStatusCode404NotFound_If_Option_Is_NotFound() {
        //Arange
        var entity = EanCodeFactory.Create();
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.GetByCodeAsync), entity.FullCode);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

    }

    [Fact]
    public async Task CreateAndAddTitleCodeAsync_Should_ReturnStatusCode200Ok_If_Success() {
        var basecode = "ABCABC3";
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.CreateAndAddTitleCodeAsync));
        var payload = default(EanCodeCreateAndUpdateRequest);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsJsonAsync(url, basecode);
        var result = JsonConvert.DeserializeObject<EanCode>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(result.BaseCode, basecode);
    }

    [Fact]
    public async Task CreateAndAddTitleCodeAsync_Should_ReturnStatusCode401BadRequest_If_BaseCode_IsEmpty() {

        // Arrange
        var basecode = string.Empty;
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.CreateAndAddTitleCodeAsync));

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsJsonAsync(url, basecode);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CreateAndAddTitleCodeAsync_Should_ReturnStatusCode401BadRequest_If_BaseCode_IsNotValid() {
        // Arrange
        var basecode = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.CreateAndAddTitleCodeAsync));

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsJsonAsync(url, basecode);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    #endregion

    #region [ Public Methods - Custom - List ]
    [Fact]
    public async Task GetAllBaseCodeAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.GetAllBaseCodeAsync));
        var expected = await this._logicProvider.GetAllBaseCodeAsync();

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<List<EanCode>>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected.Count, actual.Count);
    }

    [Fact]
    public async Task GetByBaseCodeAsync_Should_ReturnStatusCode200Ok_If_Success() {
        // Arrange
        var basecode = this.Entities.FirstOrDefault().BaseCode;
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.GetByBaseCodeAsync)) + $"/{basecode}";
        var expected = await this._logicProvider.GetByBaseCodeAsync(basecode);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<List<EanCode>>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected.Count, actual.Count);
    }

    [Fact]
    public async Task GetByBaseCodeAsync_Should_ReturnStatusCode401BadRequest_If_BaseCode_IsNotValid() {
        // Arrange
        var basecode = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.GetByBaseCodeAsync)) + $"/{basecode}";

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task GetByBaseCodeAsync_Should_ReturnStatusCode404NotFound_If_IsNotFound() {
        // Arrange
        var basecode = IdFactory.CreateId().Substring(0, 7);
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.GetByBaseCodeAsync)) + $"/{basecode}";

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetUnregisteredCodesAsync_Should_ReturnStatusCode200Ok_If_IsSuccess() {
        // Arrange
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.GetUnregisteredCodesAsync));
        var expected = await this._logicProvider.GetUnregisteredCodesAsync();

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<List<EanCode>>(await response.Content.ReadAsStringAsync());


        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected.Count, actual.Count);
    }

    [Fact]
    public async Task GetUnregisteredCodesAsync_BaseCode_Should_ReturnStatusCode200Ok_If_IsSuccess() {
        // Arrange
        var basecode = this.Entities.FirstOrDefault().BaseCode;
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.GetUnregisteredCodesAsync)) + $"/{basecode}";
        var expected = await this._logicProvider.GetUnregisteredCodesAsync(basecode);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<List<EanCode>>(await response.Content.ReadAsStringAsync());


        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected.Count, actual.Count);
    }

    [Fact]
    public async Task GetAllTitleCodeAsync_BaseCode_Should_ReturnStatusCode200Ok_If_IsSuccess() {
        // Arrange
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.GetAllTitleCodeAsync));
        var expected = await this._logicProvider.GetAllTitleCodeAsync();

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<List<EanCode>>(await response.Content.ReadAsStringAsync());


        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected.Count, actual.Count);
    }

    [Fact]
    public async Task GetAllTitleCodeAsync_TakeSkip_BaseCode_Should_ReturnStatusCode200Ok_If_IsSuccess() {
        // Arrange
        var take = 2;
        var skip = 3;
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.GetAllTitleCodeAsync)) + $"/take={take}&&skip={skip}";
        var expected = await this._logicProvider.GetAllTitleCodeAsync(take, skip);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<List<EanCode>>(await response.Content.ReadAsStringAsync());


        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected.Count, actual.Count);
    }

    [Fact]
    public async Task GetAllTitleCodeAsync_TakeSkip_BaseCode_ReturnStatusCode401BadRequest_If_Take_IsNotValid() {
        // Arrange
        var take = 0;
        var skip = 3;
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.GetAllTitleCodeAsync)) + $"/take={take}&&skip={skip}";

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task GenerateTitleCodesAsync_Should_ReturnStatusCode200Ok_If_IsSuccess() {
        // Arrange
        var random = new Random();
        var basecode = this.Entities.FirstOrDefault().BaseCode;
        var numberOfRecord = random.Next(1, 9);
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.GenerateTitleCodesAsync), basecode, numberOfRecord.ToString()); //+ $"/baseCode={basecode}&&value={numberOfRecord}";

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<List<EanCode>>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(numberOfRecord, actual.Count);
        Assert.False(actual.Select(x => x.BaseCode).Any(x => x != basecode));
    }

    [Fact]
    public async Task GenerateTitleCodesAsync_Should_ReturnStatusCode401BadRequest_If_BaseCode_IsNotValid() {
        // Arrange
        var random = new Random();
        var basecode = "A";
        var numberOfRecord = random.Next(1, 9);
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.GenerateTitleCodesAsync), basecode, numberOfRecord.ToString());

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task GenerateTitleCodesAsync_Should_ReturnStatusCode401BadRequest_If_Value_IsNotValid() {
        // Arrange
        var basecode = this.Entities.FirstOrDefault().BaseCode;
        var numberOfRecord = 0;
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.GenerateTitleCodesAsync), basecode, numberOfRecord.ToString());

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task GetBySearchFilterAsync_Should_ReturnStatusCode200Ok_If_IsSuccess() {
        // Arrange
        var random = new Random();
        var searchFilter = this.Entities.FirstOrDefault().BaseCode.Substring(0, random.Next(1, 4));
        var take = random.Next(1, 5);
        var skip = random.Next(0, 9);
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.GetBySearchFilterAsync), searchFilter, take.ToString(), skip.ToString());
        var expected = await this._logicProvider.GetBySearchFilterAsync(searchFilter, take, skip);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<List<EanCode>>(await response.Content.ReadAsStringAsync());

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected.Count, actual.Count);
    }

    [Fact]
    public async Task GetBySearchFilterAsync_Should_ReturnStatusCode404NotFound_If_NotFound() {
        // Arrange
        var random = new Random();
        var searchFilter = this.Entities.FirstOrDefault().BaseCode + this.Entities.FirstOrDefault().BaseCode;
        var take = random.Next(1, 5);
        var skip = random.Next(0, 9);
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.GetBySearchFilterAsync), searchFilter, take.ToString(), skip.ToString());

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    #endregion

    #region [ Public Methods - Custom - Add ]
    [Fact]
    public async Task AddNewBaseCodeAsync_Should_ReturnStatusCode200Ok_If_IsSuccess() {
        // Arrange
        var random = new Random();
        var basecode = "AABB" + random.Next(100, 999).ToString("000");
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.AddNewBaseCodeAsync));

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsJsonAsync(url, basecode);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task AddNewBaseCodeAsync_Should_ReturnStatusCode401BadRequest_If_Value_IsEmpty() {
        // Arrange
        var basecode = string.Empty;
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.AddNewBaseCodeAsync));

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsJsonAsync(url, basecode);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task AddNewBaseCodeAsync_Should_ReturnStatusCode401BadRequest_If_Value_IsNotValid() {
        // Arrange
        var basecode = IdFactory.CreateId();
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.AddNewBaseCodeAsync));

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsJsonAsync(url, basecode);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task AddRangeAsync_Should_ReturnStatusCode200Ok_If_IsSuccess() {
        // Arrange
        var random = new Random();
        var payload = new List<EanCode>();
        var numberOfRecord = random.Next(1, this.Entities.Count - 1);
        for (int i = 0; i < numberOfRecord; i++) {
            var item = this.Entities[i];
            item.Id = IdFactory.CreateId();
            payload.Add(item);
        }
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.AddRangeAsync));

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsJsonAsync(url, payload);
        var expected = await this._logicProvider.CountAllAsync();
        var actual = this.Entities.Count + numberOfRecord;

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task AddRangeAsync_ReturnStatusCode500InternalServerError_If_Payload_IsEmpty() {
        // Arrange
        var payload = new List<EanCode>();

        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.AddRangeAsync));

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsJsonAsync(url, payload);

        // Assert
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
    }

    [Fact]
    public async Task AddRangeAsync_ReturnStatusCode401BadRequest_If_Payload_IsNull() {
        // Arrange
        var payload = default(List<EanCode>);

        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.AddRangeAsync));

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().PostAsJsonAsync(url, payload);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    #endregion

    #region [ Public Methods - Custom - Count ]
    [Fact]
    public async Task CountAllTitleCodeAsync_Should_ReturnStatusCode200Ok_If_IsSuccess() {
        // Arrange
        var expected = this.Entities.Where(x => x.CodeType == EanCodeType.Title).Count();
        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.CountAllTitleCodeAsync));

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task CountBySearchFilterAsync_Should_ReturnStatusCode200Ok_If_IsSuccess() {
        // Arrange
        var random = new Random();
        var searchFilter = this.Entities.FirstOrDefault().BaseCode.Substring(0, random.Next(1, 4));

        var expected = await this._logicProvider.CountBySearchFilterAsync(searchFilter);

        var url = this.GetUrlEndpoint(typeof(EanCodeController), nameof(this._controller.CountBySearchFilterAsync), searchFilter);

        // Act
        var response = await this.GetThiemeMeulenhoff_HttpClient().GetAsync(url);
        var actual = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected, actual);
    }
    #endregion
}
