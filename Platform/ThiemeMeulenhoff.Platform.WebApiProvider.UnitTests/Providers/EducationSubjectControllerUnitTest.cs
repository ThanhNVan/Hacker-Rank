using Microsoft.Extensions.Logging;

namespace ThiemeMeulenhoff.Platform.WebApi;

public class EducationSubjectControllerUnitTest : BaseControllerUnitTest<EducationSubject, IEducationSubjectLogicProvider, EducationSubjectController>
{
    #region [ CTor ]
    public EducationSubjectControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override EducationSubjectController OnGetController(ILogger<EducationSubjectController> logger, IEducationSubjectLogicProvider logic) {
        return new EducationSubjectController(logger, logic);
    }
    #endregion
}
