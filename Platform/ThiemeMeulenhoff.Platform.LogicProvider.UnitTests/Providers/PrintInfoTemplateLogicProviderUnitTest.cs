using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ThiemeMeulenhoff.Platform;

public class PrintInfoTemplateLogicProviderUnitTest : BaseEntityLogicProviderUnitTest<PrintInfoTemplate, IPrintInfoTemplateDataProvider, PrintInfoTemplateLogicProvider>
{
    #region [ CTor ]
    public PrintInfoTemplateLogicProviderUnitTest() {

    }
    #endregion

    #region [ Protected Methods - Override ]
    protected override PrintInfoTemplateLogicProvider OnCreateLogicProvider(IPrintInfoTemplateDataProvider dataProvider, ILogger<PrintInfoTemplateLogicProvider> logger) {
        return new PrintInfoTemplateLogicProvider(logger, dataProvider);
    }
    #endregion

    #region [ Public Methods - Custom - Single ]
    [Fact]
    public async Task GetByNameAsync_Success() {
        // Arrange
        var Name = this._fixture.Create<string>();

        // Act
        await this._logicProvider.GetByNameAsync(Name);

        // Assert
        this._dataProvider.Verify(x => x.GetByNameAsync(Name), Times.Once);
    }

    [Fact]
    public async Task GetByNameAsync_Should_ThrowException_If_Name_IsNull() {
        // Arrange
        string id = null;

        // Act
        var result = async () => await this._logicProvider.GetByNameAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }

    [Fact]
    public async Task GetByNameAsync_Should_ThrowException_If_Name_IsEmpty() {
        // Arrange
        var id = string.Empty;

        // Act
        var result = async () => await this._logicProvider.GetByNameAsync(id);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(result);
    }
    #endregion
}
