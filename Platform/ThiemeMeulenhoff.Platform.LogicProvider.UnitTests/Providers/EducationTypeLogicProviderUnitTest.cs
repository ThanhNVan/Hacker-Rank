using Microsoft.Extensions.Logging;

namespace ThiemeMeulenhoff.Platform;

public class EducationTypeLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<EducationType, IEducationTypeDataProvider, EducationTypeLogicProvider>
{
    #region [ CTor ]
    public EducationTypeLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override EducationTypeLogicProvider OnCreateLogicProvider(IEducationTypeDataProvider dataProvider, ILogger<EducationTypeLogicProvider> logger) {
        return new EducationTypeLogicProvider(logger, dataProvider);
    }
    #endregion
}

