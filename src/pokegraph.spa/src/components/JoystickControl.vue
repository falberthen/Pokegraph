<template>
  <div class="joystick-control">
    <div class="joystick-top">
      <div @click="goUp" 
        class="joystick-button goUpButton" title="Evolutions" alt="Evolutions">
      </div>
    </div>       
    <div class="joystick-middle">
      <div @click="goLeft" 
        class="joystick-button goLeftButton" title="Go back" alt="Go back">
      </div>
      <div @click="goRight" 
        class="joystick-button goRightButton" title="Go forward" alt="Go forward">
      </div>
    </div>
    <div class="joystick-bottom">
      <div @click="goDown" 
        class="joystick-button goDownButton" title="Pre evolutions" alt="Pre evolutions">
      </div>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { eventEmitter } from '@/main';
import PokemonViewModel from '@/models/PokemonViewModel';

const props = defineProps({
  pokemon: { 
    type: Object as () => PokemonViewModel,
    required: true
  },
  totalDiscovered: { 
    type: Number,
    required: true
  },
});

function goUp(){
  const hasEvolutions = props.pokemon 
    && props.pokemon?.evolvesTo?.number;

  if(hasEvolutions) {
    eventEmitter.emit("onPokemonNumberChanged", 
      props.pokemon?.evolvesTo?.number);    
  }
}
function goLeft(){  
  const previousPokemon =  props.pokemon.number > 1 
    ? props.pokemon.number -1 : 1;
    eventEmitter.emit("onPokemonNumberChanged", 
    previousPokemon);
}
function goRight(){
  const nextPokemon = props.pokemon.number + 1;
  if(nextPokemon <= props.totalDiscovered){
    eventEmitter.emit("onPokemonNumberChanged", 
    nextPokemon); 
  }
}
function goDown(){
  const hasPreEvolutions = props.pokemon 
    && props.pokemon?.evolvesFrom?.length > 0;

  if(hasPreEvolutions) {    
    eventEmitter.emit('onPokemonNumberChanged', 
    props.pokemon?.evolvesFrom[0].number);
  }
}
</script>

<style scoped lang="scss">
.joystick-control {  
  .joystick-button {      
    width: 27px;
    height:27px;
    padding: 0;
    cursor:pointer;
  }

  .joystick-top {
    width: 100%;
    .goUpButton {     
      margin-left:35%;
    }
  }        
  .joystick-middle {
    width: 100%;
    height: 27px;
    .goLeftButton {
      float: left;
    }
    .goRightButton {          
      float: right;
    }
  }        
  .joystick-bottom {
    width: 100%;
    .goDownButton {
      margin-left:35%;
    }
  }
}
</style>