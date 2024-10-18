using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PokemonParty : MonoBehaviour
{
    [SerializeField] List<Pokemon> pokemons;

    public List<Pokemon> Pokemons {  get { return pokemons; } }

    private void Start()
    {
        foreach (var pokemon in pokemons)
        {
            pokemon.Initialisation();
        }
    }

    public Pokemon GetHealthyPokemon()
    {
        return pokemons.Where(x => x.HP > 0).FirstOrDefault(); //returns the first non-fainted pokemon in player's party list
    }
}
