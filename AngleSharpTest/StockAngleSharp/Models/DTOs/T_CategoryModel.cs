using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAngleSharp.Models.DTOs
{
    public class T_CategoryModel
    {
        public int Catetory_ID { get; set; }
        public string Catetory_Name { get; set; }
        public int Catetory_Se_ID { get; set; }
        public override string ToString()
        {
            return $"{Catetory_ID},{Catetory_Name}";
        }
    }
}
