using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

public class Pizza
{
    public string name;
    public int group;

    public Pizza(string name, int group)
    {
        this.name = name;
        this.group = group;
    }
    public static SortedDictionary<int, List<string>> PizzaGroup(params Pizza[] pizzas)
    {
        SortedDictionary<int, List<string>> groupPizza = new SortedDictionary<int, List<string>>();
        foreach (Pizza pizza in pizzas)
        {
            if (!groupPizza.ContainsKey(pizza.group))
            {
                groupPizza.Add(pizza.group, new List<string>());
            }
            groupPizza[pizza.group].Add(pizza.name);
        }
        return groupPizza;
    }
}
class PizzaTime
{
    
    static void Main(string[] args)
    {
        MethodInfo[] methods = typeof(Pizza).GetMethods();
        bool containsMethod = methods.Any(m => m.ReturnType.Name.Contains("SortedDictionary"));
        if (!containsMethod)
        {
            throw new Exception();
        }

        string[] input = Console.ReadLine().Split();//4Peperoni 2Margarita 2RunningChiken 4DonVito
        Pizza[] pizzas = new Pizza[input.Length];
        string pattern = @"(\d+)(\w+)";
        Regex rgx = new Regex(pattern);
        for (int i = 0; i < input.Length; i++)
        {
            Match match = rgx.Match(input[i]);
            int pizzaGroup = int.Parse(match.Groups[1].Value);
            string pizzaName = match.Groups[2].Value;
            Pizza myPizza = new Pizza(pizzaName, pizzaGroup);
            pizzas[i] = myPizza;
        }
        var result = Pizza.PizzaGroup(pizzas);
        foreach (var grouppizza in result)
        {
            Console.Write($"{grouppizza.Key} - ");
            Console.WriteLine(string.Join(", ", grouppizza.Value));
        }
    }
}

