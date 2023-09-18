import { BaseStatsViewModel } from "./BaseStatsViewModel";
import { GenderRatioViewModel } from "./GenderRatioViewModel";
import { PhysicalAttributesViewModel } from "./PhysicalAttributesViewModel";

export default interface PokemonViewModel {
	name: string;
	avatar: string;
	baseStats: BaseStatsViewModel;
	catchRate: number;
	evolvesFrom: PokemonViewModel[];
	evolvesTo: PokemonViewModel;
	genderRatio: GenderRatioViewModel;
	isLegendary: boolean;
	number: number;
	physicalAttributes:PhysicalAttributesViewModel;
	primaryType: string;
	secondaryType: string;
}