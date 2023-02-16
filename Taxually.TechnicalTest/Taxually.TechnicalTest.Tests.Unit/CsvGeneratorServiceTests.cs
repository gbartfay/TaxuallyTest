namespace Taxually.TechnicalTest.Tests.Unit;

using Components.Services;

[TestClass]
public class CsvGeneratorServiceTests
{
    [TestMethod]
    [DataRow("testCompanyName", "testCompanyId")]
    //More test data
    public void Generate_ValidInput_ValidResult(string companyName, string companyId)
    {
        var sut = new CsvGeneratorService();
        var actualResult = sut.Generate(companyName, companyId);
        var expectedResult = new byte[] { }; //Here we should compose the actual expected result, but I will skip this now.
        Assert.Equals(expectedResult, actualResult);
    }
    
    //...
    //More tests for CsvGeneratorService class. (Invalid input, edge cases, etc.)
}