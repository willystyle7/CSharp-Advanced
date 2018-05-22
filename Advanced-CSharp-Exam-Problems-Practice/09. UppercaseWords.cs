using System;
using System.Linq;
using System.Security;
using System.Text.RegularExpressions;

class UppercaseWords
{
    static void Main()
    {
        string input = Console.ReadLine();       
        while (input != "END")
        {
            string pattern = "(?<=^|[^A-Za-z])([A-Z]+)(?=$|[^A-Za-z])";
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                string word = match.Value;
                string wordToChange = "";
                if (IsPalindrome(word))
                {
                    wordToChange = DoubleWord(word);
                }
                else
                {
                    wordToChange = ReverseWord(word);
                }
                string pattern2 = "(?<=^|[^A-Za-z])(" + word + ")(?=$|[^A-Za-z])";
                input = Regex.Replace(input, pattern2, wordToChange);
            }
            Console.WriteLine(SecurityElement.Escape(input));
            input = Console.ReadLine();
        }
    }

    static bool IsPalindrome(string word)
    {
        bool isPalindrome = false;
        isPalindrome = word == string.Concat(word.ToCharArray().Reverse());
        return isPalindrome;
    }

    static string DoubleWord(string word)
    {
        string doubleWord = "";
        for (int i = 0; i < word.Length; i++)
        {
            doubleWord += word[i].ToString() + word[i].ToString();
        }
        return doubleWord;
    }

    static string ReverseWord(string word)
    {
        string reverseWord = "";
        for (int i = word.Length - 1; i >= 0; i--)
        {
            reverseWord += word[i].ToString();
        }
        return reverseWord;
    }

}

