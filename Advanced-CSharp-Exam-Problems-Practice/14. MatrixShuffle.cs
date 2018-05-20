using System;
using System.Linq;
using System.Text.RegularExpressions;

class MatrixShuffle
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        char[,] matrix = new char[size, size];
        string text = Console.ReadLine();
        text = text.PadRight(size * size, ' ');
        FillSpiralMAtrix(matrix, text);
        string whites = string.Empty;
        string blacks = string.Empty;
        GetChessBoards(matrix, ref whites, ref blacks);
        string result = whites + blacks;
        Console.WriteLine("<div style='background-color:{0}'>{1}</div>", IsPalindrome(result) ? "#4FE000" : "#E0000F", result);
    }

    static void FillSpiralMAtrix(char[,] matrix, string text)
    {
        int size = matrix.GetLength(0);
        int row = 0;
        int col = 0;
        string direction = "right";
        int bottom = size - 1;
        int top = 1;
        int left = 0;
        int right = size - 1;
        matrix[0, 0] = text[0];
        for (int count = 1; count < size * size; count++)
        {
            switch (direction)
            {
                case "down":
                    row++;
                    matrix[row, col] = text[count];
                    if (row == bottom)
                    {
                        direction = "left";
                        bottom--;
                    }
                    break;

                case "right":
                    col++;
                    matrix[row, col] = text[count];
                    if (col == right)
                    {
                        direction = "down";
                        right--;
                    }
                    break;

                case "up":
                    row--;
                    matrix[row, col] = text[count];
                    if (row == top)
                    {
                        direction = "right";
                        top++;
                    }
                    break;

                case "left":
                    col--;
                    matrix[row, col] = text[count];
                    if (col == left)
                    {
                        direction = "up";
                        left++;
                    }
                    break;
            }
        }
        return;
    }

    static void GetChessBoards(char[,] matrix, ref string whites, ref string blacks)
    {
        int size = matrix.GetLength(0);
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                if ((row % 2 == 0 && col % 2 == 0) || (row % 2 == 1 && col % 2 == 1))
                {
                    whites += matrix[row, col];
                }
                else
                {
                    blacks += matrix[row, col];
                }
            }
        }
        return;
    }

    static bool IsPalindrome(string result)
    {
        bool isPalindrome = false;
        result = result.ToLower();
        string pattern = @"[^a-z]+";
        result = Regex.Replace(result, pattern, "");
        isPalindrome = result == string.Concat(result.ToCharArray().Reverse());
        return isPalindrome;
    }

}

