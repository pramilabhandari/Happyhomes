using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models.Model;
using Service;

namespace HappyHome.Controllers
{

    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("[Controller]")]
    public class ChangepwdController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;


        public ChangepwdController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        // attributed routing and method to access service
        [HttpPost, Route("~/api/change-password")]
        public async Task<IActionResult> Createlogin(ChangePassword changes)
        {
            // IActionResult=return type ,return sort of result that can be 
            //interpreted by  asp.net to generate an appropriate HTTP response

            var data = await _unitOfWork.ChngpwdService.changepassword(changes);

            return Ok(data);



        }

    }
}
