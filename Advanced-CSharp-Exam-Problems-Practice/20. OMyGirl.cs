using System;
using System.Text.RegularExpressions;

class OMyGirl
{
    static void Main()
    {
        string key = Console.ReadLine();
        string pattern = @"";
        pattern = "(" + Regex.Escape(key[0].ToString());
        for (int i = 1; i < key.Length - 1; i++)
        {
            char currentChar = key[i];
            if (char.IsDigit(currentChar))
            {
                pattern += "[0-9]*";
            }
            else if (char.IsLower(currentChar))
            {
                pattern += "[a-z]*";
            }
            else if (char.IsUpper(currentChar))
            {
                pattern += "[A-Z]*";
            }
            else
            {
                pattern += Regex.Escape(currentChar.ToString());
            }
        }
        pattern += Regex.Escape(key[key.Length - 1].ToString()) + ")";
        pattern = pattern + "(.{2,6})" + pattern;
        string input;
        string result = string.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                result += match.Groups[2].Value;
            }
        }
        Console.WriteLine(result);
    }
}

