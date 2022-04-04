using DairyGraphQL.Data;
using DairyGraphQL.GraphQL.Mutations;
using DairyGraphQL.GraphQL.Queries;
using DairyGraphQL.GraphQL.Types.Cows;
using DairyGraphQL.GraphQL.Types.Farms;
using Graph.ArgumentValidator;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("CommandConStr");

builder.Services.AddPooledDbContextFactory<AppDbContext>(opt => opt.UseSqlServer(connectionString));
//builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

builder.Services
        .AddGraphQLServer()
        .AddArgumentValidator()
        .AddQueryType<Query>()
        .AddMutationType<Mutation>()
        .AddType<FarmType>()
        .AddType<CowType>()
        .AddProjections()
        .AddFiltering()
        .AddSorting();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.MapGraphQL();

/*  app.UseGraphQLVoyager(new GraphQLVoyagerOptions()
            {
                GraphQLEndPoint = "/graphql",
                Path = "/graphql-voyager"
            });*/

app.Run();
