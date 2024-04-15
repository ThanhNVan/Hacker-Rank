using System;
using System.Threading.Tasks;
using AutoFixture;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform.WebApi;

[Collection("ControllerProvider")]
[CollectionDefinition(nameof(TestDataControllerUnitTest), DisableParallelization = true)]
public class TestDataControllerUnitTest : IDisposable
{
    #region [ Fields ]
    protected readonly Fixture _fixture;
    protected readonly LogicContext _logicContext;
    protected Mock<IEntityApplicationKeyLogicProvider> _entityApplicationKeys;
    protected Mock<IContactLogicProvider> _contacts;
    protected Mock<IPersonLogicProvider> _persons;
    protected Mock<IPersonEducationFunctionLogicProvider> _personEducationFunctions;
    protected Mock<IPersonEducationSubjectLogicProvider> _personEducationSubjects;
    protected Mock<IPersonOrganizationLogicProvider> _personOrganizations;
    protected Mock<IOrganizationLogicProvider> _organizations;
    protected Mock<ISchoolLogicProvider> _schools;
    protected Mock<IAddressLogicProvider> _addresses;
    protected Mock<IProductLogicProvider> _products;
    protected Mock<IProductBundleItemLogicProvider> _productBundleItems;
    protected Mock<IPriceInfoLogicProvider> _priceInfo;
    protected Mock<ILicenceInfoLogicProvider> _licenceInfo;
    protected Mock<ILicenseSerieLogicProvider> _licenseSeries;
    protected Mock<ILicenseSerieItemLogicProvider> _licenseSerieItems;
    protected Mock<ISubjectLogicProvider> _subjects;
    protected Mock<IOrderLogicProvider> _orders;
    protected Mock<IOrderItemLogicProvider> _orderItems;
    protected Mock<IInvoiceLogicProvider> _invoices;
    protected Mock<IInvoiceItemLogicProvider> _invoiceItems;
    protected Mock<IStockMutationLogicProvider> _stockMutations;
    protected Mock<IProjectLogicProvider> _projects;
    protected Mock<IProjectTeamMemberLogicProvider> _projectTeamMembers;
    protected Mock<IPrintOrderLogicProvider> _printOrders;
    protected Mock<IPrintInfoLogicProvider> _printInfo;
    protected Mock<IPrintInfoTemplateLogicProvider> _printInfoTemplate;
    protected Mock<IEanCodeLogicProvider> _eanCodes;
    protected Mock<IEducationFunctionLogicProvider> _educationFunctions;
    protected Mock<IEducationSectorLogicProvider> _educationSectors;
    protected Mock<IEducationSubjectLogicProvider> _educationSubjects;
    protected Mock<IEducationTypeLogicProvider> _educationTypes;
    protected Mock<IDeliveryNoteLogicProvider> _deliveryNotes;
    protected Mock<IDeliveryNoteItemLogicProvider> _deliveryNoteItems;
    protected readonly TestDataController _controller;
    #endregion

    #region [ CTor ]
    public TestDataControllerUnitTest() {
        this._fixture = new Fixture();
        this.GetLogicProviders();
        this._logicContext = this.GetLogicContext();
        this._controller = this.GetController();
    }
    #endregion

    #region [ Public Methods - Custom - Add ]
    [Fact]
    public async Task AddTestDataAsync_Should_Return401BadRequestResult_If_InputLessThanZero() {
        // Arrange
        var input = -1;

        // Act
        var actual = await _controller.AddTestDataAsync(input);

        // Assert
        Assert.IsType<BadRequestObjectResult>(actual);
    }
    
    [Fact]
    public async Task AddTestDataAsync_Should_Return401BadRequestResult_If_InputGreaterThan50() {
        // Arrange
        var input = 51;

        // Act
        var actual = await _controller.AddTestDataAsync(input);

        // Assert
        Assert.IsType<BadRequestObjectResult>(actual);
    }
    
    [Fact]
    public async Task AddTestDataAsync_Should_Return401BadRequestResult_If_Error() {
        // Arrange
        var input = new Random().Next(0, 50);
        this._entityApplicationKeys.Setup(x => x.AddAsync(It.IsAny<EntityApplicationKey>())).ThrowsAsync(new Exception());

        // Act
        var actual = await _controller.AddTestDataAsync(input);

        // Assert
        Assert.IsType<BadRequestObjectResult>(actual);
    }
    
