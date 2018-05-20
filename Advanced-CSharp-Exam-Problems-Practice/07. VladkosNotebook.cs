using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class VladkosNotebook
{
    static void Main()
    {
        Dictionary<string, Player> players = new Dictionary<string, Player>();
        string input = Console.ReadLine();
        while (input != "END")
        {
            string[] token = input.Split('|');
            string color = token[0];
            string property = token[1];
            string value = token[2];
            if (players.ContainsKey(color))
            {
                Player player = players[color];
                switch (property)
                {
                    case "name":
                        player.Name = value;
                        break;
                    case "age":
                        player.Age = int.Parse(value);
                        break;
                    case "win":
                        player.Wins++;
                        player.Opponents.Add(value);
                        break;
                    case "loss":
                        player.Losses++;
                        player.Opponents.Add(value);
                        break;
                }
                players[color] = player;
            }
            else
            {
                Player player = new Player();
                player.Name = "";
                player.Age = 0;
                player.Wins = 0;
                player.Losses = 0;
                player.Opponents = new List<string>();
                switch (property)
                {
                    case "name":
                        player.Name = value;
                        break;
                    case "age":
                        player.Age = int.Parse(value);
                        break;
                    case "win":
                        player.Wins = 1;
                        player.Opponents.Add(value);
                        break;
                    case "loss":
                        player.Losses = 1;
                        player.Opponents.Add(value);
                        break;
                }
                players.Add(color, player);
            }

            input = Console.ReadLine();
        }
        players = players.Where(p => p.Value.Name != "" && p.Value.Age > 0).OrderBy(n => n.Key).ToDictionary(x => x.Key, y => y.Value);
        if (players.Count == 0)
        {
            Console.WriteLine("No data recovered.");
        }
        else
        {
            foreach (var player in players)
            {
                Console.WriteLine("Color: {0}", player.Key);
                Console.WriteLine("-age: {0}", player.Value.Age);
                Console.WriteLine("-name: {0}", player.Value.Name);
                string[] sortedOpponents = player.Value.Opponents.ToArray();
                Array.Sort(sortedOpponents, StringComparer.Ordinal);
                Console.WriteLine("-opponents: {0}", (player.Value.Opponents.Count == 0) ? "(empty)" : string.Join(", ", sortedOpponents));
                Console.WriteLine("-rank: {0:F2}", player.Value.Rank());
            }
        }
    }
}

class Player
{
    public string Name { get; set; }
    public int Age { get; set; }
    public List<string> Opponents { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }
    public double Rank()
    {
        double rank = ((double)this.Wins + 1) / ((double)this.Losses + 1);
        return rank;
    }
}