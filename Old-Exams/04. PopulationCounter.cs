using System;
using System.Collections.Generic;
using System.Linq;

class PopulationCounter
{
    static void Main()
    {
        string input = Console.ReadLine();
        Dictionary<string, Dictionary<string, long>> populationCounter = new Dictionary<string, Dictionary<string, long>>();
        while (input != "report")
        {
            string[] token = input.Split('|');
            string city = token[0];
            string country = token[1];
            long population = long.Parse(token[2]);
            if (!populationCounter.ContainsKey(country))
            {
                populationCounter.Add(country, new Dictionary<string, long>());
            }
            populationCounter[country].Add(city, population);
            input = Console.ReadLine();
        }
        foreach (var country in populationCounter.OrderByDescending(c => c.Value.Values.Sum()))
        {
            Console.WriteLine("{0} (total population: {1})", country.Key, country.Value.Values.Sum());
            foreach (var city in country.Value.OrderByDescending(c => c.Value))
            {
                Console.WriteLine("=>{0}: {1}", city.Key, city.Value);
            }
        }
    }
}