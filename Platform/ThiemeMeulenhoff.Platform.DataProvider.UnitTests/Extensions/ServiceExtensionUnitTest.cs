using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using ThiemeMeulenhoff.Platform.Data;
using RCode.Data;

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

    #region [ Public Methods - Data Provider Tests ]
    [Fact]
    public void EntityApplicationKeyDataProvider_ShouldNotBeNull() {
        // Act  
        var EntityApplicationKeyDataProvider = this._serviceProvider.GetRequiredService(typeof(IEntityApplicationKeyDataProvider));

        // Assert 
        Assert.NotNull(EntityApplicationKeyDataProvider);
        Assert.IsType<EntityApplicationKeyDataProvider<ThiemeMeulenhoffPlatformDbContext>>(EntityApplicationKeyDataProvider);
    }

    [Fact]
    public void ContactDataProvider_ShouldNotBeNull() {
        // Act  
        var ContactDataProvider = this._serviceProvider.GetRequiredService(typeof(IContactDataProvider));

        // Assert 
        Assert.NotNull(ContactDataProvider);
        Assert.IsType<ContactDataProvider<ThiemeMeulenhoffPlatformDbContext>>(ContactDataProvider);
    }

    [Fact]
    public void PersonDataProvider_ShouldNotBeNull() {
        // Act  
        var PersonDataProvider = this._serviceProvider.GetRequiredService(typeof(IPersonDataProvider));

        // Assert 
        Assert.NotNull(PersonDataProvider);
        Assert.IsType<PersonDataProvider<ThiemeMeulenhoffPlatformDbContext>>(PersonDataProvider);
    }

    [Fact]
    public void PersonEducationFunctionDataProvider_ShouldNotBeNull() {
        // Act  
        var PersonEducationFunctionDataProvider = this._serviceProvider.GetRequiredService(typeof(IPersonEducationFunctionDataProvider));

        // Assert 
        Assert.NotNull(PersonEducationFunctionDataProvider);
        Assert.IsType<PersonEducationFunctionDataProvider<ThiemeMeulenhoffPlatformDbContext>>(PersonEducationFunctionDataProvider);
    }

    [Fact]
    public void PersonEducationSubjectDataProvider_ShouldNotBeNull() {
        // Act  
        var PersonEducationSubjectDataProvider = this._serviceProvider.GetRequiredService(typeof(IPersonEducationSubjectDataProvider));

        // Assert 
        Assert.NotNull(PersonEducationSubjectDataProvider);
        Assert.IsType<PersonEducationSubjectDataProvider<ThiemeMeulenhoffPlatformDbContext>>(PersonEducationSubjectDataProvider);
    }

    [Fact]
    public void PersonOrganizationDataProvider_ShouldNotBeNull() {
        // Act  
        var PersonOrganizationDataProvider = this._serviceProvider.GetRequiredService(typeof(IPersonOrganizationDataProvider));

        // Assert 
        Assert.NotNull(PersonOrganizationDataProvider);
        Assert.IsType<PersonOrganizationDataProvider<ThiemeMeulenhoffPlatformDbContext>>(PersonOrganizationDataProvider);
    }

    [Fact]
    public void OrganizationDataProvider_ShouldNotBeNull() {
        // Act  
        var OrganizationDataProvider = this._serviceProvider.GetRequiredService(typeof(IOrganizationDataProvider));

        // Assert 
        Assert.NotNull(OrganizationDataProvider);
        Assert.IsType<OrganizationDataProvider<ThiemeMeulenhoffPlatformDbContext>>(OrganizationDataProvider);
    }

    [Fact]
    public void SchoolDataProvider_ShouldNotBeNull() {
        // Act  
        var SchoolDataProvider = this._serviceProvider.GetRequiredService(typeof(ISchoolDataProvider));

        // Assert 
        Assert.NotNull(SchoolDataProvider);
        Assert.IsType<SchoolDataProvider<ThiemeMeulenhoffPlatformDbContext>>(SchoolDataProvider);
    }

    [Fact]
    public void AddressDataProvider_ShouldNotBeNull() {
        // Act  
        var AddressDataProvider = this._serviceProvider.GetRequiredService(typeof(IAddressDataProvider));

        // Assert 
        Assert.NotNull(AddressDataProvider);
        Assert.IsType<AddressDataProvider<ThiemeMeulenhoffPlatformDbContext>>(AddressDataProvider);
    }

    [Fact]
    public void ProductDataProvider_ShouldNotBeNull() {
        // Act  
        var ProductDataProvider = this._serviceProvider.GetRequiredService(typeof(IProductDataProvider));

        // Assert 
        Assert.NotNull(ProductDataProvider);
        Assert.IsType<ProductDataProvider<ThiemeMeulenhoffPlatformDbContext>>(ProductDataProvider);
    }

    [Fact]
    public void ProductBundleItemDataProvider_ShouldNotBeNull() {
        // Act  
        var ProductBundleItemDataProvider = this._serviceProvider.GetRequiredService(typeof(IProductBundleItemDataProvider));

        // Assert 
        Assert.NotNull(ProductBundleItemDataProvider);
        Assert.IsType<ProductBundleItemDataProvider<ThiemeMeulenhoffPlatformDbContext>>(ProductBundleItemDataProvider);
    }

    [Fact]
    public void PriceInfoDataProvider_ShouldNotBeNull() {
        // Act  
        var PriceInfoDataProvider = this._serviceProvider.GetRequiredService(typeof(IPriceInfoDataProvider));

        // Assert 
        Assert.NotNull(PriceInfoDataProvider);
        Assert.IsType<PriceInfoDataProvider<ThiemeMeulenhoffPlatformDbContext>>(PriceInfoDataProvider);
    }

    [Fact]
    public void LicenceInfoDataProvider_ShouldNotBeNull() {
        // Act  
        var LicenceInfoDataProvider = this._serviceProvider.GetRequiredService(typeof(ILicenceInfoDataProvider));

        // Assert 
        Assert.NotNull(LicenceInfoDataProvider);
        Assert.IsType<LicenceInfoDataProvider<ThiemeMeulenhoffPlatformDbContext>>(LicenceInfoDataProvider);
    }

    [Fact]
    public void LicenseSerieDataProvider_ShouldNotBeNull() {
        // Act  
        var LicenseSerieDataProvider = this._serviceProvider.GetRequiredService(typeof(ILicenseSerieDataProvider));

        // Assert 
        Assert.NotNull(LicenseSerieDataProvider);
        Assert.IsType<LicenseSerieDataProvider<ThiemeMeulenhoffPlatformDbContext>>(LicenseSerieDataProvider);
    }

    [Fact]
    public void LicenseSerieItemDataProvider_ShouldNotBeNull() {
        // Act  
        var LicenseSerieItemDataProvider = this._serviceProvider.GetRequiredService(typeof(ILicenseSerieItemDataProvider));

        // Assert 
        Assert.NotNull(LicenseSerieItemDataProvider);
        Assert.IsType<LicenseSerieItemDataProvider<ThiemeMeulenhoffPlatformDbContext>>(LicenseSerieItemDataProvider);
    }

    [Fact]
    public void SubjectDataProvider_ShouldNotBeNull() {
        // Act  
        var SubjectDataProvider = this._serviceProvider.GetRequiredService(typeof(ISubjectDataProvider));

        // Assert 
        Assert.NotNull(SubjectDataProvider);
        Assert.IsType<SubjectDataProvider<ThiemeMeulenhoffPlatformDbContext>>(SubjectDataProvider);
    }

    [Fact]
    public void OrderDataProvider_ShouldNotBeNull() {
        // Act  
        var OrderDataProvider = this._serviceProvider.GetRequiredService(typeof(IOrderDataProvider));

        // Assert 
        Assert.NotNull(OrderDataProvider);
        Assert.IsType<OrderDataProvider<ThiemeMeulenhoffPlatformDbContext>>(OrderDataProvider);
    }

    [Fact]
    public void OrderItemDataProvider_ShouldNotBeNull() {
        // Act  
        var OrderItemDataProvider = this._serviceProvider.GetRequiredService(typeof(IOrderItemDataProvider));

        // Assert 
        Assert.NotNull(OrderItemDataProvider);
        Assert.IsType<OrderItemDataProvider<ThiemeMeulenhoffPlatformDbContext>>(OrderItemDataProvider);
    }

    [Fact]
    public void InvoiceDataProvider_ShouldNotBeNull() {
        // Act  
        var InvoiceDataProvider = this._serviceProvider.GetRequiredService(typeof(IInvoiceDataProvider));

        // Assert 
        Assert.NotNull(InvoiceDataProvider);
        Assert.IsType<InvoiceDataProvider<ThiemeMeulenhoffPlatformDbContext>>(InvoiceDataProvider);
    }

    [Fact]
    public void InvoiceItemDataProvider_ShouldNotBeNull() {
        // Act  
        var InvoiceItemDataProvider = this._serviceProvider.GetRequiredService(typeof(IInvoiceItemDataProvider));

        // Assert 
        Assert.NotNull(InvoiceItemDataProvider);
        Assert.IsType<InvoiceItemDataProvider<ThiemeMeulenhoffPlatformDbContext>>(InvoiceItemDataProvider);
    }

    [Fact]
    public void StockMutationDataProvider_ShouldNotBeNull() {
        // Act  
        var StockMutationDataProvider = this._serviceProvider.GetRequiredService(typeof(IStockMutationDataProvider));

        // Assert 
        Assert.NotNull(StockMutationDataProvider);
        Assert.IsType<StockMutationDataProvider<ThiemeMeulenhoffPlatformDbContext>>(StockMutationDataProvider);
    }

    [Fact]
    public void ProjectDataProvider_ShouldNotBeNull() {
        // Act  
        var ProjectDataProvider = this._serviceProvider.GetRequiredService(typeof(IProjectDataProvider));

        // Assert 
        Assert.NotNull(ProjectDataProvider);
        Assert.IsType<ProjectDataProvider<ThiemeMeulenhoffPlatformDbContext>>(ProjectDataProvider);
    }

    [Fact]
    public void ProjectTeamMemberDataProvider_ShouldNotBeNull() {
        // Act  
        var ProjectTeamMemberDataProvider = this._serviceProvider.GetRequiredService(typeof(IProjectTeamMemberDataProvider));

        // Assert 
        Assert.NotNull(ProjectTeamMemberDataProvider);
        Assert.IsType<ProjectTeamMemberDataProvider<ThiemeMeulenhoffPlatformDbContext>>(ProjectTeamMemberDataProvider);
    }

    [Fact]
    public void PrintOrderDataProvider_ShouldNotBeNull() {
        // Act  
        var PrintOrderDataProvider = this._serviceProvider.GetRequiredService(typeof(IPrintOrderDataProvider));

        // Assert 
        Assert.NotNull(PrintOrderDataProvider);
        Assert.IsType<PrintOrderDataProvider<ThiemeMeulenhoffPlatformDbContext>>(PrintOrderDataProvider);
    }

    [Fact]
    public void PrintInfoDataProvider_ShouldNotBeNull() {
        // Act  
        var PrintInfoDataProvider = this._serviceProvider.GetRequiredService(typeof(IPrintInfoDataProvider));

        // Assert 
        Assert.NotNull(PrintInfoDataProvider);
        Assert.IsType<PrintInfoDataProvider<ThiemeMeulenhoffPlatformDbContext>>(PrintInfoDataProvider);
    }

    [Fact]
    public void PrintInfoTemplateDataProvider_ShouldNotBeNull() {
        // Act  
        var PrintInfoTemplateDataProvider = this._serviceProvider.GetRequiredService(typeof(IPrintInfoTemplateDataProvider));

        // Assert 
        Assert.NotNull(PrintInfoTemplateDataProvider);
        Assert.IsType<PrintInfoTemplateDataProvider<ThiemeMeulenhoffPlatformDbContext>>(PrintInfoTemplateDataProvider);
    }

    [Fact]
    public void EanCodeDataProvider_ShouldNotBeNull() {
        // Act  
        var EanCodeDataProvider = this._serviceProvider.GetRequiredService(typeof(IEanCodeDataProvider));

        // Assert 
        Assert.NotNull(EanCodeDataProvider);
        Assert.IsType<EanCodeDataProvider<ThiemeMeulenhoffPlatformDbContext>>(EanCodeDataProvider);
    }

    [Fact]
    public void EducationFunctionDataProvider_ShouldNotBeNull() {
        // Act  
        var EducationFunctionDataProvider = this._serviceProvider.GetRequiredService(typeof(IEducationFunctionDataProvider));

        // Assert 
        Assert.NotNull(EducationFunctionDataProvider);
        Assert.IsType<EducationFunctionDataProvider<ThiemeMeulenhoffPlatformDbContext>>(EducationFunctionDataProvider);
    }

    [Fact]
    public void EducationSectorDataProvider_ShouldNotBeNull() {
        // Act  
        var EducationSectorDataProvider = this._serviceProvider.GetRequiredService(typeof(IEducationSectorDataProvider));

        // Assert 
        Assert.NotNull(EducationSectorDataProvider);
        Assert.IsType<EducationSectorDataProvider<ThiemeMeulenhoffPlatformDbContext>>(EducationSectorDataProvider);
    }

    [Fact]
    public void EducationSubjectDataProvider_ShouldNotBeNull() {
        // Act  
        var EducationSubjectDataProvider = this._serviceProvider.GetRequiredService(typeof(IEducationSubjectDataProvider));

        // Assert 
        Assert.NotNull(EducationSubjectDataProvider);
        Assert.IsType<EducationSubjectDataProvider<ThiemeMeulenhoffPlatformDbContext>>(EducationSubjectDataProvider);
    }

    [Fact]
    public void EducationTypeDataProvider_ShouldNotBeNull() {
        // Act  
        var EducationTypeDataProvider = this._serviceProvider.GetRequiredService(typeof(IEducationTypeDataProvider));

        // Assert 
        Assert.NotNull(EducationTypeDataProvider);
        Assert.IsType<EducationTypeDataProvider<ThiemeMeulenhoffPlatformDbContext>>(EducationTypeDataProvider);
    }

    [Fact]
    public void DeliveryNoteDataProvider_ShouldNotBeNull() {
        // Act  
        var DeliveryNoteDataProvider = this._serviceProvider.GetRequiredService(typeof(IDeliveryNoteDataProvider));

        // Assert 
        Assert.NotNull(DeliveryNoteDataProvider);
        Assert.IsType<DeliveryNoteDataProvider<ThiemeMeulenhoffPlatformDbContext>>(DeliveryNoteDataProvider);
    }

    [Fact]
    public void DeliveryNoteItemDataProvider_ShouldNotBeNull() {
        // Act  
        var DeliveryNoteItemDataProvider = this._serviceProvider.GetRequiredService(typeof(IDeliveryNoteItemDataProvider));

        // Assert 
        Assert.NotNull(DeliveryNoteItemDataProvider);
        Assert.IsType<DeliveryNoteItemDataProvider<ThiemeMeulenhoffPlatformDbContext>>(DeliveryNoteItemDataProvider);
    }

    [Fact]
    public void DatabaseProvider_ShouldNotBeNull() {
        // Act  
        var DatabaseProvider = this._serviceProvider.GetRequiredService(typeof(IDatabaseProvider));

        // Assert 
        Assert.NotNull(DatabaseProvider);
        Assert.IsType<DatabaseProvider>(DatabaseProvider);
    }

    [Fact]
    public void DataContext_ShouldNotBeNull() {
        // Act  
        var DataContext = this._serviceProvider.GetRequiredService(typeof(DataContext));

        // Assert 
        Assert.NotNull(DataContext);
        Assert.IsType<DataContext>(DataContext);
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
