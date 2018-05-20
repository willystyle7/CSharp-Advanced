using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StringMatrixRotation
{
    class StringMatrixRotation
    {
        static void Main(string[] args)
        {
            //match degrees from input
            string firstInput = Console.ReadLine();
            string pattern = @"^Rotate\((\d+)\)$";
            Match firstMatch = Regex.Match(firstInput, pattern);
            int degrees = int.Parse(firstMatch.Groups[1].Value) % 360;            
            //enter strings and determine max length
            string input = Console.ReadLine();
            List<string> textlines = new List<string>();
            int maxLen = 0;
            while (input != "END")
            {
                textlines.Add(input);
                if (input.Length > maxLen)
                {
                    maxLen = input.Length;
                }
                input = Console.ReadLine();
            }
            //calibrate strings with padright to max length
            int rows = textlines.Count;
            for (int i = 0; i < rows; i++)
            {
                textlines[i] = textlines[i].PadRight(maxLen);
            }
            //rotate on degrees - 4 cases
            switch (degrees)
            {
                case 0:
                    for (int i = 0; i < rows; i++)
                    {
                        Console.WriteLine(textlines[i]);
                    }
                    break;
                case 90:
                    for (int i = 0; i < maxLen; i++)
                    {
                        for (int j = 0; j < rows; j++)
                        {
                            Console.Write(textlines[rows - j - 1][i]);
                        }
                        Console.WriteLine();
                    }
                    break;
                case 180:
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < maxLen; j++)
                        {
                            Console.Write(textlines[rows - i - 1][maxLen - j - 1]);
                        }
                        Console.WriteLine();
                    }
                    break;
                case 270:
                    for (int i = 0; i < maxLen; i++)
                    {
                        for (int j = 0; j < rows; j++)
                        {
                            Console.Write(textlines[j][maxLen - i - 1]);
                        }
                        Console.WriteLine();
                    }
                    break;
            }
        }
    }
}
