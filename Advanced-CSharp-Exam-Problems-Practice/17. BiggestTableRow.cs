using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class BiggestTableRow
{
    static void Main()
    {
        string input = Console.ReadLine();
        input = Console.ReadLine();        
        double maxSum = double.MinValue;
        string store1 = "";
        string store2 = "";
        string store3 = "";
        string maxStore1 = "";
        string maxStore2 = "";
        string maxStore3 = "";
        while ((input = Console.ReadLine()) != "</table>")
        {
            string pattern = @"<td>([0-9\.\-]+?)<\/td><td>([0-9\.\-]+?)<\/td><td>([0-9\.\-]+?)<\/td>";
            Match match = Regex.Match(input, pattern);
            store1 = match.Groups[1].Value;
            store2 = match.Groups[2].Value;
            store3 = match.Groups[3].Value;
            double number1 = store1 == "-" ? 0.0 : double.Parse(store1);
            double number2 = store2 == "-" ? 0.0 : double.Parse(store2);
            double number3 = store3 == "-" ? 0.0 : double.Parse(store3);
            double sum = number1 + number2 + number3;
            if (sum > maxSum)
            {
                maxSum = sum;
                maxStore1 = store1;
                maxStore2 = store2;
                maxStore3 = store3;
            }
        }
        if (maxStore1 == "-" && maxStore2 == "-" && maxStore3 == "-")
        {
            Console.WriteLine("no data");
        }
        else
        {
            List<string> numbers = new List<string>();
            if (maxStore1 != "-") numbers.Add(maxStore1);
            if (maxStore2 != "-") numbers.Add(maxStore2);
            if (maxStore3 != "-") numbers.Add(maxStore3);
            Console.Write("{0} = {1}", maxSum, string.Join(" + ", numbers));
        }
    }
}
