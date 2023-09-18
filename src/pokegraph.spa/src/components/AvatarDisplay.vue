<template>
  <div class="avatar">
    <div  class="loading-container">
      <LoadingSpinner :loading="loading"/>
    </div>    
    <Transition name="slide-fade">
      <img v-if="pokemon.avatar && !loading"
        class="avatar-img"
        :src="pokemon.avatar"
        :title="pokemon.name">
    </Transition>
  </div>
</template>

<script lang="ts" setup>
import PokemonViewModel from '@/models/PokemonViewModel';
import LoadingSpinner from './LoadingSpinner.vue';

defineProps({
  pokemon: { 
    type: Object as () => PokemonViewModel,
    required: true
  },
  loading: { 
    type: Boolean,
    required: false
  },
});
</script>

<style scoped lang="scss">
.avatar {    
  .avatar-img {    
    max-width: 100%;
    float: left;
  }
  .loading-container {        
    top: 26%;
    left: 16%;
    position: absolute;
  }

  .slide-fade-enter-active {
    transition: all 0.9s ease-out;
  }

  .slide-fade-leave-active {
    transition: all 0.8s cubic-bezier(1, 0.5, 0.8, 1);
  }

  .slide-fade-enter-from,
  .slide-fade-leave-to {
    transform: translateX(20px);
    opacity: 0;
  }
}
</style>