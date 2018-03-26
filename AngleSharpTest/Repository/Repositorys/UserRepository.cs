using CrawlerDAL.DTOs;
using CrawlerDAL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositorys
{
    public class UserRepository : GenericRepository<T_User>
    {
        public int LoginValid(LoginDTO loginData)
        {
            var hashPwd = HashPassword.HashPwd(loginData.Password);
            var Data = Get(x => x.Account.Equals(loginData.Account)
                                && x.HashPassword.Equals(hashPwd));
            if (Data != null)
            {
                return Data.User_ID;
            }
            else
            {
                return 0;
            }
        }
        public bool Register(RegisterDTO registerData)
        {
            var result = true;
            try
            {
                var hashPwd = HashPassword.HashPwd(registerData.Password);
                T_User data = new T_User()
                {
                    Account = registerData.Account,
                    HashPassword = hashPwd,
                    AlterDate = DateTime.Now,
                    CreateDate = DateTime.Now,
                    Role = 1,
                    Status = 1,
                };
                Create(data);
                SaveChanges();
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}
