using ThiemeMeulenhoff.Platform.WebApi;

namespace ThiemeMeulenhoff.Platform.IntegrationTests;

public class LicenceInfoControllerIntegrationTest : BaseIntegrationTest<LicenceInfo, LicenceInfoController, ILicenceInfoLogicProvider>
{
    #region [ CTor ]
    public LicenceInfoControllerIntegrationTest(CustomWebApplicationFactoryClass<Program> appFactory) : base(appFactory, SeedProvider.Current.LicenceInfo) {

    }
    #endregion
}
