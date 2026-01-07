using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsyncCommands.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task Login(string username)
        {
            await Task.Delay(5000);
            // throw new ArgumentException("参数异常!登录失败,请检查传入的登录参数!");
        }
    }
}
