using Microsoft.Extensions.Logging;

namespace ThiemeMeulenhoff.Platform.WebApi;

public class EducationFunctionControllerUnitTest : BaseControllerUnitTest<EducationFunction, IEducationFunctionLogicProvider, EducationFunctionController>
{
    #region [ CTor ]
    public EducationFunctionControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override EducationFunctionController OnGetController(ILogger<EducationFunctionController> logger, IEducationFunctionLogicProvider logic) {
        return new EducationFunctionController(logger, logic);
    }
    #endregion
}
