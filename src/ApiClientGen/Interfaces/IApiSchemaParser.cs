using ApiClientGen.Models;

namespace ApiClientGen.Interfaces;

public interface IApiSchemaParser
{
    IEnumerable<ApiEndpoint> Parse(string schemaContent);
}