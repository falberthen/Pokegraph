var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<PokegraphDbContext>(options =>
    options.UseSqlite(builder.Configuration
    .GetConnectionString("DefaultConnection")));

// Services
builder.Services.AddTransient<IEvolutionChecker, EvolutionChecker>();
builder.Services.AddScoped<IPokemon, PokemonRepository>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddMutationConventions()
    .AddInMemorySubscriptions();

builder.Services.AddAutoMapperSetup();
builder.Services.AddCors();

// App
var app = builder.Build();

app.UseRouting();
app.UseWebSockets();
app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true));

app.MapGraphQL("/");

app.UseHttpsRedirection();
app.Run();