    [Fact]
    public async Task AddTestDataAsync_Should_Return200Ok_If_Success() {
        // Arrange
        var input = new Random().Next(0, 50);

        // Act
        var actual = await _controller.AddTestDataAsync(input);

        // Assert
        Assert.IsType<OkResult>(actual);
    }
    #endregion

    #region [ Protected Methods - Create ]
    protected TestDataController GetController() {
        return OnGetController(this._logicContext);
    }

    protected LogicContext GetLogicContext() {

        return new LogicContext(this._entityApplicationKeys.Object,
                                this._contacts.Object,
                                this._persons.Object,
                                this._personEducationFunctions.Object,
                                this._personEducationSubjects.Object,
                                this._personOrganizations.Object,
                                this._organizations.Object,
                                this._schools.Object,
                                this._addresses.Object,
                                this._products.Object,
                                this._productBundleItems.Object,
                                this._priceInfo.Object,
                                this._licenceInfo.Object,
                                this._licenseSeries.Object,
                                this._licenseSerieItems.Object,
                                this._subjects.Object,
                                this._orders.Object,
                                this._orderItems.Object,
                                this._invoices.Object,
                                this._invoiceItems.Object,
                                this._stockMutations.Object,
                                this._projects.Object,
                                this._projectTeamMembers.Object,
                                this._printOrders.Object,
                                this._printInfo.Object,
                                this._printInfoTemplate.Object,
                                this._eanCodes.Object,
                                this._educationFunctions.Object,
                                this._educationSectors.Object,
                                this._educationSubjects.Object,
                                this._educationTypes.Object,
                                this._deliveryNotes.Object,
                                this._deliveryNoteItems.Object);
    }

    protected void GetLogicProviders() {
        this._entityApplicationKeys = new Mock<IEntityApplicationKeyLogicProvider>();
        this._contacts = new Mock<IContactLogicProvider>();
        this._persons = new Mock<IPersonLogicProvider>();
        this._personEducationFunctions = new Mock<IPersonEducationFunctionLogicProvider>();
        this._personEducationSubjects = new Mock<IPersonEducationSubjectLogicProvider>();
        this._personOrganizations = new Mock<IPersonOrganizationLogicProvider>();
        this._organizations = new Mock<IOrganizationLogicProvider>();
        this._schools = new Mock<ISchoolLogicProvider>();
        this._addresses = new Mock<IAddressLogicProvider>();
        this._products = new Mock<IProductLogicProvider>();
        this._productBundleItems = new Mock<IProductBundleItemLogicProvider>();
        this._priceInfo = new Mock<IPriceInfoLogicProvider>();
        this._licenceInfo = new Mock<ILicenceInfoLogicProvider>();
        this._licenseSeries = new Mock<ILicenseSerieLogicProvider>();
        this._licenseSerieItems = new Mock<ILicenseSerieItemLogicProvider>();
        this._subjects = new Mock<ISubjectLogicProvider>();
        this._orders = new Mock<IOrderLogicProvider>();
        this._orderItems = new Mock<IOrderItemLogicProvider>();
        this._invoices = new Mock<IInvoiceLogicProvider>();
        this._invoiceItems = new Mock<IInvoiceItemLogicProvider>();
        this._stockMutations = new Mock<IStockMutationLogicProvider>();
        this._projects = new Mock<IProjectLogicProvider>();
        this._projectTeamMembers = new Mock<IProjectTeamMemberLogicProvider>();
        this._printOrders = new Mock<IPrintOrderLogicProvider>();
        this._printInfo = new Mock<IPrintInfoLogicProvider>();
        this._printInfoTemplate = new Mock<IPrintInfoTemplateLogicProvider>();
        this._eanCodes = new Mock<IEanCodeLogicProvider>();
        this._educationFunctions = new Mock<IEducationFunctionLogicProvider>();
        this._educationSectors = new Mock<IEducationSectorLogicProvider>();
        this._educationSubjects = new Mock<IEducationSubjectLogicProvider>();
        this._educationTypes = new Mock<IEducationTypeLogicProvider>();
        this._deliveryNotes = new Mock<IDeliveryNoteLogicProvider>();
        this._deliveryNoteItems = new Mock<IDeliveryNoteItemLogicProvider>();
    }

    protected TestDataController OnGetController(LogicContext logicContext) {
        return new TestDataController(logicContext);
    }
    #endregion

    #region [ Methods - Dispose ]
    public void Dispose() {

    }
    #endregion

}
