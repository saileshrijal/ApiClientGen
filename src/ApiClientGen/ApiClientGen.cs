using ApiClientGen.Generators;
using ApiClientGen.Interfaces;
using ApiClientGen.Services;

namespace ApiClientGen;
 
public class ApiClientGen(IApiSchemaParser parser)
{
    private readonly ClientGenerator _generator = new();

    public string GenerateClient(string schemaContent)
    {
        var endpoints = parser.Parse(schemaContent);
        return _generator.GenerateClientCode(endpoints);
    }
}