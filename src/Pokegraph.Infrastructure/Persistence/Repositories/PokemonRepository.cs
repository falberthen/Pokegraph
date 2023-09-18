namespace Pokegraph.Infrastructure.Persistence.Repositories;

public class PokemonRepository : IPokemon
{
    private readonly PokegraphDbContext _dbContext;

    public PokemonRepository(PokegraphDbContext context)
    {
        _dbContext = context 
            ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<Pokemon>> ListPokemon()
    {
        return await _dbContext.Pokemon
            .Include(p => p.EvolvesFrom)
            .Include(e => e.EvolvesTo)
            .ToListAsync();
    }

    public async Task<Pokemon> GetPokemonByNumber(PokemonNumber number)
    {
        var pokemon = await _dbContext.Pokemon
            .Include(p => p.EvolvesFrom)
            .Include(e => e.EvolvesTo)
            .FirstOrDefaultAsync(e => e.Number == number)
            ?? throw new ApplicationException("Pokemon not found.");

        return pokemon;
    }

    public async Task InsertPokemon(Pokemon pokemon)
    {
        await _dbContext
            .Pokemon.AddAsync(pokemon);

        await _dbContext
            .SaveChangesAsync();
    }

    public async Task UpdatePokemon(Pokemon pokemon)
    {
        _dbContext
            .Pokemon.Update(pokemon);

        await _dbContext
            .SaveChangesAsync();
    }
}