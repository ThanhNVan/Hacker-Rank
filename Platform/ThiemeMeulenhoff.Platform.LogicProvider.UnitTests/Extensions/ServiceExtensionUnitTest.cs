using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThiemeMeulenhoff.Platform.Data;
using Xunit;
namespace ThiemeMeulenhoff.Platform;

public class ServiceExtensionUnitTest : IDisposable
{
    #region [ Fields ]
    private readonly ServiceCollection _serviceCollection;
    private readonly IConfiguration _configuration;
    private readonly ServiceProvider _serviceProvider;
    #endregion

    #region [ CTor ]
    public ServiceExtensionUnitTest() {
        this._serviceCollection = new ServiceCollection();
        this._serviceCollection.AddLogging();
        var myConfiguration = this.GetConfiguration();
        this._configuration = new ConfigurationBuilder()
                                   .AddInMemoryCollection(myConfiguration)
                                   .Build();

        this._serviceCollection.Add_ThiemeMeulenhoff_Platform_SqlServerDataProviders(this._configuration);
        this._serviceCollection.Add_ThiemeMeulenhoff_Platform_LogicProviders(this._configuration);
        this._serviceCollection.Add_ThiemeMeulenhoff_Platform_ValidationProviders();
        this._serviceProvider = this._serviceCollection.BuildServiceProvider();
    }
    #endregion

    #region [ Public Methods - Logic Provider Unit Test ]
    [Fact]
    public void EntityApplicationKeyLogicProvider_ShouldNotBeNull() {
        // Act  
        var EntityApplicationKeyLogicProvider = this._serviceProvider.GetRequiredService(typeof(IEntityApplicationKeyLogicProvider));

        // Assert 
        Assert.NotNull(EntityApplicationKeyLogicProvider);
        Assert.IsType<EntityApplicationKeyLogicProvider>(EntityApplicationKeyLogicProvider);
    }

    [Fact]
    public void ContactLogicProvider_ShouldNotBeNull() {
        // Act  
        var ContactLogicProvider = this._serviceProvider.GetRequiredService(typeof(IContactLogicProvider));

        // Assert 
        Assert.NotNull(ContactLogicProvider);
        Assert.IsType<ContactLogicProvider>(ContactLogicProvider);
    }

    [Fact]
    public void PersonLogicProvider_ShouldNotBeNull() {
        // Act  
        var PersonLogicProvider = this._serviceProvider.GetRequiredService(typeof(IPersonLogicProvider));

        // Assert 
        Assert.NotNull(PersonLogicProvider);
        Assert.IsType<PersonLogicProvider>(PersonLogicProvider);
    }

    [Fact]
    public void PersonEducationFunctionLogicProvider_ShouldNotBeNull() {
        // Act  
        var PersonEducationFunctionLogicProvider = this._serviceProvider.GetRequiredService(typeof(IPersonEducationFunctionLogicProvider));

        // Assert 
        Assert.NotNull(PersonEducationFunctionLogicProvider);
        Assert.IsType<PersonEducationFunctionLogicProvider>(PersonEducationFunctionLogicProvider);
    }

    [Fact]
    public void PersonEducationSubjectLogicProvider_ShouldNotBeNull() {
        // Act  
        var PersonEducationSubjectLogicProvider = this._serviceProvider.GetRequiredService(typeof(IPersonEducationSubjectLogicProvider));

        // Assert 
        Assert.NotNull(PersonEducationSubjectLogicProvider);
        Assert.IsType<PersonEducationSubjectLogicProvider>(PersonEducationSubjectLogicProvider);
    }

    [Fact]
    public void PersonOrganizationLogicProvider_ShouldNotBeNull() {
        // Act  
        var PersonOrganizationLogicProvider = this._serviceProvider.GetRequiredService(typeof(IPersonOrganizationLogicProvider));

        // Assert 
        Assert.NotNull(PersonOrganizationLogicProvider);
        Assert.IsType<PersonOrganizationLogicProvider>(PersonOrganizationLogicProvider);
    }

