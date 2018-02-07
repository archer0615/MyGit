using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpNote.Notes
{
    public static class DataProcess
    {
        public static void Runs()
        {
            string data = "djaOpppewqqqTwyy";

            Dictionary<string, int> result = DataProcess.StringFound(data);
            Console.WriteLine(data);
            foreach (var item in result)
            {
                Console.WriteLine($"字元連續出現最多的為 : {item.Key} 次數 : {item.Value}");
            }
        }

        private static Dictionary<string, int> StringFound(string data)
        {
            var stringArr = data.ToCharArray();
            Dictionary<string, int> charCount = new Dictionary<string, int>();
            foreach (var item in stringArr)
            {
                if (charCount.Count == 0)
                {
                    charCount.Add(item.ToString(), 1);
                    continue;
                }

                if (charCount.ContainsKey(item.ToString()))
                    charCount[item.ToString()] = charCount[item.ToString()] + 1;
                else
                    charCount.Add(item.ToString(), 1);
            }

            var maxCount = charCount.Max(x => x.Value);
            var result = charCount.Where(x => x.Value == maxCount).ToDictionary(x => x.Key, x => x.Value);
            return result;
        }
    }
}
