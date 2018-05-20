using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace QueryMess
{
    class QueryMess
    {
        static void Main()
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                input = input.Replace("+", " ");
                input = input.Replace("%20", " ");
                input = Regex.Replace(input, @"\s+", " ");
                string[] token = input.Split(new char[] { '&', '?' }).Select(x => x.Trim()).ToArray();
                Dictionary<string, List<string>> queries = new Dictionary<string, List<string>>();
                foreach (string subline in token)
                {
                    if (subline.Contains('='))
                    {
                        string[] data = subline.Split('=').Select(x => x.Trim()).ToArray();
                        if (queries.ContainsKey(data[0]))
                        {
                            queries[data[0]].Add(data[1]);
                        }
                        else
                        {
                            queries.Add(data[0], new List<string>());
                            queries[data[0]].Add(data[1]);
                        }
                    }
                }
                foreach (var query in queries)
                {
                    Console.Write("{0}=[{1}]", query.Key, string.Join(", ", query.Value));
                }
                Console.WriteLine();
                input = Console.ReadLine();
            }
        }
    }
}