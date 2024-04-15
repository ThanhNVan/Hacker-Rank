namespace ThiemeMeulenhoff.Platform;

public class DeliveryNoteDataProviderUnitTest : BaseEntityDataProviderUnitTests<DeliveryNoteDataProvider<ThiemeMeulenhoffPlatformDbContext>, IDeliveryNoteValidationProvider, DeliveryNote>
{
    #region [ CTor ]
    public DeliveryNoteDataProviderUnitTest() : base(SeedProvider.Current.DeliveryNotes) {
    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override DeliveryNoteDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        return new DeliveryNoteDataProvider<ThiemeMeulenhoffPlatformDbContext>(
           this._logger.Object,
           this._dbContextFactory.Object,
           this._validationProvider.Object);
    }
    #endregion
}
