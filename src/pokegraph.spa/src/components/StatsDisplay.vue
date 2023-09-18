<template>
	<div class="stats-display" v-if="pokemon">
    <span class="pokemon-name">Nº{{pokemon.number}} - {{pokemon.name}}</span>
		<div class="stats-info">
			<div class="rTable">
				<div class="rTableRow">
          <div class="rTableHead"><span class="column-title">HP</span></div>
          <div class="rTableHead"><span class="column-title">Attack</span></div>
          <div class="rTableHead"><span class="column-title">Defense</span></div>
				</div>
				<div class="rTableRow">
          <div class="rTableCell">{{pokemon.baseStats?.hp}}</div>
          <div class="rTableCell">{{pokemon.baseStats?.attack}}</div>
          <div class="rTableCell">{{pokemon.baseStats?.defense}}</div>
				</div>
			</div>
			<br>
			<div class="rTable">
				<div class="rTableRow">
          <div class="rTableHead"><span class="column-title">Sp. Atk</span></div>
          <div class="rTableHead"><span class="column-title">Sp. Def</span></div>
          <div class="rTableHead"><span class="column-title">Speed</span></div>
				</div>
				<div class="rTableRow">
          <div class="rTableCell">{{pokemon.baseStats?.specialAttack}}</div>
          <div class="rTableCell">{{pokemon.baseStats?.specialDefense}}</div>
          <div class="rTableCell">{{pokemon.baseStats?.speed}}</div>
				</div>
			</div>
      <br>
      <div class="rTable">
				<div class="rTableRow">
          <div class="rTableHead"><span class="column-title">Total</span></div>
				</div>
				<div class="rTableRow">
          <div class="rTableCell">{{total}}</div>
				</div>
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
    required: false
  },
});

const total = computed(() => {
  let total = 0;
  const stats = props.pokemon?.baseStats;
  if(stats){
    Object.entries(stats).forEach(([key, value]) => {
      if(key !== "__typename") {
        total += value;
      }
    });                          
  }
  return total;
});
</script>

<style scoped lang="scss">
.stats-display {
  font-size: 1em;
  height: 250px;

  .pokemon-name {
    top: 20px;    
    font-weight: bold;
    color:black;
    position: relative;
  }
  .stats-info {
    top: 37px;
    left: 25px;    
    color:black;
    font-size: 0.9em;
    position: relative;
  }
}

.rTable {
  display: block;
  width: 100%;
}
.rTableHeading, .rTableBody, .rTableFoot, .rTableRow{
  clear: both;
}
.rTableHead, .rTableFoot{
  font-weight: bold;
}
.rTableCell, .rTableHead {
  float: left;
  text-align: left;
  height: 20px;
  overflow: hidden;  
  width: 28%;
  font-size: 1em;
}
.rTable:after {
  visibility: hidden;
  display: block;
  content: " ";
  clear: both;  
}
.column-title {
  font-weight: bold;
}
</style>