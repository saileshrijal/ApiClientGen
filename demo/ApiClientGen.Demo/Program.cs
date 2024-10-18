using ApiClientGen.Models;
using ApiClientGen.Services;

Console.WriteLine("Welcome to ApiClientGen Demo!");

// Choose whether to demo GraphQL or OpenAPI parsing
Console.WriteLine("\n1. Demo GraphQL Parsing");
Console.WriteLine("2. Demo OpenAPI Parsing");
Console.Write("Choose an option (1 or 2): ");
var choice = Console.ReadLine();

switch (choice)
{
    case "1":
        DemoGraphQl();
        break;
    case "2":
        DemoOpenApi();
        break;
    default:
        Console.WriteLine("Invalid choice. Exiting.");
        break;
}

return;

static void DisplayEndpoints(IEnumerable<ApiEndpoint> endpoints)
{
    Console.WriteLine("Parsed API Endpoints:");
    foreach (var endpoint in endpoints)
    {
        Console.WriteLine($"- Name: {endpoint.Name}");
        Console.WriteLine($"  Path: {endpoint.Path}");
        Console.WriteLine($"  HttpMethod: {endpoint.HttpMethod}");
    }

    Console.WriteLine("Demo complete!");
}

static void DemoOpenApi()
{
    Console.WriteLine("\nParsing sample OpenAPI schema...\n");

    const string schemaContent = """
                                 openapi: 3.0.0
                                 info:
                                   title: Sample API
                                   description: A sample API to illustrate OpenAPI parsing
                                   version: 1.0.0
                                 paths:
                                   /users:
                                     get:
                                       summary: List all users
                                       operationId: listUsers
                                       responses:
                                         '200':
                                           description: A list of users.
                                   /users/{id}:
                                     get:
                                       summary: Get a user by ID
                                       operationId: getUserById
                                       parameters:
                                         - name: id
                                           in: path
                                           required: true
                                           schema:
                                             type: string
                                       responses:
                                         '200':
                                           description: A single user.
                                   /users:
                                     post:
                                       summary: Create a user
                                       operationId: createUser
                                       requestBody:
                                         content:
                                           application/json:
                                             schema:
                                               type: object
                                       responses:
                                         '201':
                                           description: User created.
                                 """;

    var parser = new OpenApiParser();
    var endpoints = parser.Parse(schemaContent);

    DisplayEndpoints(endpoints);
}

static void DemoGraphQl()
{
    Console.WriteLine("\nParsing sample GraphQL schema...\n");

    const string schemaContent = """
                                     type Query {
                                         getUser(id: ID!): User
                                         listUsers: [User]
                                     }
                                     
                                     type Mutation {
                                         createUser(name: String!): User
                                         deleteUser(id: ID!): Boolean
                                     }

                                 """;

    var parser = new GraphQlParser();
    var endpoints = parser.Parse(schemaContent);

    DisplayEndpoints(endpoints);
}