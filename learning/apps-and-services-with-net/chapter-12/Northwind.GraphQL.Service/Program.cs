using Northwind.GraphQL.Service;
using Northwind.GraphQL.Service.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer()
    .AddQueryType<HelloWorldQuery>();
var app = builder.Build();

app.MapGet("/", () => "Navigate to: https://localhost:5121/graphql");

app.MapGraphQL();

await app.RunAsync();
