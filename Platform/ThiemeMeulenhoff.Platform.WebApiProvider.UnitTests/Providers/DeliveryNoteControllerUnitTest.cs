using Microsoft.Extensions.Logging;

namespace ThiemeMeulenhoff.Platform.WebApi;

public class DeliveryNoteControllerUnitTest : BaseControllerUnitTest<DeliveryNote, IDeliveryNoteLogicProvider, DeliveryNoteController>
{
    #region [ CTor ]
    public DeliveryNoteControllerUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override]
    protected override DeliveryNoteController OnGetController(ILogger<DeliveryNoteController> logger, IDeliveryNoteLogicProvider logic) {
        return new DeliveryNoteController(logger, logic);
    }
    #endregion
}
