using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDAL.DTOs
{
    public class RegisterDTO : BaseDTO
    {
        public string Account { get; set; }
        public string Password { get; set; }
    }
}
