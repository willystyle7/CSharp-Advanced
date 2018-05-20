using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XRemoval
{
    class XRemoval
    {
        static void Main()
        {
            List<List<string>> jaggedList = new List<List<string>>();
            string line = Console.ReadLine();
            while (line != "END")
            {
                jaggedList.Add(line.ToCharArray().Select(c => c.ToString()).ToList());
                line = Console.ReadLine();
            }
            bool[][] jaggedArray = new bool[jaggedList.Count][];
            for (int i = 0; i < jaggedList.Count; i++)
            {
                jaggedArray[i] = new bool[jaggedList[i].Count];
                for (int j = 0; j < jaggedList[i].Count; j++)
                {
                    jaggedArray[i][j] = false;
                }
            }
            for (int i = 1; i < jaggedList.Count - 1; i++)
            {
                for (int j = 1; j < jaggedList[i].Count; j++)
                {
                    if (j + 1 < jaggedList[i - 1].Count && j + 1 < jaggedList[i + 1].Count)
                    {
                        if (jaggedList[i][j].ToLower() == jaggedList[i - 1][j - 1].ToLower()
                            && jaggedList[i][j].ToLower() == jaggedList[i - 1][j + 1].ToLower()
                            && jaggedList[i][j].ToLower() == jaggedList[i + 1][j - 1].ToLower()
                            && jaggedList[i][j].ToLower() == jaggedList[i + 1][j + 1].ToLower())
                        {
                            jaggedArray[i][j] = true;
                            jaggedArray[i - 1][j - 1] = true;
                            jaggedArray[i - 1][j + 1] = true;
                            jaggedArray[i + 1][j - 1] = true;
                            jaggedArray[i + 1][j + 1] = true;
                        }
                    }
                }
            }
            for (int i = 0; i < jaggedList.Count; i++)
            {
                for (int j = 0; j < jaggedList[i].Count; j++)
                {
                    if (jaggedArray[i][j] == false) Console.Write(jaggedList[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}