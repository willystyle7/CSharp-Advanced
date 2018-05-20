using System;
using System.Collections.Generic;
using System.Security;

namespace ClearingCommands
{
    class ClearingCommands
    {
        static void Main()
        {
            string commands = "<>^v";
            string input = Console.ReadLine();
            List<string> lines = new List<string>();
            while (input != "END")
            {
                lines.Add(input);
                input = Console.ReadLine();
            }
            char[,] matrix = new char[lines.Count, lines[0].Length];
            int i = 0;
            foreach (string line in lines)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = line[j];
                }
                i++;
            }
            for (i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    switch (matrix[i, j])
                    {
                        case '>':
                            int k = j + 1;
                            while (k < matrix.GetLength(1))
                            {
                                if (!commands.Contains(matrix[i, k].ToString()))
                                {
                                    matrix[i, k] = ' ';
                                }
                                else
                                {
                                    break;
                                }
                                k++;
                            }
                            break;
                        case '<':
                            k = j - 1;
                            while (k >= 0)
                            {
                                if (!commands.Contains(matrix[i, k].ToString()))
                                {
                                    matrix[i, k] = ' ';
                                }
                                else
                                {
                                    break;
                                }
                                k--;
                            }
                            break;
                        case '^':
                            k = i - 1;
                            while (k >= 0)
                            {
                                if (!commands.Contains(matrix[k, j].ToString()))
                                {
                                    matrix[k, j] = ' ';
                                }
                                else
                                {
                                    break;
                                }
                                k--;
                            }
                            break;
                        case 'v':
                            k = i + 1;
                            while (k < matrix.GetLength(0))
                            {
                                if (!commands.Contains(matrix[k, j].ToString()))
                                {
                                    matrix[k, j] = ' ';
                                }
                                else
                                {
                                    break;
                                }
                                k++;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            for (i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("<p>");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(SecurityElement.Escape(matrix[i, j].ToString()));
                }
                Console.WriteLine("</p>");
            }
        }
    }
}