    [Fact]
    public void OrganizationLogicProvider_ShouldNotBeNull() {
        // Act  
        var OrganizationLogicProvider = this._serviceProvider.GetRequiredService(typeof(IOrganizationLogicProvider));

        // Assert 
        Assert.NotNull(OrganizationLogicProvider);
        Assert.IsType<OrganizationLogicProvider>(OrganizationLogicProvider);
    }

    [Fact]
    public void SchoolLogicProvider_ShouldNotBeNull() {
        // Act  
        var SchoolLogicProvider = this._serviceProvider.GetRequiredService(typeof(ISchoolLogicProvider));

        // Assert 
        Assert.NotNull(SchoolLogicProvider);
        Assert.IsType<SchoolLogicProvider>(SchoolLogicProvider);
    }

    [Fact]
    public void AddressLogicProvider_ShouldNotBeNull() {
        // Act  
        var AddressLogicProvider = this._serviceProvider.GetRequiredService(typeof(IAddressLogicProvider));

        // Assert 
        Assert.NotNull(AddressLogicProvider);
        Assert.IsType<AddressLogicProvider>(AddressLogicProvider);
    }

    [Fact]
    public void ProductLogicProvider_ShouldNotBeNull() {
        // Act  
        var ProductLogicProvider = this._serviceProvider.GetRequiredService(typeof(IProductLogicProvider));

        // Assert 
        Assert.NotNull(ProductLogicProvider);
        Assert.IsType<ProductLogicProvider>(ProductLogicProvider);
    }

    [Fact]
    public void ProductBundleItemLogicProvider_ShouldNotBeNull() {
        // Act  
        var ProductBundleItemLogicProvider = this._serviceProvider.GetRequiredService(typeof(IProductBundleItemLogicProvider));

        // Assert 
        Assert.NotNull(ProductBundleItemLogicProvider);
        Assert.IsType<ProductBundleItemLogicProvider>(ProductBundleItemLogicProvider);
    }

    [Fact]
    public void PriceInfoLogicProvider_ShouldNotBeNull() {
        // Act  
        var PriceInfoLogicProvider = this._serviceProvider.GetRequiredService(typeof(IPriceInfoLogicProvider));

        // Assert 
        Assert.NotNull(PriceInfoLogicProvider);
        Assert.IsType<PriceInfoLogicProvider>(PriceInfoLogicProvider);
    }

    [Fact]
    public void LicenceInfoLogicProvider_ShouldNotBeNull() {
        // Act  
        var LicenceInfoLogicProvider = this._serviceProvider.GetRequiredService(typeof(ILicenceInfoLogicProvider));

        // Assert 
        Assert.NotNull(LicenceInfoLogicProvider);
        Assert.IsType<LicenceInfoLogicProvider>(LicenceInfoLogicProvider);
    }

    [Fact]
    public void LicenseSerieLogicProvider_ShouldNotBeNull() {
        // Act  
        var LicenseSerieLogicProvider = this._serviceProvider.GetRequiredService(typeof(ILicenseSerieLogicProvider));

        // Assert 
        Assert.NotNull(LicenseSerieLogicProvider);
        Assert.IsType<LicenseSerieLogicProvider>(LicenseSerieLogicProvider);
    }

    [Fact]
    public void LicenseSerieItemLogicProvider_ShouldNotBeNull() {
        // Act  
        var LicenseSerieItemLogicProvider = this._serviceProvider.GetRequiredService(typeof(ILicenseSerieItemLogicProvider));

        // Assert 
        Assert.NotNull(LicenseSerieItemLogicProvider);
        Assert.IsType<LicenseSerieItemLogicProvider>(LicenseSerieItemLogicProvider);
    }

    [Fact]
    public void SubjectLogicProvider_ShouldNotBeNull() {
        // Act  
        var SubjectLogicProvider = this._serviceProvider.GetRequiredService(typeof(ISubjectLogicProvider));

        // Assert 
        Assert.NotNull(SubjectLogicProvider);
        Assert.IsType<SubjectLogicProvider>(SubjectLogicProvider);
    }

