using ThiemeMeulenhoff.Platform.WebApi;

namespace ThiemeMeulenhoff.Platform.IntegrationTests;

public class LicenseSerieControllerIntegrationTest : BaseIntegrationTest<LicenseSerie, LicenseSerieController, ILicenseSerieLogicProvider>
{
    #region [ CTor ]
    public LicenseSerieControllerIntegrationTest(CustomWebApplicationFactoryClass<Program> appFactory) : base(appFactory, SeedProvider.Current.LicenseSeries) {

    }
    #endregion
}
