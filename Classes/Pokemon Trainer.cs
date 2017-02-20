//using System;
//using System.Collections.Generic;
//using System.Linq;


//public class Trainer
//{
//    public string name;
//    public int numberOfBadges;
//    List<Pokemon> pokemonCollection;
//    private string trainerName;

//    public Trainer()
//    {
//        this.name = null;
//        this.numberOfBadges = 0;
//        this.pokemonCollection = new List<Pokemon>();
//    }

//    public Trainer(string trainerName)
//    {
//        this.trainerName = trainerName;
//    }
//}
//public class Pokemon
//{
//    public string name;
//    public string element;
//    public int health;

//    public Pokemon()
//    {
//        this.name = null;
//        this.element = null;
//        this.health = 0;   
//    }
//}
//class Program
//{
//    static void Main(string[] args)
//    {
//        string input = null;
//        Trainer trainer = new Trainer();
//        Pokemon pokemon = new Pokemon();
//        Dictionary<string, Pokemon> trainerDictionary = new Dictionary<string, Pokemon>();
//        List<Trainer> trainerList = new List<Trainer>();
//        List<Pokemon> pokemonList = new List<Pokemon>();

//        //while ((input = Console.ReadLine()) != "Tournament")
//        //{
//        //    string[] inputArgs = input.Split(new char[] {}, StringSplitOptions.RemoveEmptyEntries);

//        //    trainer.name = inputArgs[0];
//        //    pokemon.name = inputArgs[1];
//        //    pokemon.element = inputArgs[2];
//        //    pokemon.health = int.Parse(inputArgs[3]);
//        //    //trainerDictionary.Add(trainer.name, pokemon);
//        //    bool trainexist = false;

//        //    if (!trainerDictionary.ContainsKey(trainer.name))
//        //    {
//        //        trainerDictionary.Add(trainer.name, pokemon);
//        //    }


//        //    //if (trainerList.Any(x=>x.name==trainer.name))
//        //    //{
//        //    //    trainerList.FirstOrDefault(x => x.name == trainer.name);
//        //    //    trainexist = true;
//        //    //}
//        //    //if (!trainexist)
//        //    //{
//        //    //    trainer
//        //    //}
//        //}
//        //while ((input = Console.ReadLine()) != "End")
//        //{
//        //    foreach (var KeyValuePair in trainerDictionary)
//        //    {

//        //    }
//        //    switch (input)
//        //    {
//        //        case "Fire":
//        //            //TODO if have at least 1 pokemon with this element >> badges++ << ifnot health-=10 .0 >>dies>>delete

//        //            break;
//        //        case "Water":
//        //            break;
//        //        case "Electricity":
//        //            break;

//        //    }
//        //}


//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
public class Trainer
{
    public Trainer(string name)
    {
        this.name = name;
        badges = 0;
        pokemons = new List<Pokemon>();
    }
    public string name;
    public int badges = 0;
    public List<Pokemon> pokemons;
}
public class Pokemon
{
    public string name;
    public string element;
    public int health;

    public Pokemon(string name, string element, int health)
    {
        this.name = name;
        this.element = element;
        this.health = health;
    }
}
class PokemonTrainer
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        List<Trainer> trainerList = new List<Trainer>();
        List<Pokemon> pokemonList = new List<Pokemon>();
        while (input != "Tournament")
        {
            string[] trainerInfo = input.Split().ToArray();
            string trainerName = trainerInfo[0];
            string pokemonName = trainerInfo[1];
            string pokemonElement = trainerInfo[2];
            int pokemonHealth = int.Parse(trainerInfo[3]);
            Pokemon tempPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            bool trainerExists = false;
            if (trainerList.Any(x => x.name == trainerName))
            {
                trainerList.FirstOrDefault(x => x.name == trainerName).pokemons.Add(tempPokemon);
                trainerExists = true;
            }
            if (trainerExists == false)
            {
                Trainer tempTrainer = new Trainer(trainerName);
                tempTrainer.pokemons.Add(tempPokemon);
                trainerList.Add(tempTrainer);
            }
            input = Console.ReadLine();
        }
        input = Console.ReadLine();
        while (input != "End")
        {
            foreach (var trainer in trainerList)
            {
                bool foundPokemon = false;
                if (trainer.pokemons.Any(x => x.element == input))
                {
                    foundPokemon = true;
                    trainer.badges++;
                }
                if (foundPokemon == false)
                {
                    foreach (var pokemon in trainer.pokemons)
                    {
                        pokemon.health -= 10;
                    }
                }
                for (int i = 0; i < trainer.pokemons.Count; i++)
                {
                    if (trainer.pokemons[i].health <= 0)
                    {
                        trainer.pokemons.Remove(trainer.pokemons[i]);
                        i--;
                    }
                }
            }
            input = Console.ReadLine();
        }
        var result = trainerList.OrderByDescending(x => x.badges);
        foreach (var trainer in result)
        {
            Console.WriteLine($"{trainer.name} {trainer.badges} {trainer.pokemons.Count}");
        }
    }
}
