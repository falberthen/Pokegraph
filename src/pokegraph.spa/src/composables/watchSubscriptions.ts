import { watch } from 'vue';
import { eventEmitter } from '@/main';
import { useSubscription } from '@vue/apollo-composable';
import { onListedPokemon, onInsertedPokemon, onUpdatedPokemon } from '@/graphql/subscriptions';

export default function watchSubscriptions() {  
  const onListedPokemonResult = useSubscription(onListedPokemon).result;
  const onInsertedPokemonResult = useSubscription(onInsertedPokemon).result;
  const onUpdatedPokemonResult = useSubscription(onUpdatedPokemon).result;

  // Watch for changes in subscription results and emit events accordingly
  watch(onListedPokemonResult, () => {
    if (onListedPokemonResult.value) {
      eventEmitter.emit('onListedPokemon', onListedPokemonResult.value);
    }
  });

  watch(onInsertedPokemonResult, () => {
    if (onInsertedPokemonResult.value) {
      eventEmitter.emit('onInsertedPokemon', onInsertedPokemonResult.value);
    }
  });

  watch(onUpdatedPokemonResult, () => {
    if (onUpdatedPokemonResult.value) {
      eventEmitter.emit('onUpdatedPokemon', onUpdatedPokemonResult.value);
    }
  });
}
