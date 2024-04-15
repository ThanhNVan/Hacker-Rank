using Microsoft.Extensions.Logging;

namespace ThiemeMeulenhoff.Platform.WebApi;

public class EducationSectorControllerUnitTest : BaseControllerUnitTest<EducationSector, IEducationSectorLogicProvider, EducationSectorController>
{
    #region [ CTor ]
    public EducationSectorControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override EducationSectorController OnGetController(ILogger<EducationSectorController> logger, IEducationSectorLogicProvider logic) {
        return new EducationSectorController(logger, logic);
    }
    #endregion
}
