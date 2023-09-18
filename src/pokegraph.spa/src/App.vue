<template>
  <div class="header">
    <div class="header-logo">
      <img src="./assets/pokegraph-logo.png" class="logo" />
    </div>
    <div class="search-box-container">
      <SearchBox
        :currentPokemonNumber="variables.number"
        @setPokemonByNumber="setPokemonByNumber"
      />
    </div>
  </div>
  <div class="main-container">
    <div class="main-device-container">
      <MainDevice
        :pokemon="pokemon"
        :loading="loading"
        :totalDiscovered="totalDiscovered"
      />
    </div>
    <div class="disclaimer-container">
      <p>
        Pokémon is © 1995-present Nintendo, The Pokémon Company, Game Freak, Creatures Inc.
        <br/>This project does not claim to own any characters, concepts or artwork.
      </p>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { eventEmitter } from '@/main';
import { computed, onMounted, reactive } from 'vue';
import { useQuery } from '@vue/apollo-composable'
import { listPokemon, pokemonByNumber } from './graphql/queries';
import PokemonViewModel from '@/models/PokemonViewModel';
import MainDevice from '@/components/MainDevice.vue';
import watchSubscriptions from '@/composables/watchSubscriptions';
import SearchBox from '@/components/SearchBox.vue';
import useToastNotification, { ToastMessageType } from './composables/useToast';

const variables = reactive({
  number: 1,
});

// Query results
const { result: listPokemonResult, loading } = useQuery(listPokemon);
const { result: pokemonByNumberResult } = useQuery(pokemonByNumber, variables);

onMounted(() => {
  watchSubscriptions();
  subscribeToNotifications();
  subscribeJoysticEvents();
});

// METHODS
function subscribeToNotifications() {
  // notifications
  eventEmitter.on('onListedPokemon', (data: any) => {       
    useToastNotification(ToastMessageType.Info,
      `There are ${data.onListedPokemon.toString()} Pokemon discovered!`);
  });
  eventEmitter.on('onInsertedPokemon', (data: any) => {
    const pokemonVM = data.onInsertedPokemon as PokemonViewModel;    
    useToastNotification(ToastMessageType.Success,
      `${pokemonVM.name} - nº ${pokemonVM.number} was discovered!`);

    setPokemonByNumber(pokemonVM.number);
  });
  eventEmitter.on('onUpdatedPokemon', (data: any) => {
    const pokemonVM = data.onUpdatedPokemon as PokemonViewModel;    
    useToastNotification(ToastMessageType.Success,
      `${pokemonVM.name} - nº ${pokemonVM.number} was updated!`);

    setPokemonByNumber(pokemonVM.number);
  });
}

function subscribeJoysticEvents() {
  eventEmitter.on('onPokemonNumberChanged', (pokemonNumber: any) => {       
    setPokemonByNumber(pokemonNumber);
  });
}

function setPokemonByNumber(pokemonNumber: string | number = variables.number) {
  variables.number = Number(pokemonNumber);
}

// COMPUTED
const pokemon = computed(() => 
  pokemonByNumberResult.value?.pokemonByNumber 
    ?? new Object as () => PokemonViewModel);
const totalDiscovered = computed(() => 
  listPokemonResult.value?.listPokemon?.length );

</script>

<style lang="scss">
#app {
  font-family: 'Lucida Sans Unicode';
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  display: flex;
  flex-direction: column;  
}
.logo {  
  height: 150px;
}
.header {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}
.header-logo {
  width: 95%;  
}

.search-box-container {
  width: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  margin-top: 1rem; 
}

.main-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  flex: 1;
}

.main-device-container {  
  width: 100%;
  max-width: 1024px;
  margin-top: 3rem;
  min-height: 500px;
}
.disclaimer-container {  
  width: 100%;
  max-width: 1024px;
  margin-top: 3rem;
  margin-left: 5rem;
  font-size: 11pt;
}
</style>