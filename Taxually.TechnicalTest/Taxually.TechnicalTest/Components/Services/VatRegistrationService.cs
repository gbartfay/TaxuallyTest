namespace Taxually.TechnicalTest.Components.Services;

using Clients.Interfaces;
using Interfaces;

public class VatRegistrationService : IVatRegistrationService
{
    private readonly ICsvGeneratorService _csvGeneratorService;
    private readonly IXmlGeneratorService _xmlGeneratorService;
    private readonly ITaxuallyHttpClient _taxuallyHttpClient;
    private readonly ITaxuallyQueueClient _taxuallyQueueClient;

    public VatRegistrationService(
        ICsvGeneratorService csvGeneratorService, IXmlGeneratorService xmlGeneratorService,
        ITaxuallyHttpClient taxuallyHttpClient, ITaxuallyQueueClient taxuallyQueueClient)
    {
        _csvGeneratorService = csvGeneratorService;
        _xmlGeneratorService = xmlGeneratorService;
        _taxuallyHttpClient = taxuallyHttpClient;
        _taxuallyQueueClient = taxuallyQueueClient;
    }

    public async Task PostAsync<TRequest>(TRequest request)
    {
        await _taxuallyHttpClient.PostAsync("https://api.uktax.gov.uk", request);
    }

    public async Task EnqueueCsvAsync(string companyName, string companyId)
    {
        var csv = _csvGeneratorService.Generate(companyName, companyId);
        await _taxuallyQueueClient.EnqueueAsync("vat-registration-csv", csv);
    }

    public async Task EnqueueXmlAsync<TRequest>(TRequest request)
    {
        var xml = _xmlGeneratorService.Generate(request);
        await _taxuallyQueueClient.EnqueueAsync("vat-registration-xml", xml);
    }
}