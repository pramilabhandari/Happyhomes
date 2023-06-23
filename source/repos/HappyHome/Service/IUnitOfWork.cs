using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUnitOfWork
    {
        public LoginService LoginService { get; }

        public ChngpwdService ChngpwdService { get; }
        public RegisterService RegisterService { get; }
        public UserService UserService { get; }
    }
}
