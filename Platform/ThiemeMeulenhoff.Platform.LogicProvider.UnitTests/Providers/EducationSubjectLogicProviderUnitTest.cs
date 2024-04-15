using Microsoft.Extensions.Logging;

namespace ThiemeMeulenhoff.Platform;

public class EducationSubjectLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<EducationSubject, IEducationSubjectDataProvider, EducationSubjectLogicProvider>
{
    #region [ CTor ]
    public EducationSubjectLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override EducationSubjectLogicProvider OnCreateLogicProvider(IEducationSubjectDataProvider dataProvider, ILogger<EducationSubjectLogicProvider> logger) {
        return new EducationSubjectLogicProvider(logger, dataProvider);
    }
    #endregion
}