    [Fact]
    public void OrderLogicProvider_ShouldNotBeNull() {
        // Act  
        var OrderLogicProvider = this._serviceProvider.GetRequiredService(typeof(IOrderLogicProvider));

        // Assert 
        Assert.NotNull(OrderLogicProvider);
        Assert.IsType<OrderLogicProvider>(OrderLogicProvider);
    }

    [Fact]
    public void OrderItemLogicProvider_ShouldNotBeNull() {
        // Act  
        var OrderItemLogicProvider = this._serviceProvider.GetRequiredService(typeof(IOrderItemLogicProvider));

        // Assert 
        Assert.NotNull(OrderItemLogicProvider);
        Assert.IsType<OrderItemLogicProvider>(OrderItemLogicProvider);
    }

    [Fact]
    public void InvoiceLogicProvider_ShouldNotBeNull() {
        // Act  
        var InvoiceLogicProvider = this._serviceProvider.GetRequiredService(typeof(IInvoiceLogicProvider));

        // Assert 
        Assert.NotNull(InvoiceLogicProvider);
        Assert.IsType<InvoiceLogicProvider>(InvoiceLogicProvider);
    }

    [Fact]
    public void InvoiceItemLogicProvider_ShouldNotBeNull() {
        // Act  
        var InvoiceItemLogicProvider = this._serviceProvider.GetRequiredService(typeof(IInvoiceItemLogicProvider));

        // Assert 
        Assert.NotNull(InvoiceItemLogicProvider);
        Assert.IsType<InvoiceItemLogicProvider>(InvoiceItemLogicProvider);
    }

    [Fact]
    public void StockMutationLogicProvider_ShouldNotBeNull() {
        // Act  
        var StockMutationLogicProvider = this._serviceProvider.GetRequiredService(typeof(IStockMutationLogicProvider));

        // Assert 
        Assert.NotNull(StockMutationLogicProvider);
        Assert.IsType<StockMutationLogicProvider>(StockMutationLogicProvider);
    }

    [Fact]
    public void ProjectLogicProvider_ShouldNotBeNull() {
        // Act  
        var ProjectLogicProvider = this._serviceProvider.GetRequiredService(typeof(IProjectLogicProvider));

        // Assert 
        Assert.NotNull(ProjectLogicProvider);
        Assert.IsType<ProjectLogicProvider>(ProjectLogicProvider);
    }

    [Fact]
    public void ProjectTeamMemberLogicProvider_ShouldNotBeNull() {
        // Act  
        var ProjectTeamMemberLogicProvider = this._serviceProvider.GetRequiredService(typeof(IProjectTeamMemberLogicProvider));

        // Assert 
        Assert.NotNull(ProjectTeamMemberLogicProvider);
        Assert.IsType<ProjectTeamMemberLogicProvider>(ProjectTeamMemberLogicProvider);
    }

    [Fact]
    public void PrintOrderLogicProvider_ShouldNotBeNull() {
        // Act  
        var PrintOrderLogicProvider = this._serviceProvider.GetRequiredService(typeof(IPrintOrderLogicProvider));

        // Assert 
        Assert.NotNull(PrintOrderLogicProvider);
        Assert.IsType<PrintOrderLogicProvider>(PrintOrderLogicProvider);
    }

    [Fact]
    public void PrintInfoLogicProvider_ShouldNotBeNull() {
        // Act  
        var PrintInfoLogicProvider = this._serviceProvider.GetRequiredService(typeof(IPrintInfoLogicProvider));

        // Assert 
        Assert.NotNull(PrintInfoLogicProvider);
        Assert.IsType<PrintInfoLogicProvider>(PrintInfoLogicProvider);
    }

    [Fact]
    public void PrintInfoTemplateLogicProvider_ShouldNotBeNull() {
        // Act  
        var PrintInfoTemplateLogicProvider = this._serviceProvider.GetRequiredService(typeof(IPrintInfoTemplateLogicProvider));

        // Assert 
        Assert.NotNull(PrintInfoTemplateLogicProvider);
        Assert.IsType<PrintInfoTemplateLogicProvider>(PrintInfoTemplateLogicProvider);
    }

