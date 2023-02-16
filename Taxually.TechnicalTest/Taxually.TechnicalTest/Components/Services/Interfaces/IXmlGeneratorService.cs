namespace Taxually.TechnicalTest.Components.Services.Interfaces;

public interface IXmlGeneratorService
{
    public string Generate<TRequest>(TRequest request);
}