namespace Taxually.TechnicalTest.Components.Services.Interfaces;

public interface IVatRegistrationService
{
    public Task PostAsync<TRequest>(TRequest request);

    public Task EnqueueCsvAsync(string companyName, string companyId);
    
    public Task EnqueueXmlAsync<TRequest>(TRequest request);
}