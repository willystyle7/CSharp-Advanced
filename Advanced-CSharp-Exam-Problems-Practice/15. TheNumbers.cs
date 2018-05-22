using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

class TheNumbers
{
    static void Main()
    {
        string message = Console.ReadLine();
        string pattern = @"\d+";
        MatchCollection matches = Regex.Matches(message, pattern);        
       
        //1 way
        //List<string> hexNumbers = new List<string>();
        //foreach (Match match in matches)
        //{
        //    int number = int.Parse(match.Value);
        //    string hexNumber = "0x" + Convert.ToString(number, 16).PadLeft(4, '0').ToUpper();
        //    hexNumbers.Add(hexNumber);
        //}
        
        //2 way
        List<string> hexNumbers = (from Match match in matches select String.Format("0x{0}", int.Parse(match.Value).ToString("X4"))).ToList();

        //3 way
        //List<string> hexNumbers = matches.Cast<Match>().Select(n => String.Format("0x{0}", int.Parse(n.Value).ToString("X4"))).ToList();

        Console.WriteLine(string.Join("-", hexNumbers));
    }
}

