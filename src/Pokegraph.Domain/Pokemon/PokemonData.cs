namespace Pokegraph.Domain.Pokemon;

public record class PokemonData
{
    public PokemonData(int number, string name, string primaryType)
    {
        Number = number;
        Name = name;
        PrimaryType = primaryType;
    }

    public int Number { get; set; }
    public string Name { get; set; }
    public string PrimaryType { get; set; }
    public string? SecondaryType { get; set; }
    public bool IsLegendary { get; set; }
    public string? Avatar { get; set; }
    public decimal Height { get; set; }
    public decimal Weigth { get; set; }
    public decimal? MaleRatio { get; set; }
    public decimal? FemaleRatio { get; set; }
    public decimal? CatchRate { get; set; }
    public int? HP { get; set; }
    public int? Attack { get; set; }
    public int? Defense { get; set; }
    public int? SpecialAttack { get; set; }
    public int? SpecialDefense { get; set; }
    public int? Speed { get; set; }
    public int? EvolvesToNumber { get; set; }
}