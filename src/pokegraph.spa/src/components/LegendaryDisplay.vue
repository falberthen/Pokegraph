<template>
  <div class="legendary">
    <span v-if="pokemon.isLegendary" 
      class="is-legendary-display">
        Legendary
    </span>
  </div>  
</template>

<script lang="ts" setup>
import PokemonViewModel from '@/models/PokemonViewModel';

defineProps({
  pokemon: { 
    type: Object as () => PokemonViewModel,
    required: true
  },
});
</script>

<style scoped lang="scss">
.legendary {  
  width: 100px;
  background-color: rgb(1, 3, 25);
  text-align: center;
  border-radius: 5px;
  font-size: 0.8em;

  .is-legendary-display {
    color:rgb(195, 186, 52);
    font-weight: bolder;
  }
}
</style>