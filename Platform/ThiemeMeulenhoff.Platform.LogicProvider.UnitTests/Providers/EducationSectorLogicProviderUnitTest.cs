using Microsoft.Extensions.Logging;

namespace ThiemeMeulenhoff.Platform;

public class EducationSectorLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<EducationSector, IEducationSectorDataProvider, EducationSectorLogicProvider>
{
    #region [ CTor ]
    public EducationSectorLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override EducationSectorLogicProvider OnCreateLogicProvider(IEducationSectorDataProvider dataProvider, ILogger<EducationSectorLogicProvider> logger) {
        return new EducationSectorLogicProvider(logger, dataProvider);
    }
    #endregion
}

