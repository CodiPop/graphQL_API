using GuardiansOfTheGlobe_graphQLApi.DBContext;
using GuardiansOfTheGlobe_graphQLApi.Schema.Mutation;
using GuardiansOfTheGlobe_graphQLApi.Schema.Query;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection")));
builder.Services.AddGraphQLServer().AddQueryType<Qheroe>().AddMutationType<Mutation>();
var app = builder.Build();

//builder.Services.AddControllers();

app.MapGraphQL();

app.MapGet("/", () => "Hello World!");
app.UseHttpsRedirection();




app.Run();
