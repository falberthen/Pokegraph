namespace Pokegraph.Api.Automapper;

public class PokemonToPokemonViewModelProfile : Profile
{
    public PokemonToPokemonViewModelProfile()
    {
        CreateMap<Pokemon, PokemonViewModel>()
            .ForMember(t => t.Number,
                g => g.MapFrom(src => src.Number.Value))
            .ForMember(t => t.PrimaryType,
                g => g.MapFrom(src => src.PrimaryType.Name))
            .ForMember(t => t.SecondaryType,
                g => g.MapFrom(src => src.SecondaryType!.Name ?? "None"));

        CreateMap<PhysicalAttributes, PhysicalAttributesViewModel>();
        CreateMap<GenderRatio, GenderRatioViewModel>();
        CreateMap<BaseStats, BaseStatsViewModel>();
    }
}