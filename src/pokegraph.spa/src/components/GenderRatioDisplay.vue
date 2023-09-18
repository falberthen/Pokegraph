<template>
  <div class="gender-ratio-display">
    <div class="ratio-bar-display">
      <div class="male-ratio" v-if="pokemon.genderRatio?.maleRatio > 0"
        :style="{'width': getWidth(pokemon.genderRatio?.maleRatio)}" 
        :class="roundedMaleClass"         
        :title="maleRatioDescription">
        &#9794;
      </div>
      <div class="female-ratio" v-if="pokemon.genderRatio?.femaleRatio > 0" 
        :style="{'width': getWidth(pokemon.genderRatio?.femaleRatio!)}" 
        :class="roundedFemaleClass"         
        :title="femaleRatioDescription">
        &#9792;
      </div>      
    </div>
  </div>
</template>

<script lang="ts" setup>
import PokemonViewModel from '@/models/PokemonViewModel';
import { computed } from 'vue';
const props = defineProps({
  pokemon: { 
    type: Object as () => PokemonViewModel,
    required: true
  },
});

const allRundedClass = 'left-radius-only right-radius-only';

// Computed
const maleRatioDescription = computed(() => {
  return props.pokemon.genderRatio?.maleRatio + "% Male";
});
const femaleRatioDescription = computed(() => {
  return props.pokemon.genderRatio?.femaleRatio + "% Female";
});
const roundedMaleClass = computed(() => {
  let ratioClass = 'male-ratio ';
	const genderRatio = props.pokemon.genderRatio;
  return ratioClass += genderRatio 
    && genderRatio.maleRatio > 0 
    && genderRatio.femaleRatio == 0 
    ? allRundedClass : "left-radius-only";
});
const roundedFemaleClass = computed(() => {
  let ratioClass = 'female-ratio ';
	const genderRatio = props.pokemon.genderRatio;
  return ratioClass += 
    genderRatio 
    && genderRatio.femaleRatio > 0 
    && genderRatio.femaleRatio == 0 
    ? allRundedClass : "right-radius-only";
});

// Methods
function getWidth(ratio: number) : string {
  return ratio + '%';
}
</script>

<style scoped lang="scss">
.gender-ratio-display {
  .ratio-bar-display {
    width:100%;
    
    .left-radius-only {
      border-top-left-radius: 5px;
      border-bottom-left-radius: 5px;
    }
    .right-radius-only {
      border-top-right-radius: 5px;      
      border-bottom-right-radius: 5px;
    }
    .ratio-description-container,
    .male-ratio, 
    .female-ratio {
      float: left;
      text-align: center;      
      height: 25px;
      color:black;
      font-weight: bold;
      line-height: 25px;
      font-size: 0.8em;
    }
    .male-ratio {
      background-color: #4daceb;      
    }
    .female-ratio {
      background-color: #dca0ee;      
    }
  }
}
</style>