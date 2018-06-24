using System;
using System.Linq;

class BunkerBuster
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int rows = int.Parse(input[0]);
        int columns = int.Parse(input[1]);
        int[,] bunker = new int[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            int[] token = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int j = 0; j < columns; j++)
            {
                bunker[i, j] = token[j];
            }
        }
        string input2 = Console.ReadLine();
        while (input2 != "cease fire!")
        {
            string[] token2 = input2.Split();
            int row = int.Parse(token2[0]);
            int column = int.Parse(token2[1]);
            int strength = (int)token2[2][0];
            int halfStrength = strength / 2 + strength % 2;
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = column - 1; j <= column + 1; j++)
                {
                    if (i >= 0 && j >= 0 && i < rows && j < columns)
                    {
                        bunker[i, j] -= halfStrength;
                    }
                }
            }
            bunker[row, column] -= (halfStrength - strength % 2);
            input2 = Console.ReadLine();
        }
        int destroyed = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (bunker[i, j] <= 0) destroyed++;
            }
        }
        Console.WriteLine("Destroyed bunkers: {0}", destroyed);
        Console.WriteLine("Damage done: {0:F1} %", (double)destroyed * 100 / (rows * columns));
    }
}