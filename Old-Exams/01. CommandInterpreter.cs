using System;
using System.Linq;
using System.Text.RegularExpressions;

class CommandInterpreter
{
    static void Main()
    {
        string[] array = Regex.Split(Console.ReadLine(), @"\s+").ToArray();
        string commands;
        while ((commands = Console.ReadLine()) != "end")
        {
            int start = 0;
            int count = 0;
            string[] token = commands.Split();
            switch (token[0])
            {
                case "reverse":
                    start = int.Parse(token[2]);
                    count = int.Parse(token[4]);
                    if (ValidateInput(start, count, array.Length))
                    {
                        array = Reverse(array, start, count);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                    break;
                case "sort":
                    start = int.Parse(token[2]);
                    count = int.Parse(token[4]);
                    if (ValidateInput(start, count, array.Length))
                    {
                        array = Sort(array, start, count);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                    break;
                case "rollLeft":
                    count = int.Parse(token[1]);
                    if (count >= 0)
                    {
                        array = RollLeft(array, count);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");

                    }
                    break;
                case "rollRight":
                    count = int.Parse(token[1]);
                    if (count >= 0)
                    {
                        array = RollRight(array, count);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");

                    }
                    break;
            }
        }
        Console.WriteLine("[{0}]", string.Join(", ", array));
    }

    static string[] Reverse(string[] array, int start, int count)
    {
        string[] array1 = array.Take(start).ToArray();
        string[] array2 = array.Skip(start).Take(count).Reverse().ToArray();
        string[] array3 = array.Skip(start + count).ToArray();
        array = array1.Concat(array2).Concat(array3).ToArray();
        return array;
    }

    static string[] Sort(string[] array, int start, int count)
    {
        string[] array1 = array.Take(start).ToArray();
        string[] array2 = array.Skip(start).Take(count).OrderBy(x => x.ToString()).ToArray();
        string[] array3 = array.Skip(start + count).ToArray();
        array = array1.Concat(array2).Concat(array3).ToArray();
        return array;
    }

    static string[] RollLeft(string[] array, int count)
    {
        count = count % array.Length;
        string[] array1 = array.Take(count).ToArray();
        string[] array2 = array.Skip(count).ToArray();
        array = array2.Concat(array1).ToArray();
        return array;
    }

    static string[] RollRight(string[] array, int count)
    {
        count = count % array.Length;
        string[] array1 = array.Take(array.Length - count).ToArray();
        string[] array2 = array.Skip(array.Length - count).ToArray();
        array = array2.Concat(array1).ToArray();
        return array;
    }

    static bool ValidateInput(int start, int count, int length)
    {
        bool isValidInput = false;
        if ((start >= 0) && (start <= length - 1) && (count >= 0) && (start + count <= length))
        {
            isValidInput = true;
        }
        return isValidInput;
    }
}