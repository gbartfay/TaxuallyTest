namespace Taxually.TechnicalTest.Components.Services;

using System.Text;
using Interfaces;

public class CsvGeneratorService : ICsvGeneratorService
{
    public byte[] Generate(string companyName, string companyId)
    {
        var csvBuilder = new StringBuilder();
        csvBuilder.AppendLine("CompanyName,CompanyId");
        csvBuilder.AppendLine($"{companyName}{companyId}");
        return Encoding.UTF8.GetBytes(csvBuilder.ToString());
    }
}