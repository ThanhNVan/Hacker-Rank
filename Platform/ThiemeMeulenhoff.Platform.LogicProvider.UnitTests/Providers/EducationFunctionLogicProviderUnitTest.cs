using Microsoft.Extensions.Logging;

namespace ThiemeMeulenhoff.Platform;

public class EducationFunctionLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<EducationFunction, IEducationFunctionDataProvider, EducationFunctionLogicProvider>
{
    #region [ CTor ]
    public EducationFunctionLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override EducationFunctionLogicProvider OnCreateLogicProvider(IEducationFunctionDataProvider dataProvider, ILogger<EducationFunctionLogicProvider> logger) {
        return new EducationFunctionLogicProvider(logger, dataProvider);
    }
    #endregion
}
