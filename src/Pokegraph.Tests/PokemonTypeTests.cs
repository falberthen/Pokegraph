namespace Pokegraph.Tests;

public class PokemonTypeTests
{
    [Fact]
    public void CreatingPokemonType_WithNullType_ShouldThrownException()
    {
        // Given
        string? nullType = null;

        // When
        var action = () => PokemonType.From(nullType!);

        // Then
        action.Should().Throw<DomainException>();
    }

    [Fact]
    public void CreatingPokemonType_EmptyStringType_ShouldThrownException()
    {
        // Given
        string emptyType = String.Empty;

        // When
        var action = () => PokemonType.From(emptyType);

        // Then
        action.Should().Throw<DomainException>();
    }


    [Fact]
    public void CreatingPokemonType_WithValidTypeName_ShouldReturnPokemonType()
    {
        // Given
        string typeName = "Grass";

        // When
        var pokemonType = PokemonType.From(typeName);

        // Then
        pokemonType.Should().NotBeNull();
    }


    [Fact]
    public void CreatingPokemonType_WithInvalidTypeName_ShouldThrowException()
    {
        // Given
        string typeName = "None";

        // When
        var action = () => PokemonType.From(typeName);

        // Then
        action.Should().Throw<DomainException>();
    }


    [Fact]
    public void CreatingTwoPokemonTypes_WithSameTypeName_ShouldBeEqual()
    {
        // Given
        string typeName = "Grass";
        var pokemonType1 = PokemonType.From(typeName);
        var pokemonType2 = PokemonType.From(typeName);

        // When
        var areEqual = pokemonType1 == pokemonType2;

        // Then
        areEqual.Should().BeTrue();
        pokemonType1.Should().Be(pokemonType2);
    }
}