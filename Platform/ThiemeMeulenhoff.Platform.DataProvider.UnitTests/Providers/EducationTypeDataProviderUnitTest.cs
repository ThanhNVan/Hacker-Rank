namespace ThiemeMeulenhoff.Platform;

public class EducationTypeDataProviderUnitTest : BaseEntityDataProviderUnitTests<EducationTypeDataProvider<ThiemeMeulenhoffPlatformDbContext>, IEducationTypeValidationProvider, EducationType>
{
    #region [ CTor ]
    public EducationTypeDataProviderUnitTest() : base(SeedProvider.Current.EducationTypes) {
    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override EducationTypeDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        return new EducationTypeDataProvider<ThiemeMeulenhoffPlatformDbContext>(
           this._logger.Object,
           this._dbContextFactory.Object,
           this._validationProvider.Object);
    }
    #endregion
}
