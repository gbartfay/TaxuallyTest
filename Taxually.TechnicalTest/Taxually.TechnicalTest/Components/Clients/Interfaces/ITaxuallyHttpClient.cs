namespace Taxually.TechnicalTest.Components.Clients.Interfaces;

public interface ITaxuallyHttpClient
{
    public Task PostAsync<TRequest>(string url, TRequest request);
}