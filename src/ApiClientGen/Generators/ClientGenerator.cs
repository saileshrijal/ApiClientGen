using System.Text;
using ApiClientGen.Models;

namespace ApiClientGen.Generators;

public class ClientGenerator
{
    public string GenerateClientCode(IEnumerable<ApiEndpoint> endpoints)
    {
        var sb = new StringBuilder();

        foreach (var endpoint in endpoints)
        {
            sb.AppendLine($"public async Task<{endpoint.Name}Response> {endpoint.Name}()");
            sb.AppendLine("{");
            sb.AppendLine($"    // Call {endpoint.HttpMethod} {endpoint.Path}");
            sb.AppendLine("}");
            sb.AppendLine();
        }

        return sb.ToString();
    }
}