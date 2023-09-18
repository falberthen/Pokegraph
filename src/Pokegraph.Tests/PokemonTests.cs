using Xunit;
using FluentAssertions;
using Pokegraph.Domain.Pokemon;
using Pokegraph.Api.DomainServices;
using Pokegraph.Domain.SeedWork;
using NSubstitute;

namespace Pokegraph.Tests;

public class PokemonTests
{
    [Fact]
    public void CreatingPokemon_WithTwoIdenticalAggregates_ShouldReturnEqualsFalse()
    {
        // Given
        var pokemonNumber = PokemonNumber.From(25);
        var pokemonData = new PokemonData(pokemonNumber.Value, "Pikachu", PokemonType.Electric.Name)
        { Height = 10, Weigth = 10 };

        // When
        var pokemon1 = Pokemon.CatalogNew(pokemonData);
        var pokemon2 = Pokemon.CatalogNew(pokemonData);

        // Then
        (pokemon1.GetHashCode() == pokemon2.GetHashCode()).Should().BeFalse();
        pokemon1.Equals(pokemon2).Should().BeFalse();
    }

    [Fact]
    public async Task EvolvingPokemon_WithValidEvolution_ShouldEvolveToNumber()
    {
        // Given
        var pikachuNumber = PokemonNumber.From(25);
        var raichuNumber = PokemonNumber.From(26);

        var pikachuData = new PokemonData(pikachuNumber.Value, "Pikachu", PokemonType.Electric.Name);
        pikachuData = pikachuData with { Height = 10, Weigth = 10, EvolvesToNumber = raichuNumber.Value };
        var pikachu = Pokemon.CatalogNew(pikachuData);

        var raichuData = pikachuData with { Number = raichuNumber.Value, Name = "Raichu", EvolvesToNumber = default };
        var raichu = Pokemon.CatalogNew(raichuData);

        var repository = Substitute.For<IPokemon>();
        repository.GetPokemonByNumber(raichuNumber)
            .Returns(Task.FromResult(raichu));

        var evolutionChecker = new EvolutionChecker(repository);

        // When
        var canEvolveTo = await evolutionChecker
            .CanEvolveFromTo(pikachu.Number, raichuNumber);

        // Then
        Assert.NotNull(pikachu);
        pikachu.EvolvesToNumber.Should().Be(raichuNumber);
        canEvolveTo.Should().Be(true);
    }

    [Fact]
    public async Task EvolvingPokemon_WithSameEvolutionNumber_ShouldThrowException()
    {
        // Given
        var pikachuNumber = PokemonNumber.From(25);
        var raichuNumber = PokemonNumber.From(26);

        var pikachuData = new PokemonData(pikachuNumber.Value, "Pikachu", PokemonType.Electric.Name);
        pikachuData = pikachuData with { Height = 10, Weigth = 10, EvolvesToNumber = raichuNumber.Value };
        var pikachu = Pokemon.CatalogNew(pikachuData);

        var raichuData = pikachuData with { Number = raichuNumber.Value, Name = "Raichu", EvolvesToNumber = default };
        var raichu = Pokemon.CatalogNew(raichuData);

        var repository = Substitute.For<IPokemon>();
        repository.GetPokemonByNumber(Arg.Any<PokemonNumber>())
            .Returns(Task.FromResult(raichu));

        var evolutionChecker = new EvolutionChecker(repository);

        // When
        Func<Task<bool>> action = async () =>
            await evolutionChecker.CanEvolveFromTo(pikachu.Number, pikachu.Number);

        // Then
        await action.Should().ThrowAsync<DomainException>();
    }
}