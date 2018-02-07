using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpNote
{
    public static class StringReverse
    {
        public static void Run_1()
        {
            string inputString = "abcdefgh";
            Console.WriteLine(MyReverse_1(inputString));
            Console.WriteLine(MyReverse_2(inputString));
        }
        public static void Run_2()
        {
            List<string> datas = new List<string>()
            {
                "abc","aza","bac", "cba", "bca","bbb","caa"
            };
            var tmp = MyOrderBy(datas);

            foreach (var item in tmp)
                Console.WriteLine(item);
        }
        private static string MyReverse_1(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                return "請輸入字串";

            var tmpChar = data.ToCharArray().ToList();
            string result = string.Empty;
            for (int i = (tmpChar.Count); i > 0; i--)
            {
                result += tmpChar[i - 1];
            }
            return result;
        }
        private static string MyReverse_2(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                return "請輸入字串";

            var tmpChar = data.ToCharArray().ToList();
            string result = string.Empty;
            tmpChar.Reverse();
            foreach (var item in tmpChar.ToList())
            {
                result += item;
            }
            return result;
        }

        private static List<string> MyOrderBy(List<string> datas)
        {
            return datas.OrderBy(x => x, new MyOrderComparer()).ThenBy(x => x, new MyThenByComparer()).ToList();
        }
    }

    internal class MyOrderComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (Convert.ToChar(x.Substring(0, 1)) < Convert.ToChar(y.Substring(0, 1))) return -1;
            else if (Convert.ToChar(x.Substring(0, 1)) > Convert.ToChar(y.Substring(0, 1))) return 1;
            else return 0;
        }
    }
    internal class MyThenByComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (Convert.ToChar(x.Substring(1, 1)) > Convert.ToChar(y.Substring(1, 1))) return -1;
            else if (Convert.ToChar(x.Substring(1, 1)) < Convert.ToChar(y.Substring(1, 1))) return 1;
            else return 0;
        }
    }
}
