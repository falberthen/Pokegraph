import { gql } from "@apollo/client/core";

export const onListedPokemon= gql`
subscription{
  onListedPokemon
}
`;

export const onInsertedPokemon= gql`
subscription{
  onInsertedPokemon{
    number
    name
  }
}
`;

export const onUpdatedPokemon= gql`
subscription{
  onUpdatedPokemon{
    number
    name
  }
}
`;