using ThiemeMeulenhoff.Platform.WebApi;

namespace ThiemeMeulenhoff.Platform.IntegrationTests;

public class LicenseSerieItemControllerIntegrationTest : BaseIntegrationTest<LicenseSerieItem, LicenseSerieItemController, ILicenseSerieItemLogicProvider>
{
    #region [ CTor ]
    public LicenseSerieItemControllerIntegrationTest(CustomWebApplicationFactoryClass<Program> appFactory) : base(appFactory, SeedProvider.Current.LicenseSerieItems) {

    }
    #endregion
}
