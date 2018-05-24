using System;
using System.Collections.Generic;

class Parachute
{
    static void Main()
    {
        List<string> lines = new List<string>();
        string input;
        int startRow = 0;
        int startCol = 0;
        int row = 0;
        while ((input = Console.ReadLine()) != "END")
        {
            if (input.Contains("o"))
            {
                startRow = row;
                startCol = input.IndexOf('o');
            }
            lines.Add(input);
            row++;
        }
        int nextCol = startCol;
        int nextRow = startRow + 1;
        for (int i = startRow; i < lines.Count - 1; i++)
        {
            int countLeftWind = lines[i + 1].Length - lines[i + 1].Replace("<", "").Length;
            int countRightWind = lines[i + 1].Length - lines[i + 1].Replace(">", "").Length;
            nextCol = nextCol - countLeftWind + countRightWind;
            nextRow = i + 1;
            if (lines[nextRow][nextCol] == '/' || lines[nextRow][nextCol] == '\\' || lines[nextRow][nextCol] == '~' || lines[nextRow][nextCol] == '_')
            {
                switch (lines[nextRow][nextCol])
                {
                    case '/':
                    case '\\':
                        Console.WriteLine("Got smacked on the rock like a dog!");
                        break;
                    case '~':
                        Console.WriteLine("Drowned in the water like a cat!");
                        break;
                    case '_':
                        Console.WriteLine("Landed on the ground like a boss!");
                        break;
                }
                break;
            }
        }
        Console.WriteLine("{0} {1}", nextRow, nextCol);
    }
}