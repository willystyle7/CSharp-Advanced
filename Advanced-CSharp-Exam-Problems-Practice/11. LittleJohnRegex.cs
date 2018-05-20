using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class LittleJohnRegex
{
    static void Main()
    {
        // declarations
        const int N = 4;

        string arrowMatcher = "(>>>----->>)|(>>----->)|(>----->)";
        Regex rgx = new Regex(arrowMatcher);

        // input
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < N; i++)
        {
            sb.AppendFormat(" {0}", Console.ReadLine());
        }

        // matching arrows
        var arrows = rgx.Matches(sb.ToString());

        // count the arrows
        int smallAraowsCount = 0;
        int mediumArrowCount = 0;
        int largeArrowsCount = 0;

        foreach (Match match in arrows)
        {
            if (!string.IsNullOrEmpty(match.Groups[1].Value))
            {
                largeArrowsCount++;
            }
            else if (!string.IsNullOrEmpty(match.Groups[2].Value))
            {
                mediumArrowCount++;
            }
            else
            {
                smallAraowsCount++;
            }
        }

        // numbers of arrows -> string   
        string numberAsString = String.Format("{0}{1}{2}", smallAraowsCount, mediumArrowCount, largeArrowsCount);

        // -> int
        int decNumber = int.Parse(numberAsString);

        // -> binary + reversed binary
        string binNumber = Convert.ToString(decNumber, 2);
        string reversedBin = new string(binNumber.Reverse().ToArray());
        string totalBin = binNumber + reversedBin;

        // -> int
        int result = Convert.ToInt32(totalBin, 2);

        // print
        Console.WriteLine(result);
    }
}