using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class RageQuit
{
    static void Main()
    {
        string input = Console.ReadLine().ToUpper();
        string pattern = @"(\D+)(\d+)";
        HashSet<char> symbolsSet = new HashSet<char>();
        Match match = Regex.Match(input, pattern);
        StringBuilder result = new StringBuilder();
        while (match.Success)
        {
            string str = match.Groups[1].Value;
            int times = int.Parse(match.Groups[2].Value);
            for (int i = 1; i <= times; i++)
            {
                result.Append(str);
            }
            if (times > 0)
            {
                for (int j = 0; j < str.Length; j++)
                {
                    symbolsSet.Add(str[j]);
                }
            }
            match = match.NextMatch();
        }
        Console.WriteLine("Unique symbols used: {0}", symbolsSet.Count);
        Console.WriteLine(result.ToString());
    }
}
