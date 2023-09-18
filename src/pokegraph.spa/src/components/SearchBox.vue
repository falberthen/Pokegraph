<template>
  <div class="searchbox">
    <input type="text" 
      v-model="pokemonNumber" 
      @keyup.enter="setPokemonByNumber"
      class="search-box-input"/>
      <span class="search-icon" @click="setPokemonByNumber" title="Search">
        🔎
      </span>
  </div>
</template>

<script lang="ts" setup>
import { ref } from 'vue'

const emits = defineEmits(['setPokemonByNumber']);
const pokemonNumber = ref<number>();
defineProps({
  currentPokemonNumber: Number
});

function setPokemonByNumber(){
  emits("setPokemonByNumber", pokemonNumber.value);    
}
</script>

<style scoped lang="scss">
.searchbox {  
  .search-box-input {
    font-size: 1.5em;
    width:70px;
    height:35px;
    text-align: center;
  }
  .search-icon {
    font-size: 30px;
    cursor: pointer;    
  }
}
</style>