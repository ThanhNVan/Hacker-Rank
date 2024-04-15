using Microsoft.Extensions.Logging;

namespace ThiemeMeulenhoff.Platform;

public class DeliveryNoteLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<DeliveryNote, IDeliveryNoteDataProvider, DeliveryNoteLogicProvider>
{
    #region [ CTor ]
    public DeliveryNoteLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override DeliveryNoteLogicProvider OnCreateLogicProvider(IDeliveryNoteDataProvider dataProvider, ILogger<DeliveryNoteLogicProvider> logger) {
        return new DeliveryNoteLogicProvider(logger, dataProvider);
    }
    #endregion
}
