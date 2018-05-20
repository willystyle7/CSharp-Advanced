using System;
using System.Text.RegularExpressions;

class SumOfAllValues
{
    static void Main()
    {
        string keysString = Console.ReadLine();
        string textString = Console.ReadLine();
        string startKey = string.Empty;
        string endKey = string.Empty;
        string patternStartKey = @"^([A-Za-z_]+)\d+";
        string patternEndKey = @"\d+([A-Za-z_]+)$";
        startKey = Regex.Match(keysString, patternStartKey).Groups[1].Value;
        endKey = Regex.Match(keysString, patternEndKey).Groups[1].Value;
        if (startKey == string.Empty || endKey == string.Empty)
        {
            Console.WriteLine("<p>A key is missing</p>");
            return;
        }
        string pattern = startKey + "(.*?)" + endKey;
        MatchCollection matches = Regex.Matches(textString, pattern);
        double sum = 0.0;
        foreach (Match match in matches)
        {
            string value = match.Groups[1].Value;
            double valueDouble = 0.0;
            if (double.TryParse(value, out valueDouble))
            {
                sum += valueDouble;
            }
        }
        Console.WriteLine("<p>The total value is: <em>{0}</em></p>", sum == 0.0 ? "nothing" : sum.ToString());
    }
}

