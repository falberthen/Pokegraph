namespace Pokegraph.Api.ViewModels;

public record class PokemonViewModel
{
    public int Number { get; set; }
    public string Name { get; set; }
    public string PrimaryType { get; set; }
    public string? SecondaryType { get; set; }
    public float CatchRate { get; set; }
    public bool IsLegendary { get; set; }
    public string? Avatar { get; set; }
    public PhysicalAttributesViewModel PhysicalAttributes { get; set; }
    public GenderRatioViewModel GenderRatio { get; set; }  
    public BaseStatsViewModel? BaseStats { get; set; }
    public PokemonViewModel? EvolvesTo { get; set; }
    public IEnumerable<PokemonViewModel>? EvolvesFrom { get; set; }

}
