using ApiClientGen.Interfaces;
using ApiClientGen.Models;
using NSwag;

namespace ApiClientGen.Services;

public class OpenApiParser : IApiSchemaParser
{
    public IEnumerable<ApiEndpoint> Parse(string schemaContent)
    {
        var document = OpenApiDocument.FromJsonAsync(schemaContent).Result;
        return document.Operations.Select(op => new ApiEndpoint
        {
            Name = op.Operation.OperationId,
            Path = op.Path,
            HttpMethod = op.Method.ToString(),
            Type = "REST"  // For OpenAPI, we're working with RESTful endpoints
        });
    }
}