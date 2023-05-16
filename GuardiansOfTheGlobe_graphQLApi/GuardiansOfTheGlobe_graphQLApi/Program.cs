using GuardiansOfTheGlobe_graphQLApi.Schema;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer().AddQueryType<Query>();
var app = builder.Build();

//builder.Services.AddControllers();

app.MapGraphQL();

app.MapGet("/", () => "Hello World!");
app.UseHttpsRedirection();




app.Run();
