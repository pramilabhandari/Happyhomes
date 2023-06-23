using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class Login
    {

        public string UserName { get; set; }
        public string Password { get; set; }

        public string Source { get; set; }
        public string Device { get; set; }
        public string NotToken { get; set; }
    }
    public class ResponseValues : CommonResponse

    {
        public List<dynamic> Values
        { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }


    }
}
