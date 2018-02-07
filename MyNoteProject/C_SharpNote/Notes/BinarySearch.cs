using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpNote.Notes
{
    public class BinarySearch : IProcess
    {        
        public void RunMain()
        {
            List<int> list = new List<int>() { -8, -7, -5, 1, 12, 27, 35, 56 }; //由小到大排序好
            list.Sort();

            Console.WriteLine("輸入欲搜尋的元素");
            int item = Convert.ToInt32(Console.ReadLine());
            int p = BinarySearchSoution(list, item);
            if (p >= 0)
                Console.WriteLine($"元素位置 : {p}");
            else
                Console.WriteLine("元素不存在");
        }

        private static int BinarySearchSoution(List<int> list, int item)
        {
            int left = 0, right = list.Count; //設定左右邊界

            while (left <= right)
            {
                int mid = (left + right) / 2; 	// 取中間點位置索引
                if (list[mid] == item)
                {
                    return mid;
                }
                if (list[mid] < item)// 元素大於中間值，在右半繼續做二元搜尋
                {
                    left = mid + 1;             // 調整左邊位置索引
                }
                else  // 元素小於中間值 ， 在左半繼續做二元搜尋
                {
                    right = mid - 1;		    // 調整右邊位置索引
                }
            }
            return -1;
        }
    }
}
