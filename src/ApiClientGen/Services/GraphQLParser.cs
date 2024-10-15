using ApiClientGen.Interfaces;
using ApiClientGen.Models;

namespace ApiClientGen.Services;

public class GraphQlParser : IApiSchemaParser
{
    public IEnumerable<ApiEndpoint> Parse(string schemaContent)
    {
        return new List<ApiEndpoint>();
    }
}