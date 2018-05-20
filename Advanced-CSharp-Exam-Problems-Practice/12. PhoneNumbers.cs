using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class PhoneNumbers
{
    static void Main()
    {
        string input = Console.ReadLine();
        Dictionary<string, string> phoneBook = new Dictionary<string, string>();
        string pattern = @"([A-Z]+[A-Za-z]*)[^A-Za-z0-9+]*([+]?[0-9]+[0-9()\/.\-\s]*[0-9]+)";
        string allInput = "";
        while (input != "END")
        {
            allInput += input;
            input = Console.ReadLine();
        }
        MatchCollection allMatches = Regex.Matches(allInput, pattern);
        foreach (Match match in allMatches)
        {
            string name = match.Groups[1].Value;
            string phone = match.Groups[2].Value;
            phone = Regex.Replace(phone, @"[()\s\/.\-]*", "");
            if (!phoneBook.ContainsKey(name))
            {
                phoneBook.Add(name, "");
            }
            phoneBook[name] = phone;
        }
        string result = "";
        if (phoneBook.Count > 0)
        {
            result = "<ol>";
            foreach (KeyValuePair<string, string> user in phoneBook)
            {
                result += "<li><b>" + user.Key + ":</b> " + user.Value + "</li>";
            }
            result += "</ol>";
        }
        else
        {
            result = "<p>No matches!</p>";
        }
        Console.WriteLine(result);
    }
}

