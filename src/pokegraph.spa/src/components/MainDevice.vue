<template>
  <div class="main-device">
    <div v-if="pokemon" class="containers-wrapper">
      <div class="left-container">
        <div class="physical-attr-display-container">
          <AttributesDisplay :pokemon="pokemon"/>
        </div>
        <div class="gender-ratio-display-container">
          <GenderRatioDisplay :pokemon="pokemon"/>
        </div>
      </div>
      <div class="center-container">
        <div class="legendary-display-container">
          <LegendaryDisplay :pokemon="pokemon" />
        </div>
        <div class="avatar-container">
          <AvatarDisplay :pokemon="pokemon" :loading="loading" />
        </div>
        <div class="type-display-container">
          <TypeDisplay :pokemon="pokemon" />
        </div>
        <div class="joystick-container">
          <JoystickControl 
            :pokemon="pokemon"
            :totalDiscovered="totalDiscovered" />
        </div>
      </div>
      <div class="right-container">
        <div class="stats-display-container">
          <StatsDisplay :pokemon="pokemon" />
        </div>
      </div>      
    </div>
  </div>
</template>

<script lang="ts" setup>
import JoystickControl from './JoystickControl.vue';
import AvatarDisplay from './AvatarDisplay.vue';
import StatsDisplay from './StatsDisplay.vue';
import TypeDisplay from './TypeDisplay.vue';
import AttributesDisplay from './AttributesDisplay.vue';
import GenderRatioDisplay from './GenderRatioDisplay.vue';
import LegendaryDisplay from './LegendaryDisplay.vue';
import PokemonViewModel from '@/models/PokemonViewModel';

defineProps({
  pokemon: { 
    type: Object as () => PokemonViewModel,
    required: true
  },
  loading: { 
    type: Boolean,
    required: true
  },
  totalDiscovered: { 
    type: Number,
    required: true
  },
});
</script>

<style scoped lang="scss">
.main-device {    
  margin-left: 10%;
  min-width: 1024px;
  min-height: 70vh;
  background-repeat: no-repeat;
  background-image: url("../assets/pokedex-template.png");
  background-size: 70%;
  position: absolute;

  .containers-wrapper {
    display: flex;
    align-items: flex-start;
    width: 100%;
    height: 530px;    

    .left-container {
      flex-direction: column;
      flex: 1;
      max-width: 15%;
      height: 530px;
  
      .physical-attr-display-container {
        margin-left: 37%;
        margin-top: 95%;
        height: 135px;
        text-align: left;
      }
      .gender-ratio-display-container {
        width: 55%;
        margin-top: 2.5%;
        margin-left: 40%;
      }
    }

    .center-container {
      display: flex;
      flex-direction: column;
      flex: 1;
      max-width: 18%;
      height: 530px;

      .legendary-display-container {
        margin-top: 73%;        
        margin-left: 17%;
        height: 20px;       
      }
      .avatar-container {
        width: 82%;
        height: 165px;
      }
      .type-display-container {        
        width: 83%;
        margin-top: 1%;
      }
      .joystick-container {  
        margin-top:18%;
        margin-left:43%;
        width:90px;
        height:90px;
      }
    }

    .right-container {
      display: flex;
      flex-direction: column;
      flex: 1;
      max-width: 37%;
      height: 530px;

      .stats-display-container {
        margin-top: 36%;
        margin-left:20%;
      }
    }
  } 
}
</style>