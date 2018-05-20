using System;
using System.Security;

class TextGravity
{
    static void Main()
    {
        int lineLength = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        int rows = text.Length / lineLength + (text.Length % lineLength == 0 ? 0 : 1);
        char[,] matrix = new char[rows, lineLength];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < lineLength; j++)
            {
                if ((text.Length % lineLength != 0) && (i == rows - 1) && (j >= text.Length % lineLength))
                {
                    matrix[i, j] = ' ';
                }
                else matrix[i, j] = text[i * lineLength + j];
            }
        }
        for (int i = rows - 1; i > 0; i--)
        {
            for (int j = 0; j < lineLength; j++)
            {
                if (matrix[i, j] == ' ')
                {
                    int k = i;
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
        string result = "<table>";
        for (int i = 0; i < rows; i++)
        {
            result += "<tr>";
            for (int j = 0; j < lineLength; j++)
            {
                result += "<td>";
                result += SecurityElement.Escape(matrix[i, j].ToString());
                result += "</td>";
            }
            result += "</tr>";
        }
        result += "</table>";
        Console.WriteLine(result);
    }
}
