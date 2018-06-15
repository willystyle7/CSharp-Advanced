using System;
using System.Text;
using System.Text.RegularExpressions;

class TextTransformer
{
    static void Main()
    {
        string input = Console.ReadLine();
        StringBuilder resultSB = new StringBuilder();
        while (input != "burp")
        {
            resultSB.Append(input);
            input = Console.ReadLine();
        }
        string result = Regex.Replace(resultSB.ToString(), @"\s+", " ");
        string pattern = @"([$%&'])([^$%&']+)\1";
        MatchCollection matches = Regex.Matches(result, pattern);
        StringBuilder words = new StringBuilder();
        foreach (Match match in matches)
        {
            char specialChar = match.Groups[1].Value[0];
            string codeWord = match.Groups[2].Value;
            int specialValue = 0;
            switch (specialChar)
            {
                case '$':
                    specialValue = 1;
                    break;
                case '%':
                    specialValue = 2;
                    break;
                case '&':
                    specialValue = 3;
                    break;
                case '\'':
                    specialValue = 4;
                    break;
            }
            for (int i = 0; i < codeWord.Length; i++)
            {
                char currentChar;
                if (i % 2 == 0)
                {
                    currentChar = (char)(codeWord[i] + specialValue);
                }
                else
                {
                    currentChar = (char)(codeWord[i] - specialValue);
                }
                words.Append(currentChar);
            }
            words.Append(" ");
        }
        Console.WriteLine(words.ToString());
    }
}