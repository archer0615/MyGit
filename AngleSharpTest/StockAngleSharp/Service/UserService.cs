using CrawlerDAL.DTOs;
using Repository.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAngleSharp.Service
{
    public class UserService
    {
        public int LoginValidService(LoginDTO loginData)
        {
            UserRepository UR = new UserRepository();
            return UR.LoginValid(loginData);
        }
        public bool RegisterAccountService(RegisterDTO registerData)
        {
            UserRepository UR = new UserRepository();
            return UR.Register(registerData);
        }
    }
}
