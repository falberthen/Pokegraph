![Build](https://github.com/falberthen/pokegraph/actions/workflows/pokegraph.yml/badge.svg)
[![License](https://img.shields.io/github/license/falberthen/pokegraph.svg)](LICENSE)

# Pokégraph - .NET 7, GraphQL, HotChocolate and Vue 3 (composition API)

<p align="center">
  <br />
<img src="https://github.com/falberthen/pokegraph/blob/master/src/pokegraph.spa/src/assets/pokegraph-logo.png?raw=true"/>
</p>

Pokégraph is my showcase of building a GraphQL-based API with .NET 7, front-ended by a very lightweight SPA built with Vue 3 (composition API) and Apollo.
It comes with an SQLite database loaded with 151 monsters but also allows you to perform queries for listing and mutations for adding or updating the existing ones.

<p>
	Pokémon is © 1995-present Nintendo, The Pokémon Company, Game Freak, Creatures Inc.
	<br/>This project does not claim to own any characters, concepts or artwork.
</p>

<br>

## Screenshots
<img src="https://github.com/falberthen/pokegraph/blob/master/src/pokegraph.spa/images/pokegraph.gif" target="_blank"/>

<img src="https://github.com/falberthen/pokegraph/blob/master/src/pokegraph.spa/images/pokegraph-search.gif" target="_blank"/>

#### Mutations

<img src="https://github.com/falberthen/pokegraph/blob/master/src/pokegraph.spa/images/pokegraph-mutation.png" target="_blank"/>

<img src="https://github.com/falberthen/pokegraph/blob/master/src/pokegraph.spa/images/pokegraph-mutation.gif" target="_blank"/>

<br/>

## Architecture 

### Domain
This is where the domain models and business logic are defined. You may understand a bit more about the Pokémon domain by reading the code and understanding how the smaller pieces compose the aggregate.
<br/>

### Api
A .NET 7 minimal API implementing GraphQL server to perform Queries, Mutations, and Subscriptions. It's in charge of using the infrastructure to perform database operations and return mapped ViewModels to the frontend.
<br/>

### Infrastructure
Implements the database configuration and repositories. Also contains the `PokegraphDb` SQLite database with the 151 first Pokémon and their data for you to play.
<br/>

<br>

## Technologies used

Backend
<ul>
	<li><a href='https://dotnet.microsoft.com/en-us/download/dotnet/7.0' target="_blank">.NET 7</a> and 
	<a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx' target="_blank">C# 10</a></li>
	<li>.NET 7</li>
	<li>Entity Framework Core 7.0.11</li>
	<li>EntityFrameworkCore.Sqlite 7.0.11</li>
	<li>Automapper 12.0.1</li>
	<li>HotChocolate 13.5.1</li>
</ul>
<br>
Frontend
<ul>
	<li><a href='https://vuejs.org/' target="_blank">Vue 3</a> and <a href='http://www.typescriptlang.org/' target="_blank">TypeScript</a></li>
	<li><a href='https://apollo.vuejs.org/' target="_blank">Vue Apollo</a></li>
	<li><a href='https://www.npmjs.com/package/vue-toast-notification/' target="_blank">Toast for Vue</a></li>
</ul>

<br/>


## What do you need to run it

- The latest <a href="https://dotnet.microsoft.com/download" target="_blank">.NET Core SDK</a>.
- <a href='https://nodejs.org' target="_blank">NodeJs</a> for the frontend.

#### Running the GraphQL Api
    
Navigate to `Pokegraph.Api` folder and run:
```console
 $ dotnet run
``` 

#### Running the Vue 3 SPA
    
Navigate to `pokegraph.spa` and run for the node packages and serving the SPA on `http://localhost:8080` respectively:

```console
 $ npm install
 $ npm run serve
```
