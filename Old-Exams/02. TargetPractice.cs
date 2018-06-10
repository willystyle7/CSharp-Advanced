using System;
using System.Linq;

class TargetPractice
{
    static void Main()
    {
        int[] token = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = token[0];
        int columns = token[1];
        string snake = Console.ReadLine();
        int[] token2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int impactRow = token2[0];
        int impactColumn = token2[1];
        int radius = token2[2];
        char[,] matrix = new char[rows, columns];
        //fill matrix
        string direction = "left";
        int k = 0;
        for (int i = rows - 1; i >= 0; i--)
        {
            if (direction == "left")
            {
                for (int j = columns - 1; j >= 0; j--)
                {
                    matrix[i, j] = snake[k];
                    k++;
                    k = k % snake.Length;
                }
                direction = "right";
            }
            else
            {
                for (int j = 0; j <= columns - 1; j++)
                {
                    matrix[i, j] = snake[k];
                    k++;
                    k = k % snake.Length;
                }
                direction = "left";
            }
        }
        //shoot matrix - square diagonals
        //int width = 0;
        //for (int i = impactRow - radius; i <= impactRow + radius; i++)
        //{
        //    for (int j = impactColumn - width; j <= impactColumn + width; j++)
        //    {
        //        if (i >= 0 && i < rows && j >= 0 && j < columns)
        //        {
        //            matrix[i, j] = ' ';
        //        }
        //    }
        //    if (i < impactRow)
        //    {
        //        width++;
        //    }
        //    else
        //    {
        //        width--;
        //    }
        //}
        //shoot matrix - Pythagorean Theorem 
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if ((i - impactRow) * (i - impactRow) + (j - impactColumn) * (j - impactColumn) <= radius * radius)
                {
                    matrix[i, j] = ' ';
                }
            }
        }
        //gravity issues
        for (int i = rows - 1; i > 0; i--)
        {
            for (int j = 0; j < columns; j++)
            {
                if (matrix[i, j] == ' ')
                {
                    k = i;
                    do
                    {
                        k--;
                    } while (matrix[k, j] == ' ' && k > 0);
                    if (matrix[k, j] != ' ')
                    {
                        matrix[i, j] = matrix[k, j];
                        matrix[k, j] = ' ';
                    }
                }
            }
        }
        //print matrix
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}

