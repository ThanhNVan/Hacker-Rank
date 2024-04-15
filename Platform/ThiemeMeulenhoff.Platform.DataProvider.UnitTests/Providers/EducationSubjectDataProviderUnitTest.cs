namespace ThiemeMeulenhoff.Platform;

public class EducationSubjectDataProviderUnitTest : BaseEntityDataProviderUnitTests<EducationSubjectDataProvider<ThiemeMeulenhoffPlatformDbContext>, IEducationSubjectValidationProvider, EducationSubject>
{
    #region [ CTor ]
    public EducationSubjectDataProviderUnitTest() : base(SeedProvider.Current.EducationSubjects) {
    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override EducationSubjectDataProvider<ThiemeMeulenhoffPlatformDbContext> GetDataProvider() {
        return new EducationSubjectDataProvider<ThiemeMeulenhoffPlatformDbContext>(
           this._logger.Object,
           this._dbContextFactory.Object,
           this._validationProvider.Object);
    }
    #endregion
}
