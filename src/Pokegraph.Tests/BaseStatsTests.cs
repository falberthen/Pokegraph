namespace Pokegraph.Tests;

public class BaseStatsTests
{
    [Fact]
    public void CreatingBaseStats_WithNegativeNumbers_ShouldThrownException()
    {
        // Given
        var pokemonData = new PokemonData(1, "Missigno", "Ghost") { HP = -1 };

        // When
        var action = () => BaseStats.From(pokemonData);

        // Then
        action.Should().Throw<DomainException>();
    }

    [Fact]
    public void CreatingBaseStats_WithSameValues_ShouldBeEqual()
    {
        // Given
        var pokemonData1 = new PokemonData(25, "Pikachu", "Electric") { HP = 100 };
        var pokemonData2 = new PokemonData(25, "Pikachu", "Electric") { HP = 100 };
        var baseStats1 = BaseStats.From(pokemonData1);
        var baseStats2 = BaseStats.From(pokemonData2);

        // When
        var areEqual = baseStats1 == baseStats2;

        // Then
        areEqual.Should().BeTrue();
        baseStats1.Should().Be(baseStats2);
    }
}