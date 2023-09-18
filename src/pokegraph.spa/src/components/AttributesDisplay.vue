<template>
  <div class="attr-display">
    <div class="display-container">
      <div class="attr-row" v-if="pokemon.physicalAttributes?.height">
        <label>Height</label>: 
        <span class="attr-value">
          {{pokemon.physicalAttributes?.height}} cm
        </span>
      </div>
      <div class="attr-row" v-if="pokemon.physicalAttributes?.weigth">
        <label>Weigth</label>: 
        <span class="attr-value">
          {{pokemon.physicalAttributes?.weigth}} kg
        </span>
      </div>
    </div>
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
.attr-display {  
  .display-container {
    width:100%;
    min-width: 80px;
    min-height: 50px;
    float: left;
    font-weight: bold;
    font-size: 0.7em;
    
    .attr-row {      
      float: left;
      margin:1px;
    }
    .attr-value {
      font-size: 0.9em;
    }
  }
}

label {
	color: #1c5252;
	display: inline-block;
  font-size: 0.9em;
	text-transform: uppercase;
	font-weight: bold;
}
</style>