namespace ThiemeMeulenhoff.Platform;

public class EducationFunctionDataProviderUnitTest : BaseEntityDataProviderUnitTests<EducationFunctionDataProvider<ThiemeMeulenhoffPlatformDbContext>, IEducationFunctionValidationProvider, EducationFunction>
{
    #region [ CTor ]
    public EducationFunctionDataProviderUnitTest() : base(SeedProvider.Current.EducationFunctions) {
    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override EducationFunctionDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        return new EducationFunctionDataProvider<ThiemeMeulenhoffPlatformDbContext>(
           this._logger.Object,
           this._dbContextFactory.Object,
           this._validationProvider.Object);
    }
    #endregion
}
