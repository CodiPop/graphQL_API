using GuardiansOfTheGlobe_graphQLApi.DBContext;
using GuardiansOfTheGlobe_graphQLApi.Models;
using GuardiansOfTheGlobe_graphQLApi.Schema.Mutation;
using GuardiansOfTheGlobe_graphQLApi.Schema.Mutations;
using GuardiansOfTheGlobe_graphQLApi.Schema.Query;
using GuardiansOfTheGlobe_graphQLApi.Schema.Querys;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection")));
//builder.Services.AddGraphQLServer().AddQueryType<Qheroe>().AddMutationType<Mutation>();
builder.Services.AddGraphQLServer()
.AddQueryType(q => q.Name("Query"))
    .AddType<Qheroe>()
    .AddType<Qvillano>()
    .AddType<Qpatrociandor>()
    .AddType<Qagenda>()
    .AddType<Qpelea>()
    .AddType<Qmyg>()
    .AddType<Qvillanomas>()
    .AddType<Qhtop3>()
.AddMutationType(q => q.Name("Mutation"))
    .AddType<Mheroe>()
    .AddType<Mvillano>()
    .AddType<Mpelea>()
    .AddType<Magenda>()
    .AddType<Mpatrocinador>()
    .AddType<Mmyg>()
    .AddType<Mvillanomas>()
    .AddType<Mhtop3>(); 
var app = builder.Build();

//builder.Services.AddControllers();
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});
app.MapGraphQL();

app.MapGet("/", () => "Hello World!");
app.UseHttpsRedirection();




app.Run();
