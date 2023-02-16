namespace Taxually.TechnicalTest.Components.Services.Interfaces;

public interface ICsvGeneratorService
{
    public byte[] Generate(string companyName, string companyId);
}