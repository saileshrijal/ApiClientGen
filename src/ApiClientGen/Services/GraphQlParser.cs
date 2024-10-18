using System.Text.RegularExpressions;
using ApiClientGen.Interfaces;
using ApiClientGen.Models;

namespace ApiClientGen.Services;

public class GraphQlParser : IApiSchemaParser
{
    public IEnumerable<ApiEndpoint> Parse(string schemaContent)
    {
        // Parse Queries
        var queryEndpoints = ParseOperations(schemaContent, "type Query");
        var endpoints = queryEndpoints.Select(endpoint => new ApiEndpoint
            { Name = endpoint, Path = "/graphql", HttpMethod = "POST", Type = "Query" }).ToList();

        // Parse Mutations
        var mutationEndpoints = ParseOperations(schemaContent, "type Mutation");
        endpoints.AddRange(mutationEndpoints.Select(endpoint => new ApiEndpoint
            { Name = endpoint, Path = "/graphql", HttpMethod = "POST", Type = "Mutation" }));

        return endpoints;
    }

    private static IEnumerable<string> ParseOperations(string schemaContent, string typeKeyword)
    {
        // Locate the type (e.g., type Query or type Mutation) and capture the block
        var typePattern = @$"{typeKeyword}\s*{{(.*?)}}";
        var match = Regex.Match(schemaContent, typePattern, RegexOptions.Singleline);

        if (!match.Success)
            return Enumerable.Empty<string>();

        // Extract each field within the type block
        var operationsBlock = match.Groups[1].Value;
        const string operationPattern = @"(\w+)\s*\(";
        var operationMatches = Regex.Matches(operationsBlock, operationPattern);

        return operationMatches.Select(m => m.Groups[1].Value).Distinct();
    }
}