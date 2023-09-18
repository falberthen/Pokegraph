<template>
  <div v-if="pokemon.primaryType || pokemon.secondaryType">
    <div class="type-display">
      <div class="type-badge" 
        :style="{ 'background-color': getTypeColor(pokemon.primaryType)}">
        {{pokemon.primaryType}}
      </div>
      <div v-if="pokemon.secondaryType !== 'None'" 
        class="type-badge" 
        :style="{ 'background-color': getTypeColor(pokemon.secondaryType)}">
        {{pokemon.secondaryType}}
      </div>
    </div>    
  </div>
</template>

<script lang="ts" setup>
import PokemonViewModel from '@/models/PokemonViewModel';
import { PokemonTypeColors } from '@/models/PokemonTypeColors';

defineProps({
  pokemon: { 
    type: Object as () => PokemonViewModel,
    required: true
  }
});
function getTypeColor(type: string) {
  const color: PokemonTypeColors = PokemonTypeColors[type as keyof typeof PokemonTypeColors];
  return color;
}
</script>

<style scoped lang="scss">
.type-display {  
  .type-container {
    width: 100%;    
  }
  .type-badge {
    width: 47%;
    height: 22px;
    float: left;
    line-height: 24px;
    border-radius: 5px;
    margin: 2px;
    color: white;
    font-weight: bold;
    font-size: 0.6em;
  }
}
</style>
