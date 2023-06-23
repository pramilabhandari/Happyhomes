using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models.Model;
using Service;

namespace HappyHome.Controllers
{


    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("[Controller]")]
    public class LoginController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;


        public LoginController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        // attributed routing and method to access service
        [HttpPost, Route("~/api/login")]
        public async Task<IActionResult> Createlogin(Login logins)
        {
            // IActionResult=return type ,return sort of result that can be 
            //interpreted by  asp.net to generate an appropriate HTTP response

            var data = await _unitOfWork.LoginService.Logins(logins);

            return Ok(data);


  
        }
    }
}
