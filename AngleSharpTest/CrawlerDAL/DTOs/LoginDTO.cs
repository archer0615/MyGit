using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDAL.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "請輸入帳號")]
        public string Account { get; set; }
        [Required(ErrorMessage = "請輸入密碼")]
        public string Password { get; set; }
    }
}
