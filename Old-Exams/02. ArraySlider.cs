using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Numerics;

class ArraySlider
{
    static void Main()
    {
        BigInteger[] array = Regex.Split(Console.ReadLine(), @"\s+").Where(s => s.Length > 0).Select(BigInteger.Parse).ToArray();
        string input = Console.ReadLine();
        long index = 0;
        while (input != "stop")
        {
            string[] token = input.Split(' ');
            long offset = long.Parse(token[0]);
            string operation = token[1];
            BigInteger operand = BigInteger.Parse(token[2]);
            index = (index + offset) % array.Length;
            if (index < 0)
            {
                index = array.Length + index;
            }
            switch (operation)
            {
                case "&":
                    array[index] &= operand;
                    break;
                case "|":
                    array[index] |= operand;
                    break;
                case "^":
                    array[index] ^= operand;
                    break;
                case "+":
                    array[index] += operand;
                    break;
                case "-":
                    array[index] -= operand;
                    if (array[index] < 0)
                    {
                        array[index] = 0;
                    }
                    break;
                case "*":
                    array[index] *= operand;
                    break;
                case "/":
                    array[index] /= operand;
                    break;
            }
            input = Console.ReadLine();
        }
        Console.WriteLine("[{0}]", string.Join(", ", array));
    }
}