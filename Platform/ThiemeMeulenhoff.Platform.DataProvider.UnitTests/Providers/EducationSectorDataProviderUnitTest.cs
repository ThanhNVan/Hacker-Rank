namespace ThiemeMeulenhoff.Platform;

public class EducationSectorDataProviderUnitTest : BaseEntityDataProviderUnitTests<EducationSectorDataProvider<ThiemeMeulenhoffPlatformDbContext>, IEducationSectorValidationProvider, EducationSector>
{
    #region [ CTor ]
    public EducationSectorDataProviderUnitTest() : base(SeedProvider.Current.EducationSectors) {
    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override EducationSectorDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        return new EducationSectorDataProvider<ThiemeMeulenhoffPlatformDbContext>(
           this._logger.Object,
           this._dbContextFactory.Object,
           this._validationProvider.Object);
    }
    #endregion
}
