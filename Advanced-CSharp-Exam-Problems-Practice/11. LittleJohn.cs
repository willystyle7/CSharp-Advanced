using System;
using System.Linq;

namespace LittleJohn
{
    class LittleJohn
    {
        static void Main()
        {
            int smallArrows = 0;
            int mediumArrows = 0;
            int largeArrows = 0;
            for (int i = 0; i < 4; i++)
            {
                string line = Console.ReadLine();
                if (line.Contains(">>>----->>"))
                {
                    int origLength = line.Length;
                    line = line.Replace(">>>----->>", ".");
                    largeArrows += (origLength - line.Length) / 9;
                }
                if (line.Contains(">>----->"))
                {
                    int origLength = line.Length;
                    line = line.Replace(">>----->", ".");
                    mediumArrows += (origLength - line.Length) / 7;
                }
                if (line.Contains(">----->"))
                {
                    int origLength = line.Length;
                    line = line.Replace(">----->", ".");
                    smallArrows += (origLength - line.Length) / 6;
                }
            }
            string concatAllArrows = smallArrows.ToString() + mediumArrows.ToString() + largeArrows.ToString();
            string binaryArrows = Convert.ToString(int.Parse(concatAllArrows), 2);
            string reversedBinaryArrows = new string(binaryArrows.ToCharArray().Reverse().ToArray());
            string enctypted = Convert.ToString(Convert.ToInt32(binaryArrows + reversedBinaryArrows, 2), 10);
            Console.WriteLine(enctypted);
        }
    }
}
