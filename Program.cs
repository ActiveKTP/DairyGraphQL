using DairyGraphQL.Data;
using DairyGraphQL.GraphQL.Mutations;
using DairyGraphQL.GraphQL.Queries;
using DairyGraphQL.GraphQL.Types.Cows;
using DairyGraphQL.GraphQL.Types.Farms;
using Graph.ArgumentValidator;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//var connectionString = builder.Configuration.GetConnectionString("CommandConStr");
//"CommandConStr": "Server=ACTIVEX\\SQLEXPRESS;Initial Catalog=Dairy_webRep250820;User ID=dairy_user;Password=!234"
var server = builder.Configuration["DBServer"] ?? "ACTIVEX\\SQLEXPRESS";
var port = builder.Configuration["DBPort"] ?? "1433";
var user = builder.Configuration["DBUser"] ?? "dairy_user";
var password = builder.Configuration["DBPassword"] ?? "!234";
var database = builder.Configuration["Database"] ?? "Dairy_webRep250820";
var connectionString = $"Server={server}, {port};Initial Catalog={database};User ID={user};Password={password}";

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

// app.MapGet("/", () => "Hello World!");

app.MapGraphQL();
// app.MapGraphQL("/gql/dairy/regis");

/*  app.UseGraphQLVoyager(new GraphQLVoyagerOptions()
            {
                GraphQLEndPoint = "/graphql",
                Path = "/graphql-voyager"
            });*/

app.Run();