    [Fact]
    public void EanCodeLogicProvider_ShouldNotBeNull() {
        // Act  
        var EanCodeLogicProvider = this._serviceProvider.GetRequiredService(typeof(IEanCodeLogicProvider));

        // Assert 
        Assert.NotNull(EanCodeLogicProvider);
        Assert.IsType<EanCodeLogicProvider>(EanCodeLogicProvider);
    }

    [Fact]
    public void EducationFunctionLogicProvider_ShouldNotBeNull() {
        // Act  
        var EducationFunctionLogicProvider = this._serviceProvider.GetRequiredService(typeof(IEducationFunctionLogicProvider));

        // Assert 
        Assert.NotNull(EducationFunctionLogicProvider);
        Assert.IsType<EducationFunctionLogicProvider>(EducationFunctionLogicProvider);
    }

    [Fact]
    public void EducationSectorLogicProvider_ShouldNotBeNull() {
        // Act  
        var EducationSectorLogicProvider = this._serviceProvider.GetRequiredService(typeof(IEducationSectorLogicProvider));

        // Assert 
        Assert.NotNull(EducationSectorLogicProvider);
        Assert.IsType<EducationSectorLogicProvider>(EducationSectorLogicProvider);
    }

    [Fact]
    public void EducationSubjectLogicProvider_ShouldNotBeNull() {
        // Act  
        var EducationSubjectLogicProvider = this._serviceProvider.GetRequiredService(typeof(IEducationSubjectLogicProvider));

        // Assert 
        Assert.NotNull(EducationSubjectLogicProvider);
        Assert.IsType<EducationSubjectLogicProvider>(EducationSubjectLogicProvider);
    }

    [Fact]
    public void EducationTypeLogicProvider_ShouldNotBeNull() {
        // Act  
        var EducationTypeLogicProvider = this._serviceProvider.GetRequiredService(typeof(IEducationTypeLogicProvider));

        // Assert 
        Assert.NotNull(EducationTypeLogicProvider);
        Assert.IsType<EducationTypeLogicProvider>(EducationTypeLogicProvider);
    }

    [Fact]
    public void DeliveryNoteLogicProvider_ShouldNotBeNull() {
        // Act  
        var DeliveryNoteLogicProvider = this._serviceProvider.GetRequiredService(typeof(IDeliveryNoteLogicProvider));

        // Assert 
        Assert.NotNull(DeliveryNoteLogicProvider);
        Assert.IsType<DeliveryNoteLogicProvider>(DeliveryNoteLogicProvider);
    }

    [Fact]
    public void DeliveryNoteItemLogicProvider_ShouldNotBeNull() {
        // Act  
        var DeliveryNoteItemLogicProvider = this._serviceProvider.GetRequiredService(typeof(IDeliveryNoteItemLogicProvider));

        // Assert 
        Assert.NotNull(DeliveryNoteItemLogicProvider);
        Assert.IsType<DeliveryNoteItemLogicProvider>(DeliveryNoteItemLogicProvider);
    }

    [Fact]
    public void DataContext_ShouldNotBeNull() {
        // Act  
        var DataContext = this._serviceProvider.GetRequiredService(typeof(LogicContext));

        // Assert 
        Assert.NotNull(DataContext);
        Assert.IsType<LogicContext>(DataContext);
    }
    #endregion

    #region [ Private Methods ]
    private Dictionary<string, string> GetConfiguration() {
        var myConfiguration = new Dictionary<string, string>
           {
                {"PlatformDatalake", ""},
                {"ConnectionStrings:ThiemePlatformData", "ConnectionString"},
                {"Platform:BusinessRules:Settings:LicenseProductGroups", "LicenseProductGroups"},
                {"Platform:BusinessRules:Settings:BookProductGroups", "BookProductGroups"},
                {"Platform:BusinessRules:Settings:LicenseDeliveryTypeEmailExcel", "LicenseDeliveryTypeEmailExcel"},

            };

        return myConfiguration;
    }
    #endregion

    #region [ Methods - Dispose ]
    public void Dispose() {
        this._serviceCollection.Clear();
        this._serviceProvider.Dispose();
    }
    #endregion
}
