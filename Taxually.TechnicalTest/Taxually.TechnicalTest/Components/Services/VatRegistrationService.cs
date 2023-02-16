namespace Taxually.TechnicalTest.Components.Services;

using Clients.Interfaces;
using Interfaces;
using Microsoft.Extensions.Options;
using Options;

public class VatRegistrationService : IVatRegistrationService
{
    private readonly VatRegistrationServiceOptions _options;
    private readonly ICsvGeneratorService _csvGeneratorService;
    private readonly IXmlGeneratorService _xmlGeneratorService;
    private readonly ITaxuallyHttpClient _taxuallyHttpClient;
    private readonly ITaxuallyQueueClient _taxuallyQueueClient;

    public VatRegistrationService(IOptions<VatRegistrationServiceOptions> options,
        ICsvGeneratorService csvGeneratorService, IXmlGeneratorService xmlGeneratorService,
        ITaxuallyHttpClient taxuallyHttpClient, ITaxuallyQueueClient taxuallyQueueClient)
    {
        _options = options.Value;
        _csvGeneratorService = csvGeneratorService;
        _xmlGeneratorService = xmlGeneratorService;
        _taxuallyHttpClient = taxuallyHttpClient;
        _taxuallyQueueClient = taxuallyQueueClient;
    }

    public async Task PostAsync<TRequest>(TRequest request)
    {
        await _taxuallyHttpClient.PostAsync(_options.ApiUrl, request);
    }

    public async Task EnqueueCsvAsync(string companyName, string companyId)
    {
        var csv = _csvGeneratorService.Generate(companyName, companyId);
        await _taxuallyQueueClient.EnqueueAsync(_options.CsvQueueName, csv);
    }

    public async Task EnqueueXmlAsync<TRequest>(TRequest request)
    {
        var xml = _xmlGeneratorService.Generate(request);
        await _taxuallyQueueClient.EnqueueAsync(_options.XmlQueueName, xml);
    }
}