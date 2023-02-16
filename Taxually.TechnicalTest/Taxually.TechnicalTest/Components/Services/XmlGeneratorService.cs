namespace Taxually.TechnicalTest.Components.Services;

using System.Xml.Serialization;
using Interfaces;

public class XmlGeneratorService : IXmlGeneratorService
{
    public string Generate<TRequest>(TRequest request)
    {
        using (var stringwriter = new StringWriter())
        {
            var serializer = new XmlSerializer(typeof(TRequest));
            serializer.Serialize(stringwriter, request);
            return stringwriter.ToString();
        }
    }
}