using Microsoft.Extensions.Configuration;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IConfiguration config)
        {
            Configuration = config;
        }




        public LoginService LoginService => new LoginService();
        public ChngpwdService ChngpwdService =>  new ChngpwdService();

        public RegisterService RegisterService => new RegisterService();    
        public UserService UserService => new UserService();
        private IConfiguration Configuration { get; }
    }

}