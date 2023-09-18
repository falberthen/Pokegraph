import { createApp } from 'vue';
import { DefaultApolloClient } from '@vue/apollo-composable';
import { ApolloClient, HttpLink, InMemoryCache, split } from '@apollo/client/core';
import { WebSocketLink } from "@apollo/client/link/ws";
import { getMainDefinition } from '@apollo/client/utilities';
import { onError } from '@apollo/client/link/error';
import Toast from "vue-toastification";
import "vue-toastification/dist/index.css";
import App from './App.vue';
import useToastNotification, { ToastMessageType } from './composables/useToast';
import mitt from 'mitt';

interface Definition {
  kind: string
  operation?: string
}

// http link
const httpLink = new HttpLink({  
  uri: 'https://localhost:7221/graphql',
})
// subscription websocket link
const wsLink = new WebSocketLink({
  uri: "wss://localhost:7221/graphql",
  options: {
    reconnect: true,
  },
})

// error link
const errorLink = onError(({ graphQLErrors, networkError }) => {
  if (graphQLErrors) {
    graphQLErrors.map(({ extensions, message, locations, path }) => {
      const extensionMessage = extensions.message as string;
      useToastNotification(ToastMessageType.Error, extensionMessage);
      console.log(
          `[GraphQL error]: Message: ${message}, Location: ${locations}, Path: ${path}`,
        );
    });
  }

  if (networkError) 
    console.log(`[Network error]: ${networkError}`);
})

// Apollo link
const link = split(
  // split based on operation type
  ({ query }) => {
    const { kind, operation }: Definition = getMainDefinition(query)
    return kind === "OperationDefinition" && operation === "subscription"
  },
  wsLink,  
  httpLink
)

// Create the apollo client
const apolloClient = new ApolloClient({
  link: errorLink.concat(link),
  cache: new InMemoryCache(),
  connectToDevTools: true,
  defaultOptions: {
    query: {
      errorPolicy: 'all',
    },
    mutate: {
      errorPolicy: 'all',
    }
  },
});

const app = createApp(App);
const eventEmitter = mitt();
app.provide(DefaultApolloClient, apolloClient);
app.use(Toast, {
  transition: "Vue-Toastification__bounce",
  maxToasts: 20,
  newestOnTop: true
});
app.mount('#app');

export { eventEmitter };