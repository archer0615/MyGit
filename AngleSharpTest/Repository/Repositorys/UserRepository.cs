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
        public bool LoginValid(LoginDTO loginData)
        {
            var hashPwd = HashPassword.HashPwd(loginData.Password);
            return this._context.Set<T_User>()
                .Any(x => x.Account.Equals(loginData.Account)
                && x.HashPassword.Equals(hashPwd));
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
                };
                Create(data);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}
