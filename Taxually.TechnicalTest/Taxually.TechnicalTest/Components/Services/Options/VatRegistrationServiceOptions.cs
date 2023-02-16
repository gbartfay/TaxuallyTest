namespace Taxually.TechnicalTest.Components.Services.Options;

public class VatRegistrationServiceOptions
{
    public const string Name = "VatRegistrationURLs";
    
    public string ApiUrl { get; set; }
    
    public string CsvQueueName { get; set; }
    
    public string XmlQueueName { get; set; }
}