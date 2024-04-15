using Microsoft.Extensions.Logging;

namespace ThiemeMeulenhoff.Platform.WebApi;

public class EducationTypeControllerUnitTest : BaseControllerUnitTest<EducationType, IEducationTypeLogicProvider, EducationTypeController>
{
    #region [ CTor ]
    public EducationTypeControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override EducationTypeController OnGetController(ILogger<EducationTypeController> logger, IEducationTypeLogicProvider logic) {
        return new EducationTypeController(logger, logic);
    }
    #endregion
}
