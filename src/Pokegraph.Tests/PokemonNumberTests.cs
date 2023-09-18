namespace Pokegraph.Tests;

public class PokemonNumberTests
{ 
    [Fact]
    public void CreatingPokemonNumber_WithZero_ShouldThrownException()
    {
        // Given
        var pokemonNumber = 0;

        // When
        var action = () => PokemonNumber.From(pokemonNumber);

        // Then
        action.Should().Throw<DomainException>();
    }

    [Fact]
    public void CreatingPokemonNumber_WithNegativeNumber_ShouldThrownException()
    {
        // Given
        var pokemonNumber = -1;

        // When
        var action = () => PokemonNumber.From(pokemonNumber);

        // Then
        action.Should().Throw<DomainException>();
    }

    [Fact]
    public void CreatingPokemonNumber_WithSameNumbers_ShouldBeEqual()
    {
        // Given
        var pokemonNumber1 = PokemonNumber.From(10);
        var pokemonNumber2 = PokemonNumber.From(10);

        // When
        var areEqual = pokemonNumber1 == pokemonNumber2;

        // Then
        areEqual.Should().BeTrue();
        pokemonNumber1.Should().Be(pokemonNumber2);
    }
}