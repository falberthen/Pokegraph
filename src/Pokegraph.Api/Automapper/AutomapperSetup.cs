namespace Pokegraph.Api.Automapper;

public static class AutoMapperSetup
{
    public static void AddAutoMapperSetup(this IServiceCollection services)
    {
        services
            .AddAutoMapper(typeof(PokemonToPokemonViewModelProfile));
    }
}