using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpNote.LinqGroup
{
    public class TryGroupBy
    {
        public void Procees()
        {
            List<Data> dataList = new List<Data>() {
                 new Data() { KeyNo=1, Money=500, JapanMoney=200 },
                 new Data() { KeyNo=1, Money=300, JapanMoney=400 },
            };
            var sum1 = dataList.GroupBy(x => x.KeyNo).Select(x => new Data { KeyNo = x.Key, Money = x.Sum(y => y.Money) }).ToList();
            var sum2 = dataList.GroupBy(x => x.KeyNo).Select(x => new Data { KeyNo = x.Key, JapanMoney = x.Sum(y => y.JapanMoney) }).ToList();
            var all = sum1.Union(sum2);
            var last = all.GroupBy(x => x.KeyNo).Select(y => new Data() { KeyNo = y.Key, Money = y.Sum(t => t.Money), JapanMoney = y.Sum(z => z.JapanMoney) }).ToList();
            Console.WriteLine();
        }
    }
    public class Data
    {
        public int KeyNo { get; set; }
        public int Money { get; set; }
        public int JapanMoney { get; set; }
    }
}
