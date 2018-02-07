using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpNote.EnumHelper
{
    public class EnumConvert
    {
        public enum MyEnums
        {
            EnumType1 = 1,
            EnumType2 = 2,
            EnumType3 = 3
        }
        public void Run()
        {
            string result = string.Empty;
            foreach (MyEnums item in Enum.GetValues(typeof(MyEnums)))
            {
                Console.WriteLine((MyEnums)Enum.Parse(typeof(MyEnums), item.ToString(), false));
            }
            int intResult = 0;
            foreach (MyEnums item in Enum.GetValues(typeof(MyEnums)))
            {
                if (int.TryParse(item.ToString(), out intResult))
                {
                    Console.WriteLine($"{item.ToString()} 轉換成 {intResult}");
                }
            }
        }
    }
}
