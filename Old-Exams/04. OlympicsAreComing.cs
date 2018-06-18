using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class OlympicsAreComing
{
    static void Main()
    {
        string input = Console.ReadLine();
        Dictionary<string, Dictionary<string, int>> statistic = new Dictionary<string, Dictionary<string, int>>();
        while (input != "report")
        {
            string[] token = input.Split('|');
            string name = token[0].Trim();
            name = Regex.Replace(name, "\\s+", " ");
            string country = token[1].Trim();
            country = Regex.Replace(country, "\\s+", " ");
            if (statistic.ContainsKey(country))
            {
                if (!statistic[country].ContainsKey(name))
                {
                    statistic[country].Add(name, 0);
                }
                statistic[country][name]++;
            }
            else
            {
                statistic.Add(country, new Dictionary<string, int>());
                statistic[country].Add(name, 1);
            }
            input = Console.ReadLine();
        }
        foreach (var country in statistic.OrderByDescending(x => x.Value.Values.Sum()))
        {
            Console.WriteLine("{0} ({1} participants): {2} wins", country.Key, country.Value.Count, country.Value.Values.Sum());
        }
    }
}